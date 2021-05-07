using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.Servis
{
    class ObavestenjaServis
    {

        public static List<Obavestenja> svaObavestenja = new List<Obavestenja>();

       

        public static Obavestenja DodajObavestenjePacijentu(Obavestenja o)
        {
            svaObavestenja.Add(o);

            ObavestenjaRepozitorijum.Sacuvaj();

            if (svaObavestenja.Contains(o))
            {
                return o;
            }
            else
            {
                return null;
            }
        }

        /*public static String generisiIdObavestenja()
        {
            int brojac = SvaObavestenja().Count;
            bool postoji;
            do
            {
                postoji = false;
                foreach (Obavestenja o in SvaObavestenja())
                {
                    if (o.IdObavestenja.Equals("O" + brojac.ToString()))
                    {
                        postoji = true;
                        brojac++;
                        break;
                    }
                }
            } while (postoji);

            return "O" + brojac.ToString();
        }*/


        public static Obavestenja PretraziPoId(String idObavestenja)
        {
            foreach (Obavestenja o in svaObavestenja)
            {
                if (o.IdObavestenja.Equals(idObavestenja))
                {
                    return o;
                }
            }
            return null;
        }

        public static List<Obavestenja> SvaObavestenja()
        {
            return svaObavestenja;
        }

        public Repozitorijum.ObavestenjaRepozitorijum obavestenjaRepozitorijum;
    }
}
