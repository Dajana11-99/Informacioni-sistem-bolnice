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
        public static Lek PretraziLekove(String idLeka)
        {
            return LekServis.PretraziSveLekove(idLeka);
        }

        public static List<Lek> PrikaziSveLekove()
        {
            return LekServis.PrikaziSveLekove();
        }

        public static Lek IzmeniLek(Lek lek)
        {
            return LekServis.IzmeniSelektovaniLek(lek);
        }
    }
}
