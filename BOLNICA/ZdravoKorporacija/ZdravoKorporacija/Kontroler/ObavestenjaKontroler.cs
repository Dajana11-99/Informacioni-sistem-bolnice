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
        public void DodajObavestenjePacijentu(ObavestenjeDTO obavestenjeDto)
        {
            Obavestenja obavestenja = new Obavestenja(obavestenjeDto.IdObavestenja, obavestenjeDto.Naslov, obavestenjeDto.Tekst, obavestenjeDto.Datum, obavestenjeDto.IdPrimaoca);
            obavestenjaServis.DodajObavestenjePacijentu(obavestenja);
        }
        public Obavestenja PretraziPoId(String idObavestenja)
        {
            return obavestenjaServis.PretraziPoId(idObavestenja);
        }
        public List<Obavestenja> DobaviSvaObavestenja()
        {
            return obavestenjaServis.DobaviSvaObavestenja();
        }
        public List<ObavestenjeDTO> PretraziObavestenjaPoPacijentu(String idPacijenta)
        {
            List<ObavestenjeDTO> obavestenjaPacijenta = new List<ObavestenjeDTO>();
            foreach(Obavestenja obavestenje in obavestenjaServis.PretraziObavestenjaPoPacijentu(idPacijenta))
            {
                obavestenjaPacijenta.Add(new ObavestenjeDTO(obavestenje.IdObavestenja, obavestenje.Naslov,obavestenje.Tekst, obavestenje.Datum, obavestenje.IdPrimaoca));
            }
            return obavestenjaPacijenta;
           
        }


    }
}
