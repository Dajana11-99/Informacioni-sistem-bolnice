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
        private String vreme;
        private double trajanjeTermina;
        private DateTime datum;
        private TipTermina tipTermina;
        private String idTermina;
        private Sala sala;
        private Lekar lekar;
        private Pacijent pacijent;
        private bool daLiJeHitno;
        private bool ocenjenTermin;

        public String Vreme
        {
            get { return vreme; }
            set{ vreme = value; }
        }
        public double TrajanjeTermina
        {
            get { return trajanjeTermina; }
            set { trajanjeTermina = value; }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public TipTermina TipTermina
        {
            get { return tipTermina; }
            set { tipTermina = value; }
        }
        public String IdTermina
        {
            get { return idTermina; }
            set { idTermina = value; }
        }
        public Sala Sala
        {
            get { return sala; }
            set { sala = value; }
        }

        public Lekar Lekar
        {
            get { return lekar; }
            set { lekar = value; }
        }

        public Pacijent Pacijent
        {
            get { return pacijent; }
            set { pacijent = value; }
        }
        public bool OcenjenTermin
        {
            get { return ocenjenTermin; }
            set { ocenjenTermin = value; }
        }
        public bool DaLiJeHitno
        {
            get { return daLiJeHitno; }
            set { daLiJeHitno = value; }
        }

        public Termin(string idTermina)
        {
            this.idTermina = idTermina;
        }

        public Termin(String id, TipTermina tip, String vreme, double trajanje, DateTime datum, Sala sala, Pacijent pacijent, Lekar lekar)
        {
            idTermina = id;
            tipTermina = tip;
            this.vreme = vreme;
            trajanjeTermina = trajanje;
            this.datum = datum;
            this.sala = sala;
            this.pacijent = pacijent;
            this.lekar = lekar;
            ocenjenTermin = false;
        }
        public Termin(String id, TipTermina tip, String vreme, double trajanje, DateTime datum, Sala sala, Pacijent pacijent, Lekar lekar, bool hitno = false)
        {
            idTermina = id;
            tipTermina = tip;
            this.vreme = vreme;
            trajanjeTermina = trajanje;
            this.datum = datum;
            this.sala= sala;
            this.pacijent = pacijent;
            this.lekar = lekar;
            daLiJeHitno = hitno;
        }

      public Termin() { }

    }
}