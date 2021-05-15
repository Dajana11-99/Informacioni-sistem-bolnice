/***********************************************************************
 * Module:  Lekar.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Lekar
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
   public class Lekar : Osoba
   {
        public System.Collections.ArrayList termin;
        public System.Collections.ArrayList zahtevUpravniku;
        public String idZaposlenog { get; set; }
        public bool Zauzet;
        public Specijalizacija Specijalizacija { get; set; }
        public Lekar(){ }
        public Lekar(String idZaposlenog)
        {
            this.idZaposlenog = idZaposlenog;
        }
        public Lekar(String idZaposlenog, bool zauzet, Specijalizacija specijalizacija) 
        {
            this.idZaposlenog = idZaposlenog;
            Zauzet = zauzet;
            Specijalizacija = specijalizacija;
        }
        public Lekar(String idZaposlenog, bool zauzet, Specijalizacija specijalizacija,string ime, string prezime, string jmbg, string email, AdresaStanovanja adresaStanovanja) : base(ime, prezime, jmbg, email, adresaStanovanja)
        {
            this.idZaposlenog = idZaposlenog;
            Zauzet = zauzet;
            Specijalizacija = specijalizacija;
            CeloIme = ime + " " + prezime;
        }
        public Lekar(String idZaposlenog, bool zauzet, Specijalizacija specijalizacija, string ime, string prezime, string jmbg, string email, AdresaStanovanja adresaStanovanja,Korisnik korisnik) : base(ime, prezime, jmbg, email, adresaStanovanja,korisnik)
        {
            this.idZaposlenog = idZaposlenog;
            Zauzet = zauzet;
            Specijalizacija = specijalizacija;
            CeloIme = ime + " " + prezime;
        }
        public Lekar(String ime, String prezime) : base(ime, prezime)
        {
            CeloIme = ime + " " + prezime;
        }
        public void setSpecijalizacija(Specijalizacija s)
        {
            Specijalizacija = s;

        }
        public Specijalizacija getSpecijalizacija()
        {
            return this.Specijalizacija;
        }
        public bool getZauzetost (){
            return this.Zauzet;
        }
        public void setZauzetost( bool z)
        {
            Zauzet = z;
        }
    }
}