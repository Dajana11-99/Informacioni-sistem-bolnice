using Kontroler;
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
   public class BeleskaKontroler
    {
        private BeleskaServis beleskaServis = new BeleskaServis();
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        public Beleska PretraziBeleskuPoId(String idBeleske)
        {
            return beleskaServis.PretraziBeleskuPoId(idBeleske);
        }
        public void SacuvajBelesku(BeleskaDTO beleskaDTO)
        {
            Beleska beleska = new Beleska(beleskaDTO.TekstBeleske, beleskaDTO.DatumBeleske, beleskaDTO.IdBeleske, naloziPacijenataKontroler.PretragaPoId(beleskaDTO.IdPacijenta).karton.Anamneza);
            beleskaServis.SacuvajBelesku(beleska);

        }
    }
}
