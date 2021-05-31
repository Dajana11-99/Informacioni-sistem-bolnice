using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for Podsetnik.xaml
    /// </summary>
    public partial class Podsetnik : UserControl
    {
        private PodsetnikViewModel podsetnikViewModel;
        public Podsetnik(TerminDTO termin)
        {
            podsetnikViewModel = new PodsetnikViewModel(termin);
            InitializeComponent();
            this.DataContext = podsetnikViewModel;
        }
    }
}
