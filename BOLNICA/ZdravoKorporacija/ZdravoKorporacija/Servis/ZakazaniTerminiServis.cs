
using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using MoreLinq;
using ZdravoKorporacija;
using ZdravoKorporacija.Maper;
using ZdravoKorporacija.PacijentPrikaz;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.Servis;
using ZdravoKorporacija.ViewModel;

namespace Servis
{ 
    public class ZakazaniTerminiServis
    {
       
        private NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        private TerminMaper terminMaper = new TerminMaper();
        private ZakazaniTerminiRepozitorijum zakazaniTerminiRepozitorijum = new ZakazaniTerminiRepozitorijum();
        private LekarServis lekarServis = new LekarServis();
        private SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();
        private ObavestenjaServis obavestenjaServis = new ObavestenjaServis();
      
        public List<TerminDTO> DobaviSveObavljeneTermine(String idPacijenta)
        {
            List<TerminDTO> terminiPacijenta = new List<TerminDTO>();
            foreach (Termin termin in zakazaniTerminiRepozitorijum.DobaviSveZakazaneTerminePacijenta(idPacijenta))
            {
                if (DateTime.Compare(termin.Datum.Date, DateTime.Now.Date) < 0)
                    terminiPacijenta.Add(terminMaper.ZakazaniTerminModelUDto(termin));
            }
            return terminiPacijenta;

        }
        public List<TerminDTO> DobaviZakazaneTerminePacijenta(String idPacijenta)
        {
            List<TerminDTO> terminiPacijenta = new List<TerminDTO>();
            foreach (Termin termin in zakazaniTerminiRepozitorijum.DobaviSveZakazaneTerminePacijenta(idPacijenta))
            {
                if (DateTime.Compare(termin.Datum.Date, DateTime.Now.Date) >= 0)
                    terminiPacijenta.Add(terminMaper.ZakazaniTerminModelUDto(termin));
            }
            return terminiPacijenta;
        }
        public void PomeriPregled(TerminDTO stariTermin, TerminDTO noviTermin)
        {
            Termin zakazanTermin = zakazaniTerminiRepozitorijum.PretraziZakazanePoId(stariTermin.IdTermina);
            Termin slobodanTermin = terminMaper.SlobodanTerminDTOUModel(noviTermin.IdTermina);
            slobodanTermin.Pacijent = zakazanTermin.Pacijent;
            zakazanTermin.Pacijent = null;
            ZameniTermine(zakazanTermin, slobodanTermin);
            naloziPacijenataServis.ProveriMalicioznostPacijenta(slobodanTermin);
            obavestenjaServis.DodajObavestenjeOPomerenomPregledu(noviTermin, stariTermin);

        }
        private void ZameniTermine(Termin stariTermin, Termin noviTermin)
        {
            slobodniTerminiServis.DodajSlobodanTermin(stariTermin);
            zakazaniTerminiRepozitorijum.Dodaj(noviTermin);
            slobodniTerminiServis.ObrisliSlobodanTermin(noviTermin.IdTermina);
            zakazaniTerminiRepozitorijum.ObrisiZakazanTermin(stariTermin.IdTermina);
        }
      
        public void OtkaziPregled(TerminDTO termin)
        {
            Termin terminZaBrisanje = zakazaniTerminiRepozitorijum.PretraziZakazanePoId(termin.IdTermina);
            naloziPacijenataServis.ProveriMalicioznostPacijenta(terminZaBrisanje);
            zakazaniTerminiRepozitorijum.ObrisiZakazanTermin(terminZaBrisanje.IdTermina);
            terminZaBrisanje.Pacijent = null;
            slobodniTerminiServis.DodajSlobodanTermin(terminZaBrisanje);
        }
        
        public TerminDTO PretragaZakazanihTerminaPoId(String idTermina)
        {
            Termin termin = zakazaniTerminiRepozitorijum.PretraziZakazanePoId(idTermina);
            return terminMaper.ZakazaniTerminModelUDto(termin);
        }
        public  void ZakaziPregled(TerminDTO izabraniTermin,String korisnickoImePacijenta)
        {
            Termin termin = terminMaper.SlobodanTerminDTOUModel(izabraniTermin.IdTermina);
            termin.Pacijent = naloziPacijenataServis.PretraziPoKorisnickom(korisnickoImePacijenta);
            zakazaniTerminiRepozitorijum.Dodaj(termin);
            slobodniTerminiServis.ObrisliSlobodanTermin(termin.IdTermina);
            obavestenjaServis.DodajObavestenjeOZakazanomPregledu(termin.Pacijent.IdPacijenta, izabraniTermin);
        }
       
