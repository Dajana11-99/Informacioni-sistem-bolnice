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
    public partial class PacijentGlavniProzor : Window
    {
        private static Grid GlavniSadrzaj;
        public static Pacijent ulogovan = null;
        LekarRepozitorijum lekarRepozitorijum = new LekarRepozitorijum();
        TerminKontroler terminKontroler = new TerminKontroler();
        TerminRepozitorijum terminRepozitorijum = new TerminRepozitorijum();
        public PacijentGlavniProzor(String id)
        {
            InitializeComponent();
            GlavniSadrzaj = this.MainPanel;
            NaloziPacijenataRepozitorijum.UcitajPacijente();
            ulogovan = NaloziPacijenataKontroler.PretraziPoKorisnickom(id);
            imePacijenta.Content = ulogovan.Ime+" "+ulogovan.Prezime;
            Terapija terapija = new Terapija();
            foreach (Recept rec in ulogovan.karton.recepti)
            {
                if (rec.obavestiMe.Equals("DA"))
                {
                    Terapija.r = rec;
                    terapija.schedule_Timer();
                }

            }
            //MessageBox.Show(terminRepozitorijum.PretraziSlobodneTerminePoId("2").IdTermina);
            
        }

        public static Grid GetGlavniSadrzaj()
        {
            return GlavniSadrzaj;
        }
        private void karton_Click(object sender, RoutedEventArgs e)
        {

            MainPanel.Children.Clear();
            MainPanel.Children.Add(new ZdravstevniKarton());
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
            ProzorLogovanje log = new ProzorLogovanje();
            log.Show();
            this.Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //terminRepozitorijum.UpisiSlobodneTermine(terminRepozitorijum.inicijalizujSlobodneTermine());
            NaloziPacijenataRepozitorijum.UpisiPacijente();


        }
    }
    }

