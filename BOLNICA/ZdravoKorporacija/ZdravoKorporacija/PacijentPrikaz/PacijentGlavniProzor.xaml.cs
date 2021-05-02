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
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for PacijentGlavniProzor.xaml
    /// </summary>
    public partial class PacijentGlavniProzor : Window
    {
        public static Pacijent ulogovan = null;
        public PacijentGlavniProzor(String id)
        {
            InitializeComponent();
            ObavestenjaRepozitorijum.Ucitaj();
            ulogovan = NaloziPacijenataKontroler.pretraziPoKorisnickom(id);
            imePacijenta.Content = ulogovan.korisnik.KorisnickoIme;
            foreach(Recept rec in ulogovan.karton.recepti)
            {
                if (rec.obavestiMe.Equals("DA"))
                {
                    Terapija.r = rec;
                    Terapija.schedule_Timer();
                }
            }
            
        }

        private void karton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pocetna_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LicniPodaci_Click(object sender, RoutedEventArgs e)
        {

        }

        private void zakazi_Click(object sender, RoutedEventArgs e)
        {

            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new ZakazivanjeSaPrioritetom();
            MainPanel.Children.Add(usc);
        }

        private void raspored_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new RasporedTermina();
            MainPanel.Children.Add(usc);
        }

        private void terapija_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new Terapija();
            MainPanel.Children.Add(usc);

        }

        private void ankete_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            MainPanel.Children.Clear();

            usc = new PrikazAnketa();
            MainPanel.Children.Add(usc);

        }

        private void obavestenja_Click(object sender, RoutedEventArgs e)
        {
            PrikazObavestenja ob = new PrikazObavestenja();
            ob.Show();

        }

        private void pomoc_Click(object sender, RoutedEventArgs e)
        {

        }

        private void odjava_Click(object sender, RoutedEventArgs e)
        {
            NaloziPacijenataRepozitorijum.UpisiPacijente();
            LekarRepozitorijum.upisiLekare();
            TerminRepozitorijum.UpisiSlobodneTermine();
            TerminRepozitorijum.UpisiZakazaneTermine();
            ObavestenjaRepozitorijum.Sacuvaj();
            ProzorLogovanje log = new ProzorLogovanje();
            log.Show();
            this.Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LekarRepozitorijum.upisiLekare();
            TerminRepozitorijum.UpisiSlobodneTermine();
            TerminRepozitorijum.UpisiZakazaneTermine();
            ObavestenjaRepozitorijum.Sacuvaj();
            NaloziPacijenataRepozitorijum.UpisiPacijente();


        }
    }
    }

