using Kontroler;
using Model;
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
    public partial class OtkazivanjeTermina : Window
    {
        
     
        public OtkazivanjeTermina(TerminViewModel termin)
        {
            RasporedTerminaViewModel terminViewModel = new RasporedTerminaViewModel(PacijentGlavniProzor.ulogovan.korisnik.KorisnickoIme);
            InitializeComponent();
            this.DataContext = terminViewModel;
           
        }

        private void OdustaniTermin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
