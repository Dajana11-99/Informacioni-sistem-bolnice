using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Interfejs;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.RepozitorijumInterfejs
{
   public interface IBeleskaRepozitorijum:IRepozitorijum<Beleska>
    {
        Beleska PretraziBeleskuPoId(String idPacijenta);
    }
}
