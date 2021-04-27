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
    
    public partial class IzmeniLek : Window
    {
        Lek lekZaIzmenu;
        public IzmeniLek(Lek lek)
        {
            InitializeComponent();
            lekZaIzmenu = lek;
            txtImeLeka.Text = "" + lek.ImeLeka;
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            String imeLeka = txtImeLeka.Text;

            lekZaIzmenu.ImeLeka = imeLeka;

            LekServis.Izmena(lekZaIzmenu);
            Close();

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
