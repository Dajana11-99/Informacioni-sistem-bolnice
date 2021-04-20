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
using RadSaDatotekama;
using ZdravoKorporacija.RadSaDatotekama;

namespace PoslovnaLogika
{
    public class RukovanjeZahtevZaRasporedjivanjeDinamickeOpreme
    {
        public static List<ZahtevZaRasporedjivanjeDinamickeOpreme> ZahtevZaRasporedjivanjeDinamickeOpreme = new List<ZahtevZaRasporedjivanjeDinamickeOpreme>();
        public static ObservableCollection<ZahtevZaRasporedjivanjeDinamickeOpreme> observableZahtevZaRasporedjivanjeDinamickeOpreme = new ObservableCollection<ZahtevZaRasporedjivanjeDinamickeOpreme>();
        public static void inicijalizuj()
        {
            ZahtevZaRasporedjivanjeDinamickeOpreme = SkladisteZahtevZaRasporedjivanjeDinamickeOpreme.UcitajZahtevZaRasporedjivanjeDinamickeOpreme();
            OsveziKolekciju();
        }



        public static bool DodajDinamickuOpremuProstorija(ZahtevZaRasporedjivanjeDinamickeOpreme zahtevZaRasporedjivanjeDinamicke)
        {
            // da li je ta oprema vec u tom rasponu negde rasporedjena?
            // da li ima dovoljno kolicine prvo?
            // 
            var dinamickaOprema = RukovanjeDinamickomOpremom.PretraziPoId(zahtevZaRasporedjivanjeDinamicke.DinamickaOpremaId);

            if (dinamickaOprema.kolicina - zahtevZaRasporedjivanjeDinamicke.Kolicina < 0)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                return false;
            }
            
            dinamickaOprema.kolicina -= zahtevZaRasporedjivanjeDinamicke.Kolicina;
            RukovanjeDinamickomOpremom.IzmeniDinamickuOpremu(dinamickaOprema);
            ZahtevZaRasporedjivanjeDinamickeOpreme.Add(zahtevZaRasporedjivanjeDinamicke);
            OsveziKolekciju();
            SkladisteZahtevZaRasporedjivanjeDinamickeOpreme.UpisiZahtevZaRasporedjivanjeDinamickeOpreme();
            return true;
        }


    public static List<ZahtevZaRasporedjivanjeDinamickeOpreme> PrikaziDinamickuOpremu()
        {
            return ZahtevZaRasporedjivanjeDinamickeOpreme;
        }

        public static bool IzmeniDinamickuOpremu(ZahtevZaRasporedjivanjeDinamickeOpreme dinamickaOpremaZaIzmenu)
        {
           

            var s = PretraziPoId(dinamickaOpremaZaIzmenu.Id);
 

            var dinamickaOprema = RukovanjeDinamickomOpremom.PretraziPoId(s.DinamickaOpremaId);
            var dodato = dinamickaOpremaZaIzmenu.Kolicina > s.Kolicina;
            var razlikaUKoliciniDodato = dinamickaOpremaZaIzmenu.Kolicina - s.Kolicina;
            if (dodato)
            {
                if (dinamickaOprema.kolicina - razlikaUKoliciniDodato < 0)
                {
                    MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine za ovaj zahtev");
                    return false;
                }
                dinamickaOprema.kolicina -= razlikaUKoliciniDodato;
            } else
            {
                // manja kolicina rasporedjna, ostatak se vraca u magacin
                var razlikaUKoliciniOduzeto = s.Kolicina - dinamickaOpremaZaIzmenu.Kolicina;
                dinamickaOprema.kolicina += razlikaUKoliciniOduzeto;
            }

            if (dinamickaOprema.kolicina - dinamickaOpremaZaIzmenu.Kolicina < 0)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                return false;
            }
            RukovanjeDinamickomOpremom.IzmeniDinamickuOpremu(dinamickaOprema);

            s.Kolicina = dinamickaOpremaZaIzmenu.Kolicina;
            s.ProstorijaId = dinamickaOpremaZaIzmenu.ProstorijaId;
            s.RasporedjenoOd = dinamickaOpremaZaIzmenu.RasporedjenoOd;

