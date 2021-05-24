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
using System.Windows.Shapes;

namespace ZdravoKorporacija.PacijentPrikaz
{ 
    public partial class IstorijaPregleda : Window
    {
        public static ObservableCollection<Termin> TerminiPacijenta { get; set; }
        TerminKontroler terminKontroler = new TerminKontroler();
        
        public IstorijaPregleda()
        {
            InitializeComponent();
            this.DataContext = this;
            TerminiPacijenta = new ObservableCollection<Termin>();
            foreach (Termin t in terminKontroler.PrikaziSveZakazaneTermine())
            {
               /* if (t.Pacijent.korisnik.KorisnickoIme.Equals(PacijentGlavniProzor.ulogovan.korisnik.KorisnickoIme))
                {
                    if (DateTime.Compare(t.Datum.Date, DateTime.Now.Date) < 0)
                        TerminiPacijenta.Add(t);
                }*/

            }
        }

        private void IzvestajSaPregleda_Click(object sender, RoutedEventArgs e)
        {
            if(TerminiPacijentaa.SelectedIndex== -1)
            {
                MessageBox.Show("Morate izabrati termin da biste videli izveštaj o istom!");
                return;
            }
           
            IzvestajSaPregleda izvestaj = new IzvestajSaPregleda((Termin)TerminiPacijentaa.SelectedItem);
            izvestaj.Show();
            this.Close();
        }

        private void VratiSe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
