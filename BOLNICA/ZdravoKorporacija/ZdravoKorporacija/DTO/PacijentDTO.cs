
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.DTO
{
    public class PacijentDTO
    {
        private String korisnickoIme;
   
        private String jmbg;
        private string nazivMesta;
        private string broj;

        public String KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;

            }
        }
        public String Jmbg
        {
            get { return jmbg; }
            set
            {
                jmbg = value;

            }
        }
        public String NazivMesta
        {
            get { return nazivMesta; }
            set
            {
                nazivMesta = value;

            }
        }
        public String Broj
        {
            get { return broj; }
            set
            {
                broj = value;

            }
        }
        public PacijentDTO(string korisnickoIme)
        {
            this.korisnickoIme = korisnickoIme;
        }

        public PacijentDTO(string korisnickoIme, string jmbg, string nazivMesta, string broj) : this(korisnickoIme)
        {
            this.jmbg = jmbg;
            this.nazivMesta = nazivMesta;
            this.broj = broj;
        }

        public PacijentDTO()
        {
        }
    }
}
