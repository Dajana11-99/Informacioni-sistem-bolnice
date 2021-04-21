﻿/***********************************************************************
 * Module:  Recept.cs
 * Author:  Markoviccc
 * Purpose: Definition of the Class Model.Recept
 ***********************************************************************/

using System;

namespace Model
{
    public class Recept
    {
        public Lek Lek1 { get; set; }

        public String KolicinaTerapije { get; set; }
        public String PocetakTerapije { get; set; }
        private String KrajTerapije { get; set; }
        public double PeroidUzimanjaUSatima { get; set; }


        public Recept()
        {

        }

        public Recept(String kolicinaTerapije, String pocetakTerapije, String krajTarapije, double periodUzimanja,Lek lek)
        {
            KolicinaTerapije = kolicinaTerapije;
            PocetakTerapije = pocetakTerapije;
            KrajTerapije = krajTarapije;
            PeroidUzimanjaUSatima = periodUzimanja;
            this.Lek1 = lek;
        }

    }
}