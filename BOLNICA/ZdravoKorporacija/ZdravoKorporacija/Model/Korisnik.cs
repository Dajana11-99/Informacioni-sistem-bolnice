/***********************************************************************
 * Module:  Korisnik.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Korisnik
 ***********************************************************************/

using System;

namespace Model
{
   public class Korisnik
   {
      public Osoba osoba;
   
      public String KorisnickoIme;
      public String Sifra;
      public Uloga Uloga;
      public TipNaloga Nalog;
        public Korisnik(string korisnickoIme, string sifra)
        {
            KorisnickoIme = korisnickoIme;
            Sifra = sifra;
        }
        public Korisnik() { }
    }
}