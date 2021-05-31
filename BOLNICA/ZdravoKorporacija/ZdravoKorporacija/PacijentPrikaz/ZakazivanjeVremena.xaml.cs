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
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for ZakazivanjeVremena.xaml
    /// </summary>
    /// 
    public partial class ZakazivanjeVremena : UserControl
    {
        private VremenaZaZakazivanjeViewModel vremena;
        public ZakazivanjeVremena(TerminDTO izabraniTermin,ZakazivanjeDTO podaciZaPrikaz)
        {
            vremena = new VremenaZaZakazivanjeViewModel(izabraniTermin,podaciZaPrikaz);
            InitializeComponent();
            this.slobodnaVremena.ItemsSource = vremena.SlobodniTermini;
            this.DataContext = vremena;
        }

    }
}
