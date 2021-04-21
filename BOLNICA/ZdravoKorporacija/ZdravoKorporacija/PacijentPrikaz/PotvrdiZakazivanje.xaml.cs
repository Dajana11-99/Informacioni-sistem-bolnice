using Kontroler;
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
            Termin t = TerminKontroler.pretraziSlobodnePoId(izabrani.IdTermina);
            lekar.Text = t.Lekar.CeloIme;
            datum.Text = t.Datum;
            vreme.Text = t.Vreme;
            idTermin = t.IdTermina;
        }

        private void potvrdiZakazivanje_Click(object sender, RoutedEventArgs e)
        {
            Termin t = TerminKontroler.pretraziSlobodnePoId(idTermin);
            t.Pacijent = NaloziPacijenataKontroler.pretraziPoKorisnickom(PacijentGlavniProzor.ulogovan.korisnik.KorisnickoIme);
            TerminKontroler.ZakaziPregled(t);
            this.Close();
        }
    }
}
