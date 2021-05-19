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
        public Termin Termin = null;
        TerminKontroler terminKontroler = new TerminKontroler();
        public PotvrdiZakazivanje(Termin izabrani)
        {
            InitializeComponent();
            Termin t = terminKontroler.PretraziSlobodneTerminePoId(izabrani.IdTermina);
            PodesavanjePrikaza(t);
        }

        private void PodesavanjePrikaza(Termin t)
        {
            lekar.Text = t.Lekar.CeloIme;
            datum.Text = t.Datum.ToString("MM/dd/yyyy");
            vreme.Text = t.Vreme;
            Termin = t;
        }

        private void potvrdiZakazivanje_Click(object sender, RoutedEventArgs e)
        {
            Termin t = terminKontroler.PretraziSlobodneTerminePoId(Termin.IdTermina);
            t.Pacijent = NaloziPacijenataKontroler.PretraziPoKorisnickom(PacijentGlavniProzor.ulogovan.korisnik.KorisnickoIme);
            terminKontroler.ZakaziPregled(t);
            this.Close();
        }

        private void VratiSe_Click(object sender, RoutedEventArgs e)
        {
            ZakazivanjeVremena prikaz = new ZakazivanjeVremena(Termin);
            prikaz.Show();
            this.Close();
        }
    }
}
