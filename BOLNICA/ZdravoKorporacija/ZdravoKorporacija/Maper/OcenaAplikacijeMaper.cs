using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Maper
{
    public class OcenaAplikacijeMaper
    {
        public OcenaAplikacije OcenaAplikacijeDTOUModel(OcenaAplikacijeDTO ocena)
        {
            return new OcenaAplikacije(ocena.KorisnickoIme, ocena.Ocena, ocena.Datum, ocena.Komentar);
        }
    }
}
