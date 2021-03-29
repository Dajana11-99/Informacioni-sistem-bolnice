using Model;
using PoslovnaLogika;
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

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for LekarWindow.xaml
    /// </summary>
    public partial class LekarWindow : Window
    {

        public static ObservableCollection<Termin> TerminiLekara { get; set; }

        public LekarWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            TerminiLekara = new ObservableCollection<Termin>();
            foreach (Termin t in RukovanjeTerminima.PrikaziSveTermine())
                TerminiLekara.Add(t);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ZakazivanjeTerminaLekara zakazi = new ZakazivanjeTerminaLekara();
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

        }
    }
}
