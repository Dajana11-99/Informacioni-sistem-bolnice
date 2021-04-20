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
        public Lek lek;

        private String KolicinaTerapije { get; set; }
        private DateTime PocetakTerapije { get; set; }
        private DateTime KrajTerapije { get; set; }
        private double PeroidUzimanjaUSatima { get; set; }


        public Recept()
        {

        }

        public Recept(String kolicinaTerapije, DateTime pocetakTerapije, DateTime krajTarapije, double periodUzimanja)
        {
            KolicinaTerapije = kolicinaTerapije;
            PocetakTerapije = pocetakTerapije;
            KrajTerapije = krajTarapije;
            PeroidUzimanjaUSatima = periodUzimanja;
        }

    }
}