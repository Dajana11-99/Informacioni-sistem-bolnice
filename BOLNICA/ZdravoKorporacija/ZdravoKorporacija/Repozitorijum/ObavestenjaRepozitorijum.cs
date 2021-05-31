using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ZdravoKorporacija.Interfejs;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Repozitorijum
{
   public class ObavestenjaRepozitorijum:GlavniRepozitorijum<Obavestenja>,ObavestenjeRepozitorijumInterfejs
    {

        public ObavestenjaRepozitorijum()
        {
             imeFajla = "obavestenja.xml";
        }

       
    }
}
