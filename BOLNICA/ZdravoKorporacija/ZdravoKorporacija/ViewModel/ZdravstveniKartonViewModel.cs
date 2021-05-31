using Kontroler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Komande;
using ZdravoKorporacija.PacijentPrikaz;

namespace ZdravoKorporacija.ViewModel
{
   public class ZdravstveniKartonViewModel:ViewModel
    {
        private PacijentDTO pacijent;
        private Karton karton;
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();

        public ZdravstveniKartonViewModel(String korisnickoIme)
        {
            PronadjiPacijenta(korisnickoIme);
            prikaziIstorijuPregleda = new RelayCommand(Prikazi);
        }
        private void PronadjiPacijenta(String korisnickoIme )
        {
            Pacijent = new PacijentDTO(korisnickoIme,naloziPacijenataKontroler.PretraziPoKorisnickom(korisnickoIme).Jmbg, naloziPacijenataKontroler.PretraziPoKorisnickom(korisnickoIme).adresaStanovanja.Ulica, naloziPacijenataKontroler.PretraziPoKorisnickom(korisnickoIme).adresaStanovanja.Broj);
            Karton = new Karton();
            Karton = naloziPacijenataKontroler.DobaviKartonPacijenta(korisnickoIme);
        }
        public PacijentDTO Pacijent
        {
            get { return pacijent; }
            set
            {
                pacijent = value;
                OnPropertyChanged();
            }
        }
        public Karton Karton
        {
            get { return karton; }
            set
            {
                karton = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand prikaziIstorijuPregleda;

        public RelayCommand PrikaziIstorijuPregleda
        {
            get { return prikaziIstorijuPregleda; }
        }

        private void Prikazi()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IstorijaPregleda(pacijent.KorisnickoIme));
        }



    }
}
