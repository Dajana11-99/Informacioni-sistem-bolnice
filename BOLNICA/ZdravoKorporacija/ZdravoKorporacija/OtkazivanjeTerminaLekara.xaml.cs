
using Kontroler;
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
    /// Interaction logic for OtkazivanjeTerminaLekara.xaml
    /// </summary>
    public partial class OtkazivanjeTerminaLekara : Window
    {

        String id = null;
        TerminKontroler terminKontroler = new TerminKontroler();
        

        public OtkazivanjeTerminaLekara(string idTermina)
        {

            id = idTermina;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            terminKontroler.OtkaziTermin(id);
            this.Close();
        }
    }
}