            OsveziKolekciju();
            SkladisteZahtevZaRasporedjivanjeDinamickeOpreme.UpisiZahtevZaRasporedjivanjeDinamickeOpreme();
            return true;
        }

        public static bool ObrisiZahtevZaRasporedjivanjeDinamickeOpreme(String id)
        {
            List<ZahtevZaRasporedjivanjeDinamickeOpreme> dinamickaOpremaBezIzbrisane = new List<ZahtevZaRasporedjivanjeDinamickeOpreme>();
            bool nadjena = false;
            foreach (ZahtevZaRasporedjivanjeDinamickeOpreme s in ZahtevZaRasporedjivanjeDinamickeOpreme)
            {
                if (s.Id.Equals(id))
                {
                    nadjena = true;
                }
                else
                {
                    dinamickaOpremaBezIzbrisane.Add(s);
                }
            }
            ZahtevZaRasporedjivanjeDinamickeOpreme = dinamickaOpremaBezIzbrisane;
            OsveziKolekciju();
            SkladisteZahtevZaRasporedjivanjeDinamickeOpreme.UpisiZahtevZaRasporedjivanjeDinamickeOpreme();
            return nadjena;
        }

        public static ZahtevZaRasporedjivanjeDinamickeOpreme PretraziPoId(string id)
        {
            foreach (ZahtevZaRasporedjivanjeDinamickeOpreme s in ZahtevZaRasporedjivanjeDinamickeOpreme)
            {
                if (s.Id.Equals(id))
                {
                    return s;
                }
            }
            return null;
        }


        public static void OsveziKolekciju()
        {
            observableZahtevZaRasporedjivanjeDinamickeOpreme.Clear();
            foreach (ZahtevZaRasporedjivanjeDinamickeOpreme so in ZahtevZaRasporedjivanjeDinamickeOpreme)
                observableZahtevZaRasporedjivanjeDinamickeOpreme.Add(so);
        }


        public static void IzvrsiZahteveZaDanas()
        {
            foreach (ZahtevZaRasporedjivanjeDinamickeOpreme zahtev in ZahtevZaRasporedjivanjeDinamickeOpreme)
            {
                if (zahtev.RasporedjenoOd >= DateTime.Now)
                {
                    continue;
                }

                ObrisiZahtevZaRasporedjivanjeDinamickeOpreme(zahtev.Id);
                var sala = RukovanjeSalama.PretraziPoId(zahtev.ProstorijaId);
                if (sala.RasporedjenaDinamickaOprema == null)
                {
                    sala.RasporedjenaDinamickaOprema = new List<RasporedjenaDinamickaOprema>();
                }

                // 
                // da li je ovaj tip/vrsta opreme vec tu?
                // ako jeste samo uvecaj kolicinu
                RasporedjenaDinamickaOprema rasporedjenaOprema = null;
                foreach (var rasporedjena in sala.RasporedjenaDinamickaOprema)
                {
                    if (rasporedjena.dinamickaOprema.Id == zahtev.DinamickaOpremaId)
                    {
                        rasporedjenaOprema = rasporedjena;
                        break;
                    }
                }
                // ako smo je nasli
                // onda dodamo kolicinu iz zahteva
                if (rasporedjenaOprema != null)
                {
                    rasporedjenaOprema.Kolicina += zahtev.Kolicina;
                }
                else
                {
                    // u suprotnom je ovo nova oprema
                    rasporedjenaOprema = new RasporedjenaDinamickaOprema();
                    rasporedjenaOprema.Kolicina = zahtev.Kolicina;
                    sala.RasporedjenaDinamickaOprema.Add(rasporedjenaOprema);
                }
                rasporedjenaOprema.RasporedjenaOd = zahtev.RasporedjenoOd;
                rasporedjenaOprema.dinamickaOprema = RukovanjeDinamickomOpremom.PretraziPoId(zahtev.DinamickaOpremaId);
                SkladisteSala.UpisiSale();
            }

                
        }


        public static String pronadji()
        {

            bool postoji = false;
            int broj = 1;
            for (int i = 1; i <= ZahtevZaRasporedjivanjeDinamickeOpreme.Count; i++)
            {

                foreach (ZahtevZaRasporedjivanjeDinamickeOpreme t in ZahtevZaRasporedjivanjeDinamickeOpreme)
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