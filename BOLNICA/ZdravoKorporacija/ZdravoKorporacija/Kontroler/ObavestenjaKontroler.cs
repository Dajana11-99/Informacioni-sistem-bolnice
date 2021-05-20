using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Kontroler
{
   public class ObavestenjaKontroler
    {
        ObavestenjaServis obavestenjaServis = new ObavestenjaServis();
        public void DodajObavestenjePacijentu(Obavestenja obavestenje)
        {
            obavestenjaServis.DodajObavestenjePacijentu(obavestenje);
        }
        public Obavestenja PretraziPoId(String idObavestenja)
        {
            return obavestenjaServis.PretraziPoId(idObavestenja);
        }
        public List<Obavestenja> DobaviSvaObavestenja()
        {
            return obavestenjaServis.DobaviSvaObavestenja();
        }
        public List<Obavestenja> PretraziObavestenjaPoPacijentu(String idPacijenta)
        {
            return obavestenjaServis.PretraziObavestenjaPoPacijentu(idPacijenta);
        }


    }
}
