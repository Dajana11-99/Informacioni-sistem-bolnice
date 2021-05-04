/***********************************************************************
 * Module:  RukovanjeSalama.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.RukovanjeSalama
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Model;
using Servis;
using ZdravoKorporacija.Repozitorijum;

namespace PoslovnaLogika
{
    public class RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis
    {
        public static List<ZahtevZaRasporedjivanjeDinamickeOpreme> rasporedjivanjeDinamickeOpremeZahtev = new List<ZahtevZaRasporedjivanjeDinamickeOpreme>();
        public static ObservableCollection<ZahtevZaRasporedjivanjeDinamickeOpreme> prikazRasporedjivanjeDinamickeOpremeZahtev = new ObservableCollection<ZahtevZaRasporedjivanjeDinamickeOpreme>();
        public static void Inicijalizuj()
        {
            rasporedjivanjeDinamickeOpremeZahtev = SkladisteZahtevZaRasporedjivanjeDinamickeOpreme.UcitajZahtevZaRasporedjivanjeDinamickeOpreme();
            OsveziKolekciju();
        }
        public static bool DodajDinamickuOpremuProstorija(ZahtevZaRasporedjivanjeDinamickeOpreme zahtev)
        {
            if (!DovoljnoKolicineDinamickeOpreme(zahtev))
                return false;
            RukovanjeDinamickomOpremomServis.IzmeniDinamickuOpremu(IzmenaKolicineDinamickeOpreme(zahtev));
            IzmenaKolicineDinamickeOpremeProstorije(zahtev, DinamickaOpremaSalePromena(zahtev, SalaPromena(zahtev)));
            OsveziKolekciju();
            SkladisteZahtevZaRasporedjivanjeDinamickeOpreme.UpisiZahtevZaRasporedjivanjeDinamickeOpreme();
            return true;
        }
        public static bool DovoljnoKolicineDinamickeOpreme(ZahtevZaRasporedjivanjeDinamickeOpreme zahtev) 
        {
            DinamickaOprema dinamickaOprema = RukovanjeDinamickomOpremomServis.PretraziPoId(zahtev.DinamickaOpremaId);
            if (dinamickaOprema.kolicina < zahtev.Kolicina)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                return false;
            }
            return true;
        }
        public static Sala SalaPromena(ZahtevZaRasporedjivanjeDinamickeOpreme zahtevZaRasporedjivanjeDinamicke)
        {
            Sala sala = SalaServis.PretraziPoId(zahtevZaRasporedjivanjeDinamicke.ProstorijaId);
            if (sala.RasporedjenaDinamickaOprema == null)
            {
                sala.RasporedjenaDinamickaOprema = new List<RasporedjenaDinamickaOprema>();
            }

            return sala;
        }
        private static void IzmenaKolicineDinamickeOpremeProstorije(ZahtevZaRasporedjivanjeDinamickeOpreme zahtevZaRasporedjivanjeDinamicke, RasporedjenaDinamickaOprema rasporedjenaOprema)
        {
            Sala sala = SalaPromena(zahtevZaRasporedjivanjeDinamicke);
            if (rasporedjenaOprema != null)
            {
                rasporedjenaOprema.Kolicina += zahtevZaRasporedjivanjeDinamicke.Kolicina;
            }
            else
            {
                rasporedjenaOprema = new RasporedjenaDinamickaOprema();
                rasporedjenaOprema.Kolicina = zahtevZaRasporedjivanjeDinamicke.Kolicina;
                rasporedjenaOprema.dinamickaOprema = RukovanjeDinamickomOpremomServis.PretraziPoId(zahtevZaRasporedjivanjeDinamicke.DinamickaOpremaId);
                sala.RasporedjenaDinamickaOprema.Add(rasporedjenaOprema);
            }
            SalaRepozitorijum.UpisiSale();
        }
        private static RasporedjenaDinamickaOprema DinamickaOpremaSalePromena(ZahtevZaRasporedjivanjeDinamickeOpreme zahtevZaRasporedjivanjeDinamicke, Sala sala)
        {
            RasporedjenaDinamickaOprema rasporedjenaOprema = null;
            foreach (var rasporedjena in sala.RasporedjenaDinamickaOprema)
            {
                if (rasporedjena.dinamickaOprema.Id == zahtevZaRasporedjivanjeDinamicke.DinamickaOpremaId)
                {
                    rasporedjenaOprema = rasporedjena;
                    break;
                }
            }
            return rasporedjenaOprema;
        }
        private static DinamickaOprema IzmenaKolicineDinamickeOpreme(ZahtevZaRasporedjivanjeDinamickeOpreme zahtevZaRasporedjivanjeDinamicke)
        {
            DinamickaOprema dinamickaOprema = RukovanjeDinamickomOpremomServis.PretraziPoId(zahtevZaRasporedjivanjeDinamicke.DinamickaOpremaId);
            if (!DovoljnoKolicineDinamickeOpreme(zahtevZaRasporedjivanjeDinamicke))
                return dinamickaOprema;
            dinamickaOprema.kolicina -= zahtevZaRasporedjivanjeDinamicke.Kolicina;
            rasporedjivanjeDinamickeOpremeZahtev.Add(zahtevZaRasporedjivanjeDinamicke);
            return dinamickaOprema;
        }
        public static List<ZahtevZaRasporedjivanjeDinamickeOpreme> PrikaziDinamickuOpremu()
        {
            return rasporedjivanjeDinamickeOpremeZahtev;
        }
        public static ZahtevZaRasporedjivanjeDinamickeOpreme PretraziPoId(string idZahteva)
        {
            foreach (ZahtevZaRasporedjivanjeDinamickeOpreme rasporedjivanjeDinamickeOpremeZahtev in rasporedjivanjeDinamickeOpremeZahtev)
            {
                if (rasporedjivanjeDinamickeOpremeZahtev.Id.Equals(idZahteva))
                {
                    return rasporedjivanjeDinamickeOpremeZahtev;
                }
            }
            return null;
        }
        public static void OsveziKolekciju()
        {
            prikazRasporedjivanjeDinamickeOpremeZahtev.Clear();
            foreach (ZahtevZaRasporedjivanjeDinamickeOpreme rasporedjivanjeDinamickeOpremeZahtev in rasporedjivanjeDinamickeOpremeZahtev)
                prikazRasporedjivanjeDinamickeOpremeZahtev.Add(rasporedjivanjeDinamickeOpremeZahtev);
        }
        public static String pronadji()
        {

            bool postoji = false;
            int broj = 1;
            for (int i = 1; i <= rasporedjivanjeDinamickeOpremeZahtev.Count; i++)
            {
                foreach (ZahtevZaRasporedjivanjeDinamickeOpreme t in rasporedjivanjeDinamickeOpremeZahtev)
                {
                    if (t.Id.Equals(broj.ToString()))

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
            return broj.ToString();
        }
    }
}