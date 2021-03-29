/***********************************************************************
 * Module:  Termin.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.Termin
 ***********************************************************************/

using System;

namespace Model
{
   public class Termin
   {
      public Sala sala;
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
               oldLekar.RemoveTermin(this);
            }
            if (newLekar != null)
            {
               this.lekar = newLekar;
               this.lekar.AddTermin(this);
            }
         }
      }
      public Pacijent pacijent;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Pacijent GetPacijent()
      {
         return pacijent;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newPacijent</param>
      public void SetPacijent(Pacijent newPacijent)
      {
         if (this.pacijent != newPacijent)
         {
            if (this.pacijent != null)
            {
               Pacijent oldPacijent = this.pacijent;
               this.pacijent = null;
               oldPacijent.RemoveTermin(this);
            }
            if (newPacijent != null)
            {
               this.pacijent = newPacijent;
               this.pacijent.AddTermin(this);
            }
         }
      }
   
      private DateTime Vreme;
      private TipTermina TipTermina;
      private String IdTrmina;
   
   }
}