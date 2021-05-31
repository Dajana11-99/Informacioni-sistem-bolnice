using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.Model
{
    public class Obavestenja {
        private String idObavestenja { get; set; }
        private String naslov;
        private String tekst;
        private DateTime datum;
        public String idPrimaoca;
        public String IdObavestenja
        {
            get { return idObavestenja; }
            set { idObavestenja = value; }
        }
        public DateTime Datum
        {
            get { return datum; }
            set { datum = value; }
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
        public String IdPrimaoca
        {
            get { return idPrimaoca; }
            set { idPrimaoca = value; }
        }
        public Obavestenja(string idObavestenja, string naslov, string tekst, DateTime datum, string idPrimaoca)
        {
            IdObavestenja = idObavestenja;
            Naslov = naslov;
            Tekst = tekst;
            Datum = datum;
            IdPrimaoca = idPrimaoca;
        }

        public Obavestenja() { }

    
    }
}

