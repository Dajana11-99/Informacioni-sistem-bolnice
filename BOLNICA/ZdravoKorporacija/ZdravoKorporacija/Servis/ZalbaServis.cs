using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.Servis
{
    class ZalbaServis
    {
        public static List<Zalba> zalbe = new List<Zalba>();
        public static Zalba PretraziZalbe(String idZalbe)
        {
            foreach (Zalba zalba in zalbe)
            {
                if (zalba.IdZalbe.Equals(idZalbe))
                {
                    return zalba;
                }
            }
            return null;
        }
        public static List<Zalba> PrikaziSveZalbe()
        {
            return zalbe;
        }

        public static Zalba UpisiNovuZalbu(Zalba zalba)
        {
            return ZalbaRepozitorijum.upisiNovuZalbu(zalba);
        }
    }
}
