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
    public partial class IzvestajOPregledima : UserControl
    {
        private IzvestajViewModel izvestajViewModel;
        public IzvestajOPregledima(String idPacijenta)
        {
            InitializeComponent();
            izvestajViewModel = new IzvestajViewModel(idPacijenta);
            this.DataContext = izvestajViewModel;
        }
    }
}
