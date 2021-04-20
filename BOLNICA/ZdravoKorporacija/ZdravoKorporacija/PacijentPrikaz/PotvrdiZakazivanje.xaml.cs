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
    /// Interaction logic for PotvrdiZakazivanje.xaml
    /// </summary>
    public partial class PotvrdiZakazivanje : Window
    {
        public string idTermin = null;
        public PotvrdiZakazivanje(Termin izabrani)
        {
            InitializeComponent();
            Termin t = TerminServis.pretraziSlobodnePoId(izabrani.IdTermina);
            lekar.Text = t.Lekar.CeloIme;
            datum.Text = t.Datum;
            vreme.Text = t.Vreme;
            idTermin = t.IdTermina;
        }

        private void potvrdiZakazivanje_Click(object sender, RoutedEventArgs e)
        {
            Termin t = TerminServis.pretraziSlobodnePoId(idTermin);
            t.Pacijent = NaloziPacijenataServis.pretraziPoKorisnickom(PacijentGlavniProzor.ulogovan.korisnik.KorisnickoIme);
            TerminServis.ZakaziPregled(t);
            this.Close();
        }
    }
}
