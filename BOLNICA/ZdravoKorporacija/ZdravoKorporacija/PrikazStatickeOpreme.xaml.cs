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
    public partial class PrikazStatickeOpreme : Window
    {

        public static ObservableCollection<StatickaOprema> ListStatickaOprema { get; set; }
        public bool CRUDStatickeOpreme { get; set; }

        public PrikazStatickeOpreme(ObservableCollection<RasporedjenaStatickaOprema> rasporedjenaOprema = null)
        {
            InitializeComponent();
            DataContext = this;
            if (rasporedjenaOprema == null)
            {
                CRUDStatickeOpreme = true;
                ListStatickaOprema = RukovanjeStatickomOpremom.observableStatickaOprema;

            } else
            {
                CRUDStatickeOpreme = false;
                ObservableCollection<StatickaOprema> opremaIzSale = new ObservableCollection<StatickaOprema>();
                foreach(var oprema in rasporedjenaOprema)
                {
                    StatickaOprema staticka = new StatickaOprema(oprema.statickaOprema.Id);
                    staticka.kolicina = oprema.Kolicina;
                    staticka.naziv = oprema.statickaOprema.naziv;
                    opremaIzSale.Add(staticka);
                }
                ListStatickaOprema = opremaIzSale;

            }


        }

        private void Button_dodaj(object sender, RoutedEventArgs e)
        {
            DodajStatickuOpremu dodaj = new DodajStatickuOpremu();
            dodaj.Show();
        }

        private void Button_vrati_se(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_obrisi(object sender, RoutedEventArgs e)
        {
            if (SpisakStatickeOpreme.SelectedIndex != -1)
            {
                BrisanjeStatickeOpreme brisaje = new BrisanjeStatickeOpreme(((StatickaOprema)SpisakStatickeOpreme.SelectedItem).Id);
                brisaje.Show();
            }
        }

        private void Button_izmeni(object sender, RoutedEventArgs e)
        {
            if (SpisakStatickeOpreme.SelectedIndex != -1)
            {
                IzmeniStatickuOpremu izmena = new IzmeniStatickuOpremu(((StatickaOprema)SpisakStatickeOpreme.SelectedItem));
                izmena.Show();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
