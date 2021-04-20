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

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for OtkazivanjeTermina.xaml
    /// </summary>
    public partial class OtkazivanjeTermina : Window
    {
        String izabran = null;
        public OtkazivanjeTermina(String idTermina)
        {
            InitializeComponent();
            izabran = idTermina;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TerminServis.OtkaziPregled(izabran);
            this.Close();
        }
    }
}
