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
      
        public String PronadjiTekstBeleske(String idPacijenta)
        {
            return beleskaServis.PronadjiTekstBeleske(idPacijenta);
        }
        public void SacuvajBelesku(BeleskaDTO beleska)
        {
            beleskaServis.SacuvajBelesku(beleska);
        }
    }
}
