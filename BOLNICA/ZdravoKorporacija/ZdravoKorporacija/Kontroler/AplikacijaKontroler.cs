using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Kontroler
{
   public class AplikacijaKontroler
    {
        AplikacijaServis aplikacijaServis = new AplikacijaServis();
        public void SacuvajOcenuAplikacije(OcenaAplikacijeDTO ocena)
        {
            aplikacijaServis.SacuvajOcenuAplikacije(ocena);
        }
    }
}
