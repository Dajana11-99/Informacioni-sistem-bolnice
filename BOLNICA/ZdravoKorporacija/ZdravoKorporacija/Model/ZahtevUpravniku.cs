/***********************************************************************
 * Module:  ZahtevUpravniku.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.ZahtevUpravniku
 ***********************************************************************/

using System;
using System.ComponentModel;

namespace Model
{
   public class ZahtevUpravniku : INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        

        public Lekar Lekar
        {
            get;
            set;
        }

        public string opisZahteva 
        {
            get;
            set;
        }

        public string pocetakOdmora
        {
            get;
            set;
        }

        public string krajOdmora
        {
            get;
            set;
        }

        public String idZahteva
        {
            get;
            set;
        }

        public ZahtevUpravniku(Lekar lekar, string opisZahteva, string pocetakOdmora, string krajOdmora, string idZahteva)
        {
            Lekar = lekar;
            this.opisZahteva = opisZahteva;
            this.pocetakOdmora = pocetakOdmora;
            this.krajOdmora = krajOdmora;
            this.idZahteva = idZahteva;
        }
    }




}