using Kontroler;
using Model;
using NPOI.Util;
using Servis;
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
using System.Windows.Shapes;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.PacijentPrikaz
{
    public partial class OtkazivanjeTermina : Window, ICloseable
    {
        public OtkazivanjeTermina(TerminDTO termin)
        {
            RasporedTerminaViewModel terminViewModel = new RasporedTerminaViewModel(termin);
            InitializeComponent();
            this.DataContext = terminViewModel;
           
        }

        private void OdustaniTermin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
       
        }
    }
}
