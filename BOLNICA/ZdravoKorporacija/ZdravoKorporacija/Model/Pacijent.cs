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
        public String idPacijenta { get; set; }


        public Pacijent(String idPacijenta)
        {
            this.idPacijenta = idPacijenta;
        }
        public Pacijent()
        {

        }
        /*public Pacijent(String idPacijenta , string ime , string prezime , string jmbg)
        {
            this.idPacijenta = idPacijenta;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Jmbg = jmbg;
        }*/
        // public Pacijent() { }



        public Pacijent(string id, string ime, string prezime, string jmbg, string email, AdresaStanovanja adresaStanovanja) : base(ime, prezime, jmbg, email, adresaStanovanja)
        {
            idPacijenta = id;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        /*
         protected void OnPropertyChanged([CallerMemberName] string name = null)
      {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }
         */
    }
}