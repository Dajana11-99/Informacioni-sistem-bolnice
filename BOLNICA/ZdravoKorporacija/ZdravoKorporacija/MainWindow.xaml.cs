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
using System.Windows.Navigation;
using System.Windows.Shapes;

using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SalaServis RukovanjeSalama = new SalaServis();
        public MainWindow()
        {
            InitializeComponent();
            //RukovanjeTerminima.inicijalizuj();
            SalaServis.inicijalizuj();
           NaloziPacijenataServis.TestMethod();
            TerminRepozitorijum.ucitajTermine();
            LekarRepozitorijum.ucitajLekare();
            SalaRepozitorijum.UcitajSale();
            RukovanjeStatickomOpremomServis.inicijalizuj();
            RukovanjeDinamickomOpremomServis.inicijalizuj();
            RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.inicijalizuj();
            RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis.inicijalizuj();

            // Izvrsi zahteve automatski 
            RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.IzvrsiZahteveZaDanas();
            RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis.IzvrsiZahteveZaDanas();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TerminRepozitorijum.ucitajTermine();
            LekarRepozitorijum.ucitajLekare();
            PrikazTerminaPacijenta prikaz = new PrikazTerminaPacijenta();
            prikaz.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TerminRepozitorijum.ucitajTermine();
            LekarRepozitorijum.ucitajLekare();
            LekarWindow lekar = new LekarWindow();
            lekar.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PrikazPacijenata PrikazPravi = new PrikazPacijenata();
            PrikazPravi.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            UpravnikPocetna pocetna = new UpravnikPocetna();
            SalaRepozitorijum.UcitajSale();
            pocetna.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SalaRepozitorijum.UpisiSale();
            TerminRepozitorijum.upisiTermine();
           LekarRepozitorijum.upisiLekare();
        }
    }
}
