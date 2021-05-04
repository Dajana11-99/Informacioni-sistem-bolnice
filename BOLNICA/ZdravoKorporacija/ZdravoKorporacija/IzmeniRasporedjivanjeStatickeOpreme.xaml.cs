using Model;

using Servis;
using System;
using System.Collections.Generic;
using System.Windows;


namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for IzmeniRasporedjivanjeStatickeOpreme.xaml
    /// </summary>
    public partial class IzmeniRasporedjivanjeStatickeOpreme : Window
    {
        private ZahtevZaRasporedjivanjeStatickeOpreme selectedItem;

        public List<StatickaOprema> StatickaOprema;
        public List<Sala> Prostorija;

        public IzmeniRasporedjivanjeStatickeOpreme(ZahtevZaRasporedjivanjeStatickeOpreme selectedItem)
        {
            InitializeComponent();
            cmbStatickaOprema.ItemsSource = RukovanjeStatickomOpremomServis.statickaOprema;
            cmbProstorija.ItemsSource = SalaServis.sala;
            cmbProstorijaIz.ItemsSource = SalaServis.sala;
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
            zahtev.Id = RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis.pronadji();
            zahtev.Kolicina = 4; // txtKolicina.Text;
            zahtev.RasporedjenoOd = rasporedjenoOd.Value;
            zahtev.ProstorijaId = (string)cmbProstorija.SelectedValue;
            zahtev.IzProstorijaId = (string)cmbProstorijaIz.SelectedValue;
            zahtev.StatickeOpremaId = (string)cmbStatickaOprema.SelectedValue;
            RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis.DodajStatickuOpremuIzSkladista(zahtev);

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
