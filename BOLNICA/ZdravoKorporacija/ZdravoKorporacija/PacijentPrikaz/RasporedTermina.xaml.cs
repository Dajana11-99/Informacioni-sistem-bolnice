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

        public static ObservableCollection<Termin> TerminiPacijenta { get; set; }
        public RasporedTermina()
        {
            
            InitializeComponent();

            this.DataContext = this;
            TerminiPacijenta = new ObservableCollection<Termin>();
            foreach (Termin t in TerminServis.PrikaziSveTermine())
            {
                if (t.Pacijent.korisnik.KorisnickoIme.Equals(PacijentGlavniProzor.ulogovan.korisnik.KorisnickoIme))
                    TerminiPacijenta.Add(t);
            }
        }

        private void izmenaTermina_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OtkazivanjeTermina_Click(object sender, RoutedEventArgs e)
        {
            OtkazivanjeTermina otk = new OtkazivanjeTermina(((Termin)TerminiPacijentaa.SelectedItem).IdTermina);
            otk.Show();
            

        }

        private void Izvestaj_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
