/***********************************************************************
 * Module:  RukovanjeSalama.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.RukovanjeSalama
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;

namespace PoslovnaLogika
{
   public class RukovanjeSalama
   {
      public bool DodajSalu(Model.Sala unetaSala)
      {
         // TODO: implement
         return false;
      }
      
      public List<Sala> PrikaziSale()
      {
         // TODO: implement
         return null;
      }
      
      public bool Izmena(int id)
      {
            // TODO: implement
            return false;
        }
      
      public bool BrisanjeSala(int id)
      {
            // TODO: implement
            return false;
        }
      
      public Sala PretraziPoId(int id)
      {
         // TODO: implement
         return null;
      }

        public List<Sala> sala = new List<Sala>();
      
      /// <pdGenerated>default getter</pdGenerated>
      public List<Sala> GetSala()
      {
         return sala;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetSala(List<Sala> newSala)
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
            this.sala = new List<Sala>();
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