using Model;
using PoslovnaLogika;
using Servis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for RasporedjivanjeDinamickeOpreme.xaml
    /// </summary>
    public partial class RasporedjivanjeDinamickeOpreme : Window
    {
        public static ObservableCollection<ZahtevZaRasporedjivanjeDinamickeOpreme> ListRasporedele { get; set; }

        public RasporedjivanjeDinamickeOpreme()
        {
            InitializeComponent();
            DataContext = this;
            ListRasporedele = RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.prikazRasporedjivanjeDinamickeOpremeZahtev;

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajRasporedjivanjeDinamickeOpreme dodaj = new DodajRasporedjivanjeDinamickeOpreme();
            dodaj.Show();
        }
    }
}
