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
    /// Interaction logic for RenovirajSalu.xaml
    /// </summary>
    public partial class RenovirajSalu : Window
    {
        Sala salaZaIzmenu;
        public RenovirajSalu(Sala sala)
        {
            InitializeComponent();
            salaZaIzmenu = sala;
            lblNaslov.Content = $"Renoviranje {sala.TipSale} id {sala.Id}";
        }
        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            Renoviranje renoviranje = new Renoviranje();
            // 
            DateTime? RenoviranjeOd = datePickerPocetakRenoviranja.SelectedDate;
            if (!RenoviranjeOd.HasValue)
            {
                MessageBox.Show("Datum od nije unet");
                return;
            }

            DateTime? RenoviranjeDo = datePickerKrajRenoviranja.SelectedDate;
            if (!RenoviranjeDo.HasValue)
            {
                MessageBox.Show("Datum do nije unet");
                return;
            }
            if(salaZaIzmenu.Renoviranja == null)
            {
                salaZaIzmenu.Renoviranja = new List<Renoviranje>();
            }

            renoviranje.RenoviranjeOd = RenoviranjeOd.Value;
            renoviranje.RenoviranjeDo = RenoviranjeDo.Value;
            salaZaIzmenu.Renoviranja.Add(renoviranje);
            SalaServis.Izmena(salaZaIzmenu);
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
