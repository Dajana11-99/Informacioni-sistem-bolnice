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
       public RukovanjeSalama()
        {
            sala.Add(new Sala(TipSale.Pregled, "A1"));
            sala.Add(new Sala(TipSale.Operaciona, "A2"));
            sala.Add(new Sala(TipSale.Pregled, "A3"));
        }
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
      
      public bool Izmena(String id)
      {
            // TODO: implement
            return false;
        }
      
      public bool BrisanjeSala(String id)
      {
            // TODO: implement
            return false;
        }
      
      public  static Sala PretraziPoId(String id)
      {
           foreach(Sala s in sala)
            {
                if (s.Id.Equals(id))
                {
                    return s;
                }
            }
            return null;
      }

        public  static List<Sala> sala = new List<Sala>();
      
      
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
      public static void AddSala(Model.Sala newSala)
      {
         if (newSala == null)
            return;
         if (sala == null)
            sala = new List<Sala>();
         if (!sala.Contains(newSala))
             sala.Add(newSala);

         
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveSala(Model.Sala oldSala)
      {
         if (oldSala == null)
            return;
         if (sala != null)
            if (sala.Contains(oldSala))
               sala.Remove(oldSala);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllSala()
      {
         if (sala != null)
            sala.Clear();
      }
   
   }
}