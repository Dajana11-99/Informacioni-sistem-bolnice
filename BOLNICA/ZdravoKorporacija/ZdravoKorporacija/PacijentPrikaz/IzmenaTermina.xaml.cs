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

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for IzmenaTermina.xaml
    /// </summary>
    public partial class IzmenaTermina : Window
    {
        public static List<Termin> datumiZaIzmenu = new List<Termin>();
        public string idTermina = null;
        public IzmenaTermina(Termin termin)
        {
            InitializeComponent();
            lekar.Text = termin.Lekar.CeloIme;
            datum.Text = termin.Datum;
            vreme.Text = termin.Vreme;
            idTermina = termin.IdTermina;
        }

        private void prikaziDatume_Click(object sender, RoutedEventArgs e)
        {
            String datum1 = datum.Text;
            bool dostupanDatum = TerminServis.ProveriMogucnostPomeranjaDatum(datum1);
            if (dostupanDatum)
            {
                bool dostupnoVreme = TerminServis.ProveriMogucnostPomeranjaVreme(TerminServis.PretragaPoId(idTermina).Vreme);
                if (!dostupnoVreme)
                {
                    MessageBox.Show("Datum pregleda je za manje od 24h ne mozete ga pomeriti!!");
                    return;
                }

            }

            Termin t = TerminServis.PretragaPoId(idTermina);
            DateTime datumPregleda = DateTime.ParseExact(datum.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime pocetni = datumPregleda.AddDays(-2);
            DateTime krajnji = datumPregleda.AddDays(2);

            List<Termin> pomocna = new List<Termin>();
            bool nasao = false;
            datumiZaIzmenu.Clear();

            pomocna = TerminServis.nadjiSlobodneDatumeLekarauIntervalu(pocetni, krajnji, t.Lekar.idZaposlenog);
            foreach (Termin ter in pomocna)
            {
                nasao = false;
                foreach (Termin t1 in datumiZaIzmenu)
                {
                    if (t1.Datum.Equals(ter.Datum))
                    {
                        nasao = true;
                        break;
                    }
                }
                if (!nasao)
                {
                    datumiZaIzmenu.Add(ter);
                }

            }
            if (datumiZaIzmenu.Count == 0)
            {
                MessageBox.Show("Nema termina za izmenu!");
            }else
            {
                PrikazDatumaZaPomeranjeKodLekara prikaz = new PrikazDatumaZaPomeranjeKodLekara();
                prikaz.Show();
                this.Close();
            }




        }
    }
}
