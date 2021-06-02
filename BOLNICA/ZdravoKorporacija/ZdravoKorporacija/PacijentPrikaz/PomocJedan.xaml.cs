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
    /// Interaction logic for PomocJedan.xaml
    /// </summary>
    public partial class PomocJedan : UserControl
    {
        PomocViewModel pomocViewModel;
        public PomocJedan()
        {
            InitializeComponent();
            
            pomocViewModel = new PomocViewModel();
            this.DataContext = pomocViewModel;
        }
    }
}
