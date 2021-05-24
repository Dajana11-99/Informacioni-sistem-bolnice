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
       
        public PrikazDatumaZaPomeranjeKodLekara(TerminDTO terminZaPomernje)
        {
            prikazDatumaViewModel = new PrikazDatumaViewModel(terminZaPomernje);
            InitializeComponent();
            this.slobodniDatumi.ItemsSource = prikazDatumaViewModel.SlobodniDatumi;
            this.DataContext = prikazDatumaViewModel;
           
        }

    }
}
