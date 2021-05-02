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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZdravoKorporacija.Repozitorijum;

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
            foreach (Termin t in TerminServis.PrikaziSveZakazaneTermine())
                TerminiLekara.Add(t);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ZakazivanjeTerminaLekara zakazi = new ZakazivanjeTerminaLekara();
            zakazi.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TerminiLekaraa.SelectedIndex != -1)
            {


                IzmenaTerminaLekara izmena = new IzmenaTerminaLekara(((Termin)TerminiLekaraa.SelectedItem));
                izmena.Show();
            }
            else 
            {
                System.Windows.MessageBox.Show("Morate selektovati termin!","Izmena termina lekara", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (TerminiLekaraa.SelectedIndex != -1) 
            {
                OtkazivanjeTerminaLekara otkazii = new OtkazivanjeTerminaLekara(((Termin)TerminiLekaraa.SelectedItem).IdTermina);
                otkazii.Show();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnZahtevUpravniku_Click(object sender, RoutedEventArgs e)
        {
            ZahtevZaSlobodneDaneWindow zahtev = new ZahtevZaSlobodneDaneWindow();
            
            zahtev.Show();
        }

        private void btnPregledKartona_Click(object sender, RoutedEventArgs e)
        {
            if (TerminiLekaraa.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("Morate selektovati termin!", "Nedostatak informacija", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                return;
            }
            Termin t = (Termin)TerminiLekaraa.SelectedItem;
            ZdravstevniKartonPacijenta zkp = new ZdravstevniKartonPacijenta(t.Pacijent.IdPacijenta);
            zkp.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NaloziPacijenataRepozitorijum.UpisiPacijente();
            TerminRepozitorijum.UpisiZakazaneTermine();
        }
    }
}
