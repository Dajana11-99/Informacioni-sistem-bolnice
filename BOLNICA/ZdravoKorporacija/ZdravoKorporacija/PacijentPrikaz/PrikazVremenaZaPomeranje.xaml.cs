using Kontroler;
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
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.PacijentPrikaz
{
    public partial class PrikazVremenaZaPomeranje : UserControl
    {

        
        TerminKontroler terminKontroler = new TerminKontroler();
        private PrikazVremenaViewModel prikazVremenaViewModel;
        private TerminViewModel noviTermin;
        private TerminViewModel stariTermin;
        public PrikazVremenaZaPomeranje(TerminViewModel stariTermin,TerminViewModel noviTermin)
        {
            this.noviTermin = noviTermin;
            this.stariTermin = stariTermin;
            prikazVremenaViewModel = new PrikazVremenaViewModel(noviTermin);
            InitializeComponent();
            this.slobodnaVremena.ItemsSource = prikazVremenaViewModel.SlobodniTermini;
        }

        private void vratiSe_Click(object sender, RoutedEventArgs e)
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazDatumaZaPomeranjeKodLekara(noviTermin));
        }

        private void nastavi_Click(object sender, RoutedEventArgs e)
        {
            if (slobodnaVremena.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite termin!");
                return;
            }
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PotvrdiPomeranje(stariTermin, (TerminViewModel)slobodnaVremena.SelectedItem));

           

       
       
        
        }
    }
}
