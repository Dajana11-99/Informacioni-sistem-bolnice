using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Maper;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.Servis
{
   public class AplikacijaServis
    {
        AplikacijaRepozitorijum aplikacijaRepozitorijum = new AplikacijaRepozitorijum();
        OcenaAplikacijeMaper ocenaAplikacijeMaper = new OcenaAplikacijeMaper();
        public void SacuvajOcenuAplikacije(OcenaAplikacijeDTO ocena)
        {
            aplikacijaRepozitorijum.Dodaj(ocenaAplikacijeMaper.OcenaAplikacijeDTOUModel(ocena));
        }
    }
}
