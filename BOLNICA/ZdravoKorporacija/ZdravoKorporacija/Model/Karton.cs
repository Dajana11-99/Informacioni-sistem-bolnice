/***********************************************************************
 * Module:  Karton.cs
 * Author:  Markoviccc
 * Purpose: Definition of the Class Model.Karton
 ***********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Model
{
    public class Karton
    {
        public String NazivZdravstveneUstanove { get; set; }
        public String OdeljenjeNaPrijemu { get; set; }
        public String ImeRoditelja { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Pol Pol { get; set; }
        public String Telefon { get; set; }
        public String BrojKartona { get; set; }
        public BracniStatusE BracniStatus { get; set; }
        public Anamneza Anamneza { get; set; }
        public AdresaStanovanja adresaStanovanja { get; set; }
        public List<Recept> recepti { get; set; }
        public String Prezime{get;set;}
        public String Ime{get;set;}

        public String alergican { get; set; }
        public Karton()
        {
            Anamneza = new Anamneza();
            recepti=new List<Recept>();
        }
        public Karton(String odeljenje, String ime, String prezime, String imeRoditelja, DateTime datumRodjenja, Pol pol, String telefon, String brojKartona, BracniStatusE bracniStatus, Anamneza anamneza, String alergican)
        {
            OdeljenjeNaPrijemu = odeljenje;
            Ime = ime;
            Prezime = prezime;
            ImeRoditelja = imeRoditelja;
            DatumRodjenja = datumRodjenja;
            Pol = pol;
            Telefon = telefon;
            BrojKartona = brojKartona;
            BracniStatus = bracniStatus;
            Anamneza = anamneza;
            recepti = new List<Recept>();
            this.alergican = alergican;
        }
    }
}