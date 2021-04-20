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
using ZdravoKorporacija.Repozitorijum;

namespace Servis
{
    public class RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis
    {
        public static List<ZahtevZaRasporedjivanjeStatickeOpreme> ZahtevZaRasporedjivanjeStatickeOpreme = new List<ZahtevZaRasporedjivanjeStatickeOpreme>();
        public static ObservableCollection<ZahtevZaRasporedjivanjeStatickeOpreme> observableZahtevZaRasporedjivanjeStatickeOpreme = new ObservableCollection<ZahtevZaRasporedjivanjeStatickeOpreme>();
        public static void inicijalizuj()
        {
            ZahtevZaRasporedjivanjeStatickeOpreme = SkladisteZahtevZaRasporedjivanjeStatickeOpreme.UcitajZahtevZaRasporedjivanjeStatickeOpreme();
            OsveziKolekciju();
        }

        private static bool DodajZahtevIzDrugeSale(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            var sala = SalaServis.PretraziPoId(zahtev.IzProstorijaId);
            var rasporedjeno = sala.RasporedjenaStatickaOprema;
            if (rasporedjeno == null)
            {
                MessageBox.Show($"Nema rasporedjene te opreme u toj sali");
                return false;
            }

            RasporedjenaStatickaOprema taOpremaUTojSali = null;
            foreach (var raspodela in rasporedjeno)
            {
                if (raspodela.statickaOprema.Id == zahtev.StatickeOpremaId)
                {
                    taOpremaUTojSali = raspodela;
                }

            }

            if (taOpremaUTojSali == null)
            {
                MessageBox.Show($"Nema rasporedjene te opreme u toj sali");
                return false;
            }

            if (taOpremaUTojSali.Kolicina - zahtev.Kolicina < 0)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                return false;
            }

            taOpremaUTojSali.Kolicina -= zahtev.Kolicina;
            SalaServis.Izmena(sala);
            ZahtevZaRasporedjivanjeStatickeOpreme.Add(zahtev);
            OsveziKolekciju();
            SkladisteZahtevZaRasporedjivanjeStatickeOpreme.UpisiZahtevZaRasporedjivanjeStatickeOpreme();
            return true;
        }


        public static bool DodajStatickuOpremuProstorija(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {

            // DA Li JE IZ DRUGE PROSTORIJE?
            if (!String.IsNullOrEmpty(zahtev.IzProstorijaId))
            {
                return DodajZahtevIzDrugeSale(zahtev);
            }


            // IZ SKLADISTA

            // da li je ta oprema vec u tom rasponu negde rasporedjena?
            // da li ima dovoljno kolicine prvo?
            // 
            var statickaOprema = RukovanjeStatickomOpremomServis.PretraziPoId(zahtev.Id);

            if (statickaOprema.kolicina - zahtev.Kolicina < 0)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                return false;
            }

            statickaOprema.kolicina -= zahtev.Kolicina;
            RukovanjeStatickomOpremomServis.IzmeniStatickuOpremu(statickaOprema);
            ZahtevZaRasporedjivanjeStatickeOpreme.Add(zahtev);
            OsveziKolekciju();
            SkladisteZahtevZaRasporedjivanjeStatickeOpreme.UpisiZahtevZaRasporedjivanjeStatickeOpreme();
            return true;
        }


        public static List<ZahtevZaRasporedjivanjeStatickeOpreme> PrikaziStatickuOpremu()
        {
            return ZahtevZaRasporedjivanjeStatickeOpreme;
        }

        public static bool IzmeniStatickuOpremu(ZahtevZaRasporedjivanjeStatickeOpreme statickaOpremaZaIzmenu)
        {


            var s = PretraziPoId(statickaOpremaZaIzmenu.Id);


            var statickaOprema = RukovanjeStatickomOpremomServis.PretraziPoId(s.Id);
            var dodato = statickaOpremaZaIzmenu.Kolicina > s.Kolicina;
            var razlikaUKoliciniDodato = statickaOpremaZaIzmenu.Kolicina - s.Kolicina;
            if (dodato)
            {
                if (statickaOprema.kolicina - razlikaUKoliciniDodato < 0)
                {
                    MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine za ovaj zahtev");
                    return false;
                }
                statickaOprema.kolicina -= razlikaUKoliciniDodato;
            }
            else
            {
                // manja kolicina rasporedjna, ostatak se vraca u magacin
                var razlikaUKoliciniOduzeto = s.Kolicina - statickaOpremaZaIzmenu.Kolicina;
                statickaOprema.kolicina += razlikaUKoliciniOduzeto;
            }

            if (statickaOprema.kolicina - statickaOpremaZaIzmenu.Kolicina < 0)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                return false;
            }
            RukovanjeStatickomOpremomServis.IzmeniStatickuOpremu(statickaOprema);

