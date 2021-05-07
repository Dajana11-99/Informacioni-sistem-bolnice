/***********************************************************************
 * Module:  Pitanje.cs
 * Author:  dajan
 * Purpose: Definition of the Class Model.Pitanje
 ***********************************************************************/

using System;
using ZdravoKorporacija.Model;

namespace Model
{
   public class Pitanje
   {
     public OcenaAnkete Ocena { get; set; }
        public String Tekst { get; set; }
       

        public Pitanje() { }
        public Pitanje(OcenaAnkete ocena, string tekst)
        {
            Ocena = ocena;
            Tekst = tekst;
           
        }
    }
}