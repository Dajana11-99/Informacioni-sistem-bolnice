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

            Recept = new Recept(txtKolicinaLeka.Text, datePickerPocetak.SelectedDate.Value, datePickerKraj.SelectedDate.Value, double.Parse(txtPeriodUzimanja.Text),new Lek(idLeka.Text,txtNazivLeka.Text));
           
            this.Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Recept = null;
            this.Close();
        }
    }
}
