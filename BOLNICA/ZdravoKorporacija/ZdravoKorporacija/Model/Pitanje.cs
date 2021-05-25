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
        private OcenaAnkete ocena;
        private String tekst;

        public String Tekst
        {
            get { return tekst; }
            set { tekst = value; }
        }
        public OcenaAnkete Ocena
        {
            get { return ocena; }
            set { ocena = value; }
        }
    }
}