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
    /// Interaction logic for IzmenaTerminaLekara.xaml
    /// </summary>
    public partial class IzmenaTerminaLekara : Window
    {

        public List<Lekar> Lekari { get; set; }
        public String id = null;
        public IzmenaTerminaLekara(Termin t)
        {
            InitializeComponent();
            bindcombo();
            id = t.IdTermina;

            cmbLekar.SelectedIndex = konstruisi_combo(t.Lekar.idZaposlenog);
            datePickerZakazivanjeTermina.SelectedDate = DateTime.ParseExact(t.Datum, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            cmbZakazivanjeTerminaVreme.Text = t.Vreme;
            cmbPacijent.Text = t.Pacijent.idPacijenta;
            txtPredvidjenoVremeTermina.Text = t.trajanjeTermina.ToString();
           // cmbHMin.Text = 
            cmbBrojSale.Text = t.Sala.Id;
            cmbTipSale.Text = t.Sala.TipSale.ToString();
            cmbVrstaTermina.Text = t.TipTermina.ToString();
            



        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPotvrdiZakazivanjeTermina_Click(object sender, RoutedEventArgs e)
        {
            DateTime? datum = this.datePickerZakazivanjeTermina.SelectedDate;
            String formatirano = null;
            if (datum.HasValue)
                formatirano = datum.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);


            RukovanjeTerminima.IzmenaTermina(id,formatirano,cmbZakazivanjeTerminaVreme.Text,cmbLekar.Text,txtPredvidjenoVremeTermina.Text,cmbBrojSale.Text,cmbTipSale.Text,cmbVrstaTermina.Text);
            this.Close();
        }

        public int konstruisi_combo(String id)
        {
            for (int i = 0; i < Lekari.Count; i++)
            {
                if (Lekari[i].idZaposlenog.Equals(id))
                    return i;
            }
            return 0;

        }
        public void bindcombo()
        {
            List<Lekar> pomocna = new List<Lekar>();

            foreach (Lekar l in RukovanjeTerminima.pom)
            {
                if (!l.Specijalizacija.Equals(Specijalizacija.Ostapraksa))
                {
                    pomocna.Add(l);
                }
            }
            Lekari = pomocna;
            DataContext = Lekari;
        }
    }
}
