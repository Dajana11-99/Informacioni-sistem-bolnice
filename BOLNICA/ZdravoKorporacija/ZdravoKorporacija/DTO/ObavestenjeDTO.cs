using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.DTO
{
    public class ObavestenjeDTO
    {
        private String idObavestenja;
        private String naslov;
        private String tekst;
        private DateTime datum;
        private String idPrimaoca;

        public String IdObavestenja
        {
            get { return idObavestenja; }
            set { idObavestenja = value; }
        }
        public String Naslov
        {
            get { return naslov; }
            set { naslov = value; }
        }
        public String Tekst
        {
            get { return tekst; }
            set { tekst = value; }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
        }
        public String IdPrimaoca
        {
            get { return idPrimaoca; }
            set { idPrimaoca = value; }
        }
        public ObavestenjeDTO(string idObavestenja, string naslov, string tekst, DateTime datum, string idPrimaoca)
        {
            this.idObavestenja = idObavestenja;
            this.naslov = naslov;
            this.tekst = tekst;
            this.datum = datum;
            this.idPrimaoca = idPrimaoca;
        }


    }
}
