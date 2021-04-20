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


            ZahtevZaRasporedjivanjeDinamickeOpreme zahtev = new ZahtevZaRasporedjivanjeDinamickeOpreme();
            zahtev.Id = RukovanjeZahtevZaRasporedjivanjeDinamickeOpreme.pronadji();
            int kolicina = 0;
            try
            {
                kolicina = Int32.Parse(txtKolicina.Text);
            }
            catch
            {
                MessageBox.Show("Uneta kolciina mora biti >= 1");
                return;
            }
            if (kolicina <= 0)
            {
                MessageBox.Show("Uneta kolciina mora biti >= 1");
                return;
            }
            zahtev.Kolicina = kolicina; // txtKolicina.Text;
            zahtev.RasporedjenoOd = rasporedjenoOd.Value;
            zahtev.ProstorijaId = (string)cmbProstorija.SelectedValue;
            zahtev.DinamickaOpremaId = (string)cmbDinamicka.SelectedValue;
            RukovanjeZahtevZaRasporedjivanjeDinamickeOpreme.DodajDinamickuOpremuProstorija(zahtev);
            Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
