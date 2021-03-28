/***********************************************************************
 * Module:  Osoba.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Osoba
 ***********************************************************************/

using System;

namespace Model
{
   public class Osoba
   {
      public Korisnik korisnik;
   
      public String Ime { get; set; }
      public String Prezime { get; set; }
        public String Jmbg { get; set; }
        public String Email { get; set; }
        public String AdresaStanovanja { get; set; }

    }
}