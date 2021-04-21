/***********************************************************************
 * Module:  TerminKontroler.cs
 * Author:  dajan
 * Purpose: Definition of the Class Kontroler.TerminKontroler
 ***********************************************************************/

using Model;
using Servis;
using System;
using System.Collections.Generic;

namespace Kontroler
{
   public class TerminKontroler
   {
        public static bool ProveriMogucnostPomeranjaDatum(String dat) {
            return TerminServis.ProveriMogucnostPomeranjaDatum(dat);

            }
    }
}