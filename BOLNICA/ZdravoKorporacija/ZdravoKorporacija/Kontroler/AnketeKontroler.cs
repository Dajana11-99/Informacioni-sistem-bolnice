using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Kontroler
{
    public class AnketeKontroler
    {
        public static List<Pitanje> DobaviSvaPitanjaOPregledu()
        {
            return AnketaServis.DobaviSvaPitanjaOPregledu();
        }

        public static List<Ankete> DobaviSveAnkete()
        {
            return AnketaServis.DobaviSveAnkete();
        }
        public static bool DostupnaAnketaOBolnici(Pacijent pacijent)
        {
            return AnketaServis.DostupnaAnketaOBolnici(pacijent);
        }

        public static void DodajAnketu(Ankete anketa)
        {
             AnketaServis.DodajAnketu(anketa);
        }
        public AnketaServis anketeServis { get; set; }
    }
}
