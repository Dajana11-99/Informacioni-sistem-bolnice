using Model;
using PoslovnaLogika;
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
            cmbStatickaOprema.ItemsSource = RukovanjeStatickomOpremom.statickaOprema;
            cmbProstorija.ItemsSource = RukovanjeSalama.sala;
            cmbProstorijaIz.ItemsSource = RukovanjeSalama.sala;
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
            zahtev.Id = RukovanjeZahtevZaRasporedjivanjeStatickeOpreme.pronadji();
            zahtev.Kolicina = 4; // txtKolicina.Text;
            zahtev.RasporedjenoOd = rasporedjenoOd.Value;
            zahtev.ProstorijaId = (string)cmbProstorija.SelectedValue;
            zahtev.IzProstorijaId = (string)cmbProstorijaIz.SelectedValue;
            zahtev.StatickeOpremaId = (string)cmbStatickaOprema.SelectedValue;
            RukovanjeZahtevZaRasporedjivanjeStatickeOpreme.DodajStatickuOpremuProstorija(zahtev);

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
