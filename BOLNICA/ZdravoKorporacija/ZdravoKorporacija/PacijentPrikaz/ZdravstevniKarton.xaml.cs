using Kontroler;
using Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.PacijentPrikaz
{
    public partial class ZdravstevniKarton : UserControl
    {
        private ZdravstveniKartonViewModel zdravstevniKartonViewModel;
        public ZdravstevniKarton(String pacijent)
        {
            zdravstevniKartonViewModel = new ZdravstveniKartonViewModel(pacijent);
            InitializeComponent();
            this.DataContext = zdravstevniKartonViewModel;
           

        }
       /* private void IstorijaPregleda_Click(object sender, RoutedEventArgs e)
        {
            IstorijaPregleda istorija = new IstorijaPregleda();
            istorija.Show();
        }*/
    }
}
