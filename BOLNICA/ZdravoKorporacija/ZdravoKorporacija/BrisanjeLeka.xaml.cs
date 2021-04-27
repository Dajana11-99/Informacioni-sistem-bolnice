
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
    
    public partial class BrisanjeLeka : Window
    {
        string lekZaBrisanjeId;
        public BrisanjeLeka(string id)
        {
            InitializeComponent();
            lekZaBrisanjeId = id;
        }


        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            LekServis.BrisanjeLeka(lekZaBrisanjeId);
            this.Close();
        }
    }
}
