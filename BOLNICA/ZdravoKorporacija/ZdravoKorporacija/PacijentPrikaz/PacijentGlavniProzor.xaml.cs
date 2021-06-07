using Kontroler;
using Model;
using Servis;
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
using System.Windows.Shapes;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.PacijentPrikaz
{
    public partial class PacijentGlavniProzor : Window
    {
        private static Grid GlavniSadrzaj;
     
        LekarRepozitorijum lekarRepozitorijum = new LekarRepozitorijum();
        TerminKontroler terminKontroler = new TerminKontroler();
        ZakazaniTerminiRepozitorijum terminRepozitorijum = new ZakazaniTerminiRepozitorijum();
        private PacijentDTO ulogovaniPacijent;
        public PacijentGlavniProzor(String pacijent)
        {
           
            InitializeComponent();
            ulogovaniPacijent = new PacijentDTO(pacijent);
            GlavniSadrzaj = this.MainPanel;
            NaloziPacijenataRepozitorijum.UcitajPacijente();
            imePacijenta.Content = ulogovaniPacijent.KorisnickoIme;
            MainPanel.Children.Clear();
            MainPanel.Children.Add(new PocetnaStrana());

        }

        public static Grid GetGlavniSadrzaj()
        {
            return GlavniSadrzaj;
        }
        private void karton_Click(object sender, RoutedEventArgs e)
        {
           
            MainPanel.Children.Clear();
            MainPanel.Children.Add(new ZdravstevniKarton(ulogovaniPacijent.KorisnickoIme));
        }

        private void Pocetna_Click(object sender, RoutedEventArgs e)
        {
            MainPanel.Children.Clear();
            MainPanel.Children.Add(new PocetnaStrana());
        }

        private void LicniPodaci_Click(object sender, RoutedEventArgs e)
        {

        }

        private void zakazi_Click(object sender, RoutedEventArgs e)
        {
            MainPanel.Children.Clear();
            MainPanel.Children.Add(new ZakazivanjeSaPrioritetom(ulogovaniPacijent.KorisnickoIme));
        }

        private void raspored_Click(object sender, RoutedEventArgs e)
        {
         
            MainPanel.Children.Clear();
            MainPanel.Children.Add(new RasporedTermina(ulogovaniPacijent.KorisnickoIme));
        }

        private void terapija_Click(object sender, RoutedEventArgs e)
        {
           
            MainPanel.Children.Clear();
            MainPanel.Children.Add(new Terapija(ulogovaniPacijent.KorisnickoIme));
        }
        private void ankete_Click(object sender, RoutedEventArgs e)
        {
         
            MainPanel.Children.Clear();
            MainPanel.Children.Add(new PrikazAnketa());

        }

        private void obavestenja_Click(object sender, RoutedEventArgs e)
        {
            PrikazObavestenja ob = new PrikazObavestenja(ulogovaniPacijent.KorisnickoIme);
            ob.Show();

        }

        private void pomoc_Click(object sender, RoutedEventArgs e)
        {

            MainPanel.Children.Clear();
            MainPanel.Children.Add(new PocetnaPomoc());
        }

        private void odjava_Click(object sender, RoutedEventArgs e)
        {
            NaloziPacijenataRepozitorijum.UpisiPacijente();
            ProzorLogovanje log = new ProzorLogovanje();
            log.Show();
            this.Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //terminRepozitorijum.UpisiSlobodneTermine(terminRepozitorijum.inicijalizujSlobodneTermine());
            NaloziPacijenataRepozitorijum.UpisiPacijente();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPanel.Children.Clear();
            MainPanel.Children.Add(new Kalendar(ulogovaniPacijent.KorisnickoIme));
        }

        private void OceniAplikaciju_Click(object sender, RoutedEventArgs e)
        {
            MainPanel.Children.Clear();
            MainPanel.Children.Add(new OceniAplikaciju(ulogovaniPacijent.KorisnickoIme));
        }
    }
    }

