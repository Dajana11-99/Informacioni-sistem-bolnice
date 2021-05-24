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
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Servis;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.PacijentPrikaz
{
  
    public partial class PrikazObavestenja : Window
    {
        
        private ObavestenjaViewModel obavestenjaViewModel;
        public PrikazObavestenja(String pacijent)
        {
            obavestenjaViewModel = new ObavestenjaViewModel(pacijent);
            InitializeComponent();
            this.obavestenjaPacijenta.ItemsSource = obavestenjaViewModel.SvaObavestenjaPacijenta;
            this.DataContext = obavestenjaViewModel;
            
        }
        private void VratiSe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
