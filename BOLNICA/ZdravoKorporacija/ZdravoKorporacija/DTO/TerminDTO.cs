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
        public String IdTermina
        {
            get { return idTermin; }
            set { idTermin = value; OnPropertyChanged("Id"); }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; OnPropertyChanged("Datum"); }
        }
        public String Vreme
        {
            get { return vreme; }
            set { vreme = value; OnPropertyChanged("Vreme"); }
        }

        public Lekar Lekar
        {
            get { return lekar; }
            set { lekar = value; OnPropertyChanged("Lekar"); }
        }

        public String PredvidjenoVreme
        {
            get { return predvidjenoVreme; }
            set { predvidjenoVreme = value; OnPropertyChanged("PredvidjenoVreme"); }
        }

        public String NazivSale
        {
            get { return BrOperacioneSale; }
            set { BrOperacioneSale = value; OnPropertyChanged("NazivSale"); }
        }
        public String TipTermina
        {
            get { return tipTermina; }
            set { tipTermina = value; OnPropertyChanged("TipTermina"); }
        }
    }
}
