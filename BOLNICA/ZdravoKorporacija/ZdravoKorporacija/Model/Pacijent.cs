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
        public int IdPacijenta;

        public Pacijent(int idPacijenta)
        {
            IdPacijenta = idPacijenta;
        }
    }
}