        public bool ZakaziTermin(Termin termin)
        {
            return zakazaniTerminiRepozitorijum.ZakaziTermin(termin);
        }
        public void OtkaziTermin(String idTermina)
        {
            zakazaniTerminiRepozitorijum.Obrisi(idTermina);
        }

        public List<Termin> DobaviSveZakazaneTermine()
        {
            return zakazaniTerminiRepozitorijum.DobaviSve();
        }

        public void IzmenaTermina(TerminDTO terminDTO)
        {
            ValidacijaTermina(terminDTO, zakazaniTerminiRepozitorijum.IzmenaTermina(terminDTO));
        }

        public List<TerminDTO> DobaviTermineZaIzvestaj(List<DateTime> interval, String id)
        {
            List<TerminDTO> terminiZaIzvestaj = new List<TerminDTO>();

            foreach (Termin termin in zakazaniTerminiRepozitorijum.DobaviSveZakazaneTerminePacijenta(id))
            {
                if (TerminPripadaIntervalu(interval, termin.Datum))
                    terminiZaIzvestaj.Add(terminMaper.ZakazaniTerminModelUDto(termin));
            }
            return terminiZaIzvestaj.OrderBy(user => user.Datum).ToList();

        }
        private bool TerminPripadaIntervalu(List<DateTime> vremenskiInterval, DateTime datumZaPoredjenje)
        {
            return datumZaPoredjenje >= vremenskiInterval[0] && datumZaPoredjenje <= vremenskiInterval[1];
        }
        public int DobaviBrojPregledaIzvestaj(List<DateTime> interval, String idPacijenta)
        {
            int brojPregleda = 0;
            foreach (TerminDTO termin in DobaviTermineZaIzvestaj(interval, idPacijenta))
            {
                if (termin.TipTermina.ToString().Equals(TipTermina.Pregled.ToString()))
                    brojPregleda++;
                
            }
            return brojPregleda;
        }
        public int DobaviBrojOperacijaIzvestaj(List<DateTime> interval, String idPacijenta)
        {
            int brojOperacija = 0;
            foreach (TerminDTO termin in DobaviTermineZaIzvestaj(interval, idPacijenta))
            {
                if (termin.TipTermina.ToString().Equals(TipTermina.Operacija.ToString()))
                    brojOperacija++;
            }
            return brojOperacija;
        }

        private void ValidacijaTermina(TerminDTO terminDTO, Termin termin)
        {

            if (!termin.Lekar.idZaposlenog.Equals(terminDTO.Lekar))
                termin.Lekar = lekarServis.PretragaLekaraPoID(terminDTO.Lekar.idZaposlenog);
            if (!termin.Datum.Equals(terminDTO.Datum))
                termin.Datum = terminDTO.Datum;
            if (!termin.Vreme.Equals(terminDTO.Vreme))
                termin.Vreme = terminDTO.Vreme;
            if (!termin.TrajanjeTermina.Equals(terminDTO.PredvidjenoVreme))
                termin.TrajanjeTermina = double.Parse(terminDTO.PredvidjenoVreme);
            if (!termin.Sala.Id.Equals(terminDTO.NazivSale))
                termin.Sala.Id = terminDTO.NazivSale;
            if (!termin.TipTermina.Equals(terminDTO.TipTermina))
            {
                if (terminDTO.TipTermina.Equals(TipTermina.Operacija))
                {
                    termin.TipTermina = TipTermina.Operacija;
                }
                else
                {
                    termin.TipTermina = TipTermina.Pregled;
                }
            }
        }
        public void RefresujZakazaneTermine(Termin termin)
        {
            zakazaniTerminiRepozitorijum.ObrisiZakazanTermin(termin.IdTermina);
            zakazaniTerminiRepozitorijum.Dodaj(termin);
        }
    }
}