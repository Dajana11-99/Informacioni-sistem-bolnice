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
using ZdravoKorporacija.GrafZavisnosti;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.ServisInterfejs;

namespace Servis
{
    public class RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis
    {
        public static List<ZahtevZaRasporedjivanjeStatickeOpreme> ZahtevZaRasporedjivanjeStatickeOpreme = new List<ZahtevZaRasporedjivanjeStatickeOpreme>();
        public static ObservableCollection<ZahtevZaRasporedjivanjeStatickeOpreme> observableZahtevZaRasporedjivanjeStatickeOpreme = new ObservableCollection<ZahtevZaRasporedjivanjeStatickeOpreme>();
        static SalaServisInterfejs salaServis;
        public static void Inicijalizuj()
        {
            ZahtevZaRasporedjivanjeStatickeOpreme = SkladisteZahtevZaRasporedjivanjeStatickeOpreme.UcitajZahtevZaRasporedjivanjeStatickeOpreme();
            IzvrsiZahteve();
            OsveziKolekciju();
            salaServis = Injektor.Instance.Get<SalaServisInterfejs>(typeof(SalaServisInterfejs));
        }
        public static bool DodajZahtevIzDrugeSale(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            Sala sala = SalaServis.PretraziPoId(zahtev.IzProstorijaId);
            if (!RasporedjenaStatickaOpremaPosoji(zahtev))
                return false;
            if (!SalaPosedujeDovoljnuKolicinuStatickeOpreme(zahtev, sala.RasporedjenaStatickaOprema))
                return false;
            return AzuriranjeZahtevSala(zahtev, sala);
        }
        public static bool AzuriranjeZahtevSala(ZahtevZaRasporedjivanjeStatickeOpreme zahtev, Sala sala)
        {
            RasporedjenaStatickaOpremaSale(zahtev, sala.RasporedjenaStatickaOprema).Kolicina -= zahtev.Kolicina;
            salaServis.Izmena(sala);
            AzuriranjeZahteva(zahtev);
            IzvrsiZahteve();
            OsveziKolekciju();
            return true;
        }
        public static bool SalaPosedujeDovoljnuKolicinuStatickeOpreme(ZahtevZaRasporedjivanjeStatickeOpreme zahtev, List<RasporedjenaStatickaOprema> rasporedjenaStatickaOprema)
        {
            if (RasporedjenaStatickaOpremaSale(zahtev, rasporedjenaStatickaOprema).Kolicina < zahtev.Kolicina)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                return false;
            }
            return true;
        }
        public static bool RasporedjenaStatickaOpremaPosoji(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            Sala sala = SalaServis.PretraziPoId(zahtev.IzProstorijaId);
            List<RasporedjenaStatickaOprema> rasporedjena = sala.RasporedjenaStatickaOprema;
            if (rasporedjena == null || RasporedjenaStatickaOpremaSale(zahtev, rasporedjena) == null)
            {
                MessageBox.Show($"Nema rasporedjene te opreme u toj sali");
                return false;
            }
            return true;
        }
        public static RasporedjenaStatickaOprema RasporedjenaStatickaOpremaSale(ZahtevZaRasporedjivanjeStatickeOpreme zahtev, List<RasporedjenaStatickaOprema> rasporedjena)
        {
            RasporedjenaStatickaOprema opremaSalaZahtev = null;
            foreach (var raspodela in rasporedjena)
            {
                if (raspodela.statickaOprema.Id == zahtev.StatickeOpremaId)
                {
                    opremaSalaZahtev = raspodela;
                }
            }
            return opremaSalaZahtev;
        }
        public static bool DodajStatickuOpremuIzSkladista(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            if (!SkladistePosedujeDovoljnuKolicinuStatickeOpreme(zahtev))
                return false;
            AzuriranjeStatickeOpremeSkladista(zahtev);
            AzuriranjeZahteva(zahtev);
            IzvrsiZahteve();
            OsveziKolekciju();
            return true;
        }      
        public static void AzuriranjeZahteva(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            ZahtevZaRasporedjivanjeStatickeOpreme.Add(zahtev);
            SkladisteZahtevZaRasporedjivanjeStatickeOpreme.UpisiZahtevZaRasporedjivanjeStatickeOpreme();
        }

        public static void AzuriranjeStatickeOpremeSkladista(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            StatickaOprema oprema = RukovanjeStatickomOpremomServis.PretraziPoId(zahtev.StatickeOpremaId);
            oprema.kolicina -= zahtev.Kolicina;
            RukovanjeStatickomOpremomServis.IzmeniStatickuOpremu(oprema);
        }

        public static bool SkladistePosedujeDovoljnuKolicinuStatickeOpreme(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            if (RukovanjeStatickomOpremomServis.PretraziPoId(zahtev.StatickeOpremaId).kolicina < zahtev.Kolicina
               || RukovanjeStatickomOpremomServis.PrikaziStatickuOpremu() == null)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                return false;
            }
            return true;
        }

        public static List<ZahtevZaRasporedjivanjeStatickeOpreme> PrikaziStatickuOpremu()
        {
            return ZahtevZaRasporedjivanjeStatickeOpreme;
        }        
        public static bool ObrisiZahtevZaRasporedjivanjeStatickeOpreme(String id)
        {
            List<ZahtevZaRasporedjivanjeStatickeOpreme> statickaOpremaBezIzbrisane = new List<ZahtevZaRasporedjivanjeStatickeOpreme>();
            bool nadjena = false;
            foreach (ZahtevZaRasporedjivanjeStatickeOpreme zahtev in ZahtevZaRasporedjivanjeStatickeOpreme)
            {
                if (zahtev.Id.Equals(id))
                {
                    nadjena = true;

                }
                else
                {
                    statickaOpremaBezIzbrisane.Add(zahtev);
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
        public static void IzvrsiZahteve()
        {
            foreach (ZahtevZaRasporedjivanjeStatickeOpreme zahtev in ZahtevZaRasporedjivanjeStatickeOpreme)
            {
                if (zahtev.RasporedjenoOd > DateTime.Now)
                {
                    continue;
                }
                Sala sala = SalaPosedujeStatickuOprepu(zahtev);
                DodavanjeStatickeOpremeSali(zahtev, sala);
                ObrisiZahtevZaRasporedjivanjeStatickeOpreme(zahtev.Id);
                SalaRepozitorijum.UpisiSale();
            }
        }

        public static Sala SalaPosedujeStatickuOprepu(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            var sala = SalaServis.PretraziPoId(zahtev.ProstorijaId);
            if (sala.RasporedjenaStatickaOprema == null)
            {
                sala.RasporedjenaStatickaOprema = new List<RasporedjenaStatickaOprema>();
            }

            return sala;
        }

        public static void DodavanjeStatickeOpremeSali(ZahtevZaRasporedjivanjeStatickeOpreme zahtev, Sala sala)
        {
            var rasporedjenaOprema = RasporedjenaStatickaOpremaSale(zahtev, sala.RasporedjenaStatickaOprema);
            if (rasporedjenaOprema != null)
            {
                rasporedjenaOprema.Kolicina += zahtev.Kolicina;
            }
            else
            {
                rasporedjenaOprema = new RasporedjenaStatickaOprema();
                rasporedjenaOprema.Kolicina = zahtev.Kolicina;
                rasporedjenaOprema.RasporedjenaOd = zahtev.RasporedjenoOd;
                rasporedjenaOprema.statickaOprema = RukovanjeStatickomOpremomServis.PretraziPoId(zahtev.StatickeOpremaId);
                sala.RasporedjenaStatickaOprema.Add(rasporedjenaOprema);
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