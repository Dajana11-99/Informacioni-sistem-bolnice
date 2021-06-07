using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.DTO
{
   public  class OcenaAplikacijeDTO
    {
        private String korisnickoIme;
        private int ocena;
        private DateTime datum;
        private String komentar;

        public OcenaAplikacijeDTO()
        {
        }

        public OcenaAplikacijeDTO(string korisnickoIme, int ocena, DateTime datum, string komentar)
        {
            this.korisnickoIme = korisnickoIme;
            this.ocena = ocena;
            this.datum = datum;
            this.komentar = komentar;
        }

        public String KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; }
        }
        public int Ocena
        {
            get { return ocena; }
            set { ocena = value; }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }

        public String Komentar
        {
            get { return komentar; }
            set { komentar = value; }
        }

    }
}
