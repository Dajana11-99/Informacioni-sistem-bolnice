/***********************************************************************
 * Module:  Sala.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Sala
 ***********************************************************************/

using System;

namespace Model
{
   public class Sala
   {
      public TipSale TipSale { get; set; }
        public String Id { get; set; }
        public bool Zauzeta { get; set; }
        public int sprat { get; set; }
        float kvadratura;

        public Sala(TipSale tipSale, string id)
        {
            TipSale = tipSale;
            Id = id;
        }

        public Sala() { }
    }

}