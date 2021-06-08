using PoslovnaLogika;
using Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.ServisInterfejs;

namespace ZdravoKorporacija.GrafZavisnosti
{
    public class Startup
    {
        public void RegistrujKontrolere()
        {

        }

        public void RegistrujServise()
        {
            Injektor.Instance.Add(typeof(SalaServisInterfejs), typeof(SalaServis));
            Injektor.Instance.Add(typeof(LekServisInterfejs), typeof(LekServis));
            Injektor.Instance.Add(typeof(RukovanjeDinamickomOpremomServisInterfejs), typeof(RukovanjeDinamickomOpremomServis));
            Injektor.Instance.Add(typeof(RukovanjeStatickomOpremomServisInterfejs), typeof(RukovanjeStatickomOpremomServis));
            Injektor.Instance.Add(typeof(RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs), typeof(RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis));
            Injektor.Instance.Add(typeof(RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs), typeof(RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis));
        }

        public void RegistrujRepozitorijuma()
        {

        }

        public void InicijalizujKomponente()
        {
            SalaServisInterfejs salaServis = Injektor.Instance.Get<SalaServisInterfejs>(typeof(SalaServisInterfejs));
            salaServis.inicijalizuj();
            LekServisInterfejs lekServisInterfejs = Injektor.Instance.Get<LekServisInterfejs>(typeof(LekServisInterfejs));
           lekServisInterfejs.inicijalizuj();
            RukovanjeDinamickomOpremomServisInterfejs rukovanjeDinamickomOpremomServisInterfejs = Injektor.Instance.Get<RukovanjeDinamickomOpremomServisInterfejs>(typeof(RukovanjeDinamickomOpremomServisInterfejs));
            rukovanjeDinamickomOpremomServisInterfejs.inicijalizuj();
            RukovanjeStatickomOpremomServisInterfejs rukovanjeStatickomOpremomServisInterfejs = Injektor.Instance.Get<RukovanjeStatickomOpremomServisInterfejs>(typeof(RukovanjeStatickomOpremomServisInterfejs));
            rukovanjeStatickomOpremomServisInterfejs.inicijalizuj();
            RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs rukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs = Injektor.Instance.Get<RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs> (typeof(RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs));
            rukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs.Inicijalizuj();
            RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs rukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs = Injektor.Instance.Get<RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs>(typeof(RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs));
            rukovanjeZahtevZaRasporedjivanjeStatickeOpremeServisInterfejs.Inicijalizuj();

        }

    
    }
}
