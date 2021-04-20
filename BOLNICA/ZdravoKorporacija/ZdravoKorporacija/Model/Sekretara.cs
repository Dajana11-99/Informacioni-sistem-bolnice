/***********************************************************************
 * Module:  Sekretara.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Sekretara
 ***********************************************************************/

using System;

namespace Model
{
   public class Sekretara : Osoba
   {
      public String IdZaposlenog;

        public Sekretara( String idZaposlenog,string ime, string prezime, string jmbg, string email, AdresaStanovanja adresaStanovanja ,Korisnik korisnik) : base(ime, prezime, jmbg, email, adresaStanovanja,korisnik)
        {
            IdZaposlenog = idZaposlenog;

        }
    }
}