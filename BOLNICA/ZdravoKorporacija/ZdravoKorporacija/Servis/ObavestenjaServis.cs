using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Interfejs;
using ZdravoKorporacija.Maper;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.Servis
{
   public class ObavestenjaServis
    {

        private ObavestenjeRepozitorijumInterfejs obavestenjaRepozitorijum = new ObavestenjaRepozitorijum();
        private ObavestenjeMaper obavestenjeMaper = new ObavestenjeMaper();
        public  void DodajObavestenjePacijentu(ObavestenjeDTO obavestenje)
        {
            obavestenjaRepozitorijum.Dodaj(obavestenjeMaper.ObavestenjeDtoUModel(obavestenje));
        }
        public List<ObavestenjeDTO> PretraziObavestenjaPoPacijentu(String idPacijenta)
        {
            string upit = "//ArrayOfObavestenja/Obavestenja[IdPrimaoca='" + idPacijenta + "']";
            List<ObavestenjeDTO> obavestenjaPacijenta = new List<ObavestenjeDTO>();
            foreach(Obavestenja obavestenje in obavestenjaRepozitorijum.PretraziPoIdObjekta(upit))
            {
                obavestenjaPacijenta.Add(obavestenjeMaper.ObavestenjeModelUDto(obavestenje));
            }
           return SortirajPoDatumu(obavestenjaPacijenta);
        }
        private List<ObavestenjeDTO> SortirajPoDatumu(List<ObavestenjeDTO> nesortiranaObavestenja)
        {
            return nesortiranaObavestenja.OrderByDescending(user => user.Datum).ToList();
        }
     
    }
}
