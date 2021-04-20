using Model;

using Servis;
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
    public partial class PrikazDinamickeOpreme : Window
    {

        public static ObservableCollection<DinamickaOprema> ListDinamickaOprema { get; set; }
        public PrikazDinamickeOpreme()
        {
            InitializeComponent();
            DataContext = this;

            ListDinamickaOprema = RukovanjeDinamickomOpremomServis.observableDinamickaOprema;


        }

        private void Button_dodaj(object sender, RoutedEventArgs e)
        {
            DodajDinamickuOpremu dodaj = new DodajDinamickuOpremu();
            dodaj.Show();
        }

        private void Button_vrati_se(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_obrisi(object sender, RoutedEventArgs e)
        {
            if (SpisakDinamickeOpreme.SelectedIndex != -1)
            {
                BrisanjeDinamickeOpreme brisaje = new BrisanjeDinamickeOpreme(((DinamickaOprema)SpisakDinamickeOpreme.SelectedItem).Id);
                brisaje.Show();
            }
        }

        private void Button_izmeni(object sender, RoutedEventArgs e)
        {
            if (SpisakDinamickeOpreme.SelectedIndex != -1)
            {
                IzmeniDinamickuOpremu izmena = new IzmeniDinamickuOpremu(((DinamickaOprema)SpisakDinamickeOpreme.SelectedItem));
                izmena.Show();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
