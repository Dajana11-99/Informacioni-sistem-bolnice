
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
    /// Interaction logic for IzbrisiPacijenta.xaml
    /// </summary>
    public partial class IzbrisiPacijenta : Window
    {
        Pacijent sacuvaj;
        public IzbrisiPacijenta(Pacijent P)
        {
            InitializeComponent();
            sacuvaj = P;
        }

        private void BRISI(object sender, RoutedEventArgs e)
        {
            NaloziPacijenataServis.ObriseNalog(sacuvaj);
            this.Close();
        }

        private void NEBRISI(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
