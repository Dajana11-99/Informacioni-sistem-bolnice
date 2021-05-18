/***********************************************************************
 * Module:  Lek.cs
 * Author:  Markoviccc
 * Purpose: Definition of the Class Model.Lek
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
    public class Lek : INotifyPropertyChanged
    {
        public String IdLeka { get; set; }
        public String ImeLeka { get; set; }
        public String KolicinaLeka { get; set; }
        public String SastojciLeka { get; set; }

        public List<Sastojak> ListaSastojaka { get; set; }
        public List<Lek> ListaZamenaZaLek { get; set; }

        public Lek() { }
        public Lek(String id,String ime)
        {
            IdLeka = id;
            ImeLeka = ime;
        }
        public static explicit operator Lek(int v)
        {
            throw new NotImplementedException();
        }
        public Lek(String id, String ime, String kolicina, String sastojci)
        {
            IdLeka = id;
            ImeLeka = ime;
            KolicinaLeka = kolicina;
            SastojciLeka = sastojci;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
 
    }
}