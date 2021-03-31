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

        public Osoba(string ime, string prezime, string jmbg, string email, string adresaStanovanja)
        {
            Ime = ime;
            Prezime = prezime;
            Jmbg = jmbg;
            Email = email;
            AdresaStanovanja = adresaStanovanja;
        }
        public Osoba()
        {

        }

        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Jmbg { get; set; }
        public String Email { get; set; }
        public String AdresaStanovanja { get; set; }

    }
}