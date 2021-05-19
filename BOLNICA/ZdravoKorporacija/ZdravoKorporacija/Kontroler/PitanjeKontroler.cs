using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Kontroler
{
    public class PitanjeKontroler
    {
        PitanjeServis pitanjeServis = new PitanjeServis();
        public List<Pitanje> DobaviSvaPitanjaOBolnici()
        {

            return pitanjeServis.DobaviSvaPitanjaOBolnici();
        }

        public List<Pitanje> DobaviSvaPitanjaOPregledu()
        {
            return pitanjeServis.DobaviSvaPitanjaOPregledu();

        }
    }
}
