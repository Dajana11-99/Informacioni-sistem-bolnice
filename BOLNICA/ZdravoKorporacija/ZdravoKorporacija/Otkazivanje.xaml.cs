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
using PoslovnaLogika;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for Otkazivanje.xaml
    /// </summary>
    public partial class Otkazivanje : Window
    {
        String id = null;
        public Otkazivanje(String idTermina)
        {
            id = idTermina;
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            RukovanjeTerminima.OtkaziPregled(id);
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
