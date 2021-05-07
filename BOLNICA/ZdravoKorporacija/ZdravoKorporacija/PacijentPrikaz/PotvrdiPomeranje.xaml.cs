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

    public partial class PotvrdiPomeranje : Window
    {
        public Termin Termin = null;
        public PotvrdiPomeranje(Termin izabrani)
        {
            InitializeComponent();
            Termin= TerminKontroler.PretraziSlobodneTerminePoId(izabrani.IdTermina);
            PodesavanjePrikaza(Termin);
        }

        private void PodesavanjePrikaza(Termin termin)
        {
            lekar.Text = termin.Lekar.CeloIme;
            datum.Text = termin.Datum.ToString("MM/dd/yyyy");
            vreme.Text = termin.Vreme;
            Termin = termin;
        }


        private void potvrdiIzmenu_Click(object sender, RoutedEventArgs e)
        {
            TerminKontroler.PomeriPregled(Termin.IdTermina);
            if (PacijentGlavniProzor.ulogovan.Maliciozan == true)
                MessageBox.Show("Ovo je vas poslednji otkazan termin. Nalog je blokiran!");
            this.Close();



        }

        

     
        private void VratiSe_Click(object sender, RoutedEventArgs e)
        {
            PrikazVremenaZaPomeranje prikaz = new PrikazVremenaZaPomeranje(Termin);
            prikaz.Show();
            this.Close();
        }
    }
}
