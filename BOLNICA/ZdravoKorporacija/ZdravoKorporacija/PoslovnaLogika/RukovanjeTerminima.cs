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
       public List<Termin> zakazani = new List<Termin>();
      public bool ZakaziPregled(Termin terminT)
      {
            // TODO: implement
            zakazani.Add(terminT);
            return false;
        }
      
      public List<Termin> PrikaziPregled()
      {
         // TODO: implement
         return null;
      }
      
      public bool ZakaziOperaciju()
      {
            // TODO: implement
            return false;
        }
      
      public bool OtkaziOperaciju(int idTermina)
      {
            // TODO: implement
            return false;
        }
      
      public List<Termin> PrikaziZakazanihOperacija()
      {
         // TODO: implement
         return null;
      }
      
      public bool PomeranjePregleda(int idTermina)
      {
            // TODO: implement
            return false;
        }
      
      public bool PomeranjeOperacija(int idTermina)
      {
            // TODO: implement
            return false;
        }
      
      public bool OtkaziPregled(int idTermina)
      {
            // TODO: implement
            return false;
        }
      
      public Termin PretragaPoId(String idTermina)
      {
            // TODO: implement
            return null;
        }
      
      public Termin PretraziPoVremenu(DateTime vreme)
      {
         // TODO: implement
         return null;
      }
   
   }
}