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
        public PrikazVremenaZaPomeranje(TerminDTO stariTermin,TerminDTO noviTermin)
        {
            prikazVremenaViewModel = new PrikazVremenaViewModel(stariTermin, noviTermin);
            InitializeComponent();
            this.slobodnaVremena.ItemsSource = prikazVremenaViewModel.SlobodniTermini;
            this.DataContext = prikazVremenaViewModel;
        }
    }
}
