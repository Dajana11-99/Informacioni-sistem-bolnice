using Model;
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
    /// Interaction logic for ZahtevZaSlobodneDaneWindow.xaml
    /// </summary>
    public partial class ZahtevZaSlobodneDaneWindow : Window
    {

        public static ObservableCollection<ZahtevUpravniku> zahtevs { get; set; }
        public ZahtevZaSlobodneDaneWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            zahtevs = new ObservableCollection<ZahtevUpravniku>();
            foreach(ZahtevUpravniku zahtev in ZahtevServis.PrikaziZahteve()) 
            {
                zahtevs.Add(zahtev);

            }
        }

        private void btnIzmeniZahtev_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOdustaniOdZahteva_Click(object sender, RoutedEventArgs e)
        {
            if (poslatiZahtevi.SelectedIndex != -1)
            {
                OtkazivanjeZahteva otkazivanje = new OtkazivanjeZahteva(((ZahtevUpravniku)poslatiZahtevi.SelectedItem).idZahteva);
                otkazivanje.Show();
               
            }
        }

        private void btnDodajZahtev_Click(object sender, RoutedEventArgs e)
        {
            DodajZahtevWindow dodajZahtev = new DodajZahtevWindow();
            dodajZahtev.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
