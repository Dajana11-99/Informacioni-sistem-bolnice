using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Model;
using PoslovnaLogika;

namespace ZdravoKorporacija
{
  
    public partial class PrikazTerminaPacijenta : Window
    {
        public static ObservableCollection <Termin> TerminiPacijenta { get; set; }
        public PrikazTerminaPacijenta()
        {

            InitializeComponent();
            this.DataContext = this;
            TerminiPacijenta = new ObservableCollection<Termin>();
            foreach (Termin t in RukovanjeTerminima.PrikaziSveTermine())
                TerminiPacijenta.Add(t);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ZakaziPregledPacijent zakazi = new ZakaziPregledPacijent();
            zakazi.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
