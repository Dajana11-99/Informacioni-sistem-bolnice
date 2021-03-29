/***********************************************************************
 * Module:  RukovanjeTerminima.cs
 * Author:  filip
 * Purpose: Definition of the Class PoslovnaLogika.RukovanjeTerminima
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using ZdravoKorporacija;

namespace PoslovnaLogika
{
   public class RukovanjeTerminima
   {
       public static List<Termin> zakazani = new List<Termin>();
      public static bool ZakaziPregled(Termin terminT)
      {

            zakazani.Add(terminT);
            PrikazTerminaPacijenta.TerminiPacijenta.Add(terminT);
            if (zakazani.Contains(terminT))
            {
                return true;
            }
            return false;
        }
        public static String pronadji()
        {
            String povratni = null;
            bool postoji=false;
           int broj  = 1;
            for (int i = 1; i <= zakazani.Count; i++)
            {

                foreach (Termin t in zakazani)
                {
                    if (t.IdTermina.Equals( broj.ToString()))

                    {
                        postoji = true;
                        break;
                    }


                }
                 
                if (!postoji) 
                    return broj.ToString();
                postoji = false;
                broj++;
             

            }
            return  broj.ToString() ;
           
           
        }
      
      public static List<Termin> PrikaziSveTermine()
      {

            return zakazani;
      }
      
      public bool ZakaziTermin()
      {
           
            return false;
        }
      
      public bool OtkaziTermin(String idTermina)
      {
            
            return false;
        }
    
      public bool IzmenaPregleda(String idTermina)
      {
            // TODO: implement
            return false;
        }
      
      public bool IzmenaTermina(String idTermina)
      {
            // TODO: implement
            return false;
        }
      
      public  static bool OtkaziPregled(String idTermina)
      {
            Termin t = PretragaPoId(idTermina);
            zakazani.Remove(t);
            PrikazTerminaPacijenta.TerminiPacijenta.Remove(t);
            if (zakazani.Contains(t)) 
                return false;
            return true;
                
        }
      
      public  static Termin PretragaPoId(String idTermina)
      {
            foreach (Termin t in zakazani)
            {
                if (t.IdTermina.Equals(idTermina))
                {
                    return t;
                }
            }
            return null;
        }
      
      public Termin PretraziPoVremenu(DateTime vreme)
      {
         // TODO: implement
         return null;
      }
   
   }
}