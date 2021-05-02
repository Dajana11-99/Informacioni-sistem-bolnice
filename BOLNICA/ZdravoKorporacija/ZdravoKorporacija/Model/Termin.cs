/***********************************************************************
 * Module:  Termin.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Termin
 ***********************************************************************/

using System;
using System.ComponentModel;

namespace Model
{
    public class Termin : INotifyPropertyChanged

    {
        public String Vreme
        {
            get;
            set;
        }

        public double TrajanjeTermina
        {
            get;
            set;
        }

        public DateTime Datum
        {

            get;
            set;

        }


        public TipTermina TipTermina

        {
            get;
            set;
        }


        public String IdTermina

        {
            get;
            set;
        }


        public Sala Sala
        {
            get;
            set;
        }
        public Lekar Lekar
        {
            get;
            set;
        }

        public Pacijent Pacijent
        {
            get;
            set;
        }

        public bool OcenjenTermin { get; set; }

        public Termin(String id, TipTermina tip, String vreme, double trajanje, DateTime datum, Sala sala, Pacijent p, Lekar l)

        {
            IdTermina = id;
            TipTermina = tip;
            Vreme = vreme;
            TrajanjeTermina = trajanje;
            Datum = datum;
            Sala = sala;
            Pacijent = p;
            Lekar = l;
            OcenjenTermin = false;



        }

    

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name) 
        { 
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

      public Termin() { }
    }
}