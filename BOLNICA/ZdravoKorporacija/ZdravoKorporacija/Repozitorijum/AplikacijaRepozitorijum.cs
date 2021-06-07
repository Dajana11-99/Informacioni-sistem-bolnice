using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Repozitorijum
{
    public class AplikacijaRepozitorijum: GlavniRepozitorijum<OcenaAplikacije>
    {
        public AplikacijaRepozitorijum()
        {
            imeFajla = "ocenaAplikacije.xml";
        }
    }
}
