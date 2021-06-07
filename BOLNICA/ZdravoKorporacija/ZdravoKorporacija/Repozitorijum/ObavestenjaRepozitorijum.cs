using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ZdravoKorporacija.Interfejs;
using ZdravoKorporacija.IRepozitorijum;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Repozitorijum
{
   public class ObavestenjaRepozitorijum: GlavniRepozitorijum<Obavestenja>, IObavestenjeRepozitorijum
    {

        public ObavestenjaRepozitorijum()
        {
             imeFajla = "obavestenja.xml";
        }

        public List<Obavestenja> DobaviObavestenjaPacijenta(string idPacijenta)
        {
            return PretraziPoIdObjekta("//ArrayOfObavestenja/Obavestenja[IdPrimaoca='" + idPacijenta + "']");
        }

    }
}
