using Model;

using Servis;
using System.Collections.ObjectModel;
using System.Windows;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for RasporedjivanjeStatickeOpreme.xaml
    /// </summary>
    public partial class RasporedjivanjeStatickeOpreme : Window
    {
        public static ObservableCollection<ZahtevZaRasporedjivanjeStatickeOpreme> ListRasporedele { get; set; }

        public RasporedjivanjeStatickeOpreme()
        {
            InitializeComponent();
            DataContext = this;
            ListRasporedele = RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis.observableZahtevZaRasporedjivanjeStatickeOpreme;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajRasporedjivanjeStatickeOpreme dodaj = new DodajRasporedjivanjeStatickeOpreme();
            dodaj.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (SpisakRaspodela.SelectedIndex != -1)
            {
                BrisanjeStatickeOpreme brisaje = new BrisanjeStatickeOpreme(((StatickaOpremaProstorija)SpisakRaspodela.SelectedItem).Id);
                brisaje.Show();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (SpisakRaspodela.SelectedIndex != -1)
            {
                IzmeniRasporedjivanjeStatickeOpreme izmena = new IzmeniRasporedjivanjeStatickeOpreme(((ZahtevZaRasporedjivanjeStatickeOpreme)SpisakRaspodela.SelectedItem));
                izmena.Show();
            }
        }


    }
}
