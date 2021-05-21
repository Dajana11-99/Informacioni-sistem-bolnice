/***********************************************************************
 * Module:  Termin.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Termin
 ***********************************************************************/

using System;
using System.ComponentModel;
using ZdravoKorporacija.ViewModel;

namespace Model
{
    public class Termin 

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
        public bool DaLiJeHitno
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
        public Termin(String id, TipTermina tip, String vreme, double trajanje, DateTime datum, Sala sala, Pacijent p, Lekar l, bool hitno = false)
        {
            IdTermina = id;
            TipTermina = tip;
            Vreme = vreme;
            TrajanjeTermina = trajanje;
            Datum = datum;
            Sala = sala;
            Pacijent = p;
            Lekar = l;
            DaLiJeHitno = hitno;
        }

      public Termin() { }
    }
}