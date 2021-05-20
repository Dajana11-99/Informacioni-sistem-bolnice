using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.Servis
{
   public class ObavestenjaServis
    {

        ObavestenjaRepozitorijum obavestenjaRepozitorijum = new ObavestenjaRepozitorijum();
        public  void DodajObavestenjePacijentu(Obavestenja obavestenje)
        {
            obavestenjaRepozitorijum.SacuvajObavestenje(obavestenje);
        }
        public Obavestenja PretraziPoId(String idObavestenja)
        {
            return obavestenjaRepozitorijum.PretraziPoId(idObavestenja);
        }
        public List<Obavestenja> DobaviSvaObavestenja()
        {
            return obavestenjaRepozitorijum.DobaviSvaObavestenja();
        }
        public List<Obavestenja> PretraziObavestenjaPoPacijentu(String idPacijenta)
        {
            return obavestenjaRepozitorijum.PretraziObavestenjaPoPacijentu(idPacijenta);
        }

     
    }
}
