using Kontroler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;

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


    }
}
