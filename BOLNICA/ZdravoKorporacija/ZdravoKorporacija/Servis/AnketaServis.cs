using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Servis
{
    public class AnketaServis
    {
        public static List<Pitanje> pitanjaOPregledu = new List<Pitanje>();
        public static List<Pitanje> pitanjaOBolnici = new List<Pitanje>();
        public static List<Ankete> popunjeneAnkete = new List<Ankete>();
        public static void inicijalizujPitanja()
        {
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Higijena ordinacije/sobe za preglede"));
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Ljubaznost osoblja" ));
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Ljubaznost lekara"));
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Strucnost lekara"));
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Zadovoljstvo pruženom zdravstvenom uslugom"));
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Usluge se obavljaju u skladu sa rasporedom termina"));
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Da li biste preporučili prijateljima ovog lekara"));
        }

        public static void inicijalizujPitanjaOBolnici()
        {
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Izgled bolnice"));
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Higijena bolnice"));
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Pristupačna lokacija"));
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Obezbeđen parking"));
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Aplikacija bolnice"));
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Celokupna ocena osoblja"));
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Celokupna ocena bolnice"));
            pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Da li biste prijateljima preporučili kliniku Zdravo"));
        }

        public static List<Pitanje> DobaviSvaPitanjaOPregledu()
        {
            return pitanjaOPregledu;
        }


        public static List<Pitanje> DobaviSvaPitanjaOBolnici()
        {
            return pitanjaOBolnici;
        }
        public static List<Ankete> DobaviSveAnkete()
        {
            return popunjeneAnkete;
        }

        public static void DodajAnketu(Ankete anketa)
        {
            popunjeneAnkete.Add(anketa);
        }

        public static bool DostupnaAnketaOBolnici(Pacijent pacijent)
        {
            DateTime novaAnketa=NadjiDatumPoslednjeAnketeOBolnici(pacijent).AddMonths(3);
            if (DateTime.Compare(DateTime.Now.Date, novaAnketa.Date) >= 0)
                return true;
            
            return false;
        }

        public static DateTime NadjiDatumPoslednjeAnketeOBolnici(Pacijent pacijent)
        {
            List<Ankete> anketePacijenta = new List<Ankete>();
            foreach (Ankete anketa in popunjeneAnkete)
            {
                if (anketa.Pacijent.IdPacijenta.Equals(pacijent.IdPacijenta) && anketa.termin == null)
                {
                    anketePacijenta.Add(anketa);
                }
            }
            if (anketePacijenta.Count == 0)
            {
                return DateTime.Now.Date.AddMonths(-3);
            }


            return SortirajTerminePoDatumu(anketePacijenta)[0].ocenioBolnicu;
        }

        public static List<Ankete> SortirajTerminePoDatumu(List<Ankete> nesortiraniDatumi)
        {
            return nesortiraniDatumi.OrderByDescending(user => user.ocenioBolnicu).ToList();
        }

        public Repozitorijum.AnketeRepozitorijum anketeRepozitorijum;
    }
}
