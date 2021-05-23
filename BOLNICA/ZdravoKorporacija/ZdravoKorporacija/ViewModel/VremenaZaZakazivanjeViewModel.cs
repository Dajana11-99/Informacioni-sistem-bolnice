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
    public class VremenaZaZakazivanjeViewModel : ViewModel
    {
        private ObservableCollection<TerminDTO> slobodniTermini;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private TerminDTO selektovaniTermin;
        private String poruka;
        private ZakazivanjeDTO podaciZaPrikaz;

        public VremenaZaZakazivanjeViewModel(TerminDTO izabraniTermin,ZakazivanjeDTO podaciZaPrikaz)
        {
            this.podaciZaPrikaz = podaciZaPrikaz;
            UcitajUKolekciju(izabraniTermin);
            vratiSeKomanda = new RelayCommand(VratiSe);
            potvrdiZakazivanjeKomanda = new RelayCommand(Potvrdi);

        }
        private void UcitajUKolekciju(TerminDTO izabraniTermin)
        {
            SlobodniTermini = new ObservableCollection<TerminDTO>();
            foreach(TerminDTO termin in terminKontroler.NadjiVremeZakazivanjeTermina(izabraniTermin))
            {
                SlobodniTermini.Add(termin);
            }
        }
        public ObservableCollection<TerminDTO> SlobodniTermini
        {
            get { return slobodniTermini; }
            set
            {
                slobodniTermini = value;
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
        public TerminDTO SelektovaniTermin
        {
            get { return selektovaniTermin; }
            set
            {
                selektovaniTermin = value;
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
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new DatumiKodIzabranogLekara(podaciZaPrikaz));
        }

        private RelayCommand potvrdiZakazivanjeKomanda;

        public RelayCommand PotvrdiZakazivanjeKomanda
        {
            get { return potvrdiZakazivanjeKomanda; }
        }

        private void Potvrdi()
        {
            if (SelektovaniTermin != null)
            {
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PotvrdiZakazivanje(SelektovaniTermin,podaciZaPrikaz));

            }
            else
            {
                Poruka = "*Morate izabrati vreme!";
            }
        }

    }
}
