/***********************************************************************
 * Module:  RukovanjeSalama.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.RukovanjeSalama
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model;
using RadSaDatotekama;

namespace PoslovnaLogika
{
   public class RukovanjeSalama
   {
       public static void inicijalizuj() 
        {
            sala.Add(new Sala(TipSale.Pregled, "A1"));
            sala.Add(new Sala(TipSale.Operaciona, "A2"));
            sala.Add(new Sala(TipSale.Pregled, "A3"));
        }
      public static bool DodajSalu(Model.Sala unetaSala)
      {
         if (sala.Contains(unetaSala))
            {
                return false;
            }
         else
            {
                sala.Add(unetaSala);
                RukovanjeDatotekama2.UpisiSale();
                OsveziKolekciju();
                return true;
            }
      }
      
      public static List<Sala> PrikaziSale()
      {
         return sala;
      }
      
      public bool Izmena(String id)
      {
            // TODO: implement
            return false;
        }
      
      public bool BrisanjeSala(String id)
      {
            List<Sala> saleBezIzbrisane = new List<Sala>();
            bool nadjena = false;
            foreach (Sala s in sala)
            {
                if (s.Id.Equals(id))
                {
                    nadjena = true;
                } else
                {
                    saleBezIzbrisane.Add(s);
                }
            }
            sala = saleBezIzbrisane;
            return nadjena;
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
        public static ObservableCollection<Sala> observableSala = new ObservableCollection<Sala>();

        public static void OsveziKolekciju()
        {
            observableSala.Clear();
            foreach (Sala sala in sala)
                observableSala.Add(sala);
        }

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

            DodajSalu(newSala);



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


        public static String pronadji()
        {

            bool postoji = false;
            int broj = 1;
            for (int i = 1; i <= sala.Count; i++)
            {

                foreach (Sala t in sala)
                {
                    if (t.Id.Equals(broj.ToString()))

                    {
                        postoji = true;
                        break;                    }


                }

                if (!postoji)
                    return broj.ToString();
                postoji = false;
                broj++;



            }
            return broj.ToString();


        }


    }
}