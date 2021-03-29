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

        public static List<Lekar> pom= new List<Lekar>();
        public  static void inicijalizuj()
        {
            
            pom.Add(new Lekar("Dajana Zlokapa",false,Specijalizacija.Ostapraksa));
            pom.Add(new Lekar("Stefan Markovic ",false,Specijalizacija.Neurohirurg));
            pom.Add(new Lekar("Nikola Nikolic ",false,Specijalizacija.Ostapraksa));
            pom.Add(new Lekar(" Marko Markovic",false,Specijalizacija.Ostapraksa));
          

           


                
        }
        public static Lekar PretragaLekaraPoID(String id)
        {
            foreach (Lekar l in pom)
            {
                if (l.idZaposlenog.Equals(id))
                {
                    return l;
                }
                
            }
            return null;
        }
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
    
      public  static bool IzmenaPregleda(String idTermina,String lekar,String datum,String vreme)
      {
            Termin t = PretragaPoId(idTermina);
            if (!t.Lekar.idZaposlenog.Equals(lekar))
            {
                t.Lekar = PretragaLekaraPoID(lekar);
            }
            if (!t.Datum.Equals(datum))
            {
                t.Datum = datum;
            }
            if (!t.Vreme.Equals(vreme))
            {
                t.Vreme = vreme;
            }
            int ind = PrikazTerminaPacijenta.TerminiPacijenta.IndexOf(t);
            PrikazTerminaPacijenta.TerminiPacijenta.RemoveAt(ind);
            PrikazTerminaPacijenta.TerminiPacijenta.Insert(ind, t);
            return true;
            
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