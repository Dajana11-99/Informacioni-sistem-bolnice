using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.ViewModel
{
    public class TerminDTO
    {
        private String idTermin;
        private DateTime datum;
        private String vreme;
        private Lekar lekar;
        private String predvidjenoVreme;
        private String BrOperacioneSale;
        private String tipTermina;
        public TerminDTO(string idTermin, DateTime datum, string vreme, Lekar lekar, string predvidjenoVreme, string brOperacioneSale, String tipTermina)
        {
            this.idTermin = idTermin;
            this.datum = datum;
            this.vreme = vreme;
            this.lekar = lekar;
            this.predvidjenoVreme = predvidjenoVreme;
            this.BrOperacioneSale = brOperacioneSale;
            this.tipTermina = tipTermina;
        }

        public String GetIdTermina() 
        {
            return idTermin;
        }
        public DateTime GetDatum()
        {
            return datum;
        }
        public String GetVreme()
        {
            return vreme;
        }
        public String GetLekar()
        {
            return lekar.idZaposlenog;
        }
        public String GetPredvidjenoVreme()
        {
            return predvidjenoVreme;
        }
        public String GetBrOperacioneSale()
        {
            return BrOperacioneSale;
        }
        public String GetTipTermin()
        {
            return tipTermina;
        }
    }
}
