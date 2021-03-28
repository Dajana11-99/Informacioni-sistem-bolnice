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

        public double trajanjeTermina
        {
            get;
            set;
        }

        public String Datum
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
        public Lekar lekar
        {
            get;
            set;
        }

        public Pacijent pacijent
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name) 
        { 
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

       public Termin(String id, TipTermina tip, String vreme,double trajanje,String datum,Sala sala,Pacijent p,Lekar l)
        
        {
            IdTermina = id;
            TipTermina = tip;
            Vreme = vreme;
            trajanjeTermina = trajanje;
            Datum = datum;
            Sala = sala;
            pacijent = p;
            lekar = l;


        }
    }
}