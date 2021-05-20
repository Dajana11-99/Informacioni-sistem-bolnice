/***********************************************************************
 * Module:  TerminKontroler.cs
 * Author:  dajan
 * Purpose: Definition of the Class Kontroler.TerminKontroler
 ***********************************************************************/

using Model;
using Servis;
using System;
using System.Collections.Generic;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.ViewModel;

namespace Kontroler
{
   public class TerminKontroler
   {
        public List<Termin> DobaviSveZakazaneTermine()
        {
            return terminiServis.DobaviSveZakazaneTermine();
        }
        public static bool ProveriMogucnostPomeranjaDatum(DateTime dat)
        {
            return TerminServis.ProveriMogucnostPomeranjaDatum(dat);
        }
        public  List<Termin> NadjiVremeTermina(Termin izabraniTermin)
        {
            return terminiServis.NadjiVremeTermina(izabraniTermin);
        }
        public static List<Termin> NadjiSlobodneTermineLekara(String idZaposlenog, List<Termin> datumiUIntervalu)
        {
            return TerminServis.NadjiSlobodneTermineLekara(idZaposlenog, datumiUIntervalu);
        }
       public  List<Termin> NadjiDatumUIntervalu(DateTime pocetak, DateTime kraj)
        {
            return terminiServis.NadjiDatumUIntervalu(pocetak, kraj);
        }
        public  List<Termin> PrikaziSveZakazaneTermine()
        {
            return terminiServis.PrikaziSveZakazaneTermine();
        }
        public  Termin PretraziSlobodneTerminePoId(String IdTermina)
        {
            return terminiServis.PretraziSlobodneTerminePoId(IdTermina);
        }
        public bool ZakaziTermin(Termin termin)
        {
            return terminiServis.ZakaziTermin(termin);
        }
        public void OtkaziTermin(String idTermina)
        {
            terminiServis.OtkaziTermin(idTermina);
        }
        public  void ZakaziPregled(Termin t)
        {
            terminiServis.ZakaziPregled(t);
        }
        public  void PomeriPregled(String idTermina)
        {
            terminiServis.PomeriPregled(idTermina);
        }
        public  void OtkaziPregled(String idTermina)
        {
            terminiServis.OtkaziPregled(idTermina);
        }
        public  Termin PretragaZakazanihTerminaPoId(String izabran)
        {
            return terminiServis.PretragaZakazanihTerminaPoId(izabran);
        }
        public static bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            return TerminServis.ProveriMogucnostPomeranjaVreme(vreme);
        }

        public void IzmenaTermina(TerminDTO terminDTO) 
        {
            terminiServis.IzmenaTermina(terminDTO);
        }
        public TerminServis terminiServis = new TerminServis();

    }
}