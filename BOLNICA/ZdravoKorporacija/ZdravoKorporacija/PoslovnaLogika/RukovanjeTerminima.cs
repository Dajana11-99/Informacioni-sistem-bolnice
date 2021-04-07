/***********************************************************************
 * Module:  RukovanjeTerminima.cs
 * Author:  filip
 * Purpose: Definition of the Class PoslovnaLogika.RukovanjeTerminima
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using ZdravoKorporacija;

namespace PoslovnaLogika
{
    public class RukovanjeTerminima
    {
        public static List<Termin> zakazani = new List<Termin>();

        public static List<Lekar> pom = new List<Lekar>();
        public static void inicijalizuj()
        {

            pom.Add(new Lekar("L1", false, Specijalizacija.Ostapraksa,"Dajana","Zlokapa","2711999105018","dajanazlokapa@gmail.com", new AdresaStanovanja("Ljubice Ravasi","2A")));
            pom.Add(new Lekar("L2 ", false, Specijalizacija.Neurohirurg,"Stefan","Markovic","3008997181967","stefan.markovic@gmail.com", new AdresaStanovanja("Laze Lazarevica", " 43")));
            pom.Add(new Lekar("L3 ", false, Specijalizacija.Ostapraksa,"Nikola","Nikolic","2401965194820","nikola.nikolic@gmail.com", new AdresaStanovanja("Patrijarha Pavla"," 23")));
            pom.Add(new Lekar("L4", false, Specijalizacija.Ostapraksa, "Marko", "Markovic", "65395728557", "marko.markovic@gmail.com", new AdresaStanovanja("Mihajla Pupina"," 12")));
            pom.Add(new Lekar("L5", false, Specijalizacija.Kardiolog,"Milan","Djenic","5686323676","milan.djenic@gmail.com", new AdresaStanovanja("Narodnih heroja","32")));
            pom.Add(new Lekar("l6", false, Specijalizacija.Stomatolog,"Petar","Petrovic","6583892377523","petar.petrovic@gmail.com", new AdresaStanovanja("Ustanicka", "8")));

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
            PrikazTerminaPacijenta.TerminiPacijenta.Add(terminT);
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

        public static bool IzmenaPregleda(String idTermina, String lekar, String datum, String vreme)
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
            PrikazTerminaPacijenta.TerminiPacijenta.Remove(t);
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

    }
}