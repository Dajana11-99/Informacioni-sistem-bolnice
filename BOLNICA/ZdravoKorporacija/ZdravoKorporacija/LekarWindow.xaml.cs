using Kontroler;
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
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija
{

    public partial class LekarWindow : Window
    {
        public static ObservableCollection<Termin> TerminiLekara { get; set; }
        LekarRepozitorijum lekarRepozitorijum = new LekarRepozitorijum();
        LekoviRepozitorijum lekoviRepozitorijum = new LekoviRepozitorijum();
        TerminKontroler terminKontroler = new TerminKontroler();
        public Lekar Ulogovan = null;
        public LekarKontroler lekarKontroler = new LekarKontroler();
        public LekarWindow(String korisnickoIme)
        {
            InitializeComponent();
            Ulogovan = lekarRepozitorijum.PretraziPoKorisnickomImenu(korisnickoIme);
            this.DataContext = this;
            TerminiLekara = new ObservableCollection<Termin>();
            PrikaziTermineUlogovanogLekara();
        }
        private void PrikaziTermineUlogovanogLekara()
        {
            foreach (Termin termin in terminKontroler.PrikaziSveZakazaneTermine())
            {
                if (termin.Lekar.CeloIme.Equals(Ulogovan.CeloIme))
                    TerminiLekara.Add(termin);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ZakazivanjeTerminaLekara zakaziTermin = new ZakazivanjeTerminaLekara();
            zakaziTermin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TerminiLekaraa.SelectedIndex != -1)
            {
                IzmenaTerminaLekara izmenaTermina = new IzmenaTerminaLekara(((Termin)TerminiLekaraa.SelectedItem));
                izmenaTermina.Show();
            }
            else
            {
                System.Windows.MessageBox.Show("Morate selektovati termin!", "Izmena termina lekara", MessageBoxButton.OK,
                    (MessageBoxImage)MessageBoxIcon.Warning);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (TerminiLekaraa.SelectedIndex != -1)
            {
                OtkazivanjeTerminaLekara otkaziTermin = new OtkazivanjeTerminaLekara(((Termin)TerminiLekaraa.SelectedItem).IdTermina);
                otkaziTermin.Show();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnZahtevUpravniku_Click(object sender, RoutedEventArgs e)
        {
            ZahtevZaSlobodneDaneWindow zahtevZaSlobodneDane = new ZahtevZaSlobodneDaneWindow();
            zahtevZaSlobodneDane.Show();
        }

        private void BtnPregledKartona_Click(object sender, RoutedEventArgs e)
        {
            if (TerminiLekaraa.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("Morate selektovati termin!", "Nedostatak informacija", MessageBoxButton.OK,
                    (MessageBoxImage)MessageBoxIcon.Warning);
                return;
            }
            Termin termin = (Termin)TerminiLekaraa.SelectedItem;
            ZdravstevniKartonPacijenta zdravstvniKarton = new ZdravstevniKartonPacijenta(termin.Pacijent.IdPacijenta);
            zdravstvniKarton.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NaloziPacijenataRepozitorijum.UpisiPacijente();
            LekoviRepozitorijum.upisiLekove();
        }

        private void BtnPregledLekova_Click(object sender, RoutedEventArgs e)
        {
            PregledLekovaWindow pregledLekovaProzor = new PregledLekovaWindow();
            pregledLekovaProzor.Show();
        }

        private void BtnOdjaviSe_Click(object sender, RoutedEventArgs e)
        {
            ProzorLogovanje prikazLogina = new ProzorLogovanje();
            prikazLogina.Show();
            this.Close();
        }
    }
}