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
using PoslovnaLogika;
using RadSaDatotekama;
using ZdravoKorporacija.RadSaDatotekama;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RukovanjeSalama RukovanjeSalama = new RukovanjeSalama();
        public MainWindow()
        {
            InitializeComponent();
            //RukovanjeTerminima.inicijalizuj();
            RukovanjeSalama.inicijalizuj();
            UpravljanjePacijentima.TestMethod();
            SkladisteTermina.ucitajTermine();
            SkladisteLekara.ucitajLekare();
            SkladisteSala.UcitajSale();
            RukovanjeStatickomOpremom.inicijalizuj();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SkladisteTermina.ucitajTermine();
            SkladisteLekara.ucitajLekare();
            PrikazTerminaPacijenta prikaz = new PrikazTerminaPacijenta();
            prikaz.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SkladisteTermina.ucitajTermine();
            SkladisteLekara.ucitajLekare();
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
            SkladisteSala.UcitajSale();
            pocetna.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SkladisteSala.UpisiSale();
            SkladisteTermina.upisiTermine();
           SkladisteLekara.upisiLekare();
        }
    }
}
