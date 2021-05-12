using Model;
using PoslovnaLogika;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZdravoKorporacija.PacijentPrikaz;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for ProzorLogovanje.xaml
    /// </summary>
    public partial class ProzorLogovanje : Window
    {
        List<Sekretara> Sekretari = new List<Sekretara>();
        List<Upravnik> Upravnici = new List<Upravnik>();
        List<Lekar> Lekari = new List<Lekar>();
        List<Pacijent> Pacijenti = new List<Pacijent>();
        List<Lek> Lekovi = new List<Lek>();
        LekarRepozitorijum lekarRepozitorijum = new LekarRepozitorijum();
        public ProzorLogovanje()
        {
            InitializeComponent();
            Sekretari.Add(new Sekretara("S1", "Filip", "Nikolic", "1234567891012", "filip.nikolic@gmail.com", new AdresaStanovanja("Adresa", "1"), new Korisnik("filip.nikolic", "filip.nikolic")));
            Upravnici.Add(new Upravnik("U1", "Mirjana", "Jovanov", "1234567891082", "mirjana.jovanov@gmail.com", new AdresaStanovanja("Adresa", "2"), new Korisnik("mirjana.jovanov", "mirjana.jovanov")));
            Lekari.Add(new Lekar("L1", false, Specijalizacija.Ostapraksa, "Stefan", "Markovic", "1234567899082", "stefan.markovic@gmail.com", new AdresaStanovanja("Adresa", "3"), new Korisnik("stefan.markovic", "stefan.markovic")));
            Lekari.Add(new Lekar("L5", false, Specijalizacija.Kardiolog, "Milan", "Djenic", "1234567899082", "milan.djenic@gmail.com", new AdresaStanovanja("Narodjih Heroja ", "32"), new Korisnik("milan.markovic", "milan.markovic")));
            //Lekari.Add(new Lekar("L1", false, Specijalizacija.Ostapraksa, "Pera", "Peric", "2711999105018", "dajanazlokapa@gmail.com", new AdresaStanovanja("Ljubice Ravasi", "2A"), new Korisnik("pera.peric", "pera.peric")));
          //  Pacijenti.Add(new Pacijent("P1", "Dajana", "Zlokapa", "2711999105018", "dajana.zlokapa@gmail.com", new AdresaStanovanja("Adresa", "4"), new Korisnik("dajana.zlokapa", "dajana.zlokapa")));

            Lozinka.PasswordChar = '*';
            Lozinka.MaxLength = 15;

            SalaRepozitorijum.UcitajSale();
           //lekarRepozitorijum.ucitajLekare();
            //Dajana
            TerminRepozitorijum.UcitajZakazaneTermine();
           
           //TerminServis.inicijalizuj(); //Inicijalizacija lekara
          //TerminServis.inicijalizujSlobodneTermine();
          TerminRepozitorijum.UcitajSlobodneTermine();
            AnketaServis.inicijalizujPitanja();
            AnketaServis.inicijalizujPitanjaOBolnici();
            lekarRepozitorijum.Inicijalizuj();



            //////----------------------
            //LekServis.inicijalizujLekove();
            LekoviRepozitorijum.ucitajLekove();
            ZalbaRepozitorijum.ucitajZalbe();



            //SalaServis.inicijalizuj();


            SalaServis.inicijalizuj();
            LekServis.inicijalizuj();
            RukovanjeStatickomOpremomServis.inicijalizuj();
            RukovanjeDinamickomOpremomServis.inicijalizuj();
            RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.Inicijalizuj();
            RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis.Inicijalizuj();

             
            //RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.IzvrsiZahteveZaDanas();
            //RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis.IzvrsiZahteveZaDanas();

           //NaloziPacijenataServis.inic();

            NaloziPacijenataRepozitorijum.UcitajPacijente();

           // ObavestenjaRepozitorijum.Ucitaj();
           AnketeRepozitorijum.UcitajAnkete();




            
        }

        private void potvrdi_Click(object sender, RoutedEventArgs e)
        {

            bool nasao = false;
            if (korisnickoIme.Text.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti korisničko ime!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Lozinka.Password.Equals(""))
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti lozinku!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Lozinka.Password.Length < 8)
            {
                System.Windows.Forms.MessageBox.Show("Uneta lozinka mora biti dugačka bar 8 karaktera!", "Proverite podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (Upravnik u in Upravnici)
            {
                if (u.korisnik.KorisnickoIme.Equals(korisnickoIme.Text))
                {
                    if (u.korisnik.Sifra.Equals(Lozinka.Password))
                    {
                        UpravnikPocetna up = new UpravnikPocetna();
                        up.Show();
                        this.Close();
                        nasao = true;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Neipravno korisničko ime ili lozinka!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            foreach (Sekretara u in Sekretari)
            {
                if (u.korisnik.KorisnickoIme.Equals(korisnickoIme.Text))
                {
                    if (u.korisnik.Sifra.Equals(Lozinka.Password))
                    {
                        PrikazPacijenata pp = new PrikazPacijenata();
                        pp.Show();
                        this.Close();
                        nasao = true;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Neipravno korisničko ime ili lozinka!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            foreach (Lekar u in Lekari)
            {
                if (u.korisnik.KorisnickoIme.Equals(korisnickoIme.Text))
                {
                    if (u.korisnik.Sifra.Equals(Lozinka.Password))
                    {
                        LekarWindow lw = new LekarWindow(korisnickoIme.Text);
                        lw.Show();
                        this.Close();
                        nasao = true;
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Neipravno korisničko ime ili lozinka!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            foreach (Pacijent u in NaloziPacijenataServis.ListaPacijenata)
            {
                if (u.korisnik.KorisnickoIme.Equals(korisnickoIme.Text))
                {
                    if (u.korisnik.Sifra.Equals(Lozinka.Password))
                    {
                        if (u.Maliciozan == false)
                        {
                            PacijentGlavniProzor pg = new PacijentGlavniProzor(korisnickoIme.Text);
                            pg.Show();
                            this.Close();
                            nasao = true;
                        }else
                        {
                            System.Windows.Forms.MessageBox.Show("VAS NALOG JE BLOKIRAN OBRATITE SE SEKRETARU!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Neipravno korisničko ime ili lozinka!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (!nasao)
            {
                System.Windows.Forms.MessageBox.Show("Ne postoji korisnik!", "Proverite unete podatke", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            SalaRepozitorijum.UpisiSale();
            TerminRepozitorijum.UpisiZakazaneTermine();
            lekarRepozitorijum.upisiLekare();
            NaloziPacijenataRepozitorijum.UpisiPacijente();
            TerminRepozitorijum.UpisiSlobodneTermine();
            LekRepozitorijum.UpisiLekove();
            LekoviRepozitorijum.upisiLekove();  
        }
    }
}
