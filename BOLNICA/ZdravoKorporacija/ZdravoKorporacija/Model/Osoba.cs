/***********************************************************************
 * Module:  Osoba.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Osoba
 ***********************************************************************/

using System;
using System.ComponentModel;

namespace Model
{
    public class Osoba : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public Korisnik korisnik { get; set; }

        public Osoba(string ime, string prezime, string jmbg, string email,AdresaStanovanja adresaStanovanja)
        {
            Ime = ime;
            Prezime = prezime;
            Jmbg = jmbg;
            Email = email;
            this.adresaStanovanja = adresaStanovanja;
        }
        public Osoba()
        {

        }
        public Osoba(string ime, string prezime, string jmbg, string email, AdresaStanovanja adresaStanovanja,Korisnik korisnik)
        {
            Ime = ime;
            Prezime = prezime;
            Jmbg = jmbg;
            Email = email;
            this.adresaStanovanja = adresaStanovanja;
            this.korisnik = korisnik;
        }
        public Osoba(string ime, string prezime)
        {
            Ime = ime;
            Prezime = prezime;
        }

      
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public String Jmbg { get; set; }
        public String Email { get; set; }
        public String CeloIme { get; set; }

        public AdresaStanovanja adresaStanovanja { get; set; }
     

    }
}