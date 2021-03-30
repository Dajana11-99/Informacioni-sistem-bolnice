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

            pom.Add(new Lekar("Dajana Zlokapa", false, Specijalizacija.Ostapraksa));
            pom.Add(new Lekar("Stefan Markovic ", false, Specijalizacija.Neurohirurg));
            pom.Add(new Lekar("Nikola Nikolic ", false, Specijalizacija.Ostapraksa));
            pom.Add(new Lekar(" Marko Markovic", false, Specijalizacija.Ostapraksa));
            pom.Add(new Lekar(" Milan Djenic", false, Specijalizacija.Kardiolog));
            pom.Add(new Lekar(" Petar Petrovic", false, Specijalizacija.Stomatolog));

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
            if (!t.Lekar.idZaposlenog.Equals(lekar))
            {
                t.Lekar = PretragaLekaraPoID(lekar);
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

        public static bool IzmenaTermina(String idTermina, String datum, String vreme, String lekar, String predvidjenoVreme, String BrOperaioneSale, String tipSale, String vrstaTerminaOperacije)
        {
            Termin t = PretragaPoId(idTermina);
            if (!t.Lekar.idZaposlenog.Equals(lekar))
            {
                t.Lekar = PretragaLekaraPoID(lekar);
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
            if (!t.Sala.TipSale.Equals(tipSale))
            {
                if (tipSale.Equals(TipSale.Operaciona))
                {
                    t.Sala.TipSale = TipSale.Operaciona;
                }
                else if (tipSale.Equals(TipSale.Pregled))
                {
                    t.Sala.TipSale = TipSale.Pregled;
                }
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