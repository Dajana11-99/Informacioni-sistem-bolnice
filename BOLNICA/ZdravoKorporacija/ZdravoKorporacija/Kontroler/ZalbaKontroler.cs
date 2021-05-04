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
        public static Zalba pretraziZalbe(String idZalbe)
        {
            return ZalbaServis.pretraziZalbe(idZalbe);
        }

        public static List<Zalba> prikaziSveZalbe()
        {
            return ZalbaServis.prikaziSveZalbe();
        }

        public static Zalba upisiNovuZalbu(Zalba zalba)
        {
            return ZalbaServis.upisiNovuZalbu(zalba);
        }
    }
}
