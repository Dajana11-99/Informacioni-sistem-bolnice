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



        public static bool DodajDinamickuOpremuProstorija(ZahtevZaRasporedjivanjeDinamickeOpreme unetaStatickaOprema)
        {
            // da li je ta oprema vec u tom rasponu negde rasporedjena?
            // da li ima dovoljno kolicine prvo?
            // 
            var statickaOprema = RukovanjeStatickomOpremom.PretraziPoId(unetaStatickaOprema.Id);

            if (statickaOprema.kolicina - unetaStatickaOprema.Kolicina < 0)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                return false;
            }
            
            statickaOprema.kolicina -= unetaStatickaOprema.Kolicina;
            RukovanjeStatickomOpremom.IzmeniStatickuOpremu(statickaOprema);
            ZahtevZaRasporedjivanjeDinamickeOpreme.Add(unetaStatickaOprema);
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
 

            var dinamickaOprema = RukovanjeDinamickomOpremom.PretraziPoId(s.Id);
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
                var rasporedjenaDinamickaOprema = new RasporedjenaDinamickaOprema();
                rasporedjenaDinamickaOprema.Kolicina = zahtev.Kolicina;
                rasporedjenaDinamickaOprema.RasporedjenaOd = zahtev.RasporedjenoOd;
                rasporedjenaDinamickaOprema.dinamickaOprema = RukovanjeDinamickomOpremom.PretraziPoId(zahtev.DinamickaOpremaId);
                sala.RasporedjenaDinamickaOprema.Add(rasporedjenaDinamickaOprema);
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