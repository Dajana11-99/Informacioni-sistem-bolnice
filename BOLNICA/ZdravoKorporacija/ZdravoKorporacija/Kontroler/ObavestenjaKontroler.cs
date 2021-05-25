using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Kontroler
{
   public class ObavestenjaKontroler
    {
        ObavestenjaServis obavestenjaServis = new ObavestenjaServis();
        public void DodajObavestenjePacijentu(ObavestenjeDTO obavestenje)
        {
            obavestenjaServis.DodajObavestenjePacijentu(obavestenje);
        }
        public List<ObavestenjeDTO> PretraziObavestenjaPoPacijentu(String idPacijenta)
        {
            return obavestenjaServis.PretraziObavestenjaPoPacijentu(idPacijenta);

        }


    }
}
