using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Komande;
using ZdravoKorporacija.Kontroler;

namespace ZdravoKorporacija.ViewModel
{
   public class OcenaAplikacijeViewModel:ViewModel
    {
        private OcenaAplikacijeDTO ocenaAplikacije= new OcenaAplikacijeDTO();
        private String poruka;
        private String korisnickoIme="";
        private AplikacijaKontroler aplikacijaKontroler = new AplikacijaKontroler();

        public OcenaAplikacijeViewModel(String korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
            sacuvajOcenu = new RelayCommand(Sacuvaj);
        }
        public OcenaAplikacijeDTO OcenaAplikacije
        {
            get { return ocenaAplikacije; }
            set
            {
                ocenaAplikacije = value;
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

        private RelayCommand sacuvajOcenu;

        public RelayCommand SacuvajOcenu
        {
            get { return sacuvajOcenu; }
        }
        private void Sacuvaj()
        {
            OcenaAplikacije.KorisnickoIme = korisnickoIme;
            OcenaAplikacije.Datum = DateTime.Now;
            OcenaAplikacije.Ocena += 1;
            
            aplikacijaKontroler.SacuvajOcenuAplikacije(OcenaAplikacije);
            Poruka = "*Vasa ocena je sačuvana. Hvala Vam na mišljenju!";
        }
    }
}
