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
        private TerminServis terminiServis = new TerminServis();
        public List<TerminDTO> NadjiVremeTermina(TerminDTO izabraniTermin)
        {
            return terminiServis.NadjiVremeTermina(izabraniTermin);
        }
        public TerminDTO PretragaZakazanihTerminaPoId(String izabran)
        {
            return terminiServis.PretragaZakazanihTerminaPoId(izabran);
        }
        public  List<TerminDTO> NadjiDatumUIntervalu(DateTime pocetak, DateTime kraj)
        {
            return terminiServis.NadjiDatumUIntervalu(pocetak, kraj);
        }
        public  void ZakaziPregled(TerminDTO terminZaZakazivanje,String korisnickoImePacijenta)
        {
            terminiServis.ZakaziPregled(terminZaZakazivanje, korisnickoImePacijenta);
        }
        public  void PomeriPregled(TerminDTO stariTermin, TerminDTO noviTermin)
        {
            terminiServis.PomeriPregled(stariTermin, noviTermin);
        }
        public  void OtkaziPregled(TerminDTO termin)
        {
            terminiServis.OtkaziPregled(termin);
        }
        public List<TerminDTO> DobaviSveSlobodneDatumeZaPomeranje(TerminDTO termin)
        {
            return terminiServis.DobaviSveSlobodneDatumeZaPomeranje(termin);   
        }
        public List<TerminDTO> DobaviSlobodneTermineZaZakazivanje(List<DateTime> interval, String idLekara)
        {
            return terminiServis.DobaviSlobodneTermineZaZakazivanje(interval, idLekara);
        }
        public List<TerminDTO> DobaviSveObavljeneTermine(String idPacijenta)
        {
            return terminiServis.DobaviSveObavljeneTermine(idPacijenta);
        }
        public List<TerminDTO> DobaviZakazaneTerminePacijenta(String idPacijenta)
        {
            return terminiServis.DobaviZakazaneTerminePacijenta(idPacijenta);
        }
        public TerminDTO PretraziSlobodneTerminePoId(String IdTermina)
        {
            return terminiServis.PretraziSlobodneTerminePoId(IdTermina);
        }
        public List<Termin> PrikaziSveZakazaneTermine()
        {
            return terminiServis.PrikaziSveZakazaneTermine();
        }
        public bool ProveriMogucnostPomeranjeVreme(String vreme)
        {
           return terminiServis.ProveriMogucnostPomeranjaVreme(vreme);
        }
        public void IzmenaTermina(TerminDTO terminDTO) 
        {
            terminiServis.IzmenaTermina(terminDTO);
        }
        public bool ZakaziTermin(Termin termin)
        {
            return terminiServis.ZakaziTermin(termin);
        }
        public List<Termin> DobaviSveZakazaneTermine()
        {
            return terminiServis.DobaviSveZakazaneTermine();
        }
        public void OtkaziTermin(String idTermina)
        {
            terminiServis.OtkaziTermin(idTermina);
        }

        public List<TerminDTO> DobaviTermineZaIzvestaj(List<DateTime> interval, String id)
        {
            return terminiServis.DobaviTermineZaIzvestaj(interval, id);
        }

        public int DobaviBrojPregledaIzvestaj(List<DateTime> interval, String idPacijenta)
        {
            return terminiServis.DobaviBrojPregledaIzvestaj(interval, idPacijenta);
        }
        public int DobaviBrojOperacijaIzvestaj(List<DateTime> interval, String idPacijenta)
        {
            return terminiServis.DobaviBrojOperacijaIzvestaj(interval, idPacijenta);
        }
    }
}