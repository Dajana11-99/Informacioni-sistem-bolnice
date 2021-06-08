using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.ServisInterfejs
{
    public interface LekServisInterfejs : GlavniServisInterfejs<Lek>
    {
        void inicijalizuj();
        bool DodajLek(Lek unetiLek);
        Lek PretraziPoId(String id);
        List<Lek> PrikaziLekove();
        bool Izmena(Lek lekZaIzmenu);
        Lek PretraziSveLekove(String idLeka);
        List<Lek> PrikaziSveLekove();
        Lek IzmeniSelektovaniLek(Lek lek);
        bool BrisanjeLeka(String idLeka);
    }
}
