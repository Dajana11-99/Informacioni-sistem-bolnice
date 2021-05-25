using Kontroler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Komande;
using ZdravoKorporacija.PacijentPrikaz;

namespace ZdravoKorporacija.ViewModel
{
    public class PotvrdiPomeranjeViewModel
    {
        private TerminDTO stariTermin=new TerminDTO();
        private TerminDTO noviTermin;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private String idPacijenta;
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();

        public PotvrdiPomeranjeViewModel(TerminDTO stariTermin, TerminDTO noviTermin)
        {
            this.idPacijenta = stariTermin.IdPacijenta;
            this.stariTermin = stariTermin;
            this.noviTermin = noviTermin;
            pomeriTerminKomanda = new RelayCommand(PomeriPregled);
            vratiSe = new RelayCommand(VratiSeNazad);
        }

        private RelayCommand pomeriTerminKomanda;

        public RelayCommand PomeriTerminKomanda
        {
            get { return pomeriTerminKomanda; }
        }

        private RelayCommand vratiSe;

        public RelayCommand VratiSe
        {
            get { return vratiSe; }
        }
        public void VratiSeNazad()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazVremenaZaPomeranje(stariTermin,noviTermin));
        }

        public TerminDTO NoviTermin
        {
            get { return noviTermin; }
        }

        public TerminDTO StariTermin
        {
            get { return stariTermin; }
             set{ stariTermin = value; }
        }

        public void PomeriPregled()
        {
            
            String korisnickoImePacijenta =naloziPacijenataKontroler.PretragaPoId(idPacijenta).korisnik.KorisnickoIme;
            terminKontroler.PomeriPregled(stariTermin, noviTermin);
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new RasporedTermina(korisnickoImePacijenta));
        }

    }
}
