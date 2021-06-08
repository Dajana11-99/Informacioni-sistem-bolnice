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
    public class RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis : RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs
    {
        public static List<ZahtevZaRasporedjivanjeStatickeOpreme> ZahtevZaRasporedjivanjeStatickeOpreme = new List<ZahtevZaRasporedjivanjeStatickeOpreme>();
        public static ObservableCollection<ZahtevZaRasporedjivanjeStatickeOpreme> observableZahtevZaRasporedjivanjeStatickeOpreme = new ObservableCollection<ZahtevZaRasporedjivanjeStatickeOpreme>();
        static SalaServisInterfejs salaServis;
        RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs rukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis;
        RukovanjeStatickomOpremomServisInterfejs rukovanjeStatickomOpremomServis;
        public void Inicijalizuj()
        {
            ZahtevZaRasporedjivanjeStatickeOpreme = SkladisteZahtevZaRasporedjivanjeStatickeOpreme.UcitajZahtevZaRasporedjivanjeStatickeOpreme();
            IzvrsiZahteve();
            OsveziKolekciju();
            salaServis = Injektor.Instance.Get<SalaServisInterfejs>(typeof(SalaServisInterfejs));
            rukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis = Injektor.Instance.Get<RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs>(typeof(RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs));
            rukovanjeStatickomOpremomServis = Injektor.Instance.Get<RukovanjeStatickomOpremomServisInterfejs>(typeof(RukovanjeStatickomOpremomServisInterfejs));
        }
        public bool DodajZahtevIzDrugeSale(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            Sala sala = salaServis.PretraziPoId(zahtev.IzProstorijaId);
            if (!RasporedjenaStatickaOpremaPosoji(zahtev))
                return false;
            if (!SalaPosedujeDovoljnuKolicinuStatickeOpreme(zahtev, sala.RasporedjenaStatickaOprema))
                return false;
            return AzuriranjeZahtevSala(zahtev, sala);
        }
        public bool AzuriranjeZahtevSala(ZahtevZaRasporedjivanjeStatickeOpreme zahtev, Sala sala)
        {
            RasporedjenaStatickaOpremaSale(zahtev, sala.RasporedjenaStatickaOprema).Kolicina -= zahtev.Kolicina;
            salaServis.Izmena(sala);
            AzuriranjeZahteva(zahtev);
            IzvrsiZahteve();
            OsveziKolekciju();
            return true;
        }
        public bool SalaPosedujeDovoljnuKolicinuStatickeOpreme(ZahtevZaRasporedjivanjeStatickeOpreme zahtev, List<RasporedjenaStatickaOprema> rasporedjenaStatickaOprema)
        {
            if (RasporedjenaStatickaOpremaSale(zahtev, rasporedjenaStatickaOprema).Kolicina < zahtev.Kolicina)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                return false;
            }
            return true;
        }
        public bool RasporedjenaStatickaOpremaPosoji(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            Sala sala = salaServis.PretraziPoId(zahtev.IzProstorijaId);
            List<RasporedjenaStatickaOprema> rasporedjena = sala.RasporedjenaStatickaOprema;
            if (rasporedjena == null || RasporedjenaStatickaOpremaSale(zahtev, rasporedjena) == null)
            {
                MessageBox.Show($"Nema rasporedjene te opreme u toj sali");
                return false;
            }
            return true;
        }
        public RasporedjenaStatickaOprema RasporedjenaStatickaOpremaSale(ZahtevZaRasporedjivanjeStatickeOpreme zahtev, List<RasporedjenaStatickaOprema> rasporedjena)
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
        public bool DodajStatickuOpremuIzSkladista(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            if (!SkladistePosedujeDovoljnuKolicinuStatickeOpreme(zahtev))
                return false;
            AzuriranjeStatickeOpremeSkladista(zahtev);
            AzuriranjeZahteva(zahtev);
            IzvrsiZahteve();
            OsveziKolekciju();
            return true;
        }      
        public  void AzuriranjeZahteva(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            ZahtevZaRasporedjivanjeStatickeOpreme.Add(zahtev);
            SkladisteZahtevZaRasporedjivanjeStatickeOpreme.UpisiZahtevZaRasporedjivanjeStatickeOpreme();
        }

        public  void AzuriranjeStatickeOpremeSkladista(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            StatickaOprema oprema = rukovanjeStatickomOpremomServis.PretraziPoId(zahtev.StatickeOpremaId);
            oprema.kolicina -= zahtev.Kolicina;
            rukovanjeStatickomOpremomServis.IzmeniStatickuOpremu(oprema);
        }

        public bool SkladistePosedujeDovoljnuKolicinuStatickeOpreme(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            if (rukovanjeStatickomOpremomServis.PretraziPoId(zahtev.StatickeOpremaId).kolicina < zahtev.Kolicina
               || rukovanjeStatickomOpremomServis.PrikaziStatickuOpremu() == null)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                return false;
            }
            return true;
        }

        public List<ZahtevZaRasporedjivanjeStatickeOpreme> PrikaziStatickuOpremu()
        {
            return ZahtevZaRasporedjivanjeStatickeOpreme;
        }        
        public bool ObrisiZahtevZaRasporedjivanjeStatickeOpreme(String id)
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

        public ZahtevZaRasporedjivanjeStatickeOpreme PretraziPoId(string id)
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
        public  void IzvrsiZahteve()
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

        public Sala SalaPosedujeStatickuOprepu(ZahtevZaRasporedjivanjeStatickeOpreme zahtev)
        {
            var sala = salaServis.PretraziPoId(zahtev.ProstorijaId);
            if (sala.RasporedjenaStatickaOprema == null)
            {
                sala.RasporedjenaStatickaOprema = new List<RasporedjenaStatickaOprema>();
            }

            return sala;
        }

        public  void DodavanjeStatickeOpremeSali(ZahtevZaRasporedjivanjeStatickeOpreme zahtev, Sala sala)
        {
            var rasporedjenaOprema = rukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis.RasporedjenaStatickaOpremaSale(zahtev, sala.RasporedjenaStatickaOprema);
            if (rasporedjenaOprema != null)
            {
                rasporedjenaOprema.Kolicina += zahtev.Kolicina;
            }
            else
            {
                rasporedjenaOprema = new RasporedjenaStatickaOprema();
                rasporedjenaOprema.Kolicina = zahtev.Kolicina;
                rasporedjenaOprema.RasporedjenaOd = zahtev.RasporedjenoOd;
                rasporedjenaOprema.statickaOprema = rukovanjeStatickomOpremomServis.PretraziPoId(zahtev.StatickeOpremaId);
                sala.RasporedjenaStatickaOprema.Add(rasporedjenaOprema);
            }
        }

        public  String pronadji()
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