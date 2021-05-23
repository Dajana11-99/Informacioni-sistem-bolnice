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
        public  List<TerminViewModel> NadjiVremeTermina(TerminDTO izabraniTermin)
        {
            List<TerminViewModel> sviSlobodniTermini = new List<TerminViewModel>();
            Termin termin = PretraziSlobodneTerminePoId(izabraniTermin.IdTermina);
            foreach(Termin slobodanTermin in terminiServis.NadjiVremeTermina(termin))
            {
                sviSlobodniTermini.Add(KonvertujDTOUViewModel(slobodanTermin));
            }
            return sviSlobodniTermini;
        }
        public List<TerminDTO> NadjiVremeZakazivanjeTermina(TerminDTO izabraniTermin)
        {
            List<TerminDTO> terminiDatuma = new List<TerminDTO>();
            Termin terminZaPrikaz = PretraziSlobodneTerminePoId(izabraniTermin.IdTermina);
            foreach(Termin termin in terminiServis.NadjiVremeTermina(terminZaPrikaz))
            {
                terminiDatuma.Add(new TerminDTO(termin.IdTermina, termin.Datum, termin.Vreme, termin.Lekar, termin.TrajanjeTermina.ToString(), termin.Sala.Id,termin.TipTermina.ToString()));
            }
            return terminiDatuma;
        }
        public  List<TerminDTO> NadjiDatumUIntervalu(DateTime pocetak, DateTime kraj)
        {
            List<TerminDTO> slobodniTerminiUIntervalu = new List<TerminDTO>();
            foreach(Termin termin in terminiServis.NadjiDatumUIntervalu(pocetak, kraj))
            {
                slobodniTerminiUIntervalu.Add(new TerminDTO(termin.IdTermina, termin.Datum,termin.Vreme, termin.Lekar, termin.TrajanjeTermina.ToString(), termin.Sala.Id, termin.TipTermina.ToString()));
            }
            return slobodniTerminiUIntervalu;
            
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
        public  void ZakaziPregled(TerminDTO terminZaZakazivanje,String korisnickoImePacijenta)
        {
            Termin termin = PretraziSlobodneTerminePoId(terminZaZakazivanje.IdTermina);
            terminiServis.ZakaziPregled(termin,korisnickoImePacijenta);
        }
        public  void PomeriPregled(TerminDTO stariTerminDTO, TerminDTO noviTerminDTO)
        {
            Termin stariTermin = PretragaZakazanihTerminaPoId(stariTerminDTO.IdTermina);
            Termin noviTermin = PretraziSlobodneTerminePoId(noviTerminDTO.IdTermina);
            terminiServis.PomeriPregled(stariTermin,noviTermin);
        }
        public  void OtkaziPregled(TerminDTO terminDto)
        {
            Termin termin = PretragaZakazanihTerminaPoId(terminDto.IdTermina);
            terminiServis.OtkaziPregled(termin);
        }
        public  Termin PretragaZakazanihTerminaPoId(String izabran)
        {
            return terminiServis.PretragaZakazanihTerminaPoId(izabran);
        }
        public List<TerminViewModel> DobaviSveSlobodneDatumeZaPomeranje(TerminDTO termin)
        {
            List<TerminViewModel> slobodniTerminiZaPomeranje = new List<TerminViewModel>();
            Termin terminZaPomeranje = PretragaZakazanihTerminaPoId(termin.IdTermina);
           
            foreach(Termin slobodniTermin in terminiServis.DobaviSveSlobodneDatumeZaPomeranje(terminZaPomeranje))
            {
                slobodniTerminiZaPomeranje.Add(KonvertujDTOUViewModel(slobodniTermin));
            }
            return slobodniTerminiZaPomeranje;
            
        }
        public List<TerminDTO> DobaviSlobodneTermineZaZakazivanje(List<DateTime> interval, String idLekara)
        {
            List<TerminDTO> slobodniTerminiZaZakazivanje = new List<TerminDTO>();
           foreach(Termin termin in terminiServis.DobaviSlobodneTermineZaZakazivanje(interval, idLekara))
            {
                slobodniTerminiZaZakazivanje.Add(new TerminDTO(termin.IdTermina, termin.Datum, termin.Vreme, termin.Lekar, termin.TrajanjeTermina.ToString(), termin.Sala.Id, termin.TipTermina.ToString()));
            }
            return slobodniTerminiZaZakazivanje;

        }
      public List<TerminViewModel> DobaviZakazaneTerminePacijenta(String idPacijenta)
        {
            List<TerminViewModel> sviZakazaniTerminiPacijenta = new List<TerminViewModel>();
          foreach(Termin termin in terminiServis.DobaviZakazaneTerminePacijenta(idPacijenta))
            {
                sviZakazaniTerminiPacijenta.Add(KonvertujDTOUViewModel(termin));
            }
            return sviZakazaniTerminiPacijenta;
        }
        private TerminViewModel KonvertujDTOUViewModel(Termin termin)
        {
            TerminDTO terminDTO = new TerminDTO(termin.IdTermina, termin.Datum, termin.Vreme,termin.Lekar, termin.TrajanjeTermina.ToString(), termin.Sala.Id, termin.TipTermina.ToString());
            TerminViewModel terminViewModel = new TerminViewModel(terminDTO);
            return terminViewModel;
        }
        public bool ProveriMogucnostPomeranjeVreme(String vreme)
        {
           return terminiServis.ProveriMogucnostPomeranjaVreme(vreme);
        }
        public void IzmenaTermina(TerminDTO terminDTO) 
        {
            terminiServis.IzmenaTermina(terminDTO);
        }
        public TerminServis terminiServis = new TerminServis();

    }
}