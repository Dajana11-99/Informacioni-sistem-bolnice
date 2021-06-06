
using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using MoreLinq;
using ZdravoKorporacija;
using ZdravoKorporacija.Maper;
using ZdravoKorporacija.PacijentPrikaz;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.ViewModel;

namespace Servis
{ 
    public class TerminServis
    {
       
        private NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        private TerminMaper terminMaper = new TerminMaper();
        private TerminRepozitorijum terminRepozitorijum = new TerminRepozitorijum();
        private LekarRepozitorijum lekarRepozitorijum = new LekarRepozitorijum();

        public  List<TerminDTO> NadjiVremeTermina(TerminDTO izabraniTermin)
        {
            List<TerminDTO> vremeDatumaSlobodnogTermina = new List<TerminDTO>();
            foreach (Termin termin in terminRepozitorijum.DobaviSlobodneTermine())
            {
                if (termin.Datum.Equals(izabraniTermin.Datum) && 
                    izabraniTermin.Lekar.korisnik.KorisnickoIme.Equals(termin.Lekar.korisnik.KorisnickoIme))
                    vremeDatumaSlobodnogTermina.Add(terminMaper.SlobodanTerminModelUDto(termin));
            }
            return SortirajTerminePoPocetnomVremenu(UkloniDupleDatume(vremeDatumaSlobodnogTermina));
        }
    
        public  List<TerminDTO> NadjiDatumUIntervalu(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            List<TerminDTO> slobodniDatumi = new List<TerminDTO>();
            foreach (Termin termin in terminRepozitorijum.DobaviSlobodneTermine())
            {
                if (DateTime.Compare(termin.Datum, pocetakIntervala) >= 0
                    && DateTime.Compare(termin.Datum, krajIntervala) <= 0)
                    slobodniDatumi.Add(terminMaper.SlobodanTerminModelUDto(termin));
            }
            return SortirajTerminePoDatumu(slobodniDatumi);
        }

        public List<TerminDTO> DobaviSlobodneTermineZaZakazivanje(List<DateTime>interval, String lekar)
        {
            List<TerminDTO> terminiKodIzabranogLekara = new List<TerminDTO>();
            List<TerminDTO> datumiUIntervalu = NadjiDatumUIntervalu(interval[0], interval[1]);
            terminiKodIzabranogLekara = NadjiSlobodneTermineLekara(lekar,datumiUIntervalu);
            return terminiKodIzabranogLekara;
        }
        public List<TerminDTO> DobaviSveSlobodneDatumeZaPomeranje(TerminDTO termin)
        {
            List<TerminDTO> sviSlobodniDatumi = new List<TerminDTO>();
            List<TerminDTO> datumiUIntervalu = NadjiDatumUIntervalu(termin.Datum.AddDays(-2), termin.Datum.AddDays(2));
            sviSlobodniDatumi =NadjiSlobodneTermineLekara(termin.Lekar.CeloIme,datumiUIntervalu);
             ObrisiDatumeIzProslosti(sviSlobodniDatumi);
            return sviSlobodniDatumi;
        }
        private  List<TerminDTO> SortirajTerminePoDatumu(List<TerminDTO> nesortiraniDatumi)
        {
            return nesortiraniDatumi.OrderBy(user => user.Datum).ToList();
        }
        private  List<TerminDTO> UkloniDupleDatume(List<TerminDTO> dupliTermini)
        {
            List<TerminDTO> jedinstveniTermini = new List<TerminDTO>();
            foreach (TerminDTO termin in dupliTermini.DistinctBy(t => t.Datum))
                jedinstveniTermini.Add(termin);
            return jedinstveniTermini;
        }

        private  List<TerminDTO> SortirajTerminePoPocetnomVremenu(List<TerminDTO> nesortiraniTermini)
        {
            return nesortiraniTermini.OrderBy(user => DateTime.ParseExact(user.Vreme, "HH:mm", null)).ToList();
        }

        public  bool ProveriMogucnostPomeranjaDatum(DateTime datumPregleda)
        {
            if (DateTime.Compare(DateTime.Now.AddDays(1).Date, datumPregleda.Date) == 0)
                return true;
            return false;
        }

        private List<TerminDTO> ObrisiDatumeIzProslosti(List<TerminDTO> sviSlobodniTermini)
        {
            List<TerminDTO> terminiUBuducnosti = new List<TerminDTO>();
            foreach(TerminDTO termin in sviSlobodniTermini)
            {
                if (NasaoDatumUProslosti(termin))
                    terminiUBuducnosti.Add(termin);
            }

            return terminiUBuducnosti;
        }

        private bool NasaoDatumUProslosti(TerminDTO termin)
        {
            if (DateTime.Compare(termin.Datum.Date, DateTime.Now.Date) > 0)
            {
                return true;
            }
            else if (DateTime.Compare(termin.Datum.Date, DateTime.Now.AddDays(1).Date) == 0)
            {
                if (ProveriMogucnostPomeranjaVreme(termin.Vreme))
                    return true;       
            }
            return false;
        }

