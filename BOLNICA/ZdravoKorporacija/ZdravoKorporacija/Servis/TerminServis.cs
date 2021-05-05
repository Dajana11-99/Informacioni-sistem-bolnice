/***********************************************************************
 * Module:  RukovanjeTerminima.cs
 * Author:  filip
 * Purpose: Definition of the Class PoslovnaLogika.RukovanjeTerminima
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using MoreLinq;
using ZdravoKorporacija;
using ZdravoKorporacija.PacijentPrikaz;
using ZdravoKorporacija.Repozitorijum;

namespace Servis
{
    public class TerminServis
    {
        public static int MAXBR_PROMENA = 5;
        public static List<Termin> zakazaniTermini = new List<Termin>();
        public static List<Lekar> sviLekari = new List<Lekar>();
        public static List<Termin> slobodniTermini = new List<Termin>();
        /* public static void inicijalizuj()
         { 
             pom.Add(new Lekar("L1", false, Specijalizacija.Ostapraksa,"Pera","Peric","2711999105018","dajanazlokapa@gmail.com", new AdresaStanovanja("Ljubice Ravasi","2A"),new Korisnik("pera.peric","pera.peric")));
             pom.Add(new Lekar("L2", false, Specijalizacija.Ostapraksa,"Stefan","Markovic","3008997181967","stefan.markovic@gmail.com", new AdresaStanovanja("Laze Lazarevica", " 43"), new Korisnik("stefan.markovic", "stefan.markovic")));
             pom.Add(new Lekar("L3", false, Specijalizacija.Ostapraksa,"Nikola","Nikolic","2401965194820","nikola.nikolic@gmail.com", new AdresaStanovanja("Patrijarha Pavla"," 23"), new Korisnik("nikola.markovic", "nikola.markovic")));
             pom.Add(new Lekar("L4", false, Specijalizacija.Ostapraksa, "Marko", "Markovic", "65395728557", "marko.markovic@gmail.com", new AdresaStanovanja("Mihajla Pupina"," 12"), new Korisnik("marko.markovic", "marko.markovic")));
             pom.Add(new Lekar("L5", false, Specijalizacija.Kardiolog,"Milan","Djenic","5686323676","milan.djenic@gmail.com", new AdresaStanovanja("Narodnih heroja","32"), new Korisnik("milan.markovic", "milan.markovic")));
             pom.Add(new Lekar("l6", false, Specijalizacija.Stomatolog,"Petar","Petrovic","6583892377523","petar.petrovic@gmail.com", new AdresaStanovanja("Ustanicka", "8"), new Korisnik("petar.markovic", "petar.markovic")));

         }*/
       public static void inicijalizujSlobodneTermine()
        {
           
            slobodniTermini.Add(new Termin("2", TipTermina.Pregled, "16:30", 30, new DateTime(2021, 5, 8), SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L1")));
            slobodniTermini.Add(new Termin("3", TipTermina.Pregled, "16:30", 30, new DateTime(2021, 4, 29), SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L1")));
            slobodniTermini.Add(new Termin("4", TipTermina.Pregled, "16:30", 30, new DateTime(2021, 4, 28), SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L1")));
            slobodniTermini.Add(new Termin("5", TipTermina.Pregled, "16:30", 30, new DateTime(2021, 5, 9), SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L1")));
            slobodniTermini.Add(new Termin("6", TipTermina.Pregled, "19:00", 30, new DateTime(2021, 5, 11), SalaServis.PretraziPoId("A1"), null, PretragaLekaraPoID("L2")));
            slobodniTermini.Add(new Termin("7", TipTermina.Pregled, "16:30", 30, new DateTime(2021, 5, 12), SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L2")));
            slobodniTermini.Add(new Termin("8", TipTermina.Pregled, "14:30", 30, new DateTime(2021, 5, 13), SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L2")));

            slobodniTermini.Add(new Termin("9", TipTermina.Pregled, "15:30", 30, new DateTime(2021, 5, 13), SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L5")));
            slobodniTermini.Add(new Termin("10", TipTermina.Pregled, "15:30", 30, new DateTime(2021, 5, 15), SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L5")));
            slobodniTermini.Add(new Termin("11", TipTermina.Pregled, "15:30", 30, new DateTime(2021, 5, 16), SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L5")));
            slobodniTermini.Add(new Termin("12", TipTermina.Pregled, "15:30", 30, new DateTime(2021, 5, 10), SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L5")));
        }
      
        public static List<Termin> NadjiVremeTermina(Termin izabraniTermin)
        {
            List<Termin> vremeDatumaSlobodnogTermina = new List<Termin>();
            foreach (Termin termin in TerminRepozitorijum.UcitajSlobodneTermine())
            {
                if (termin.Datum.Equals(izabraniTermin.Datum) && 
                    izabraniTermin.Lekar.korisnik.KorisnickoIme.Equals(termin.Lekar.korisnik.KorisnickoIme))
                    vremeDatumaSlobodnogTermina.Add(termin);
            }
            return UkloniDupleDatume(vremeDatumaSlobodnogTermina);
        }
        public static List<Termin> PrikaziSlobodneTermine()
        {
            return slobodniTermini;
        }
        public static List<Termin> NadjiSlobodneTermineLekara(String idLekara, List<Termin> datumiUIntervalu)
        {
            List<Termin> slobodniTerminiKodLekara = new List<Termin>();
            foreach (Termin termin in datumiUIntervalu)
            {
                if (termin.Lekar.idZaposlenog.Equals(idLekara))
                    slobodniTerminiKodLekara.Add(termin);
            }
            return slobodniTerminiKodLekara;
        }
       public static Termin PretraziSlobodneTerminePoId(String idTermina)
        {
            foreach (Termin termin in TerminRepozitorijum.UcitajSlobodneTermine())
            {
                if (termin.IdTermina.Equals(idTermina))
                    return termin;
            }
            return null;
        }
        public static List<Termin> NadjiDatumUIntervalu(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            List<Termin> slobodniDatumi = new List<Termin>();
            foreach (Termin termin in TerminRepozitorijum.UcitajSlobodneTermine())
            {
                if (DateTime.Compare(termin.Datum, pocetakIntervala) >= 0
                    && DateTime.Compare(termin.Datum, krajIntervala) <= 0)
                    slobodniDatumi.Add(termin);
            }
            return SortirajTerminePoDatumu(slobodniDatumi);
        }
        public static List<Termin> SortirajTerminePoDatumu(List<Termin> nesortiraniDatumi)
        {
            return nesortiraniDatumi.OrderBy(user => user.Datum).ToList();
        }
       public static Lekar PretragaLekaraPoID(String idLekara)
        {
            foreach (Lekar lekar in sviLekari)
            {
                if (lekar.idZaposlenog.Equals(idLekara))
                    return lekar;
            }
            return null;
        }
        public static Lekar PretragaPoLekaru(String imeLekara, String prezimeLekara)
        {
            foreach (Lekar lekar in sviLekari)
            {
                if (lekar.Ime.Equals(imeLekara) && lekar.Prezime.Equals(prezimeLekara))
                    return lekar;
            }
            return null;
        }
        public static void ZakaziPregled(Termin termin)
        {
            zakazaniTermini.Add(termin);
            slobodniTermini.Remove(termin);
            SacuvajNoveTermine();
        }
        public static List<Termin> PrikaziSveZakazaneTermine()
        {
            return zakazaniTermini;
        }
        public static void ZakaziTermin(Termin termin)
        {
            zakazaniTermini.Add(termin);
            LekarWindow.TerminiLekara.Add(termin);
        }
        public static void OtkaziTermin(String idTermina)
        {
            Termin termin = PretragaZakazanihTerminaPoId(idTermina);
            zakazaniTermini.Remove(termin);
            LekarWindow.TerminiLekara.Remove(termin);
        }

        public static void PomeriPregled(String idTermina)
        {
            Termin stariTermin = PretragaZakazanihTerminaPoId(RasporedTermina.TerminZaPomeranje.IdTermina);
            stariTermin.Pacijent = null;
            Termin noviTermin = PretraziSlobodneTerminePoId(idTermina);
            noviTermin.Pacijent = NaloziPacijenataServis.pretraziPoKorisnickom(PacijentGlavniProzor.ulogovan.korisnik.KorisnickoIme);
            ProveriMalicioznostPacijenta(noviTermin.Pacijent);
            BrisanjeTabelarnogPrikaza(stariTermin, noviTermin);
        }

        private static void BrisanjeTabelarnogPrikaza(Termin stariTermin, Termin noviTermin)
        {
            ZameniTermine(stariTermin, noviTermin);
            int indeks = RasporedTermina.TerminiPacijenta.IndexOf(stariTermin);
            RasporedTermina.TerminiPacijenta.RemoveAt(indeks);
            RasporedTermina.TerminiPacijenta.Insert(indeks, noviTermin);
        }
        private static void ZameniTermine(Termin stariTermin, Termin noviTermin)
        {
            zakazaniTermini.Remove(stariTermin);
            zakazaniTermini.Add(noviTermin);
            slobodniTermini.Remove(noviTermin);
            slobodniTermini.Add(stariTermin);
            SacuvajNoveTermine();
        }
        private static void SacuvajNoveTermine()
        {
            TerminRepozitorijum.UpisiSlobodneTermine();
            TerminRepozitorijum.UpisiZakazaneTermine();
        }
        public static void ProveriMalicioznostPacijenta(Pacijent pacijent)
        {
            int broj = pacijent.Zloupotrebio + 1;
            pacijent.Zloupotrebio = broj;
            if (pacijent.Zloupotrebio > MAXBR_PROMENA)
                pacijent.Maliciozan = true;
               
        }
        public static void OtkaziPregled(String idTermina)
        {
            Termin termin = PretragaZakazanihTerminaPoId(idTermina);
            BrisanjePrikazaPosleOtkazivanja(termin);
            ProveriMalicioznostPacijenta(NaloziPacijenataServis.pretraziPoKorisnickom(PacijentGlavniProzor.ulogovan.korisnik.KorisnickoIme));
           
        }

        private static void BrisanjePrikazaPosleOtkazivanja(Termin termin)
        {
            zakazaniTermini.Remove(termin);
            termin.Pacijent = null;
            slobodniTermini.Add(termin);
            RasporedTermina.TerminiPacijenta.Remove(termin);
            SacuvajNoveTermine();
        }

        public static Lekar PretraziPoKorisnickomImenu(String korisnickoIme)
        {
            foreach(Lekar lekar in sviLekari)
            {
                if (lekar.korisnik.KorisnickoIme.Equals(korisnickoIme))
                    return lekar;
            }
            return null;
        }
       
        private static List<Termin> UkloniDupleDatume(List<Termin> dupliTermini)
        {
            List<Termin> jedinstveniTermini = new List<Termin>();
            foreach (Termin termin in dupliTermini.DistinctBy(t => t.Datum))
                jedinstveniTermini.Add(termin);
            return SortirajTerminePoPocetnomVremenu(jedinstveniTermini);
        }

        private static List<Termin> SortirajTerminePoPocetnomVremenu(List<Termin> nesortiraniTermini)
        {
            return nesortiraniTermini.OrderBy(user => DateTime.ParseExact(user.Vreme, "HH:mm", null)).ToList();
        }

        public static bool ProveriMogucnostPomeranjaDatum(DateTime datumPregleda)
        {
            if (DateTime.Compare(DateTime.Now.AddDays(1).Date, datumPregleda.Date) == 0)
                return true;
            return false;
        }

        public static bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            DateTime vremePregleda = DateTime.ParseExact(vreme, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            if (vremePregleda.Hour < DateTime.Now.Hour)
                return false;
            else if (vremePregleda.Hour == DateTime.Now.Hour && DateTime.Now.Minute == vremePregleda.Minute)
                return false;
            else if (vremePregleda.Hour == DateTime.Now.Hour && DateTime.Now.Minute > vremePregleda.Minute)
                return false;
            return true;
        }
        public static Termin PretragaZakazanihTerminaPoId(String idTermina)
        {
            foreach (Termin termin in zakazaniTermini)
            {
                if (termin.IdTermina.Equals(idTermina))
                    return termin;
            }
            return null;
        }
            public static bool IzmenaTermina(String idTermina, DateTime datum, String vreme, String lekar, String predvidjenoVreme, String BrOperaioneSale, String vrstaTerminaOperacije)
            {
                Termin t = PretragaZakazanihTerminaPoId(idTermina);
                String[] pomm = lekar.Split(' ');
                Termin tp = PretragaZakazanihTerminaPoId(idTermina);
                tp.Lekar = PretragaPoLekaru(pomm[0], pomm[1]);

                if (!t.Lekar.idZaposlenog.Equals(tp.Lekar.idZaposlenog))
                {
                    t.Lekar = PretragaLekaraPoID(tp.Lekar.idZaposlenog);
                }

                if (!t.Datum.Equals(datum))
                {
                    t.Datum = datum;
                }
                if (!t.Vreme.Equals(vreme))
                {
                    t.Vreme = vreme;
                }
                if (!t.TrajanjeTermina.Equals(predvidjenoVreme))
                {
                    t.TrajanjeTermina = double.Parse(predvidjenoVreme);

                }


                if (!t.Sala.Id.Equals(BrOperaioneSale))
                {
                    t.Sala.Id = BrOperaioneSale;
                }



                if (!t.TipTermina.Equals(vrstaTerminaOperacije))
                {
                    if (vrstaTerminaOperacije.Equals(TipTermina.Operacija))
                    {
                        t.TipTermina = TipTermina.Operacija;
                    }
                    else
                    {
                        t.TipTermina = TipTermina.Pregled;
                    }


                    int ind = LekarWindow.TerminiLekara.IndexOf(t);
                    LekarWindow.TerminiLekara.RemoveAt(ind);
                    LekarWindow.TerminiLekara.Insert(ind, t);
                }
                return true;
            }


        public TerminRepozitorijum terminRepozitorijum;
    }
}