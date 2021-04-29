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
        public static List<Termin> nadjiVremeTermina(Termin izabraniTermin)
        {
            return TerminServis.NadjiVremeTermina(izabraniTermin);
        }
        public static List<Termin> nadjiSlobodneTermineLekara(String idZaposlenog, List<Termin> datumi)
        {
            return TerminServis.NadjiSlobodneTermineLekara(idZaposlenog, datumi);
        }
        public static List<Termin> nadjiDatumUIntervalu(DateTime pocetak, DateTime kraj)
        {
            return TerminServis.NadjiDatumUIntervalu(pocetak, kraj);
        }
        public static List<Termin> PrikaziSveTermine()
        {
            return TerminServis.PrikaziSveTermine();
        }
        public static Termin pretraziSlobodnePoId(String IdTermina)
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
        public static Termin PretragaPoId(String izabran)
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