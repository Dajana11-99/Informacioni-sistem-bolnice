using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.Maper
{
   public class TerminMaper
    {
        internal TerminDTO SlobodanTerminModelUDto(Termin termin)
        {
            return new TerminDTO(termin.IdTermina, termin.Datum, termin.Vreme, termin.Lekar, termin.TrajanjeTermina.ToString(), termin.Sala.Id, termin.TipTermina.ToString());
        }

        internal TerminDTO ZakazaniTerminModelUDto(Termin termin)
        {
            return new TerminDTO(termin.IdTermina, termin.Datum, termin.Vreme, termin.Lekar, termin.TrajanjeTermina.ToString(), termin.Sala.Id, termin.TipTermina.ToString(), termin.Pacijent.IdPacijenta);
        }
    }
}
