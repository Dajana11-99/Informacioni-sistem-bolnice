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
    /// Interaction logic for OtkazivanjeZahteva.xaml
    /// </summary>
    public partial class OtkazivanjeZahteva : Window
    {
        String idZ = null;
        public OtkazivanjeZahteva(String idZahteva)
        {

            this.idZ = idZahteva;
            InitializeComponent();
        }

        private void btnPotvrdiOtkazivanje_Click(object sender, RoutedEventArgs e)
        {
            ZahtevServis.Obrisi(idZ);
            this.Close();
        }

        private void btnOdustaniOdOtkazivanja_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
