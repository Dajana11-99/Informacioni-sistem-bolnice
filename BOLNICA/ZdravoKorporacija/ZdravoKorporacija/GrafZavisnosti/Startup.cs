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

        }

        public void RegistrujRepozitorijuma()
        {

        }

        public void InicijalizujKomponente()
        {
            SalaServisInterfejs salaServis = Injektor.Instance.Get<SalaServisInterfejs>(typeof(SalaServisInterfejs));
            salaServis.inicijalizuj();
        }

    
    }
}
