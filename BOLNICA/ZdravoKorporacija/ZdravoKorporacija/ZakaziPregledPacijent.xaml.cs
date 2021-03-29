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
using Model;
using PoslovnaLogika;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for ZakaziPregledPacijent.xaml
    /// </summary>
    public partial class ZakaziPregledPacijent : Window
    {
        public ZakaziPregledPacijent()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String id =RukovanjeTerminima.pronadji();
            Lekar l = new Lekar(lekar.Text);
            Pacijent p = new Pacijent(pacijent.Text);
            Sala sala = new Sala(TipSale.Pregled, null);
            TipTermina tip = TipTermina.Pregled;
            DateTime? datum = this.datum.SelectedDate;
            String formatirano = null;
            if (datum.HasValue)
                formatirano = datum.Value.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String v = vreme.Text;
            Double trajanje = 30;
            Termin t = new Termin(id, tip, v, trajanje, formatirano, sala, p, l);

            RukovanjeTerminima.ZakaziPregled(t);
            this.Close();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
