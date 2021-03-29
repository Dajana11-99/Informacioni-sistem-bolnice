/***********************************************************************
 * Module:  Lekar.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Lekar
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Model
{
   public class Lekar : Osoba
   {
      public System.Collections.ArrayList termin;
        public System.Collections.ArrayList zahtevUpravniku;

        public String idZaposlenog { get; set; }
        public Boolean Zauzet;
        public Specijalizacija Specijalizacija;

        public Lekar()
        {

        }

        public Lekar(String idZaposlenog)
        {
            this.idZaposlenog = idZaposlenog;
        }

        public Lekar(String idZaposlenog, bool zauzet, Specijalizacija specijalizacija) 

        {
            this.idZaposlenog = idZaposlenog;
            Zauzet = zauzet;
            Specijalizacija = specijalizacija;
        }

       

        public void setSpecijalizacija(Specijalizacija s)
        {
            Specijalizacija = s;

        }

        public Specijalizacija getSpecijalizacija()
        {
            return this.Specijalizacija;
        }


        public bool getZauzetost (){
            return this.Zauzet;
        }

        public void setZauzetost( bool z)
        {
            Zauzet = z;
        }

      

      
    }
}