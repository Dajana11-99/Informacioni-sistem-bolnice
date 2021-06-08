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
using ZdravoKorporacija.GrafZavisnosti;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.ServisInterfejs;

namespace PoslovnaLogika
{
    public class RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis : RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs
    {
        public static List<ZahtevZaRasporedjivanjeDinamickeOpreme> rasporedjivanjeDinamickeOpremeZahtev = new List<ZahtevZaRasporedjivanjeDinamickeOpreme>();
        public static ObservableCollection<ZahtevZaRasporedjivanjeDinamickeOpreme> prikazRasporedjivanjeDinamickeOpremeZahtev = new ObservableCollection<ZahtevZaRasporedjivanjeDinamickeOpreme>();
        RukovanjeDinamickomOpremomServisInterfejs rukovanjeDinamickomOpremomServis;
        public  void Inicijalizuj()
        {
            rasporedjivanjeDinamickeOpremeZahtev = SkladisteZahtevZaRasporedjivanjeDinamickeOpreme.UcitajZahtevZaRasporedjivanjeDinamickeOpreme();
            OsveziKolekciju();
            rukovanjeDinamickomOpremomServis = Injektor.Instance.Get<RukovanjeDinamickomOpremomServisInterfejs>(typeof(RukovanjeDinamickomOpremomServisInterfejs));
        }
        public  bool DodajDinamickuOpremuProstorija(ZahtevZaRasporedjivanjeDinamickeOpreme zahtev)
        {
            if (!DovoljnoKolicineDinamickeOpreme(zahtev))
                return false;
            rukovanjeDinamickomOpremomServis.IzmeniDinamickuOpremu(IzmenaKolicineDinamickeOpreme(zahtev));
            IzmenaKolicineDinamickeOpremeProstorije(zahtev, DinamickaOpremaSalePromena(zahtev, SalaPromena(zahtev)));
            OsveziKolekciju();
            SkladisteZahtevZaRasporedjivanjeDinamickeOpreme.UpisiZahtevZaRasporedjivanjeDinamickeOpreme();
            return true;
        }
        public bool DovoljnoKolicineDinamickeOpreme(ZahtevZaRasporedjivanjeDinamickeOpreme zahtev) 
        {
            DinamickaOprema dinamickaOprema = rukovanjeDinamickomOpremomServis.PretraziPoId(zahtev.DinamickaOpremaId);
            if (dinamickaOprema.kolicina < zahtev.Kolicina)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                return false;
            }
            return true;
        }
        public Sala SalaPromena(ZahtevZaRasporedjivanjeDinamickeOpreme zahtevZaRasporedjivanjeDinamicke)
        {
            SalaServisInterfejs salaServis = Injektor.Instance.Get<SalaServisInterfejs>(typeof(SalaServisInterfejs));
            Sala sala = salaServis.PretraziPoId(zahtevZaRasporedjivanjeDinamicke.ProstorijaId);
            if (sala.RasporedjenaDinamickaOprema == null)
            {
                sala.RasporedjenaDinamickaOprema = new List<RasporedjenaDinamickaOprema>();
            }

            return sala;
        }
        private void IzmenaKolicineDinamickeOpremeProstorije(ZahtevZaRasporedjivanjeDinamickeOpreme zahtevZaRasporedjivanjeDinamicke, RasporedjenaDinamickaOprema rasporedjenaOprema)
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
                rasporedjenaOprema.dinamickaOprema = rukovanjeDinamickomOpremomServis.PretraziPoId(zahtevZaRasporedjivanjeDinamicke.DinamickaOpremaId);
                sala.RasporedjenaDinamickaOprema.Add(rasporedjenaOprema);
            }
            SalaRepozitorijum.UpisiSale();
        }
        private RasporedjenaDinamickaOprema DinamickaOpremaSalePromena(ZahtevZaRasporedjivanjeDinamickeOpreme zahtevZaRasporedjivanjeDinamicke, Sala sala)
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
        private  DinamickaOprema IzmenaKolicineDinamickeOpreme(ZahtevZaRasporedjivanjeDinamickeOpreme zahtevZaRasporedjivanjeDinamicke)
        {
            DinamickaOprema dinamickaOprema = rukovanjeDinamickomOpremomServis.PretraziPoId(zahtevZaRasporedjivanjeDinamicke.DinamickaOpremaId);
            if (!DovoljnoKolicineDinamickeOpreme(zahtevZaRasporedjivanjeDinamicke))
                return dinamickaOprema;
            dinamickaOprema.kolicina -= zahtevZaRasporedjivanjeDinamicke.Kolicina;
            rasporedjivanjeDinamickeOpremeZahtev.Add(zahtevZaRasporedjivanjeDinamicke);
            return dinamickaOprema;
        }
        public List<ZahtevZaRasporedjivanjeDinamickeOpreme> PrikaziDinamickuOpremu()
        {
            return rasporedjivanjeDinamickeOpremeZahtev;
        }
        public ZahtevZaRasporedjivanjeDinamickeOpreme PretraziPoId(string idZahteva)
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
        public void OsveziKolekciju()
        {
            prikazRasporedjivanjeDinamickeOpremeZahtev.Clear();
            foreach (ZahtevZaRasporedjivanjeDinamickeOpreme rasporedjivanjeDinamickeOpremeZahtev in rasporedjivanjeDinamickeOpremeZahtev)
                prikazRasporedjivanjeDinamickeOpremeZahtev.Add(rasporedjivanjeDinamickeOpremeZahtev);
        }
        public  String pronadji()
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