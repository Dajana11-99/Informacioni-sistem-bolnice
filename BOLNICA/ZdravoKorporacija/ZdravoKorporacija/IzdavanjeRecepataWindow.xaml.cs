using Model;
using Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.PacijentPrikaz;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for IzdavanjeRecepataWindow.xaml
    /// </summary>
    public partial class IzdavanjeRecepataWindow : Window
    {
        public Recept Recept { get; set; }
        public IzdavanjeRecepataWindow()
        {
            InitializeComponent();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {

            DateTime? datum = this.datePickerPocetak.SelectedDate;
            DateTime? datum1 = this.datePickerKraj.SelectedDate;
            String formatirano = null;
            String formatirano1 = null;
            if (datum.HasValue)
                formatirano = datum.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (datum1.HasValue)
                formatirano1 = datum1.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            Recept = new Recept(txtKolicinaLeka.Text, formatirano, formatirano1, double.Parse(txtPeriodUzimanja.Text),new Lek(idLeka.Text,txtNazivLeka.Text),ZdravstevniKartonPacijenta.pacijent.idPacijenta);

            //OBAVESTENJA
            
            DateTime pocetni = DateTime.Now;
            DateTime krajnji = (DateTime)datum1;
            int trajanje = (int)(krajnji - pocetni).TotalDays + 1;
            String sadrzaj = "Terapija: " + Recept.Lek1.ImeLeka  +
              "\ndnevna količina: " + Recept.KolicinaTerapije + ",\nvremenski interval između doza: " + Recept.PeroidUzimanjaUSatima + "h.";

            String idObavestenja = ObavestenjaServis.generisiIdObavestenja();

          
            Obavestenja o = new Obavestenja(idObavestenja, "Terapija", sadrzaj, pocetni, ZdravstevniKartonPacijenta.pacijent.idPacijenta);
            ObavestenjaServis.DodajObavestenjePacijentu(o);

            DateTime datumPom;
            for (int i = 1; i <= trajanje; i++)
            {
                datumPom = pocetni.AddDays(i);
                String form = datumPom.ToString();

                String[] splits = form.Split(' ');
                String[] brojevi = splits[0].Split('/');

                //assigns year, month, day, hour, min, seconds
                DateTime konacni = new DateTime(Int32.Parse(brojevi[2]), Int32.Parse(brojevi[0]), Int32.Parse(brojevi[1]), 8, 0, 0);
              
                idObavestenja =ObavestenjaServis.generisiIdObavestenja();

                o = new Obavestenja(idObavestenja, "Terapija", sadrzaj, konacni, ZdravstevniKartonPacijenta.pacijent.idPacijenta);


                ObavestenjaServis.DodajObavestenjePacijentu(o);

            }
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Recept = null;
            this.Close();
        }
    }
}
