
using System;
using System.Collections.Generic;

namespace Model
{
   public class Ankete
   {
        private String dodatniKomentar;
        private List<Pitanje> pitanja;
        private Termin termin;

        private Pacijent pacijent;
        public DateTime ocenioBolnicu;

        public String DodatniKomenta
        {
            get { return dodatniKomentar; }
            set { dodatniKomentar = value; }
        }
        public List<Pitanje> Pitanja
        {
            get { return pitanja; }
            set { pitanja = value; }
        }
        public Termin Termin
        {
            get { return termin; }
            set { termin = value; }
        }
        public Pacijent Pacijent
        {
            get { return pacijent; }
            set { pacijent = value; }
        }

        public DateTime OcenioBolnicu
        {
            get { return ocenioBolnicu; }
            set { ocenioBolnicu = value; }
        }
        public Ankete(string dodatniKomentar, List<Pitanje> pitanja, Termin termin,Pacijent pacijent)
        {
            this.dodatniKomentar = dodatniKomentar;
            this.pitanja = pitanja;
            this.termin = termin;
            this.pacijent = pacijent;
        }

        public Ankete(string dodatniKomentar, List<Pitanje> pitanja, Termin termin, Pacijent pacijent, DateTime ocenioBolnicu) : this(dodatniKomentar, pitanja, termin, pacijent)
        {
            this.ocenioBolnicu = ocenioBolnicu;
        }

        public Ankete() { }





    }
}