
using Model;
using Servis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ZdravoKorporacija.RepozitorijumInterfejs;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Repozitorijum
{
   public class AnketeRepozitorijum: GlavniRepozitorijum<Ankete>
    {
       
        ZakazaniTerminiServis zakazaniTerminiServis = new ZakazaniTerminiServis();

        public AnketeRepozitorijum()
        {
            imeFajla = "sveAnkete.xml";
        }
      
      
    }
}
