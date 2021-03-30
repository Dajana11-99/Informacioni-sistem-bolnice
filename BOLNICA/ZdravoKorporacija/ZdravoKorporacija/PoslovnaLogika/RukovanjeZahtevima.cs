/***********************************************************************
 * Module:  RukovanjeZahtevima.cs
 * Author:  filip
 * Purpose: Definition of the Class PoslovnaLogika.RukovanjeZahtevima
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using ZdravoKorporacija;

namespace PoslovnaLogika
{
   public class RukovanjeZahtevima
   {
        public static List<ZahtevUpravniku> zahtevi = new List<ZahtevUpravniku>();



        public static List<Lekar> pomocna = new List<Lekar>();

        public static long idZahteva = 1;

        public static void inicijalizuj()
        {

            pomocna.Add(new Lekar("Dajana Zlokapa", false, Specijalizacija.Ostapraksa));
            pomocna.Add(new Lekar("Stefan Markovic ", false, Specijalizacija.Neurohirurg));
            pomocna.Add(new Lekar("Nikola Nikolic ", false, Specijalizacija.Ostapraksa));
            pomocna.Add(new Lekar(" Marko Markovic", false, Specijalizacija.Ostapraksa));
            pomocna.Add(new Lekar(" Milan Djenic", false, Specijalizacija.Kardiolog));
            pomocna.Add(new Lekar(" Petar Petrovic", false, Specijalizacija.Stomatolog));

        }

        public static Lekar PretragaLekaraPoID(String id)
        {
            foreach (Lekar l in pomocna)
            {
                if (l.idZaposlenog.Equals(id))
                {
                    return l;
                }

            }
            return null;
        }

            public static bool KreirajZahtev(ZahtevUpravniku zahtevPar)
      {
            zahtevi.Add(zahtevPar);
            ZahtevZaSlobodneDaneWindow.zahtevs.Add(zahtevPar);
            if (zahtevi.Contains(zahtevPar))
            {
                return true;
            }
            else 
            {
                return false;
            }
            
        }

        public static string nadjiIDZahteva()
        {
            long broj = idZahteva;
            idZahteva++;
            return broj.ToString();
        }
      
      public static List<ZahtevUpravniku> PrikaziZahteve()
      {
            return zahtevi;
      }
      
      public bool IzmeniZahtev(int iDZahteva)
      {
            return false;
        }
      
      public bool Obrisi(int iDZahetva)
      {
            // TODO: implement
            return false;
        }
      
      public bool PretraziZahtev(int iDZahteva)
      {
            // TODO: implement
            return false;
        }
   
   }
}