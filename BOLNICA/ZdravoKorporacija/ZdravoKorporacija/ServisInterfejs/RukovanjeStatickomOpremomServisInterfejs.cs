using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.ServisInterfejs
{
    public interface RukovanjeStatickomOpremomServisInterfejs : GlavniServisInterfejs<StatickaOprema>
    {
        void inicijalizuj();
        bool DodajStatickuOpremu(StatickaOprema unetaStatickaOprema);
        bool IzmeniStatickuOpremu(StatickaOprema statickaOpremaZaIzmenu);
        List<StatickaOprema> PrikaziStatickuOpremu();
        bool ObrisiStatickuOpremu(String id);
        StatickaOprema PretraziPoId(String id);
    }
}

