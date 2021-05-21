
using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using MoreLinq;
using ZdravoKorporacija;
using ZdravoKorporacija.PacijentPrikaz;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.ViewModel;

namespace Servis
{ 
    public class TerminServis
    {
        public List<Termin> DobaviSveZakazaneTermine()
        {
            return terminRepozitorijum.DobaviZakazaneTermine();
        }
        public  List<Termin> NadjiVremeTermina(Termin izabraniTermin)
        {
            List<Termin> vremeDatumaSlobodnogTermina = new List<Termin>();
            foreach (Termin termin in terminRepozitorijum.DobaviSlobodneTermine())
            {
                if (termin.Datum.Equals(izabraniTermin.Datum) && 
                    izabraniTermin.Lekar.korisnik.KorisnickoIme.Equals(termin.Lekar.korisnik.KorisnickoIme))
                    vremeDatumaSlobodnogTermina.Add(termin);
            }
            return UkloniDupleDatume(vremeDatumaSlobodnogTermina);
        }
      
        public static List<Termin> NadjiSlobodneTermineLekara(String idLekara, List<Termin> datumiUIntervalu)
        {
            List<Termin> slobodniTerminiKodLekara = new List<Termin>();
            foreach (Termin termin in datumiUIntervalu)
            {
                if (termin.Lekar.idZaposlenog.Equals(idLekara))
                    slobodniTerminiKodLekara.Add(termin);
            }
            return slobodniTerminiKodLekara;
        }
    
        public  List<Termin> NadjiDatumUIntervalu(DateTime pocetakIntervala, DateTime krajIntervala)
        {
            List<Termin> slobodniDatumi = new List<Termin>();
            foreach (Termin termin in terminRepozitorijum.DobaviSlobodneTermine())
            {
                if (DateTime.Compare(termin.Datum, pocetakIntervala) >= 0
                    && DateTime.Compare(termin.Datum, krajIntervala) <= 0)
                    slobodniDatumi.Add(termin);
            }
            return SortirajTerminePoDatumu(slobodniDatumi);
        }
        public static List<Termin> SortirajTerminePoDatumu(List<Termin> nesortiraniDatumi)
        {
            return nesortiraniDatumi.OrderBy(user => user.Datum).ToList();
        }
        private static List<Termin> UkloniDupleDatume(List<Termin> dupliTermini)
        {
            List<Termin> jedinstveniTermini = new List<Termin>();
            foreach (Termin termin in dupliTermini.DistinctBy(t => t.Datum))
                jedinstveniTermini.Add(termin);
            return SortirajTerminePoPocetnomVremenu(jedinstveniTermini);
        }

        private static List<Termin> SortirajTerminePoPocetnomVremenu(List<Termin> nesortiraniTermini)
        {
            return nesortiraniTermini.OrderBy(user => DateTime.ParseExact(user.Vreme, "HH:mm", null)).ToList();
        }

        public static bool ProveriMogucnostPomeranjaDatum(DateTime datumPregleda)
        {
            if (DateTime.Compare(DateTime.Now.AddDays(1).Date, datumPregleda.Date) == 0)
                return true;
            return false;
        }

        public static bool ProveriMogucnostPomeranjaVreme(String vreme)
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

        public  List<Termin> PrikaziSveZakazaneTermine()
        {
            return terminRepozitorijum.DobaviZakazaneTermine();
        }
        public List<Termin> DobaviZakazaneTerminePacijenta(String idPacijenta)
        {
            List<Termin> terminiPacijenta = new List<Termin>();
            foreach (Termin t in terminRepozitorijum.DobaviSveZakazaneTerminePacijenta(idPacijenta))
            {
                    if (DateTime.Compare(t.Datum.Date, DateTime.Now.Date) >= 0)
                        terminiPacijenta.Add(t);
            }
            return terminiPacijenta;
        }
        public  Termin PretraziSlobodneTerminePoId(String IdTermina)
        {
            return terminRepozitorijum.PretraziSlobodneTerminePoId(IdTermina);
        }
        public bool ZakaziTermin(Termin termin)
        {
            return terminRepozitorijum.ZakaziTermin(termin);
        }
        public  void ZakaziPregled(Termin t)
        {
            terminRepozitorijum.ZakaziPregled(t);
        }
        public  void PomeriPregled(String idTermina)
        {
            terminRepozitorijum.PomeriPregled(idTermina);
           
        }
        public  void OtkaziPregled(String idTermina)
        {
            terminRepozitorijum.OtkaziPregled(idTermina);
          
        }
        public   Termin PretragaZakazanihTerminaPoId(String izabran)
        {
            return terminRepozitorijum.PretraziZakazanePoId(izabran);
        }
        public void OtkaziTermin(String idTermina)
        {
            terminRepozitorijum.OtkaziTermin(idTermina);
        }
        public TerminRepozitorijum terminRepozitorijum = new TerminRepozitorijum();
        public LekarRepozitorijum lekarRepozitorijum = new LekarRepozitorijum();
    }
}