using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Komande;
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.PacijentPrikaz;

namespace ZdravoKorporacija.ViewModel
{
    public class PodsetnikViewModel:ViewModel
    {
        private ObavestenjeDTO obavestenje;
        private TerminDTO izabraniTermin;
        private Timer timer;
        private ObavestenjaKontroler obavestenjaKontroler = new ObavestenjaKontroler();
        
        public PodsetnikViewModel(TerminDTO izabraniTermin)
        {
            Obavestenje = new ObavestenjeDTO();
            this.izabraniTermin = izabraniTermin;
            vratiSeKomanda = new RelayCommand(VratiSe);
            sacuvajObavestenjeKomanda = new RelayCommand(Sacuvaj);
        }
        public ObavestenjeDTO Obavestenje
        {
            get { return obavestenje; }
            set
            {
                obavestenje = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand vratiSeKomanda;

        public RelayCommand VratiSeKomanda
        {
            get { return vratiSeKomanda; }
        }
        private void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazBeleske(izabraniTermin));
        }

        private RelayCommand sacuvajObavestenjeKomanda;

        public RelayCommand SacuvajObavestenjeKomanda
        {
            get { return sacuvajObavestenjeKomanda; }
        }

        private void Sacuvaj()
        {
            schedule_Timer();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazBeleske(izabraniTermin));

        }

        private void schedule_Timer()
        {
            double tickTime = (double)(DateTime.Now.AddSeconds(Obavestenje.NaKolikoSati) - DateTime.Now).TotalMilliseconds;
            timer = new Timer(tickTime);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();

        }
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ObavestenjeDTO obavestenje = new ObavestenjeDTO(Guid.NewGuid().ToString(), Obavestenje.Naslov,Obavestenje.Tekst, DateTime.Now,izabraniTermin.IdPacijenta);
            obavestenjaKontroler.DodajObavestenjePacijentu(obavestenje);
            timer.Stop();
            schedule_Timer();
        }

    }
}
