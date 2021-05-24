using Kontroler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Komande;
using ZdravoKorporacija.PacijentPrikaz;

namespace ZdravoKorporacija.ViewModel
{
   
    public class PrikazDatumaViewModel:ViewModel
    {
        private ObservableCollection<TerminDTO> slobodniDatumi;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private TerminDTO terminZaPomeranje;
        private TerminDTO selektovaniTermin;
        private String poruka;
       
        public ObservableCollection<TerminDTO> SlobodniDatumi
        {
            get { return slobodniDatumi; }
            set
            {
                slobodniDatumi = value;
                OnPropertyChanged();
            }
        }

        public TerminDTO SelektovaniTermin
        {
            get { return selektovaniTermin; }
            set
            {
                selektovaniTermin = value;
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
        public PrikazDatumaViewModel(TerminDTO terminZaPomeranje)
        {
            this.terminZaPomeranje = terminZaPomeranje;
      
            UcitajUKolekciju();
            vratiSeKomanda = new RelayCommand(VratiSe);
            prikaziDatumeKomanda = new RelayCommand(PrikaziDatume);
            vratiSeNaDatume = new RelayCommand(VratiSeNazad);
            prikaziTermineKomanda = new RelayCommand(PrikaziTermine);
        }

        public TerminDTO TerminZaPomeranje
        {
            get { return terminZaPomeranje; }
        }
        private void UcitajUKolekciju()
        {
            
            SlobodniDatumi = new ObservableCollection<TerminDTO>();
            foreach (TerminDTO termin in terminKontroler.DobaviSveSlobodneDatumeZaPomeranje(terminZaPomeranje))
            { 
                this.SlobodniDatumi.Add(termin);
            }
            if (SlobodniDatumi.Count == 0)
            {
                Poruka = "*Nema slobodnih datuma za pomeranje! Vrati se nazad.";
            }
            
        }

        private RelayCommand prikaziDatumeKomanda;

        public RelayCommand PrikaziDatumeKomanda
        {
            get { return prikaziDatumeKomanda; }
        }

        private RelayCommand vratiSeKomanda;

        public RelayCommand VratiSeKomanda
        {
            get { return vratiSeKomanda; }
        }

        private RelayCommand prikaziTermineKomanda;
        public RelayCommand PrikaziTermineKomanda
        {
            get { return prikaziTermineKomanda; }
        }

        private RelayCommand vratiSeNaDatume;

        public RelayCommand VratiSeNaDatumeKomanda
        {
            get { return vratiSeNaDatume; }
        }

        public void PrikaziTermine()
        {
            if (SelektovaniTermin != null)
            {
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazVremenaZaPomeranje(terminZaPomeranje, SelektovaniTermin));
            }else
            {
                Poruka = "*Morate izabrati datum!";
            }
        }

       public void VratiSeNazad()
        {
      
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IzmenaTermina(TerminZaPomeranje));
        }
        public void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new RasporedTermina(TerminZaPomeranje.IdPacijenta));
        }

        public void PrikaziDatume()
        {

            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazDatumaZaPomeranjeKodLekara(terminZaPomeranje));
        }


    }
}
