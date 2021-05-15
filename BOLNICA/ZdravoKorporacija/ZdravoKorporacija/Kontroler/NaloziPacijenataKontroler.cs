/***********************************************************************
 * Module:  NaloziPacijenataKontroler.cs
 * Author:  dajan
 * Purpose: Definition of the Class Kontroler.NaloziPacijenataKontroler
 ***********************************************************************/

using Model;
using Servis;
using System;

namespace Kontroler
{
   public class NaloziPacijenataKontroler
   {
        public static Pacijent PretraziPoKorisnickom(String korisnickoIme)
        {
            return NaloziPacijenataServis.PretraziPoKorisnickom(korisnickoIme);
        }
   }
}