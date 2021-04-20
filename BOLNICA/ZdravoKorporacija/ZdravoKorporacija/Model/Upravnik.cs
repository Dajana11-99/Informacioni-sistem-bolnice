/***********************************************************************
 * Module:  Upravnik.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Upravnik
 ***********************************************************************/

using System;

namespace Model
{
   public class Upravnik : Osoba
   {
      public String IdZaposlenog;

        public Upravnik( String idZaposlenog,string ime, string prezime, string jmbg, string email, AdresaStanovanja adresaStanovanja, Korisnik korisnik) : base(ime, prezime, jmbg, email, adresaStanovanja, korisnik)
        {
            IdZaposlenog = idZaposlenog;
        }
    }
}