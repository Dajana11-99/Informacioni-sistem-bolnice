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
        public static bool ProveriMogucnostPomeranjaDatum(String dat) {
            return TerminServis.ProveriMogucnostPomeranjaDatum(dat);

            }


        public static List<Termin> nadjiVremeTermina(Termin izabraniTermin)
        {
            return TerminServis.nadjiVremeTermina(izabraniTermin);
        }

        public static List<Termin> nadjiSlobodneDatumeLekarauIntervalu(DateTime pocetak, DateTime kraj,String idZaposlenog)
        {
            return TerminServis.nadjiSlobodneDatumeLekarauIntervalu(pocetak, kraj, idZaposlenog);
        }

        public static List<Termin> nadjiDatumUIntervalu(DateTime pocetak, DateTime kraj)
        {
            return TerminServis.nadjiDatumUIntervalu(pocetak, kraj);
        }

        public static List<Termin> PrikaziSveTermine()
        {
            return TerminServis.PrikaziSveTermine();
        }

        public static Termin pretraziSlobodnePoId(String IdTermina)
        {
            return TerminServis.pretraziSlobodnePoId(IdTermina);
        }

        public static bool ZakaziPregled(Termin t)
        {
            return TerminServis.ZakaziPregled(t);
        }

        public static void PomeriPregled(String id)
        {
            TerminServis.PomeriPregled(id);
        }

        public static bool OtkaziPregled(String id)
        {
            return TerminServis.OtkaziPregled(id);
        }

        public static Termin PretragaPoId(String izabran)
        {
            return TerminServis.PretragaPoId(izabran);
        }

        public static bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            return TerminServis.ProveriMogucnostPomeranjaVreme(vreme);
        }
    }
}