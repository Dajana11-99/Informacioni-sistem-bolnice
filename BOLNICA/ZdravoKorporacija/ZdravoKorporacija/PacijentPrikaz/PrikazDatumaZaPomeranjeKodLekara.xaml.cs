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
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for PrikazDatumaZaPomeranjeKodLekara.xaml
    /// </summary>
    public partial class PrikazDatumaZaPomeranjeKodLekara :UserControl
    {
        private PrikazDatumaViewModel prikazDatumaViewModel;
       
        public PrikazDatumaZaPomeranjeKodLekara(TerminViewModel terminZaPomernje)
        {
            prikazDatumaViewModel = new PrikazDatumaViewModel(terminZaPomernje);
            InitializeComponent();
            this.slobodniDatumi.ItemsSource = prikazDatumaViewModel.SlobodniDatumi;
            this.DataContext = prikazDatumaViewModel;
           
        }

       /* private void vratiSe_Click(object sender, RoutedEventArgs e)
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IzmenaTermina(termin));
        }

        private void nastavi_Click(object sender, RoutedEventArgs e)
        {
            if (slobodniDatumi.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite datum!");
                return;
            }
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazVremenaZaPomeranje(termin,(TerminViewModel)slobodniDatumi.SelectedItem));



        }
       */
    }
}
