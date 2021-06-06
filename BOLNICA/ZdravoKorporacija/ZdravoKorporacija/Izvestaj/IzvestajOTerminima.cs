using ceTe.DynamicPDF;
using Kontroler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Page = ceTe.DynamicPDF.Page;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using Label = ceTe.DynamicPDF.PageElements.Label;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.Izvestaj
{
    public class IzvestajOTerminima
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        TerminKontroler terminKontroler = new TerminKontroler();
        public void KreirajIzvestaj(List<DateTime> interval, String idPacijenta)
        {

            String imeIPrezime = naloziPacijenataKontroler.PretragaPoId(idPacijenta).Ime + " " + naloziPacijenataKontroler.PretragaPoId(idPacijenta).Prezime;
            String korisnicko = naloziPacijenataKontroler.PretragaPoId(idPacijenta).korisnik.KorisnickoIme;

            Document document = new Document();
            Page prvaStranica = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(prvaStranica);
            String naslov = "IZVEŠTAJ RASPOREDA TERMINA\n Pacijent: " + imeIPrezime + "\n";
            naslov += "Datum izveštaja: " + DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss");
            Label label = new Label(naslov, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center);
            prvaStranica.Elements.Add(label);

            int trajanjeIntervala = (int)(interval[1] - interval[0]).TotalDays + 1;
            List<TerminDTO> sviTerminiPacijenta = terminKontroler.DobaviTermineZaIzvestaj(interval, idPacijenta);
            ///tabela raspored
            Table2 table = new Table2(-30, 120, 600, 300);
            table.CellDefault.Border.Color = RgbColor.DeepPink;
            table.CellDefault.Border.LineStyle = LineStyle.Solid;
            table.CellDefault.Padding.Value = 3.0f;

            // Add columns to the table
            table.Columns.Add(80);    ///tip
            table.Columns.Add(90);     //lekar
            table.Columns.Add(80);     //datum
            table.Columns.Add(80);     ///vreme
            table.Columns.Add(80);    //prostor
            table.Columns.Add(80);    //odrzan
            table.Columns.Add(80);    //dijagnoza
            // The first row is used as a table heading
            Row2 row1 = table.Rows.Add(20, Font.HelveticaBold, 14, RgbColor.Black,
            RgbColor.White);
            row1.CellDefault.Align = TextAlign.Center;
            row1.CellDefault.VAlign = VAlign.Center;
            row1.Cells.Add("Termini " + interval[0].Date.ToString("dd.MM.yyyy.") + " - " + interval[1].Date.ToString("dd.MM.yyyy."), 7);

            // The second row is the column headings
            Row2 row2 = table.Rows.Add(Font.HelveticaBoldOblique, 12);
            row2.CellDefault.Align = TextAlign.Center;

            row2.Cells.Add("Tip termina");
            row2.Cells.Add("Lekar");
            row2.Cells.Add("Datum");
            row2.Cells.Add("Vreme");
            row2.Cells.Add("Prostor");
            row2.Cells.Add("Odrzan");
            row2.Cells.Add("Dijagnoza");

            Row2 row3;
            int brojOdrzanih = 0;
            int brojNeodrzanih = 0;
            for (int i = 0; i < sviTerminiPacijenta.Count; i++)
            {
                row3 = table.Rows.Add(30);
                row3.Cells.Add(new FormattedTextArea(sviTerminiPacijenta[i].TipTermina, 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                row3.Cells.Add(new FormattedTextArea(sviTerminiPacijenta[i].Lekar.CeloIme, 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                row3.Cells.Add(new FormattedTextArea(sviTerminiPacijenta[i].Datum.ToString("dd/MM/yyyy"), 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                row3.Cells.Add(new FormattedTextArea(sviTerminiPacijenta[i].PredvidjenoVreme, 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                row3.Cells.Add(new FormattedTextArea(sviTerminiPacijenta[i].NazivSale, 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                if (DateTime.Compare(sviTerminiPacijenta[i].Datum, DateTime.Now) < 0)
                {
                    row3.Cells.Add(new FormattedTextArea("DA", 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                    row3.Cells.Add(new FormattedTextArea(naloziPacijenataKontroler.DobaviKartonPacijenta(korisnicko).Anamneza.Simptomi, 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                    brojOdrzanih++;
                }
                else
                {
                    row3.Cells.Add(new FormattedTextArea("NE", 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                    row3.Cells.Add(new FormattedTextArea("", 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                    brojNeodrzanih++;
                }


            }

            prvaStranica.Elements.Add(table);

            Page drugaStranica = new Page();
            document.Pages.Add(drugaStranica);

            // Create a chart
            Chart chart3 = new Chart(0, 0, 500, 300);
            // Add a plot area to the chart
            PlotArea plotArea22 = chart3.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title11 = new Title("Ukupan broj pregleda i operacija u zadatom periodu");
            chart3.HeaderTitles.Add(title11);

            // Create a indexed stacked column series elements and add values to it
            IndexedStackedColumnSeriesElement seriesElement11 = new IndexedStackedColumnSeriesElement("Termin");

            seriesElement11.Values.Add(terminKontroler.DobaviBrojPregledaIzvestaj(interval, idPacijenta));
            seriesElement11.Values.Add(terminKontroler.DobaviBrojOperacijaIzvestaj(interval, idPacijenta));


            // Create autogradient and assign it to series
            seriesElement11.Color = new AutoGradient(90f, CmykColor.DeepPink, CmykColor.DeepPink);


            // Create a Indexed Stacked Column Series
            IndexedStackedColumnSeries columnSeries = new IndexedStackedColumnSeries();
            // Add indexed stacked column series elements to the Indexed Stacked Column Series
            columnSeries.Add(seriesElement11);


            // Add series to the plot area
            plotArea22.Series.Add(columnSeries);

            // Create a title and add it to the yaxis
            Title lTitle = new Title("Broj termina");
            columnSeries.YAxis.Titles.Add(lTitle);



            columnSeries.XAxis.Labels.Add(new IndexedXAxisLabel("PREGLEDI", 0));
            columnSeries.XAxis.Labels.Add(new IndexedXAxisLabel("OPERACIJE", 1));


            drugaStranica.Elements.Add(chart3);

            ////treci
            Chart odnosKolicina = new Chart(-30, 430, 600, 300);
            PlotArea plotArea2 = odnosKolicina.PlotAreas.Add(50, 50, 500, 300);
            Title tTitle = new Title("Odnos odrzanih i neodrzanih termina u zeljenom periodu");
            odnosKolicina.HeaderTitles.Add(tTitle);
            AutoGradient odrzaniBoja = new AutoGradient(90f, CmykColor.Red, CmykColor.DeepPink);
            AutoGradient neodrzaniBoja = new AutoGradient(90f, CmykColor.Red, CmykColor.Lavender);

            ScalarDataLabel da = new ScalarDataLabel(true, true, false);
            PieSeries pieSeries = new PieSeries();
            pieSeries.DataLabel = da;
            plotArea2.Series.Add(pieSeries);


            pieSeries.Elements.Add(brojOdrzanih, "Odrzani termini");
            pieSeries.Elements.Add(brojNeodrzanih, "Neodrzani termini");
            pieSeries.Elements[0].Color = odrzaniBoja;
            pieSeries.Elements[1].Color = neodrzaniBoja;

            drugaStranica.Elements.Add(odnosKolicina);

            String nazivIzvestaja = "IzvestajiPacijenta/IzvestajOTerminima" + DateTime.Now.ToString("dd.MM.yyyy.HH.mm") + ".pdf";
            document.Draw(nazivIzvestaja);

        }
    }
}
