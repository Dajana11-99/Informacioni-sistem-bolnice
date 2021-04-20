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
    /// Interaction logic for DatumiKodSvihLekara.xaml
    /// </summary>
    public partial class DatumiKodSvihLekara : Window
    {
        public static ObservableCollection<Termin> slobodniDatumiKodSvih { get; set; }
        public DatumiKodSvihLekara()
        {
            InitializeComponent();
            slobodniDatumiKodSvih = new ObservableCollection<Termin>();
            foreach (Termin t in ZakazivanjeSaPrioritetom.slobodniDatumi)
                slobodniDatumiKodSvih.Add(t);

            slobodniDatumiKodSvihLista.ItemsSource = slobodniDatumiKodSvih;
        }

        private void nastavi_Click(object sender, RoutedEventArgs e)
        {
            ZakazivanjeVremena vreme = new ZakazivanjeVremena(((Termin)slobodniDatumiKodSvihLista.SelectedItem));
            vreme.Show();
            this.Close();
        }

        private void vratiSe_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
