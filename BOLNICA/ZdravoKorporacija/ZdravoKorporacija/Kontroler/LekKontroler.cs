using Model;
using Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Kontroler
{
    class LekKontroler
    {
        public static Lek pretraziLekove(String idLeka)
        {
            return LekServis.pretraziSveLekove(idLeka);
        }

        public static List<Lek> prikaziSveLekove()
        {
            return LekServis.prikaziSveLekove();
        }

        public static Lek IzmeniLek(Lek lek)
        {
            return LekServis.IzmeniSelektovaniLek(lek);
        }
    }
}
