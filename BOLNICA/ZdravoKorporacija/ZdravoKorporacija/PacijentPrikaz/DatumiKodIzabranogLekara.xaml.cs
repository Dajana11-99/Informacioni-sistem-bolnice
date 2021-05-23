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
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.PacijentPrikaz
{
    public partial class DatumiKodIzabranogLekara : UserControl
    {
        private DatumiKoIzabranogLekaraViewModel datumi;
        public DatumiKodIzabranogLekara(ZakazivanjeDTO podaci)
        {
            datumi = new DatumiKoIzabranogLekaraViewModel(podaci);
            InitializeComponent();
            this.slobodniDatumiLista.SelectedItem = datumi.SlobodniKodIzabranog;
            this.DataContext = datumi;
        }

     
    }
}
