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
        public Karton karton;
        public System.Collections.ArrayList termin;

        public bool maliciozan { get; set; }
        public int zloupotrebio { get; set; }
        public String idPacijenta { get; set; }
        public String Anamneza { get; set; }

        public Pacijent(String idPacijenta)
        {
            this.idPacijenta = idPacijenta;
        }
        public Pacijent()
        {

        }
        public Pacijent(string id, string ime, string prezime, string jmbg, string email, AdresaStanovanja adresaStanovanja) : base(ime, prezime, jmbg, email, adresaStanovanja)
        {
            idPacijenta = id;
            maliciozan = false;
            zloupotrebio = 0;
        }

        public Pacijent(string id, string ime, string prezime, string jmbg, string email, AdresaStanovanja adresaStanovanja,Korisnik korisnik) : base(ime, prezime, jmbg, email, adresaStanovanja,korisnik)
        {
            idPacijenta = id;
            maliciozan = false;
            zloupotrebio = 0;
        }
       
      
    }
}