using Model;
using PoslovnaLogika;
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
    /// Interaction logic for RasporedjivanjeStatickeOpreme.xaml
    /// </summary>
    public partial class RasporedjivanjeStatickeOpreme : Window
    {
        public static ObservableCollection<StatickaOpremaProstorija> ListRasporedele { get; set; }

        public RasporedjivanjeStatickeOpreme()
        {
            InitializeComponent();
            ListRasporedele = RukovanjeStatickaOpremaProstorija.observableStatickaOpremaProstorija;

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
                IzmeniRasporedjivanjeStatickeOpreme izmena = new IzmeniRasporedjivanjeStatickeOpreme(((StatickaOpremaProstorija)SpisakRaspodela.SelectedItem));
                izmena.Show();
            }
        }


    }
}
