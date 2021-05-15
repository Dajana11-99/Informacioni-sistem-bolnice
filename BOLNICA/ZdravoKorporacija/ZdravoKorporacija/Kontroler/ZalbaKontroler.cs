using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Kontroler
{
    class ZalbaKontroler
    {
        public static Zalba PretraziZalbe(String idZalbe)
        {
            return ZalbaServis.PretraziZalbe(idZalbe);
        }

        public static List<Zalba> PrikaziSveZalbe()
        {
            return ZalbaServis.PrikaziSveZalbe();
        }

        public static Zalba UpisiNovuZalbu(Zalba zalba)
        {
            return ZalbaServis.UpisiNovuZalbu(zalba);
        }
    }
}
