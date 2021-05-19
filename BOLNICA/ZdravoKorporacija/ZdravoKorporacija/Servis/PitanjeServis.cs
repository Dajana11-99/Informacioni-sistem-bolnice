using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.Servis
{
public class PitanjeServis
    {
        PitanjeRepozitorijum pitanjeRepozitorijum = new PitanjeRepozitorijum();
        public List<Pitanje> DobaviSvaPitanjaOBolnici()
        {

            return pitanjeRepozitorijum.DobaviSvaPitanjaOBolnici();
        }
      
        public List<Pitanje> DobaviSvaPitanjaOPregledu()
        {
            return pitanjeRepozitorijum.DobaviSvaPitanjaOPregledu();

        }
        
    }
}
