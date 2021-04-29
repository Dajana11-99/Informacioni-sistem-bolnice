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
        public Lek Lek1 { get; set; }

        public String KolicinaTerapije { get; set; }
        public DateTime PocetakTerapije { get; set; }
        public DateTime KrajTerapije { get; set; }
        public double PeroidUzimanjaUSatima { get; set; }
        public String obavestiMe { get; set; }

        public String idPacijenta { get; set; }



        public Recept()
        {

        }

        public Recept(String kolicinaTerapije, DateTime pocetakTerapije, DateTime krajTarapije, double periodUzimanja,Lek lek,String pac)
        {
            KolicinaTerapije = kolicinaTerapije;
            PocetakTerapije = pocetakTerapije;
            KrajTerapije = krajTarapije;
            PeroidUzimanjaUSatima = periodUzimanja;
            this.Lek1 = lek;
            idPacijenta = pac;
            obavestiMe = "NE";
        }

    }
}