/***********************************************************************
 * Module:  Pacijent.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Pacijent
 ***********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
    public class Pacijent : Osoba, INotifyPropertyChanged
    {
        public Karton karton { get; set; }
        public System.Collections.ArrayList termin;

        public bool Maliciozan { get; set; }
        public int Zloupotrebio { get; set; }
        public String IdPacijenta { get; set; }
        public String Anamneza { get; set; }

        public Pacijent(String idPacijenta)
        {
            this.IdPacijenta = idPacijenta;
        }
        public Pacijent()
        {

        }
        public Pacijent(string id, string ime, string prezime, string jmbg, string email, AdresaStanovanja adresaStanovanja) : base(ime, prezime, jmbg, email, adresaStanovanja)
        {
            IdPacijenta = id;
            Maliciozan = false;
            Zloupotrebio = 0;
        }

        public Pacijent(string id, string ime, string prezime, string jmbg, string email, AdresaStanovanja adresaStanovanja,Korisnik korisnik) : base(ime, prezime, jmbg, email, adresaStanovanja,korisnik)
        {
            IdPacijenta = id;
            Maliciozan = false;
            Zloupotrebio = 0;
        }
       
      
    }
}