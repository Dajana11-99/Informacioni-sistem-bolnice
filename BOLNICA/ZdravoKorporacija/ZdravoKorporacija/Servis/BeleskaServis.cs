using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.Servis
{
  public  class BeleskaServis
    {
        private BeleskaRepozitorijum beleskaRepozitorijum = new BeleskaRepozitorijum();
        public Beleska PretraziBeleskuPoId(String idBeleske)
        {
            return beleskaRepozitorijum.PretraziBeleskuPoId(idBeleske);
        }
        public void SacuvajBelesku(Beleska beleska)
        {
            beleskaRepozitorijum.SacuvajBelesku(beleska);
           
        }
    }
}
