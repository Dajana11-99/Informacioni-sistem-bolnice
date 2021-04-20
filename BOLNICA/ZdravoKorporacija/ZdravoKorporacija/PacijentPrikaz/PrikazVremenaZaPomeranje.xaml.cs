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

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for PrikazVremenaZaPomeranje.xaml
    /// </summary>
    public partial class PrikazVremenaZaPomeranje : Window
    {

        public static ObservableCollection<Termin> VremenaTerminaPomeranje { get; set; }
        public PrikazVremenaZaPomeranje(Termin termin)
        {
            InitializeComponent();
            VremenaTerminaPomeranje = new ObservableCollection<Termin>();

            foreach (Termin t in TerminServis.nadjiVremeTermina(termin))
            {
                VremenaTerminaPomeranje.Add(t);
            }

            slobodnaVremenaLista.ItemsSource = VremenaTerminaPomeranje;
        }

        private void vratiSe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nastavi_Click(object sender, RoutedEventArgs e)
        {
            if (slobodnaVremenaLista.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite termin!");
                return;
            }
            PotvrdiPomeranje pz = new PotvrdiPomeranje(((Termin)slobodnaVremenaLista.SelectedItem));
            pz.Show();
            this.Close();
        }
    }
}
