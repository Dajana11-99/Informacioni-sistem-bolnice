/***********************************************************************
 * Module:  Pacijent.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Pacijent
 ***********************************************************************/

using System;

namespace Model
{
   public class Pacijent : Osoba
   {
      public Karton karton;
      public System.Collections.ArrayList termin;
        public String idPacijenta { get; set; }
       

        public Pacijent(String idPacijenta)
        {
            this.idPacijenta = idPacijenta;
        }
    }
}