            s.Kolicina = statickaOpremaZaIzmenu.Kolicina;
            s.ProstorijaId = statickaOpremaZaIzmenu.ProstorijaId;
            s.RasporedjenoOd = statickaOpremaZaIzmenu.RasporedjenoOd;

            OsveziKolekciju();
            SkladisteZahtevZaRasporedjivanjeStatickeOpreme.UpisiZahtevZaRasporedjivanjeStatickeOpreme();
            return true;
        }

        public static bool ObrisiZahtevZaRasporedjivanjeStatickeOpreme(String id)
        {
            List<ZahtevZaRasporedjivanjeStatickeOpreme> statickaOpremaBezIzbrisane = new List<ZahtevZaRasporedjivanjeStatickeOpreme>();
            bool nadjena = false;
            foreach (ZahtevZaRasporedjivanjeStatickeOpreme s in ZahtevZaRasporedjivanjeStatickeOpreme)
            {
                if (s.Id.Equals(id))
                {
                    nadjena = true;
                }
                else
                {
                    statickaOpremaBezIzbrisane.Add(s);
                }
            }
            ZahtevZaRasporedjivanjeStatickeOpreme = statickaOpremaBezIzbrisane;
            OsveziKolekciju();
            SkladisteZahtevZaRasporedjivanjeStatickeOpreme.UpisiZahtevZaRasporedjivanjeStatickeOpreme();
            return nadjena;
        }

        public static ZahtevZaRasporedjivanjeStatickeOpreme PretraziPoId(string id)
        {
            foreach (ZahtevZaRasporedjivanjeStatickeOpreme s in ZahtevZaRasporedjivanjeStatickeOpreme)
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
            observableZahtevZaRasporedjivanjeStatickeOpreme.Clear();
            foreach (ZahtevZaRasporedjivanjeStatickeOpreme so in ZahtevZaRasporedjivanjeStatickeOpreme)
                observableZahtevZaRasporedjivanjeStatickeOpreme.Add(so);
        }


        public static void IzvrsiZahteveZaDanas()
        {
            foreach (ZahtevZaRasporedjivanjeStatickeOpreme zahtev in ZahtevZaRasporedjivanjeStatickeOpreme)
            {
                if (zahtev.RasporedjenoOd >= DateTime.Now)
                {
                    continue;
                }

                ObrisiZahtevZaRasporedjivanjeStatickeOpreme(zahtev.Id);
                var sala = SalaServis.PretraziPoId(zahtev.ProstorijaId);
                if (sala.RasporedjenaStatickaOprema == null)
                {
                    sala.RasporedjenaStatickaOprema = new List<RasporedjenaStatickaOprema>();
                }
                var rasporedjenaOprema = new RasporedjenaStatickaOprema();
                rasporedjenaOprema.Kolicina = zahtev.Kolicina;
                rasporedjenaOprema.RasporedjenaOd = zahtev.RasporedjenoOd;
                rasporedjenaOprema.statickaOprema = RukovanjeStatickomOpremomServis.PretraziPoId(zahtev.StatickeOpremaId);
                sala.RasporedjenaStatickaOprema.Add(rasporedjenaOprema);
                SalaRepozitorijum.UpisiSale();
            }


        }


        public static String pronadji()
        {

            bool postoji = false;
            int broj = 1;
            for (int i = 1; i <= ZahtevZaRasporedjivanjeStatickeOpreme.Count; i++)
            {

                foreach (ZahtevZaRasporedjivanjeStatickeOpreme t in ZahtevZaRasporedjivanjeStatickeOpreme)
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