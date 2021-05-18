/***********************************************************************
 * Module:  Sala.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Sala
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model
{
   public class Sala
   {
        public TipSale TipSale { get; set; }
        public String Id { get; set; }
        public bool Zauzeta { get; set; }
        public string sprat { get; set; }
        public float kvadratura { get; set; }

        

        public List<RasporedjenaStatickaOprema> RasporedjenaStatickaOprema { get; set; }
        public List<RasporedjenaDinamickaOprema> RasporedjenaDinamickaOprema { get; set; }

        public Renoviranje Renoviranje { get; set; }



        public Sala(TipSale tipSale, string id)
        {
            TipSale = tipSale;
            Id = id;
        }

       
        public Sala() { }
    }

}