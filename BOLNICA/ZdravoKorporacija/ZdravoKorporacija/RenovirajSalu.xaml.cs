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
using ZdravoKorporacija.GrafZavisnosti;
using ZdravoKorporacija.ServisInterfejs;

namespace ZdravoKorporacija
{
    public partial class RenovirajSalu : Window
    {
        Sala salaZaIzmenu;
        SalaServisInterfejs salaServis;
        List<string> opcijaRazdvajanje = new List<string>()
        {
            "Razdvajanje na dve nove sobe",
            "Spajanje sa drugom sobom u novu sobu",
            "Renoviranje bez razdvajanja/spajanja"
        };

 
        public RenovirajSalu(Sala sala)
        {
            InitializeComponent();
            cboxTipRenoviranja.ItemsSource = opcijaRazdvajanje;
            cboxTipRenoviranja.SelectedIndex = 2;
            salaZaIzmenu = sala;
            cboxIzborSaleZaSpajanje.ItemsSource = SalaServis.sala;
            lblNaslov.Content = $"Renoviranje {sala.TipSale} id {sala.Id}";
            DaLiPostojiRenoviranje();
            salaServis = Injektor.Instance.Get<SalaServisInterfejs>(typeof(SalaServisInterfejs));
        }

        private void DaLiPostojiRenoviranje()
        {
            if (salaZaIzmenu.Renoviranje != null)
            {
                MessageBox.Show("Sala je pod renoviranjem, nije moguce dodati novo renoviranje dok se trenutno rensoviranje ne zavrsi ili izbrise");
                Close();
            }
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            Renoviranje renoviranje = GetRenoviranje();
            if (renoviranje == null)
            {
                return;
            }
            salaZaIzmenu.Renoviranje = renoviranje;
            salaServis.RenovirajSalu(salaZaIzmenu);
        }

        private Renoviranje GetRenoviranje()
        {
            Renoviranje renoviranje = new Renoviranje();
            DateTime? RenoviranjeOd = datePickerPocetakRenoviranja.SelectedDate;
            if (!DatumUnet(RenoviranjeOd))
                return null;
            DateTime? RenoviranjeDo = datePickerKrajRenoviranja.SelectedDate;
            if (!DatumUnet(RenoviranjeDo))
                return null;
            renoviranje.RenoviranjeOd = RenoviranjeOd.Value;
            renoviranje.RenoviranjeDo = RenoviranjeDo.Value;
            DodajSpajanje(renoviranje);
            DodajRazdvajanje(renoviranje);
            return renoviranje;
        }

        private void DodajRazdvajanje(Renoviranje renoviranje)
        {
            if ((string)cboxTipRenoviranja.SelectedItem != opcijaRazdvajanje[0])
                return;

            renoviranje.Razdvajanje = true;
            renoviranje.NazivPrveNoveSale = txtNazivPrveSale.Text;
            renoviranje.NazivDrugeNoveSale = txtNazivDrugeSale.Text;
        }

        private void DodajSpajanje(Renoviranje renoviranje)
        {
            if ((string)cboxTipRenoviranja.SelectedItem != opcijaRazdvajanje[1])
                return;

            renoviranje.Spajanje = true;
            renoviranje.SalaZaSpajanje = (Sala)cboxIzborSaleZaSpajanje.SelectedItem;
            renoviranje.NazivNovoSpojeneSale = txtNazivNoveSale.Text;
        }

        private static bool DatumUnet(DateTime? renoviranje)
        {
            if (!renoviranje.HasValue)
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

        private void onTipRenoviranjaChange(object sender, SelectionChangedEventArgs e)
        {
            int spajanje = 1;
            int razdvajanje = 0;
            if ((string)cboxTipRenoviranja.SelectedItem == opcijaRazdvajanje[spajanje])
                PrikaziSpajanje();
            else if ((string)cboxTipRenoviranja.SelectedItem == opcijaRazdvajanje[razdvajanje])
                PrikaziRazdvajanje();
            else
                SakrijSpajanjeRazdvajanja();

        }

        private void SakrijSpajanjeRazdvajanja()
        {
            txtNazivDrugeSale.Visibility = Visibility.Hidden;
            txtNazivPrveSale.Visibility = Visibility.Hidden;
            txtNazivNoveSale.Visibility = Visibility.Hidden;
            cboxIzborSaleZaSpajanje.Visibility = Visibility.Hidden;
        }

        private void PrikaziSpajanje()
        {
            txtNazivDrugeSale.Visibility = Visibility.Hidden;
            txtNazivPrveSale.Visibility = Visibility.Hidden;
            txtNazivNoveSale.Visibility = Visibility.Visible;
            cboxIzborSaleZaSpajanje.Visibility = Visibility.Visible;
        }

        private void PrikaziRazdvajanje()
        {
            txtNazivDrugeSale.Visibility = Visibility.Visible;
            txtNazivPrveSale.Visibility = Visibility.Visible;
            txtNazivNoveSale.Visibility = Visibility.Hidden;
            cboxIzborSaleZaSpajanje.Visibility = Visibility.Hidden;
        }
    }
}
