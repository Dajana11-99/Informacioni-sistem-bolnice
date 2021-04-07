/***********************************************************************
 * Module:  AdresaStanovanja.cs
 * Author:  dajan
 * Purpose: Definition of the Class Model.AdresaStanovanja
 ***********************************************************************/

using System;
using System.ComponentModel;

namespace Model
{
    public class AdresaStanovanja: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public String Ulica { get; set; }
        public String Broj;

        public Mesto[] mesto;

        public AdresaStanovanja(string ulica, string broj)
        {
            Ulica = ulica;
            Broj = broj;
        }
        public AdresaStanovanja() { }
    }
}