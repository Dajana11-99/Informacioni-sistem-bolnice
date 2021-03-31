using Model;
using PoslovnaLogika;
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

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for ZakazivanjeTerminaLekara.xaml
    /// </summary>
    public partial class ZakazivanjeTerminaLekara : Window
    {
        public List<Pacijent> Pacijenti { get; set; }
        public List<Lekar> Lekari { get; set; }

        public ZakazivanjeTerminaLekara()
        {
            InitializeComponent();
            bindcombo();
        }

        public void bindcombo()
        {
            List<Lekar> pomocna = new List<Lekar>();

            foreach (Lekar l in RukovanjeTerminima.pom)
            {
                if (!l.Specijalizacija.Equals(Specijalizacija.Ostapraksa))
                {
                    pomocna.Add(l);
                }
            }

            Lekari = pomocna;
            DataContext = Lekari;

        }

        private void btnPotvrdiZakazivanjeTermina_Click(object sender, RoutedEventArgs e)
        {
            String id = RukovanjeTerminima.pronadji();
            Lekar l = new Lekar(cmbLekar.Text);
            Pacijent p = new Pacijent(cmbPacijent.Text);
            String idSale = brojSale.Text;
            String vr = cmbZakazivanjeTerminaVreme.Text;


            TipTermina tipP;
            String tip = cmbVrstaTermina.Text;
            if (tip.Equals(TipTermina.Pregled))
            {
                tipP = TipTermina.Pregled;
            }
            else
            {
                tipP = TipTermina.Operacija;
            }

          
           
            Sala s = null;
            if (tipP.Equals(TipTermina.Pregled))
            {
                s = new Sala(TipSale.Pregled, brojSale.Text);
            }else
            {
                s = new Sala(TipSale.Operaciona, brojSale.Text);
            }
           

           

            DateTime? datum = datePickerZakazivanjeTermina.SelectedDate;
            String formatirano = null;
            if (datum.HasValue)
                formatirano = datum.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            String hmin = cmbHMin.Text;
            String vreme = txtPredvidjenoVremeTermina.Text;
            Double predvidjenoVreme = 0;
            if (hmin.Equals("h"))
            {
                predvidjenoVreme = double.Parse(vreme) * 60;

            }
            else
            {
                predvidjenoVreme = double.Parse(vreme);
            }

            Termin t = new Termin(id, tipP, vr, predvidjenoVreme, formatirano, s, p, l);

            RukovanjeTerminima.ZakaziTermin(t);
            this.Close();







        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
