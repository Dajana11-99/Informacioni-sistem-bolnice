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
    /// Interaction logic for IzmeniSalu.xaml
    /// </summary>
    public partial class IzmeniStatickuOpremu : Window
    {
        StatickaOprema statickaOpremaZaIzmenu;
        public IzmeniStatickuOpremu(StatickaOprema staticka)
        {
            InitializeComponent();
            statickaOpremaZaIzmenu = staticka;
            txtNaziv.Text = "" + staticka.naziv;
            txtKolicina.Text = "" + staticka.kolicina;

        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {

            String naziv = txtNaziv.Text;

            int kolicina;

            try
            {
                kolicina = Int32.Parse(txtKolicina.Text);
            }
            catch
            {
                MessageBox.Show($"Kolicina mora biti ceo broj!!");
                return;
            }

            statickaOpremaZaIzmenu.naziv = naziv;
            statickaOpremaZaIzmenu.kolicina = kolicina;

            RukovanjeStatickomOpremomServis.IzmeniStatickuOpremu(statickaOpremaZaIzmenu);
            Close();

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

