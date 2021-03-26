/***********************************************************************
 * Module:  ZahtevUpravniku.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.ZahtevUpravniku
 ***********************************************************************/

using System;

namespace Model
{
   public class ZahtevUpravniku
   {
      public Lekar lekar;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Lekar GetLekar()
      {
         return lekar;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newLekar</param>
      public void SetLekar(Lekar newLekar)
      {
         if (this.lekar != newLekar)
         {
            if (this.lekar != null)
            {
               Lekar oldLekar = this.lekar;
               this.lekar = null;
               oldLekar.RemoveZahtevUpravniku(this);
            }
            if (newLekar != null)
            {
               this.lekar = newLekar;
               this.lekar.AddZahtevUpravniku(this);
            }
         }
      }
   
      private string OpisZahteva;
      private DateTime PocetakOdmora;
      private DateTime KrajOdmora;
      private int IDZahteva;
   
   }
}