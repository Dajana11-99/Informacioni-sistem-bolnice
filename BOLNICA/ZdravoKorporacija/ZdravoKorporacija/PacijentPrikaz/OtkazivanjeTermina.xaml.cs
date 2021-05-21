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
            RasporedTerminaViewModel terminViewModel = new RasporedTerminaViewModel(PacijentGlavniProzor.ulogovan.korisnik.KorisnickoIme,termin);
            
         
            InitializeComponent();
            this.DataContext = terminViewModel;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       private void OtkaziTermin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        /* private void Button_Click_1(object sender, RoutedEventArgs e)
         {
             Termin termin = terminKontroler.PretragaZakazanihTerminaPoId(izabraniIdTermina);

             if (DateTime.Compare(DateTime.Now.Date, termin.Datum.Date) == 0)
             {
                 MessageBox.Show("Termin je za manje od 24h ne mozete ga otkazati!");
                 return;
             }

             terminKontroler.OtkaziPregled(izabraniIdTermina);
             if (PacijentGlavniProzor.ulogovan.Maliciozan == true)
             {
                 MessageBox.Show("Ovo je vas poslednji otkazan termin. Nalog je blokiran!");

                 return;
             }
             this.Close();
         }*/
    }
}
