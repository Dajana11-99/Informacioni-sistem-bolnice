using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.ViewModel
{
    public class TerminDTO:ViewModel
    {
        private String idTermin;
        private DateTime datum;
        private String vreme;
        private Lekar lekar;
        private String predvidjenoVreme;
        private String BrOperacioneSale;
        private String tipTermina;
        private String idPacijenta;

        public TerminDTO(string idTermin, DateTime datum, string vreme, Lekar lekar, string predvidjenoVreme, string brOperacioneSale, string tipTermina, string idPacijenta) : this(idTermin)
        {
            this.datum = datum;
            this.vreme = vreme;
            this.lekar = lekar;
            this.predvidjenoVreme = predvidjenoVreme;
            BrOperacioneSale = brOperacioneSale;
            this.tipTermina = tipTermina;
            this.idPacijenta = idPacijenta;
        }

        public TerminDTO(string idTermin, DateTime datum, string vreme, Lekar lekar, string predvidjenoVreme, string brOperacioneSale, string tipTermina) : this(idTermin)
        {
            this.datum = datum;
            this.vreme = vreme;
            this.lekar = lekar;
            this.predvidjenoVreme = predvidjenoVreme;
            BrOperacioneSale = brOperacioneSale;
            this.tipTermina = tipTermina;
        }

        public String IdTermina
        {
            get { return idTermin; }
            set { idTermin = value; }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public String Vreme
        {
            get { return vreme; }
            set { vreme = value; }
        }
        public String IdPacijenta
        {
            get { return idPacijenta; }
            set { idPacijenta = value; }
        }

        public Lekar Lekar
        {
            get { return lekar; }
            set { lekar = value; }
        }

        public String PredvidjenoVreme
        {
            get { return predvidjenoVreme; }
            set { predvidjenoVreme = value; }
        }

        public String NazivSale
        {
            get { return BrOperacioneSale; }
            set { BrOperacioneSale = value; }
        }
        public String TipTermina
        {
            get { return tipTermina; }
            set { tipTermina = value; }
        }


        public TerminDTO(string idTermin)
        {
            this.idTermin = idTermin;
        }

    }
}
