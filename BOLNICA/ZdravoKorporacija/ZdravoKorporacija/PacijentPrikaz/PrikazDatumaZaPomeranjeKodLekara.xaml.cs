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
    /// Interaction logic for PrikazDatumaZaPomeranjeKodLekara.xaml
    /// </summary>
    public partial class PrikazDatumaZaPomeranjeKodLekara : Window
    {
        public static ObservableCollection<Termin> SlobodniDatumiPomeranjeLekar { get; set; }
        public PrikazDatumaZaPomeranjeKodLekara()
        {
            InitializeComponent();
            SlobodniDatumiPomeranjeLekar = new ObservableCollection<Termin>();

            foreach (Termin t in IzmenaTermina.datumiZaIzmenu)
            {
                SlobodniDatumiPomeranjeLekar.Add(t);
            }

            slobodniDatumiPomLista.ItemsSource = SlobodniDatumiPomeranjeLekar;
        }

        private void vratiSe_Click(object sender, RoutedEventArgs e)
        {
            IzmenaTermina prikaz = new IzmenaTermina(IzmenaTermina.Termin);
            prikaz.Show();
            this.Close();
        }

        private void nastavi_Click(object sender, RoutedEventArgs e)
        {
            if (slobodniDatumiPomLista.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite datum!");
                return;
            }

             PrikazVremenaZaPomeranje pr = new PrikazVremenaZaPomeranje((Termin)slobodniDatumiPomLista.SelectedItem);
            pr.Show();
            this.Close();
           
        }
    }
}
