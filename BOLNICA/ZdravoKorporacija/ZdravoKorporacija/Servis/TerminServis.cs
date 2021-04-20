/***********************************************************************
 * Module:  RukovanjeTerminima.cs
 * Author:  filip
 * Purpose: Definition of the Class PoslovnaLogika.RukovanjeTerminima
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using ZdravoKorporacija;
using ZdravoKorporacija.PacijentPrikaz;
using ZdravoKorporacija.Repozitorijum;

namespace Servis
{
    public class TerminServis
    {
        public static List<Termin> zakazani = new List<Termin>();

        public static List<Lekar> pom = new List<Lekar>();
        public static List<Termin> SlobodniTermini = new List<Termin>();
        public static void inicijalizuj()
        {

            pom.Add(new Lekar("L1", false, Specijalizacija.Ostapraksa,"Pera","Peric","2711999105018","dajanazlokapa@gmail.com", new AdresaStanovanja("Ljubice Ravasi","2A"),new Korisnik("pera.peric","pera.peric")));
            pom.Add(new Lekar("L2", false, Specijalizacija.Ostapraksa,"Stefan","Markovic","3008997181967","stefan.markovic@gmail.com", new AdresaStanovanja("Laze Lazarevica", " 43"), new Korisnik("stefan.markovic", "stefan.markovic")));
            pom.Add(new Lekar("L3", false, Specijalizacija.Ostapraksa,"Nikola","Nikolic","2401965194820","nikola.nikolic@gmail.com", new AdresaStanovanja("Patrijarha Pavla"," 23"), new Korisnik("nikola.markovic", "nikola.markovic")));
            pom.Add(new Lekar("L4", false, Specijalizacija.Ostapraksa, "Marko", "Markovic", "65395728557", "marko.markovic@gmail.com", new AdresaStanovanja("Mihajla Pupina"," 12"), new Korisnik("marko.markovic", "marko.markovic")));
            pom.Add(new Lekar("L5", false, Specijalizacija.Kardiolog,"Milan","Djenic","5686323676","milan.djenic@gmail.com", new AdresaStanovanja("Narodnih heroja","32"), new Korisnik("milan.markovic", "milan.markovic")));
            pom.Add(new Lekar("l6", false, Specijalizacija.Stomatolog,"Petar","Petrovic","6583892377523","petar.petrovic@gmail.com", new AdresaStanovanja("Ustanicka", "8"), new Korisnik("petar.markovic", "petar.markovic")));

        }

        public static void inicijalizujSlobodneTermine()
        {

            SlobodniTermini.Add(new Termin("6", TipTermina.Pregled, "16:30", 30, "21/04/2021", SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L1")));
            SlobodniTermini.Add(new Termin("7", TipTermina.Pregled, "18:30", 30, "21/04/2021", SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L1")));
            SlobodniTermini.Add(new Termin("8", TipTermina.Pregled, "18:30", 30, "22/04/2021", SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L1")));
            SlobodniTermini.Add(new Termin("9", TipTermina.Pregled, "16:30", 30, "23/04/2021", SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L1")));
            SlobodniTermini.Add(new Termin("10", TipTermina.Pregled, "16:30", 30, "26/04/2021", SalaServis.PretraziPoId("a3"), null, PretragaLekaraPoID("L1")));


           


            SlobodniTermini.Add(new Termin("1", TipTermina.Pregled, "16:30", 30, "21/04/2021", SalaServis.PretraziPoId("A2"), null, PretragaLekaraPoID("L4")));
           SlobodniTermini.Add(new Termin("2", TipTermina.Pregled, "18:30", 30, "21/04/2021", SalaServis.PretraziPoId("A2"), null, PretragaLekaraPoID("L4")));
           SlobodniTermini.Add(new Termin("3", TipTermina.Pregled, "18:30", 30, "22/04/2021", SalaServis.PretraziPoId("A2"), null, PretragaLekaraPoID("L4")));
           SlobodniTermini.Add(new Termin("4", TipTermina.Pregled, "16:30", 30, "23/04/2021", SalaServis.PretraziPoId("A2"), null, PretragaLekaraPoID("L4")));
           SlobodniTermini.Add(new Termin("5", TipTermina.Pregled, "16:30", 30, "26/04/2021", SalaServis.PretraziPoId("A2"), null, PretragaLekaraPoID("L4")));



            SlobodniTermini.Add(new Termin("11", TipTermina.Pregled, "16:30", 30, "21/04/2021", SalaServis.PretraziPoId("A1"), null, PretragaLekaraPoID("L2")));
            SlobodniTermini.Add(new Termin("12", TipTermina.Pregled, "18:30", 30, "21/04/2021", SalaServis.PretraziPoId("A1"), null, PretragaLekaraPoID("L2")));
            SlobodniTermini.Add(new Termin("13", TipTermina.Pregled, "18:30", 30, "22/04/2021", SalaServis.PretraziPoId("A1"), null, PretragaLekaraPoID("L2")));
            SlobodniTermini.Add(new Termin("14", TipTermina.Pregled, "16:30", 30, "23/04/2021", SalaServis.PretraziPoId("A1"), null, PretragaLekaraPoID("L2")));
            SlobodniTermini.Add(new Termin("15", TipTermina.Pregled, "16:30", 30, "26/04/2021", SalaServis.PretraziPoId("A1"), null, PretragaLekaraPoID("L2")));








        }

        public static List<Termin> nadjiVremeTermina(Termin izabraniTermin)
        {
            List<Termin> pomocna = new List<Termin>();
            List<Termin> pomocna2 = new List<Termin>();
            foreach (Termin t in SlobodniTermini)
            {

                if (t.Datum.Equals(izabraniTermin.Datum) && izabraniTermin.Lekar.korisnik.KorisnickoIme.Equals(t.Lekar.korisnik.KorisnickoIme))
                {
                    pomocna.Add(t);


                    
                }


            }
            bool nasao = false;
            foreach (Termin ter1 in pomocna)
            {
                nasao = false;
                foreach (Termin ter2 in pomocna2)
                {
                    if (ter2.Vreme.Equals(ter1.Vreme))
                    {
                        nasao = true;
                        break;
                    }
                }
                if (!nasao)
                {

                    pomocna2.Add(ter1);
                    
                }

            }

            List<Termin> vreme = pomocna2.OrderBy(user => DateTime.ParseExact(user.Vreme, "HH:mm", null)).ToList();
            return vreme;
        }


        public static List<Termin> prikaziSlobodneTermine()
        {
            return SlobodniTermini;
        }
     

        public static List<Termin> nadjiSlobodneDatumeLekarauIntervalu(DateTime pocetak,DateTime kraj, String id)
        {
            List<Termin> datumi = new List<Termin>();
            List<Termin> povratna = new List<Termin>();

            datumi = nadjiDatumUIntervalu(pocetak, kraj);

          
            foreach(Termin d in datumi)
            {
               
                if (d.Lekar.idZaposlenog.Equals(id))
                {
                   
                    povratna.Add(d);
                }
            }


            return  povratna;


        }
        public static Termin pretraziSlobodnePoId(String id)
        {
            foreach(Termin t in SlobodniTermini)
            {
                if (t.IdTermina.Equals(id))
                {
                    return t;
                }
            }
            return null;
        }
        public static List<Termin> nadjiDatumUIntervalu(DateTime pocetak,DateTime kraj)
        {
            List<Termin> pomocna1 = new List<Termin>();
          
            foreach (Termin  t in SlobodniTermini)
            {
                DateTime datum = DateTime.ParseExact(t.Datum, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (DateTime.Compare(datum, pocetak) >= 0 && DateTime.Compare(datum, kraj) <= 0)
                {
                    pomocna1.Add(t);
                }
            }
            List<Termin> sortiraniDatumi = pomocna1.OrderBy(user => DateTime.ParseExact(user.Datum, "dd/MM/yyyy", null)).ToList();

            return sortiraniDatumi;
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
        public static Lekar PretragaPoLekaru(String ime,String prezime)
        {
            bool pomocni=false;
            foreach(Lekar l in pom)
            {
                if (l.Ime.Equals(ime) && l.Prezime.Equals(prezime))
                {

                    return l;
                    break;
                }

               

               
              
            }
            return null;
        }
        public static bool ZakaziPregled(Termin terminT)
        {

           
            zakazani.Add(terminT);
              //RasporedTermina.TerminiPacijenta.Add(terminT);
            SlobodniTermini.Remove(terminT);
          
            TerminRepozitorijum.upisiSlobodneTermine();
            TerminRepozitorijum.upisiTermine();
            if (zakazani.Contains(terminT))
            {
                return true;
            }
            return false;
        }
        public static String pronadji()
        {

            bool postoji = false;
            int broj = 1;
            for (int i = 1; i <= zakazani.Count; i++)
            {

                foreach (Termin t in zakazani)
                {
                    if (t.IdTermina.Equals(broj.ToString()))

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

        public static List<Termin> PrikaziSveTermine()
        {

            return zakazani;
        }

        public static bool ZakaziTermin(Termin terminT)
        {

            zakazani.Add(terminT);
            LekarWindow.TerminiLekara.Add(terminT);
            if (zakazani.Contains(terminT))
            {
                return true;
            }
            return false;
        }
        public static bool OtkaziTermin(String idTermina)
        {

            Termin t = PretragaPoId(idTermina);
            zakazani.Remove(t);
            LekarWindow.TerminiLekara.Remove(t);
            if (zakazani.Contains(t))
                return false;
            return true;
        }

      /*  public static bool IzmenaPregleda(String idTermina, String lekar, String datum, String vreme)
        {
            Termin t = PretragaPoId(idTermina);
            String[] pomm = lekar.Split(' ');
            Termin tp = PretragaPoId(idTermina);
            tp.Lekar= PretragaPoLekaru(pomm[0], pomm[1]);

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
            int ind = PrikazTerminaPacijenta.TerminiPacijenta.IndexOf(t);
            PrikazTerminaPacijenta.TerminiPacijenta.RemoveAt(ind);
            PrikazTerminaPacijenta.TerminiPacijenta.Insert(ind, t);
            return true;

        }
      */
        public static bool IzmenaTermina(String idTermina, String datum, String vreme, String lekar, String predvidjenoVreme, String BrOperaioneSale,  String vrstaTerminaOperacije)
        {
            Termin t = PretragaPoId(idTermina);
            String[] pomm = lekar.Split(' ');
            Termin tp = PretragaPoId(idTermina);
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
            if (!t.trajanjeTermina.Equals(predvidjenoVreme))
            {
                t.trajanjeTermina = double.Parse(predvidjenoVreme);

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
        public static bool OtkaziPregled(String idTermina)
        {
            Termin t = PretragaPoId(idTermina);
            zakazani.Remove(t);
            t.Pacijent = null;
            SlobodniTermini.Add(t);

            RasporedTermina.TerminiPacijenta.Remove(t);
            if (zakazani.Contains(t))
                return false;
            return true;

        }

        public static Termin PretragaPoId(String idTermina)
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


        public TerminRepozitorijum terminRepozitorijum;
    }
}