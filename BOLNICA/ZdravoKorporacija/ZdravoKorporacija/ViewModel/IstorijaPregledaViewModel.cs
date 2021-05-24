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
   public  class IstorijaPregledaViewModel:ViewModel
    {
        private ObservableCollection<TerminDTO> sviZakazaniTerminiPacijenta;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private String idPacijenta;
        private String korisnickoIme;
        private TerminDTO selektovaniTermin;
        private String poruka;
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();

        public IstorijaPregledaViewModel(String korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
            idPacijenta = naloziPacijenataKontroler.PretraziPoKorisnickom(korisnickoIme).IdPacijenta;
            UcitajUKolekciju();
            vratiSeNazadKomanda = new RelayCommand(VratiSe);
            informacijeSaPregleda = new RelayCommand(ViseInformacija);
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
        private void UcitajUKolekciju()
        {
            SviZakazaniTerminiPacijenta = new ObservableCollection<TerminDTO>();
            foreach(TerminDTO termin in terminKontroler.DobaviSveObavljeneTermine(idPacijenta))
            {
                SviZakazaniTerminiPacijenta.Add(termin);
            }
        }

        public ObservableCollection<TerminDTO> SviZakazaniTerminiPacijenta
        {
            get { return sviZakazaniTerminiPacijenta; }
            set
            {
                sviZakazaniTerminiPacijenta = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand vratiSeNazadKomanda;

        public RelayCommand VratiSeNazadKomanda
        {
            get { return vratiSeNazadKomanda; }
        }

        private RelayCommand informacijeSaPregleda;

        public RelayCommand InformacijeSaPregleda
        {
            get { return informacijeSaPregleda; }
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

        private void ViseInformacija()
        {
            if (SelektovaniTermin != null)
            {
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IzvestajSaPregleda(SelektovaniTermin));
            }
            else
            {
                Poruka = "*Morate izabrati pregled da biste videli vise informacija";
            }
           
        }
        private void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new ZdravstevniKarton(korisnickoIme));
        }


    }
}
