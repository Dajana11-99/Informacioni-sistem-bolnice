using Model;
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
    /// Interaction logic for IzdavanjeRecepataWindow.xaml
    /// </summary>
    public partial class IzdavanjeRecepataWindow : Window
    {
        public Recept Recept { get; set; }
        public IzdavanjeRecepataWindow()
        {
            InitializeComponent();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {

            DateTime? datum = this.datePickerPocetak.SelectedDate;
            DateTime? datum1 = this.datePickerKraj.SelectedDate;
            String formatirano = null;
            String formatirano1 = null;
            if (datum.HasValue)
                formatirano = datum.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (datum1.HasValue)
                formatirano1 = datum1.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            Recept = new Recept(txtKolicinaLeka.Text, formatirano, formatirano1, double.Parse(txtPeriodUzimanja.Text),new Lek(idLeka.Text,txtNazivLeka.Text));
           
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Recept = null;
            this.Close();
        }
    }
}
