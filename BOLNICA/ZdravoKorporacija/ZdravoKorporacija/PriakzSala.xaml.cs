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
    /// Interaction logic for PriakzSala.xaml
    /// </summary>
    public partial class PriakzSala : Window
    {

        public static ObservableCollection<Sala> ListSala { get; set; }
        public PriakzSala()
        {
            InitializeComponent();
            DataContext = this;

            ListSala = RukovanjeSalama.observableSala;
    

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DodajSalu dodaj = new DodajSalu();
            dodaj.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
