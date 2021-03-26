/***********************************************************************
 * Module:  Lekar.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Lekar
 ***********************************************************************/

using System;

namespace Model
{
   public class Lekar : Osoba
   {
      public System.Collections.ArrayList termin;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetTermin()
      {
         if (termin == null)
            termin = new System.Collections.ArrayList();
         return termin;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetTermin(System.Collections.ArrayList newTermin)
      {
         RemoveAllTermin();
         foreach (Termin oTermin in newTermin)
            AddTermin(oTermin);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddTermin(Termin newTermin)
      {
         if (newTermin == null)
            return;
         if (this.termin == null)
            this.termin = new System.Collections.ArrayList();
         if (!this.termin.Contains(newTermin))
         {
            this.termin.Add(newTermin);
            newTermin.SetLekar(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveTermin(Termin oldTermin)
      {
         if (oldTermin == null)
            return;
         if (this.termin != null)
            if (this.termin.Contains(oldTermin))
            {
               this.termin.Remove(oldTermin);
               oldTermin.SetLekar((Lekar)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllTermin()
      {
         if (termin != null)
         {
            System.Collections.ArrayList tmpTermin = new System.Collections.ArrayList();
            foreach (Termin oldTermin in termin)
               tmpTermin.Add(oldTermin);
            termin.Clear();
            foreach (Termin oldTermin in tmpTermin)
               oldTermin.SetLekar((Lekar)null);
            tmpTermin.Clear();
         }
      }
      public System.Collections.ArrayList zahtevUpravniku;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetZahtevUpravniku()
      {
         if (zahtevUpravniku == null)
            zahtevUpravniku = new System.Collections.ArrayList();
         return zahtevUpravniku;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetZahtevUpravniku(System.Collections.ArrayList newZahtevUpravniku)
      {
         RemoveAllZahtevUpravniku();
         foreach (ZahtevUpravniku oZahtevUpravniku in newZahtevUpravniku)
            AddZahtevUpravniku(oZahtevUpravniku);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddZahtevUpravniku(ZahtevUpravniku newZahtevUpravniku)
      {
         if (newZahtevUpravniku == null)
            return;
         if (this.zahtevUpravniku == null)
            this.zahtevUpravniku = new System.Collections.ArrayList();
         if (!this.zahtevUpravniku.Contains(newZahtevUpravniku))
         {
            this.zahtevUpravniku.Add(newZahtevUpravniku);
            newZahtevUpravniku.SetLekar(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveZahtevUpravniku(ZahtevUpravniku oldZahtevUpravniku)
      {
         if (oldZahtevUpravniku == null)
            return;
         if (this.zahtevUpravniku != null)
            if (this.zahtevUpravniku.Contains(oldZahtevUpravniku))
            {
               this.zahtevUpravniku.Remove(oldZahtevUpravniku);
               oldZahtevUpravniku.SetLekar((Lekar)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllZahtevUpravniku()
      {
         if (zahtevUpravniku != null)
         {
            System.Collections.ArrayList tmpZahtevUpravniku = new System.Collections.ArrayList();
            foreach (ZahtevUpravniku oldZahtevUpravniku in zahtevUpravniku)
               tmpZahtevUpravniku.Add(oldZahtevUpravniku);
            zahtevUpravniku.Clear();
            foreach (ZahtevUpravniku oldZahtevUpravniku in tmpZahtevUpravniku)
               oldZahtevUpravniku.SetLekar((Lekar)null);
            tmpZahtevUpravniku.Clear();
         }
      }
   
      private int IdZaposlenog;
      private Boolean Zauzet;
      private Specijalizacija Specijalizacija;
   
   }
}