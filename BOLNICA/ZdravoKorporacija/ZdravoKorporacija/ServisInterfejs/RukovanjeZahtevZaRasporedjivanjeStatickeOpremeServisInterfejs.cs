using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.ServisInterfejs
{
    public interface RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs : GlavniServisInterfejs<ZahtevZaRasporedjivanjeStatickeOpreme>
    {
        void Inicijalizuj();
        bool DodajZahtevIzDrugeSale(ZahtevZaRasporedjivanjeStatickeOpreme zahtev);
        RasporedjenaStatickaOprema RasporedjenaStatickaOpremaSale(ZahtevZaRasporedjivanjeStatickeOpreme zahtev, List<RasporedjenaStatickaOprema> rasporedjena);
        bool DodajStatickuOpremuIzSkladista(ZahtevZaRasporedjivanjeStatickeOpreme zahtev);
        String pronadji();
    }
}
