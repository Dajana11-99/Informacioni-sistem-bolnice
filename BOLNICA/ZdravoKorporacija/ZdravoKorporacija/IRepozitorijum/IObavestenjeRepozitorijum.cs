using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Interfejs;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.IRepozitorijum
{
   public  interface IObavestenjeRepozitorijum:IRepozitorijum<Obavestenja>
    {
        List<Obavestenja> DobaviObavestenjaPacijenta(String idPacijenta);
    }
}
