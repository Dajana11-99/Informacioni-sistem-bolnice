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
   public class PotvrdiZakazivanjeViewModel:ViewModel
    {
        private TerminDTO izabraniTermin;
        private ZakazivanjeDTO podaciZaPrikaz;
        private TerminKontroler terminKontroler = new TerminKontroler();
        public PotvrdiZakazivanjeViewModel(TerminDTO izabraniTermin,ZakazivanjeDTO podaciZaPrikaz)
        {
            this.IzabraniTermin = izabraniTermin;
            this.podaciZaPrikaz = podaciZaPrikaz;
            vratiSeKomanda = new RelayCommand(VratiSe);
            potvrdiKomanda = new RelayCommand(Potvrdi);
        }
        public TerminDTO IzabraniTermin
        {
            get { return izabraniTermin; }
            set
            {
                izabraniTermin = value;
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
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new ZakazivanjeVremena(IzabraniTermin, podaciZaPrikaz));
        }

        private RelayCommand potvrdiKomanda;

        public RelayCommand PotvrdiKomanda
        {
            get { return potvrdiKomanda; }
        }
        private void Potvrdi()
        {
            terminKontroler.ZakaziPregled(IzabraniTermin,podaciZaPrikaz.KorisnickoImePacijenta);
           PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new RasporedTermina(podaciZaPrikaz.KorisnickoImePacijenta));
        }

    }
}
