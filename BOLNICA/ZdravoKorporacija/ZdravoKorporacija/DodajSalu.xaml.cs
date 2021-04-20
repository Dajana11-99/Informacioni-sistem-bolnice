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
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for DodajSalu.xaml
    /// </summary>
    public partial class DodajSalu : Window
    {
        public DodajSalu()
        {
            InitializeComponent();

        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            TipSale tipS;
            String id = txtId.Text;
            Sala postojecaSala = SalaServis.PretraziPoId(id);
            if (postojecaSala != null)
            {
                MessageBox.Show($"Postoji vec sala sa ID-em:{id}");
                return;
            }

            String tipSale = cmbTipSale.Text;
            if (tipSale.Equals(TipSale.Pregled.ToString()))
            {
                tipS = TipSale.Pregled;
            }
            else
            {
                tipS = TipSale.Operaciona;
            }

            String sprat = txtSprat.Text;
            

            Sala s = new Sala(tipS, id);
            s.sprat = sprat;

            SalaServis.DodajSalu(s);
            SalaRepozitorijum.UpisiSale();
            Close();


        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
