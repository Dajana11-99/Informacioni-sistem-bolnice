using Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Maper
{
   public class BeleskaMaper
    {
        private NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        public BeleskaDTO BeleskaModelUDto(Beleska beleska)
        {
            return new BeleskaDTO(beleska.TekstBeleske, beleska.DatumBeleske, beleska.IdBeleske, beleska.Anamneza.IdPacijenta);
        }

        public Beleska BeleskaDtoUModel(BeleskaDTO beleska)
        {
            return new Beleska(beleska.TekstBeleske, beleska.DatumBeleske, beleska.IdBeleske, naloziPacijenataServis.PretragaPoId(beleska.IdPacijenta).karton.Anamneza);
        }
    }
}
