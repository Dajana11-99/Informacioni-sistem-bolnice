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

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for DodajZahtevWindow.xaml
    /// </summary>
    public partial class DodajZahtevWindow : Window
    {
        public List<Lekar> Lekari { get; set; }

        public DodajZahtevWindow()
        {
            InitializeComponent();
        }
      

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            Lekar l = new Lekar(txtLekar.Text);
            string opis = OpisZahteva.Text;
            DateTime? datum = datePickerPocetakOdmora.SelectedDate;
            String foramtirano1 = null;
            String foramtirano2 = null;

            if (datum.HasValue)
                foramtirano1 = datum.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            DateTime? datum1 = datePickerKrajOdmora.SelectedDate;
            if (datum1.HasValue)
                foramtirano2 = datum1.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            string ID = ZahtevServis.nadjiIDZahteva();

            ZahtevUpravniku Zahtev= new ZahtevUpravniku(l, opis, foramtirano1, foramtirano2, ID);

            ZahtevServis.KreirajZahtev(Zahtev);

            this.Close();


        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
