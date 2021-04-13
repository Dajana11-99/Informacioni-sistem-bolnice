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
    /// Interaction logic for OdusustvaUpravnik.xaml
    /// </summary>
    public partial class OdusustvaUpravnik : Window
    {
        public List<ZahtevUpravniku> zahtevs { get; set; }
        public string Opis{ get; set; }
        public OdusustvaUpravnik()
        {
            InitializeComponent();
            zahtevs = new List<ZahtevUpravniku>();
            foreach (ZahtevUpravniku zahtev in RukovanjeZahtevima.PrikaziZahteve())
            {
                zahtevs.Add(zahtev);

            }

        }

        private void OdobriZahtevClick(object sender, RoutedEventArgs e)
        {
            if (poslatiZahtevi.SelectedIndex != -1)
            {
                var zahtev = (ZahtevUpravniku)poslatiZahtevi.SelectedItem;
                zahtev.status = StatusZahteva.Prihvacen;

            }
        }

        private void OdbijZahtev(object sender, RoutedEventArgs e)
        {
            if (poslatiZahtevi.SelectedIndex != -1)
            {
                var zahtev = (ZahtevUpravniku)poslatiZahtevi.SelectedItem;
                zahtev.status = StatusZahteva.Odbijen;

            }
        }
    }
}
