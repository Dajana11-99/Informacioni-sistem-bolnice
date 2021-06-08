using Model;

using Servis;
using System;
using System.Collections.Generic;
using System.Windows;
using ZdravoKorporacija.GrafZavisnosti;
using ZdravoKorporacija.ServisInterfejs;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for IzmeniRasporedjivanjeStatickeOpreme.xaml
    /// </summary>
    public partial class IzmeniRasporedjivanjeStatickeOpreme : Window
    {
       // private ZahtevZaRasporedjivanjeStatickeOpreme selectedItem;

        public List<StatickaOprema> StatickaOprema;
        public List<Sala> Prostorija;
        RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs rukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis;

        public IzmeniRasporedjivanjeStatickeOpreme(ZahtevZaRasporedjivanjeStatickeOpreme selectedItem)
        {
            InitializeComponent();
            cmbStatickaOprema.ItemsSource = RukovanjeStatickomOpremomServis.statickaOprema;
            cmbProstorija.ItemsSource = SalaServis.sala;
            cmbProstorijaIz.ItemsSource = SalaServis.sala;
            rukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis = Injektor.Instance.Get<RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs>(typeof(RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs));
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            DateTime? rasporedjenoOd = datePickerRasporedjenoOd.SelectedDate;
            if (!rasporedjenoOd.HasValue)
            {
                MessageBox.Show("Datum od nije unet");
                return;
            }


            ZahtevZaRasporedjivanjeStatickeOpreme zahtev = new ZahtevZaRasporedjivanjeStatickeOpreme();
            zahtev.Id = rukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis.pronadji();
            zahtev.Kolicina = 4; // txtKolicina.Text;
            zahtev.RasporedjenoOd = rasporedjenoOd.Value;
            zahtev.ProstorijaId = (string)cmbProstorija.SelectedValue;
            zahtev.IzProstorijaId = (string)cmbProstorijaIz.SelectedValue;
            zahtev.StatickeOpremaId = (string)cmbStatickaOprema.SelectedValue;
            rukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis.DodajStatickuOpremuIzSkladista(zahtev);

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
