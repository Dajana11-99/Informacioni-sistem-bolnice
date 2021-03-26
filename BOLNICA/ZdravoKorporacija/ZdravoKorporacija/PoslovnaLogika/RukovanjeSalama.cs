/***********************************************************************
 * Module:  RukovanjeSalama.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.RukovanjeSalama
 ***********************************************************************/

using System;

namespace PoslovnaLogika
{
   public class RukovanjeSalama
   {
      public Boolean DodajSalu(Model.Sala unetaSala)
      {
         // TODO: implement
         return null;
      }
      
      public List<Sala> PrikaziSale()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean Izmena(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean BrisanjeSala(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Sala PretraziPoId(int id)
      {
         // TODO: implement
         return null;
      }
   
      public System.Collections.ArrayList sala;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetSala()
      {
         if (sala == null)
            sala = new System.Collections.ArrayList();
         return sala;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetSala(System.Collections.ArrayList newSala)
      {
         RemoveAllSala();
         foreach (Model.Sala oSala in newSala)
            AddSala(oSala);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddSala(Model.Sala newSala)
      {
         if (newSala == null)
            return;
         if (this.sala == null)
            this.sala = new System.Collections.ArrayList();
         if (!this.sala.Contains(newSala))
            this.sala.Add(newSala);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveSala(Model.Sala oldSala)
      {
         if (oldSala == null)
            return;
         if (this.sala != null)
            if (this.sala.Contains(oldSala))
               this.sala.Remove(oldSala);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllSala()
      {
         if (sala != null)
            sala.Clear();
      }
   
   }
}