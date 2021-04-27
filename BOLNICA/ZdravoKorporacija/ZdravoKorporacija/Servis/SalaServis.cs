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
using ZdravoKorporacija;
using ZdravoKorporacija.Repozitorijum;

namespace Servis
{
   public class SalaServis
   {
       public static void inicijalizuj() 
        {
            sala = SalaRepozitorijum.UcitajSale();
            OsveziKolekciju();
        }
        public static Sala PretraziPoTipu(TipSale tip)
        {
            Sala salaa = null;
            foreach (Sala s in sala)
            {

                if (s.TipSale.Equals(tip))
                    salaa = s;
                break;
               
            }

            return salaa;
                
            

           
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
                SalaRepozitorijum.UpisiSale();
                OsveziKolekciju();
                return true;
            }
      }


        public static List<Sala> PrikaziSale()
      {
         return sala;
      }

        public static bool DaLiJeSalaSlobodna(Sala sala, DateTime termin)
        {
            if(sala.Renoviranja == null || sala.Renoviranja.Count == 0)
            {
                return false;
            } 
            foreach(Renoviranje renoviranje in sala.Renoviranja)
            {
                // ponde do petka
                // ili pre pon ili posle petka
                if (renoviranje.RenoviranjeOd >= termin && renoviranje.RenoviranjeDo <= termin)
                {
                    return false;
                }
            }
            return true;
        }
      
      public static bool Izmena(Sala salaZaIzmenu)
      {
            foreach (Sala s in sala)
            {
                if (s.Id.Equals(salaZaIzmenu.Id))
                {
                    s.sprat = salaZaIzmenu.sprat;
                    s.TipSale = salaZaIzmenu.TipSale;
                    s.Zauzeta = salaZaIzmenu.Zauzeta;
                    s.RasporedjenaDinamickaOprema = salaZaIzmenu.RasporedjenaDinamickaOprema;
                    s.RasporedjenaStatickaOprema = salaZaIzmenu.RasporedjenaStatickaOprema;
                    s.Renoviranja = salaZaIzmenu.Renoviranja;
                }
              
            }
            SalaRepozitorijum.UpisiSale();
            OsveziKolekciju();

            return true;
        }
      
      public static bool BrisanjeSala(String id)
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
            OsveziKolekciju();
            SalaRepozitorijum.UpisiSale();
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

        public ZdravoKorporacija.Repozitorijum.SalaRepozitorijum salaRepozitorijum;
    }
}