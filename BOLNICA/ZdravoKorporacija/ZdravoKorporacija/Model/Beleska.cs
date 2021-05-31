using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.Model
{
    public class Beleska
    {
        private String tekstBeleske;
        private DateTime datumBeleske;
        private String idBeleske;
        private Anamneza anamneza;

        public String TekstBeleske
        {
            get { return tekstBeleske; }
            set { tekstBeleske = value; }
        }
        public DateTime DatumBeleske
        {
            get { return datumBeleske; }
            set { datumBeleske = value; }
        }
        public String IdBeleske
        {
            get { return idBeleske; }
            set { idBeleske = value; }
        }
        public Anamneza Anamneza
        {
            get { return anamneza; }
            set { anamneza = value; }
        }

        public Beleska(string tekstBeleske, DateTime datumBeleske, string idBeleske, Anamneza anamneza)
        {
            this.tekstBeleske = tekstBeleske;
            this.datumBeleske = datumBeleske;
            this.idBeleske = idBeleske;
            this.anamneza = anamneza;
        }
        public Beleska() { }
    }
}
