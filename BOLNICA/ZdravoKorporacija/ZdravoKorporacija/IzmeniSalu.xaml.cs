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
    public partial class IzmeniSalu : Window
    {
        Sala salaZaIzmenu;
        public IzmeniSalu(Sala sala)
        {
            InitializeComponent();
            salaZaIzmenu = sala;
            txtSprat.Text = "" + sala.sprat;
            cmbTipSale.Text = sala.TipSale.ToString();
            chkboxZauzeta.IsChecked = sala.Zauzeta;
        }
        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            TipSale tipS;
            String tipSale = cmbTipSale.Text;
            tipS = TipSale(tipSale);
            String sprat = txtSprat.Text;
            salaZaIzmenu.sprat = sprat;
            salaZaIzmenu.Zauzeta = chkboxZauzeta.IsChecked.Value;
            salaZaIzmenu.TipSale = tipS;
            SalaServis.Izmena(salaZaIzmenu);
            Close();
        }
        private static TipSale TipSale(string tipSale)
        {
            TipSale tipS;
            if (tipSale.Equals(global::Model.TipSale.Pregled.ToString()))
            {
                tipS = global::Model.TipSale.Pregled;
            }
            else
            {
                tipS = global::Model.TipSale.Operaciona;
            }
            return tipS;
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
