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
    public partial class PriakzSala : Window
    {

        public static ObservableCollection<Sala> ListSala { get; set; }
        public PriakzSala()
        {
            InitializeComponent();
            DataContext = this;

            ListSala = SalaServis.observableSala;
    

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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (SpisakSala.SelectedIndex != -1)
            {
                BrisanjeSale brisaje = new BrisanjeSale(((Sala)SpisakSala.SelectedItem).Id);
                brisaje.Show();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (SpisakSala.SelectedIndex != -1)
            {
                IzmeniSalu izmena = new IzmeniSalu(((Sala)SpisakSala.SelectedItem));
                izmena.Show();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            OdusustvaUpravnik odsustvoUpravnik = new OdusustvaUpravnik();
            odsustvoUpravnik.Show();
        }
        
        private void btnPregledStatickeOpreme_Click(object sender, RoutedEventArgs e)
        {
            if (SpisakSala.SelectedIndex != -1)
            {
                Sala salaCijaSeOpremaPrikazuje = (Sala)SpisakSala.SelectedItem;
                // staticvke
                List<RasporedjenaStatickaOprema> oprema = salaCijaSeOpremaPrikazuje.RasporedjenaStatickaOprema;
                ObservableCollection<RasporedjenaStatickaOprema> opremaKol = 
                        new ObservableCollection<RasporedjenaStatickaOprema>(oprema);
                PrikazStatickeOpreme prikz = new PrikazStatickeOpreme(opremaKol);
                prikz.Show();
            }
           
        }

        private void btnPregledDinamickeOpreme_Click(object sender, RoutedEventArgs e)
        {
            if (SpisakSala.SelectedIndex != -1)
            {
                Sala salaCijaSeOpremaPrikazuje = (Sala)SpisakSala.SelectedItem;
                // staticvke
                List<RasporedjenaDinamickaOprema> oprema = salaCijaSeOpremaPrikazuje.RasporedjenaDinamickaOprema;
                ObservableCollection<RasporedjenaDinamickaOprema> opremaKol =
                  new ObservableCollection<RasporedjenaDinamickaOprema>(oprema);
                PrikazDinamickeOpreme prikz = new PrikazDinamickeOpreme(opremaKol);
                prikz.Show();
            }
        }
    }
}
