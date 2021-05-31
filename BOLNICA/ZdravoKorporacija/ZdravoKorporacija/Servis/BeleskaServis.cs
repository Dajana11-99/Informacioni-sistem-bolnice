using Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Maper;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.Servis
{
  public  class BeleskaServis
    {
        private BeleskaRepozitorijum beleskaRepozitorijum = new BeleskaRepozitorijum();
        private BeleskaMaper beleskaMaper = new BeleskaMaper();
       
        public String PronadjiTekstBeleske(String idPacijenta)
        {
            if (beleskaRepozitorijum.PretraziBeleskuPoId(idPacijenta)==null)
                return   "";
            return beleskaRepozitorijum.PretraziBeleskuPoId(idPacijenta).TekstBeleske;
        }
        public void SacuvajBelesku(BeleskaDTO beleska)
        {
            beleskaRepozitorijum.SacuvajBelesku(beleskaMaper.BeleskaDtoUModel(beleska));
        }
    }
}
