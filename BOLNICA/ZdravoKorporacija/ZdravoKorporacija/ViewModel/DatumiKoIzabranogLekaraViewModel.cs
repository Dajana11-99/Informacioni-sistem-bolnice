using Kontroler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Komande;
using ZdravoKorporacija.PacijentPrikaz;

namespace ZdravoKorporacija.ViewModel
{
   public class DatumiKoIzabranogLekaraViewModel:ViewModel
    {
        private ObservableCollection<TerminDTO> slobodniKodIzabranog;
        private TerminDTO selektovaniTermin;
        private String poruka;
    
        private TerminKontroler terminKontroler = new TerminKontroler();
        private ZakazivanjeDTO podaciZaSlanje;
        private List<DateTime> datumiUIntervalu=new List<DateTime>();


        public DatumiKoIzabranogLekaraViewModel(ZakazivanjeDTO podaci)
        {
            podaciZaSlanje = podaci;
            datumiUIntervalu.Add(podaci.DatumOd);
            datumiUIntervalu.Add(podaci.DatumDo);
            ProveriPrioritet();
            vratiSeKomanda = new RelayCommand(VratiSe);
            prikaziTermineKomanda = new RelayCommand(PrikaziTermine);

        }

        private void ProveriPrioritet()
        {
            List<TerminDTO> datumiZaZakazivanje = terminKontroler.DobaviSlobodneTermineZaZakazivanje(datumiUIntervalu, podaciZaSlanje.IzabraniLekar.CeloIme);
                if (datumiZaZakazivanje.Count != 0)
                {
          
                UcitajUKolekciju(datumiZaZakazivanje);

                }else
                {
                    if (podaciZaSlanje.Prioritet == 1)
                    {
                   
                    datumiZaZakazivanje = UcitajDatumePrioritetLekar();
                    }else
                    {
                  
                    datumiZaZakazivanje = UcitajDatumePrioritetVreme();
                    }
                if (datumiZaZakazivanje.Count == 0)
                {
                    Poruka = "*Nema slobodnih datuma! Vratite se na predhodnu stranicu i podesite nove parametre.";
                    return;
                }
                UcitajUKolekciju(datumiZaZakazivanje);
                }
        }
        private List<TerminDTO> UcitajDatumePrioritetLekar()
        {
            DateTime datumOd = datumiUIntervalu[0].AddDays(-7);
            DateTime datumDo = datumiUIntervalu[1].AddDays(7);
            List<DateTime> intervalDatuma = new List<DateTime>();
            intervalDatuma.Add(datumOd);
            intervalDatuma.Add(datumDo);
            return terminKontroler.DobaviSlobodneTermineZaZakazivanje(intervalDatuma, podaciZaSlanje.IzabraniLekar.CeloIme);
        }

        private List<TerminDTO> UcitajDatumePrioritetVreme()
        {
            return terminKontroler.NadjiDatumUIntervalu(podaciZaSlanje.DatumOd, podaciZaSlanje.DatumDo);
        }
        private void UcitajUKolekciju(List<TerminDTO>datumiKodIzabranogLekara)
        {
            SlobodniKodIzabranog = new ObservableCollection<TerminDTO>();
            foreach(TerminDTO termin in datumiKodIzabranogLekara)
            {
                SlobodniKodIzabranog.Add(termin);
            }
        }
        public ObservableCollection<TerminDTO> SlobodniKodIzabranog
        {
            get { return slobodniKodIzabranog; }
            set
            {
                slobodniKodIzabranog = value;
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

        private RelayCommand vratiSeKomanda;

        public RelayCommand VratiSeKomanda
        {
            get { return vratiSeKomanda; }
        }

        private void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new ZakazivanjeSaPrioritetom(podaciZaSlanje.KorisnickoImePacijenta));
        }


        private RelayCommand prikaziTermineKomanda;

        public RelayCommand PrikaziTermineKomanda
        {
            get { return prikaziTermineKomanda; }
        }

        private void PrikaziTermine()
        {
            if (SelektovaniTermin != null)
            {
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new ZakazivanjeVremena(SelektovaniTermin,podaciZaSlanje));
            }else
            {
                Poruka = "*Morate izabrati datum!";
            }
        }
    }
}
