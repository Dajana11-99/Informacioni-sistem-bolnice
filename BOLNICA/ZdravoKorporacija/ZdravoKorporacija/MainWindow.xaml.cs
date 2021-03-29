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
            RukovanjeTerminima.inicijalizuj();
            
            RukovanjeDatotekama2.ucitajTermine();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RukovanjeDatotekama2.ucitajTermine();
            PrikazTerminaPacijenta prikaz = new PrikazTerminaPacijenta();
            prikaz.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            RukovanjeDatotekama2.InicijalizujSale();
            RukovanjeSalama.SetSala(RukovanjeDatotekama2.UcitajSale());
            UpravnikPocetna pocetna = new UpravnikPocetna();
            pocetna.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            RukovanjeDatotekama2.upisiTermine();
        }
    }
}
