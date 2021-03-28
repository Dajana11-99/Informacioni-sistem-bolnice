/***********************************************************************
 * Module:  RukovanjeTerminima.cs
 * Author:  filip
 * Purpose: Definition of the Class PoslovnaLogika.RukovanjeTerminima
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;

namespace PoslovnaLogika
{
   public class RukovanjeTerminima
   {
       public static List<Termin> zakazani = new List<Termin>();
      public bool ZakaziPregled(Termin terminT)
      { 

            return false;
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
      
      public bool OtkaziPregled(String idTermina)
      {
            // TODO: implement
            return false;
        }
      
      public Termin PretragaPoId(String idTermina)
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