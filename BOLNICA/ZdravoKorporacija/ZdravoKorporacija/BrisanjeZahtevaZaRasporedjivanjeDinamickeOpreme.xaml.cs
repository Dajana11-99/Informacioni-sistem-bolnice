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
using PoslovnaLogika;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for BrisanjeZahtevaZaRasporedjivanjeDinamickeOpreme.xaml
    /// </summary>
    public partial class BrisanjeZahtevaZaRasporedjivanjeDinamickeOpreme : Window
    {
        private string zahtevId;

        public BrisanjeZahtevaZaRasporedjivanjeDinamickeOpreme(string id)
        {
            InitializeComponent();
            zahtevId = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.ObrisiZahtevZaRasporedjivanjeDinamickeOpreme(zahtevId);
            this.Close();
        }
    }
}
