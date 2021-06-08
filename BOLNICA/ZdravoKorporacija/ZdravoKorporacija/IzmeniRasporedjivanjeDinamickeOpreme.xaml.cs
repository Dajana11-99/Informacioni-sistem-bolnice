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
using ZdravoKorporacija.ServisInterfejs;
using ZdravoKorporacija.GrafZavisnosti;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for IzmeniRasporedjivanjeDinamickeOpreme.xaml
    /// </summary>
    public partial class IzmeniRasporedjivanjeDinamickeOpreme : Window
    {
        RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs rukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis;
        public IzmeniRasporedjivanjeDinamickeOpreme()
        {
            InitializeComponent();
            cmbDinamicka.ItemsSource = RukovanjeDinamickomOpremomServis.dinamickaOprema;
            cmbProstorija.ItemsSource = SalaServis.sala;
            rukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis = Injektor.Instance.Get<RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs>(typeof(RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs));
        }
        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            DateTime? rasporedjenoOd = datePickerRasporedjenoOd.SelectedDate;
            if(!DatumUnet(rasporedjenoOd))
                return;
            DateTime? rasporedjenoDo = this.datePickerRasporedjenoDo.SelectedDate;
            if (!DatumUnet(rasporedjenoDo))
                return;
            ZahtevZaRasporedjivanjeDinamickeOpreme zahtev = new ZahtevZaRasporedjivanjeDinamickeOpreme();
            zahtev.Id = rukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.pronadji();
            zahtev.Kolicina = 4; // txtKolicina.Text;
            zahtev.ProstorijaId = (string)cmbProstorija.SelectedValue;
            zahtev.DinamickaOpremaId = (string)cmbDinamicka.SelectedValue;
            rukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.DodajDinamickuOpremuProstorija(zahtev);
        }
        private static bool DatumUnet(DateTime? rasporedjeno)
        {
            if (!rasporedjeno.HasValue)
            {
                MessageBox.Show("Datum od nije unet");
                return false;
            }
            return true;
        }
        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
