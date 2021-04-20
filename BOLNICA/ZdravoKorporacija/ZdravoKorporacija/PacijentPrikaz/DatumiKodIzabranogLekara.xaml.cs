using Model;
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

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for DatumiKodIzabranogLekara.xaml
    /// </summary>
    public partial class DatumiKodIzabranogLekara : Window
    {
        public static ObservableCollection<Termin> slobodniDatumiKodIzabranog { get; set; }
        public DatumiKodIzabranogLekara()
        {
            InitializeComponent();
            slobodniDatumiKodIzabranog = new ObservableCollection<Termin>();
            foreach (Termin t in ZakazivanjeSaPrioritetom.slobodniDatumi)
                slobodniDatumiKodIzabranog.Add(t);

            slobodniDatumiLista.ItemsSource = slobodniDatumiKodIzabranog;
        }

        private void vratiSe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void nastavi_Click(object sender, RoutedEventArgs e)
        {
            if (slobodniDatumiLista.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite datum");
                return;
            }

            ZakazivanjeVremena zakazi = new ZakazivanjeVremena(((Termin)slobodniDatumiLista.SelectedItem));
            zakazi.Show();
            this.Close();
        }
    }
}