        public List<TerminDTO> DobaviSveObavljeneTermine(String idPacijenta)
        {
            List<TerminDTO> terminiPacijenta = new List<TerminDTO>();
            foreach (Termin termin in terminRepozitorijum.DobaviSveZakazaneTerminePacijenta(idPacijenta))
            {
                if (DateTime.Compare(termin.Datum.Date, DateTime.Now.Date) < 0)
                    terminiPacijenta.Add(terminMaper.ZakazaniTerminModelUDto(termin));
            }
            return terminiPacijenta;

        }
        public List<TerminDTO> DobaviZakazaneTerminePacijenta(String idPacijenta)
        {
            List<TerminDTO> terminiPacijenta = new List<TerminDTO>();
            foreach (Termin termin in terminRepozitorijum.DobaviSveZakazaneTerminePacijenta(idPacijenta))
            {
                if (DateTime.Compare(termin.Datum.Date, DateTime.Now.Date) >= 0)
                    terminiPacijenta.Add(terminMaper.ZakazaniTerminModelUDto(termin));
            }
            return terminiPacijenta;
        }
        public void PomeriPregled(TerminDTO stariTermin, TerminDTO noviTermin)
        {
            Termin zakazanTermin = terminRepozitorijum.PretraziZakazanePoId(stariTermin.IdTermina);
            Termin slobodanTermin = terminRepozitorijum.PretraziSlobodneTerminePoId(noviTermin.IdTermina);
            slobodanTermin.Pacijent = zakazanTermin.Pacijent;
            zakazanTermin.Pacijent = null;
            ZameniTermine(zakazanTermin, slobodanTermin);
            naloziPacijenataServis.ProveriMalicioznostPacijenta(slobodanTermin);
        }
        private void ZameniTermine(Termin stariTermin, Termin noviTermin)
        {
            terminRepozitorijum.ZameniTermine(stariTermin, noviTermin);
        }
      
        public void OtkaziPregled(TerminDTO termin)
        {
            Termin terminZaBrisanje = terminRepozitorijum.PretraziZakazanePoId(termin.IdTermina);
            naloziPacijenataServis.ProveriMalicioznostPacijenta(terminZaBrisanje);
            terminRepozitorijum.OtkazivanjePregleda(terminZaBrisanje);
        }
        public  TerminDTO PretraziSlobodneTerminePoId(String idTermina)
        {
            Termin termin= terminRepozitorijum.PretraziSlobodneTerminePoId(idTermina);
            return terminMaper.SlobodanTerminModelUDto(termin);
        }
        public TerminDTO PretragaZakazanihTerminaPoId(String idTermina)
        {
            Termin termin = terminRepozitorijum.PretraziZakazanePoId(idTermina);
            return terminMaper.ZakazaniTerminModelUDto(termin);
        }
        public  void ZakaziPregled(TerminDTO izabraniTermin,String korisnickoImePacijenta)
        {
            Termin termin = terminRepozitorijum.PretraziSlobodneTerminePoId(izabraniTermin.IdTermina);
            termin.Pacijent = naloziPacijenataServis.PretraziPoKorisnickom(korisnickoImePacijenta);
            terminRepozitorijum.ZakaziPregled(termin);
        }
        public List<TerminDTO> NadjiSlobodneTermineLekara(String lekar, List<TerminDTO> datumiUIntervalu)
        {
            List<TerminDTO> slobodniTerminiKodLekara = new List<TerminDTO>();
            foreach (TerminDTO termin in datumiUIntervalu)
            {
                if (termin.Lekar.CeloIme.Equals(lekar))
                    slobodniTerminiKodLekara.Add(termin);
            }
            return UkloniDupleDatume(slobodniTerminiKodLekara);
        }
        public bool ZakaziTermin(Termin termin)
        {
            return terminRepozitorijum.ZakaziTermin(termin);
        }
        public void OtkaziTermin(String idTermina)
        {
            terminRepozitorijum.OtkaziTermin(idTermina);
        }
        public List<Termin> PrikaziSveZakazaneTermine()
        {
            return terminRepozitorijum.DobaviZakazaneTermine();
        }

        public List<Termin> DobaviSveZakazaneTermine()
        {
            return terminRepozitorijum.DobaviZakazaneTermine();
        }

        public void IzmenaTermina(TerminDTO terminDTO)
        {
            ValidacijaTermina(terminDTO, terminRepozitorijum.IzmenaTermina(terminDTO));
        }

        private void ValidacijaTermina(TerminDTO terminDTO, Termin termin)
        {

            if (!termin.Lekar.idZaposlenog.Equals(terminDTO.Lekar))
                termin.Lekar = lekarRepozitorijum.PretragaLekaraPoID(terminDTO.Lekar.idZaposlenog);
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
        public bool ProveriMogucnostPomeranjaVreme(String vreme)
        {
            DateTime vremePregleda = DateTime.ParseExact(vreme, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            if (vremePregleda.Hour < DateTime.Now.Hour)
                return false;
            else if (vremePregleda.Hour == DateTime.Now.Hour && DateTime.Now.Minute == vremePregleda.Minute)
                return false;
            else if (vremePregleda.Hour == DateTime.Now.Hour && DateTime.Now.Minute > vremePregleda.Minute)
                return false;
            return true;
        }


        public List<TerminDTO> DobaviTermineZaIzvestaj(List<DateTime> interval, String id)
        {
            List<TerminDTO> terminiZaIzvestaj = new List<TerminDTO>();

            foreach (Termin termin in terminRepozitorijum.DobaviSveZakazaneTerminePacijenta(id))
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
                {

                    brojPregleda++;
                }
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
    }
}