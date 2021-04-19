using Model;
using PoslovnaLogika;
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

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for DodajRasporedjivanjeDinamickeOpreme.xaml
    /// </summary>
    public partial class DodajRasporedjivanjeDinamickeOpreme : Window
    {
        public DodajRasporedjivanjeDinamickeOpreme()
        {
            InitializeComponent();
            cmbDinamicka.ItemsSource = RukovanjeDinamickomOpremom.dinamickaOprema;
            cmbProstorija.ItemsSource = RukovanjeSalama.sala;
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            DateTime? rasporedjenoOd = datePickerRasporedjenoOd.SelectedDate;
            if (!rasporedjenoOd.HasValue)
            {
                MessageBox.Show("Datum od nije unet");
                return;
            }


            DateTime? rasporedjenoDo = this.datePickerRasporedjenoDo.SelectedDate;
            if (!rasporedjenoDo.HasValue)
            {
                MessageBox.Show("Datum do nije unet");
                return;
            }

            ZahtevZaRasporedjivanjeDinamickeOpreme zahtev = new ZahtevZaRasporedjivanjeDinamickeOpreme();
            zahtev.Id = RukovanjeZahtevZaRasporedjivanjeDinamickeOpreme.pronadji();
            zahtev.Kolicina = 4; // txtKolicina.Text;
            zahtev.RasporedjenoOd = rasporedjenoOd.Value;
            zahtev.ProstorijaId = (string)cmbProstorija.SelectedValue;
            zahtev.DinamickaOpremaId = (string)cmbDinamicka.SelectedValue;
            RukovanjeZahtevZaRasporedjivanjeDinamickeOpreme.DodajDinamickuOpremuProstorija(zahtev);

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
