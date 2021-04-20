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
using PoslovnaLogika;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for IzmeniRasporedjivanjeDinamickeOpreme.xaml
    /// </summary>
    public partial class IzmeniRasporedjivanjeDinamickeOpreme : Window
    {
        public IzmeniRasporedjivanjeDinamickeOpreme()
        {
            InitializeComponent();
            cmbDinamicka.ItemsSource = RukovanjeDinamickomOpremomServis.dinamickaOprema;
            cmbProstorija.ItemsSource = SalaServis.sala;
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
            zahtev.Id = RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.pronadji();
            zahtev.Kolicina = 4; // txtKolicina.Text;
            zahtev.RasporedjenoOd = rasporedjenoOd.Value;
            zahtev.ProstorijaId = (string)cmbProstorija.SelectedValue;
            zahtev.DinamickaOpremaId = (string)cmbDinamicka.SelectedValue;
            RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.DodajDinamickuOpremuProstorija(zahtev);

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
