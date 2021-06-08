using Model;
using Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.GrafZavisnosti;
using ZdravoKorporacija.Servis;
using ZdravoKorporacija.ServisInterfejs;

namespace ZdravoKorporacija.Kontroler
{
    public class LekKontroler
    {
        public static Lek PretraziLekove(String idLeka)
        {
            LekServisInterfejs lekServis = Injektor.Instance.Get<LekServisInterfejs>(typeof(LekServisInterfejs));
            return lekServis.PretraziSveLekove(idLeka);
        }

        public static List<Lek> PrikaziSveLekove()
        {
            LekServisInterfejs lekServis = Injektor.Instance.Get<LekServisInterfejs>(typeof(LekServisInterfejs));
            return lekServis.PrikaziSveLekove();
        }

        public static Lek IzmeniLek(Lek lek)
        {
            LekServisInterfejs lekServis = Injektor.Instance.Get<LekServisInterfejs>(typeof(LekServisInterfejs));
            return lekServis.IzmeniSelektovaniLek(lek);
        }
    }
}
