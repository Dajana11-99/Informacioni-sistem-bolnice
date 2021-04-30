/***********************************************************************
 * Module:  Ankete.cs
 * Author:  dajan
 * Purpose: Definition of the Class Model.Ankete
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model
{
   public class Ankete
   {
      public String DodatniKomentar { get; set; }
      public List<Pitanje> pitanja { get; set; }
      public Termin termin { get; set; }
      
        public Pacijent Pacijent { get;set; }
      public DateTime ocenioBolnicu { get; set; }

        public Ankete(string dodatniKomentar, List<Pitanje> pitanja, Termin termin,Pacijent pacijent)
        {
            DodatniKomentar = dodatniKomentar;
            this.pitanja = pitanja;
            this.termin = termin;
            this.Pacijent = pacijent;
         
          
        }

        public Ankete(string dodatniKomentar, List<Pitanje> pitanja, Termin termin, Pacijent pacijent, DateTime ocenioBolnicu) : this(dodatniKomentar, pitanja, termin, pacijent)
        {
            this.ocenioBolnicu = ocenioBolnicu;
        }

        public Ankete() { }





    }
}