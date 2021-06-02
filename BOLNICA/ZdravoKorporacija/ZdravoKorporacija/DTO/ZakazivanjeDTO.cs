using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;

namespace ZdravoKorporacija.ViewModel
{
   public class ZakazivanjeDTO:ViewModel
    {
        private DateTime datumOd = DateTime.Now.AddDays(1);
        private DateTime datumDo = DateTime.Now.AddDays(3);
        private int prioritet;
        private String korisnickoImePacijenta;
        private LekarDTO izabraniLekar;


        public LekarDTO IzabraniLekar
        {
            get { return izabraniLekar; }
            set
            {
                izabraniLekar = value;
                OnPropertyChanged();

            }

        }

        public String KorisnickoImePacijenta
        {
            get { return korisnickoImePacijenta; }
            set
            {
                korisnickoImePacijenta = value;
                OnPropertyChanged();

            }

        }

        public DateTime DatumOd
        {
            get { return datumOd; }
            set
            {
                datumOd = value;
                OnPropertyChanged();

            }
        }

        public DateTime DatumDo
        {
            get { return datumDo; }
            set
            {
                datumDo = value;
                OnPropertyChanged();

            }
        }

        public int Prioritet
        {
            get { return prioritet; }
            set
            {
                prioritet = value;
                OnPropertyChanged();

            }
        }
    }
}
