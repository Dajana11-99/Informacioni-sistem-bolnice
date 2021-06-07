using Model;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Maper;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.RepozitorijumInterfejs;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.Servis
{
   public  class SlobodniTerminiServis
    {
        private ISlobodniTerminiRepozitorijum slobodniTerminiRepozitorijum = new SlobodniTerminiRepozitorijum();
        private TerminMaper terminMaper = new TerminMaper();
        public List<TerminDTO> NadjiVremeTermina(TerminDTO izabraniTermin)
        {
            List<TerminDTO> vremeDatumaSlobodnogTermina = new List<TerminDTO>();
            foreach (Termin termin in slobodniTerminiRepozitorijum.DobaviSve())
            {
                if (termin.Datum.Equals(izabraniTermin.Datum) &&
                    izabraniTermin.Lekar.korisnik.KorisnickoIme.Equals(termin.Lekar.korisnik.KorisnickoIme))
                    vremeDatumaSlobodnogTermina.Add(terminMaper.SlobodanTerminModelUDto(termin));
            }
            return SortirajTerminePoPocetnomVremenu(UkloniDupleDatume(vremeDatumaSlobodnogTermina));
        }

        public List<TerminDTO> NadjiDatumUIntervalu(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            List<TerminDTO> slobodniDatumi = new List<TerminDTO>();
            foreach (Termin termin in slobodniTerminiRepozitorijum.DobaviSve())
            {
                if (DateTime.Compare(termin.Datum, pocetakIntervala) >= 0
                    && DateTime.Compare(termin.Datum, krajIntervala) <= 0)
                    slobodniDatumi.Add(terminMaper.SlobodanTerminModelUDto(termin));
            }
            return SortirajTerminePoDatumu(slobodniDatumi);
        }

        public List<TerminDTO> DobaviSlobodneTermineZaZakazivanje(List<DateTime> interval, String lekar)
        {
            List<TerminDTO> terminiKodIzabranogLekara = new List<TerminDTO>();
            List<TerminDTO> datumiUIntervalu = NadjiDatumUIntervalu(interval[0], interval[1]);
            terminiKodIzabranogLekara = NadjiSlobodneTermineLekara(lekar, datumiUIntervalu);
            return terminiKodIzabranogLekara;
        }
        public List<TerminDTO> DobaviSveSlobodneDatumeZaPomeranje(TerminDTO termin)
        {
            List<TerminDTO> sviSlobodniDatumi = new List<TerminDTO>();
            List<TerminDTO> datumiUIntervalu = NadjiDatumUIntervalu(termin.Datum.AddDays(-2), termin.Datum.AddDays(2));
            sviSlobodniDatumi = NadjiSlobodneTermineLekara(termin.Lekar.CeloIme, datumiUIntervalu);
            ObrisiDatumeIzProslosti(sviSlobodniDatumi);
            return sviSlobodniDatumi;
        }

        private List<TerminDTO> SortirajTerminePoDatumu(List<TerminDTO> nesortiraniDatumi)
        {
            return nesortiraniDatumi.OrderBy(user => user.Datum).ToList();
        }
        private List<TerminDTO> UkloniDupleDatume(List<TerminDTO> dupliTermini)
        {
            List<TerminDTO> jedinstveniTermini = new List<TerminDTO>();
            foreach (TerminDTO termin in dupliTermini.DistinctBy(t => t.Datum))
                jedinstveniTermini.Add(termin);
            return jedinstveniTermini;
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

        private List<TerminDTO> SortirajTerminePoPocetnomVremenu(List<TerminDTO> nesortiraniTermini)
        {
            return nesortiraniTermini.OrderBy(user => DateTime.ParseExact(user.Vreme, "HH:mm", null)).ToList();
        }
        private List<TerminDTO> ObrisiDatumeIzProslosti(List<TerminDTO> sviSlobodniTermini)
        {
            List<TerminDTO> terminiUBuducnosti = new List<TerminDTO>();
            foreach (TerminDTO termin in sviSlobodniTermini)
            {
                if (NasaoDatumUProslosti(termin))
                    terminiUBuducnosti.Add(termin);
            }

            return terminiUBuducnosti;
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

        public TerminDTO PretraziSlobodnePoId(String idTermina)
        {
            Termin termin = slobodniTerminiRepozitorijum.PretraziSlobodneTerminePoId(idTermina);
            return  terminMaper.SlobodanTerminModelUDto(termin);
        }
        public void DodajSlobodanTermin(Termin termin)
        {
            slobodniTerminiRepozitorijum.Dodaj(termin);
        }
        public void ObrisliSlobodanTermin(String idTermina)
        {
            slobodniTerminiRepozitorijum.ObrisiSlobodanTermin(idTermina);
        }
    }
}
