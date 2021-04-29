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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for RasporedTermina.xaml
    /// </summary>
    public partial class RasporedTermina : UserControl


    {

        public static Termin TerminZaPomeranje = null;
        public static ObservableCollection<Termin> TerminiPacijenta { get; set; }
        public RasporedTermina()
        {
            
            InitializeComponent();

            this.DataContext = this;
            TerminiPacijenta = new ObservableCollection<Termin>();
            foreach (Termin t in TerminKontroler.PrikaziSveTermine())
            {
                if (t.Pacijent.korisnik.KorisnickoIme.Equals(PacijentGlavniProzor.ulogovan.korisnik.KorisnickoIme))
                    TerminiPacijenta.Add(t);
            }
        }

        private void izmenaTermina_Click(object sender, RoutedEventArgs e)
        {
            if (TerminiPacijentaa.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite termin za izmenu");
                return;
            }
            if (PacijentGlavniProzor.ulogovan.maliciozan == true)
            {
                MessageBox.Show("Vas nalog je blokiran!");

                return;
            }
            TerminZaPomeranje = (Termin)TerminiPacijentaa.SelectedItem;
            IzmenaTermina izmeni = new IzmenaTermina(TerminZaPomeranje);
            izmeni.Show();
            
        }

        private void OtkazivanjeTermina_Click(object sender, RoutedEventArgs e)

        {

            if (TerminiPacijentaa.SelectedIndex == -1)
            {
                MessageBox.Show("Izaberite termin za otkazivanje");
                
                return;
            }

            if (PacijentGlavniProzor.ulogovan.maliciozan == true)
            {
                MessageBox.Show("Vas nalog je blokiran!");
               
                return;
            }
            OtkazivanjeTermina otk = new OtkazivanjeTermina(((Termin)TerminiPacijentaa.SelectedItem).IdTermina);
            otk.Show();
            

        }

        private void Izvestaj_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
