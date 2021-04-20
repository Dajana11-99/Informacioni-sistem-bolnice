/***********************************************************************
 * Module:  Recept.cs
 * Author:  Markoviccc
 * Purpose: Definition of the Class Model.Recept
 ***********************************************************************/

using System;

namespace Model
{
    public class Recept
    {
        public Lek lek { get; set; }

        public String KolicinaTerapije { get; set; }
        public DateTime PocetakTerapije { get; set; }
        private DateTime KrajTerapije { get; set; }
        public double PeroidUzimanjaUSatima { get; set; }


        public Recept()
        {

        }

        public Recept(String kolicinaTerapije, DateTime pocetakTerapije, DateTime krajTarapije, double periodUzimanja,Lek lek)
        {
            KolicinaTerapije = kolicinaTerapije;
            PocetakTerapije = pocetakTerapije;
            KrajTerapije = krajTarapije;
            PeroidUzimanjaUSatima = periodUzimanja;
            this.lek = lek;
        }

    }
}