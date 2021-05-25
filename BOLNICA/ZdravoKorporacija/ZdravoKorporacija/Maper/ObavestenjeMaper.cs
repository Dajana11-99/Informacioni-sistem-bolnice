using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Maper
{
   public class ObavestenjeMaper
    {
        public ObavestenjeDTO ObavestenjeModelUDto(Obavestenja obavestenje)
        {
            return new ObavestenjeDTO(obavestenje.IdObavestenja, obavestenje.Naslov, obavestenje.Tekst, obavestenje.Datum, obavestenje.IdPrimaoca);
        }
        public Obavestenja ObavestenjeDtoUModel(ObavestenjeDTO obavestenje)
        {
            return new Obavestenja(obavestenje.IdObavestenja, obavestenje.Naslov, obavestenje.Tekst, obavestenje.Datum, obavestenje.IdPrimaoca);
        }
    }
}
