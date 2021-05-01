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
           
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Higijena ordinacije/sobe za preglede", false));
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Ljubaznost osoblja", false));
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Ljubaznost lekara", false));
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Strucnost lekara", false));
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Zadovoljstvo pruženom zdravstvenom uslugom", false));
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Usluge se obavljaju u skladu sa rasporedom termina", false));
            pitanjaOPregledu.Add(new Pitanje(OcenaAnkete.pet, "Da li biste preporučili prijateljima ovog lekara", false));
      
        }

        public static void inicijalizujPitanjaOBolnici()
        {
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Izgled bolnice", true));
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Higijena bolnice", true));
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Pristupačna lokacija", true));
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Obezbeđen parking", true));
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Aplikacija bolnice", true));
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Celokupna ocena osoblja", true));
           pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.pet, "Celokupna ocena bolnice", true));
            pitanjaOBolnici.Add(new Pitanje(OcenaAnkete.da, "Da li biste prijateljima preporučili kliniku Zdravo", true));
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
            DateTime novaAnketa=NadjiSveAnketePacijenta(pacijent).AddMonths(3);
            if (DateTime.Compare(DateTime.Now.Date, novaAnketa.Date) >= 0)
                return true;
            
            return false;
        }

        public static DateTime NadjiSveAnketePacijenta(Pacijent pacijent)
        {
            List<Ankete> anketePacijenta = new List<Ankete>();
            foreach (Ankete anketa in popunjeneAnkete)
            {
                if (anketa.Pacijent.idPacijenta.Equals(pacijent.idPacijenta) && anketa.termin == null)
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


    }
}
