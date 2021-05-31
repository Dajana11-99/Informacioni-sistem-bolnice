using Kontroler;
using Model;
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
   public class ViseInformacijaViewModel:ViewModel
    {
        private TerminDTO selektovaniTermin;
        private String dijagnoza;
        private String anamneza;
        private String korisnickoIme;
        private String terapija;
        private String kontrola;
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();

        public ViseInformacijaViewModel(TerminDTO izabraniTermin)
        {
            SelektovaniTermin = izabraniTermin;
            korisnickoIme = naloziPacijenataKontroler.PretragaPoId(izabraniTermin.IdPacijenta).korisnik.KorisnickoIme;
            Dijagnoza = naloziPacijenataKontroler.PretragaPoId(izabraniTermin.IdPacijenta).karton.Anamneza.Simptomi;
            Anamneza = naloziPacijenataKontroler.PretragaPoId(izabraniTermin.IdPacijenta).karton.Anamneza.IzvestajLekara;
            UcitajUKolekciju(izabraniTermin.IdPacijenta);
            Kontrola = "Po potrebi.";
            vratiSeKomanda = new RelayCommand(VratiSe);
            kreirajBelesku = new RelayCommand(Kreiraj);


        }
        private void UcitajUKolekciju(String idPacijenta)
        {
            
            foreach (Recept recept in naloziPacijenataKontroler.PretragaPoId(idPacijenta).karton.recepti)
            {
                Terapija += recept.Lek1.ImeLeka + " " + "Svakih " + recept.PeroidUzimanjaUSatima + "h.\n";
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
        public String Kontrola
        {
            get { return kontrola; }
            set
            {
                kontrola = value;
                OnPropertyChanged();
            }
        }
        public String Anamneza
        {
            get { return anamneza; }
            set
            {
                anamneza = value;
                OnPropertyChanged();
            }
        }
        public String KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
              
            }
        }
        public String Dijagnoza
        {
            get { return dijagnoza; }
            set
            {
                dijagnoza = value;
                OnPropertyChanged();
            }
        }
        public String Terapija
        {
            get { return terapija; }
            set
            {
                terapija = value;
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
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IstorijaPregleda(korisnickoIme));
        }

        private RelayCommand kreirajBelesku;

        public RelayCommand KreirajBelesku
        {
            get { return kreirajBelesku; }
        }

        private void Kreiraj()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazBeleske(SelektovaniTermin));
        }

    }
}
