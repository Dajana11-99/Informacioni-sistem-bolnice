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
        public static List<Pitanje> pitanja = new List<Pitanje>();
        public static List<Ankete> popunjeneAnkete = new List<Ankete>();
        public static void inicijalizujPitanja()
        {
           
            pitanja.Add(new Pitanje(OcenaAnkete.pet, "Higijena ordinacije/sobe za preglede", false));
            pitanja.Add(new Pitanje(OcenaAnkete.pet, "Ljubaznost osoblja", false));
            pitanja.Add(new Pitanje(OcenaAnkete.pet, "Ljubaznost lekara", false));
            pitanja.Add(new Pitanje(OcenaAnkete.pet, "Strucnost lekara", false));
            pitanja.Add(new Pitanje(OcenaAnkete.pet, "Zadovoljstvo pruženom zdravstvenom uslugom", false));
            pitanja.Add(new Pitanje(OcenaAnkete.pet, "Usluge se obavljaju u skladu sa rasporedom termina", false));
            pitanja.Add(new Pitanje(OcenaAnkete.pet, "Da li biste preporučili prijateljima ovog lekara", false));
            pitanja.Add(new Pitanje(OcenaAnkete.pet, "Izgled bolnice", true));
            pitanja.Add(new Pitanje(OcenaAnkete.pet, "Higijena bolnice", true));
            pitanja.Add(new Pitanje(OcenaAnkete.pet, "Celokupna ocena klinike", true));
            pitanja.Add(new Pitanje(OcenaAnkete.da, "Da li biste prijateljima preporučili kliniku Zdravo", true));
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
