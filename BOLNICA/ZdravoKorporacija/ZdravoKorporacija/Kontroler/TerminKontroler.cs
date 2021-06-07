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
using ZdravoKorporacija.Servis;
using ZdravoKorporacija.ViewModel;

namespace Kontroler
{
   public class TerminKontroler
   {
        private ZakazaniTerminiServis zakazaniTerminiServis = new ZakazaniTerminiServis();
        private SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();
        public List<TerminDTO> NadjiVremeTermina(TerminDTO izabraniTermin)
        {
            return slobodniTerminiServis.NadjiVremeTermina(izabraniTermin);
        }
        public TerminDTO PretragaZakazanihTerminaPoId(String izabran)
        {
            return zakazaniTerminiServis.PretragaZakazanihTerminaPoId(izabran);
        }
        public  List<TerminDTO> NadjiDatumUIntervalu(DateTime pocetak, DateTime kraj)
        {
            return slobodniTerminiServis.NadjiDatumUIntervalu(pocetak, kraj);
        }
        public  void ZakaziPregled(TerminDTO terminZaZakazivanje,String korisnickoImePacijenta)
        {
            zakazaniTerminiServis.ZakaziPregled(terminZaZakazivanje, korisnickoImePacijenta);
        }
        public  void PomeriPregled(TerminDTO stariTermin, TerminDTO noviTermin)
        {
            zakazaniTerminiServis.PomeriPregled(stariTermin, noviTermin);
        }
        public  void OtkaziPregled(TerminDTO termin)
        {
            zakazaniTerminiServis.OtkaziPregled(termin);
        }
        public List<TerminDTO> DobaviSveSlobodneDatumeZaPomeranje(TerminDTO termin)
        {
            return slobodniTerminiServis.DobaviSveSlobodneDatumeZaPomeranje(termin);   
        }
        public List<TerminDTO> DobaviSlobodneTermineZaZakazivanje(List<DateTime> interval, String idLekara)
        {
            return slobodniTerminiServis.DobaviSlobodneTermineZaZakazivanje(interval, idLekara);
        }
        public List<TerminDTO> DobaviSveObavljeneTermine(String idPacijenta)
        {
            return zakazaniTerminiServis.DobaviSveObavljeneTermine(idPacijenta);
        }
        public List<TerminDTO> DobaviZakazaneTerminePacijenta(String idPacijenta)
        {
            return zakazaniTerminiServis.DobaviZakazaneTerminePacijenta(idPacijenta);
        }
        public TerminDTO PretraziSlobodneTerminePoId(String IdTermina)
        {
            return slobodniTerminiServis.PretraziSlobodnePoId(IdTermina);
        }
        public List<Termin> PrikaziSveZakazaneTermine()
        {
            return zakazaniTerminiServis.DobaviSveZakazaneTermine();
        }
        public bool ProveriMogucnostPomeranjeVreme(String vreme)
        {
           return slobodniTerminiServis.ProveriMogucnostPomeranjaVreme(vreme);
        }
        public void IzmenaTermina(TerminDTO terminDTO) 
        {
            zakazaniTerminiServis.IzmenaTermina(terminDTO);
        }
        public bool ZakaziTermin(Termin termin)
        {
            return zakazaniTerminiServis.ZakaziTermin(termin);
        }
        public List<Termin> DobaviSveZakazaneTermine()
        {
            return zakazaniTerminiServis.DobaviSveZakazaneTermine();
        }
        public void OtkaziTermin(String idTermina)
        {
            zakazaniTerminiServis.OtkaziTermin(idTermina);
        }

        public List<TerminDTO> DobaviTermineZaIzvestaj(List<DateTime> interval, String id)
        {
            return zakazaniTerminiServis.DobaviTermineZaIzvestaj(interval, id);
        }

        public int DobaviBrojPregledaIzvestaj(List<DateTime> interval, String idPacijenta)
        {
            return zakazaniTerminiServis.DobaviBrojPregledaIzvestaj(interval, idPacijenta);
        }
        public int DobaviBrojOperacijaIzvestaj(List<DateTime> interval, String idPacijenta)
        {
            return zakazaniTerminiServis.DobaviBrojOperacijaIzvestaj(interval, idPacijenta);
        }
    }
}