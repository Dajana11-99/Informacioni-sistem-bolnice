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

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for PotvrdiPomeranje.xaml
    /// </summary>
    public partial class PotvrdiPomeranje : Window
    {
        public string idTermina = null;
        public PotvrdiPomeranje(Termin izabrani)
        {
            InitializeComponent();
            Termin termin = TerminKontroler.pretraziSlobodnePoId(izabrani.IdTermina);
            lekar.Text = termin.Lekar.CeloIme;
            datum.Text = termin.Datum;
            vreme.Text = termin.Vreme;
            idTermina = termin.IdTermina;

        }

  

        private void potvrdiIzmenu_Click(object sender, RoutedEventArgs e)
        {
        
            TerminKontroler.PomeriPregled(idTermina);
            this.Close();
        }
    }
}
