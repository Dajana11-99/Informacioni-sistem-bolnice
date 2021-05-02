/***********************************************************************
 * Module:  TerminKontroler.cs
 * Author:  dajan
 * Purpose: Definition of the Class Kontroler.TerminKontroler
 ***********************************************************************/

using Model;
using Servis;
using System;
using System.Collections.Generic;

namespace Kontroler
{
   public class TerminKontroler
   {
        public static bool ProveriMogucnostPomeranjaDatum(DateTime dat)
        {
            return TerminServis.ProveriMogucnostPomeranjaDatum(dat);
        }
        public static List<Termin> NadjiVremeTermina(Termin izabraniTermin)
        {
            return TerminServis.NadjiVremeTermina(izabraniTermin);
        }
        public static List<Termin> NadjiSlobodneTermineLekara(String idZaposlenog, List<Termin> datumiUIntervalu)
        {
            return TerminServis.NadjiSlobodneTermineLekara(idZaposlenog, datumiUIntervalu);
        }
        public static List<Termin> NadjiDatumUIntervalu(DateTime pocetak, DateTime kraj)
        {
            return TerminServis.NadjiDatumUIntervalu(pocetak, kraj);
        }
        public static List<Termin> PrikaziSveZakazaneTermine()
        {
            return TerminServis.PrikaziSveZakazaneTermine();
        }
        public static Termin PretraziSlobodneTerminePoId(String IdTermina)
        {
            return TerminServis.PretraziSlobodneTerminePoId(IdTermina);
        }
        public static void ZakaziPregled(Termin t)
        {
            TerminServis.ZakaziPregled(t);
        }
        public static void PomeriPregled(String id)
        {
            TerminServis.PomeriPregled(id);
        }
        public static void OtkaziPregled(String id)
        {
            TerminServis.OtkaziPregled(id);
        }
        public static Termin PretragaZakazanihTerminaPoId(String izabran)
        {
            return TerminServis.PretragaZakazanihTerminaPoId(izabran);
        }
        public static bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            return TerminServis.ProveriMogucnostPomeranjaVreme(vreme);
        }
        public TerminServis terminiServis { get; set; }

    }
}