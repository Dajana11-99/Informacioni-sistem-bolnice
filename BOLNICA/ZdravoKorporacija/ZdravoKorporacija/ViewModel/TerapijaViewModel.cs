using Kontroler;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Data;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Komande;
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.ViewModel
{
   public  class TerapijaViewModel:ViewModel
    {
        private ObservableCollection<ReceptDTO> receptiPacijenta;
        private String poruka;
        private Timer timer;
        private String idPacijenta;
        private ObavestenjaKontroler obavestenjeKontroler = new ObavestenjaKontroler();
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();

        public ObservableCollection<ReceptDTO> ReceptiPacijenta
        {
            get { return receptiPacijenta; }
            set
            {
                receptiPacijenta = value;
                OnPropertyChanged();
            }
        }

        private ReceptDTO selektovaniLek;

        public ReceptDTO SelektovaniLek
        {
            get { return selektovaniLek; }
            set
            {
                selektovaniLek = value;
                OnPropertyChanged();
            }
        }
        public String Poruka
        {
            get { return poruka; }
            set
            {
                poruka = value;
                OnPropertyChanged();
            }
        }
        public TerapijaViewModel(String korisnickoIme)
        {
            idPacijenta = naloziPacijenataKontroler.PretraziPoKorisnickom(korisnickoIme).IdPacijenta;
            UcitajUKolekciju(idPacijenta);
            ukljuciObavestenjakomanda = new RelayCommand(Ukljuci);
            iskljuciObavestenjakomanda = new RelayCommand(Iskljuci);
        }

        private void UcitajUKolekciju(String idPacijenta)
        {
            ReceptiPacijenta = new ObservableCollection<ReceptDTO>();
            foreach(Recept recept in naloziPacijenataKontroler.PretragaPoId(idPacijenta).karton.recepti)
            {
                ReceptiPacijenta.Add(new ReceptDTO(recept.Lek1.ImeLeka,recept.Lek1.IdLeka,recept.KolicinaTerapije,recept.PocetakTerapije,recept.KrajTerapije,recept.PeroidUzimanjaUSatima,recept.obavestiMe,recept.idPacijenta));
            }
        }

        private RelayCommand ukljuciObavestenjakomanda;

        public RelayCommand UkljuciObavestenjaKomanda
        {
            get { return ukljuciObavestenjakomanda; }
        }


        private void Ukljuci()
        {
          
            schedule_Timer();
            if (SelektovaniLek.ObavestiMe.Equals("DA"))
            {
                Poruka = "*Vec primate obavestenja o ovoj terapiji!";
            }
            SelektovaniLek.ObavestiMe = "DA";
            naloziPacijenataKontroler.IzmeniPacijenta(SelektovaniLek);
            CollectionViewSource.GetDefaultView(ReceptiPacijenta).Refresh();
            Poruka ="*Uspešno ste uključili obaveštenja o terapiji!";
        }
       
        private void schedule_Timer()
        {
              double tickTime = (double)(DateTime.Now.AddSeconds(SelektovaniLek.PeriodUzimanjaTerapije) - DateTime.Now).TotalMilliseconds;
            timer = new Timer(tickTime);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();

        }
        private  String Sadrzaj()
        {
            return  "Lek: " + selektovaniLek.NazivLeka  + ".\nIsteklo je " + selektovaniLek.PeriodUzimanjaTerapije + "h od poslednje doze." +
            "\nKoličina u sledećoj dozi: " + selektovaniLek.KolicinaTerapije + ".";
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ObavestenjeDTO obavestenje = new ObavestenjeDTO(Guid.NewGuid().ToString(), "Terapija", Sadrzaj(), DateTime.Now,idPacijenta);
            obavestenjeKontroler.DodajObavestenjePacijentu(obavestenje);
            timer.Stop();
            schedule_Timer();
        }


        private RelayCommand iskljuciObavestenjakomanda;

        public RelayCommand IskljuciObavestenjaKomanda
        {
            get { return iskljuciObavestenjakomanda; }
        }
        private void Iskljuci()
        {
          
            if (SelektovaniLek.ObavestiMe.Equals("NE"))
            {
                Poruka = "*Vec ste iskljucili obavestenja o ovoj terapiji";
            }
            SelektovaniLek.ObavestiMe = "NE";
            naloziPacijenataKontroler.IzmeniPacijenta(SelektovaniLek);
            CollectionViewSource.GetDefaultView(ReceptiPacijenta).Refresh();
            timer.Stop();
            Poruka = "*Uspešno ste isključili obaveštenja o terapiji!";
        }


    }
}
