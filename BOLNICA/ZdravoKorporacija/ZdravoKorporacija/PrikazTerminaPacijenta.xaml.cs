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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Model;
using Servis;
using ZdravoKorporacija.Repozitorijum;

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
            foreach (Termin t in TerminServis.PrikaziSveTermine())
                TerminiPacijenta.Add(t);
           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ZakaziPregledPacijent zakazi = new ZakaziPregledPacijent();
            zakazi.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TerminiPacijentaa.SelectedIndex != -1)
            {
                IzmenaPacijenta izmena = new IzmenaPacijenta(((Termin)TerminiPacijentaa.SelectedItem));
                izmena.Show();
            }
            else
                System.Windows.MessageBox.Show("Izaberite termin pregleda za izmenu!", "Upozorenje", MessageBoxButton.OK);
            return;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (TerminiPacijentaa.SelectedIndex != -1)
            {

                Otkazivanje otkazivanje = new Otkazivanje(((Termin)TerminiPacijentaa.SelectedItem).IdTermina);
                otkazivanje.Show();
                
            }
            else
            {
                System.Windows.MessageBox.Show( "Izaberite termin za otkazivanje!","Otkazivanje termina");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TerminRepozitorijum.upisiTermine();
            LekarRepozitorijum.upisiLekare();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TerminRepozitorijum.upisiTermine();
            LekarRepozitorijum.upisiLekare();
        }
    }
}
