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
      public TipSale TipSale;
      public String Id;
      public bool Zauzeta;
        public int sprat;
        float kvadratura;

        public Sala(TipSale tipSale, string id)
        {
            TipSale = tipSale;
            Id = id;
        }
    }

}