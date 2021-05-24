using Kontroler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for PrikazAnketa.xaml
    /// </summary>
    public partial class PrikazAnketa : UserControl
    {
        public static ObservableCollection<Termin> Ankete { get; set; }
        TerminKontroler terminKontroler = new TerminKontroler();
        public PrikazAnketa()
        {
            InitializeComponent();
            this.DataContext = this;
            Ankete = new ObservableCollection<Termin>();
            foreach (Termin t in terminKontroler.PrikaziSveZakazaneTermine())
            {
              /*  if (t.Pacijent.korisnik.KorisnickoIme.Equals(PacijentGlavniProzor.ulogovan.korisnik.KorisnickoIme))
                {
                    if(DateTime.Compare(t.Datum.Date,DateTime.Now.Date)<0 && !t.OcenjenTermin)
                       Ankete.Add(t);
                }*/
                  
            }
        }

        private void PopuniAnketu_Click(object sender, RoutedEventArgs e)
        {
           
            if(TerminiPacijentaa.SelectedIndex == -1)
            {
                MessageBox.Show("Odaberite pregled za koji ćete popuniti anketu");
                return;
            }
            PopuniAnketu popuni = new PopuniAnketu((Termin)TerminiPacijentaa.SelectedItem);
            popuni.Show();
        }

        private void OceniBolnicu_Click(object sender, RoutedEventArgs e)
        {
           /* if (!anketeKontroler.DostupnaAnketaOBolnici(PacijentGlavniProzor.ulogovan))
            {
                MessageBox.Show("Već ste ocenili bolnicu!");
                return;
            }*/
          
            OceniBolnicu oceni = new OceniBolnicu();
            oceni.Show();

        }
        AnketeKontroler anketeKontroler = new AnketeKontroler();
    }
}
