using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.RepozitorijumInterfejs;

namespace ZdravoKorporacija.Repozitorijum
{
  public  class BeleskaRepozitorijum : GlavniRepozitorijum<Beleska>, IBeleskaRepozitorijum
    {
       public BeleskaRepozitorijum()
        {
            imeFajla= "beleska.xml";
        }
      
        public Beleska PretraziBeleskuPoId(String idPacijenta)
        {
           
            foreach(Beleska beleska in DobaviSve())
            {
                if (beleska.Anamneza.idPacijenta.Equals(idPacijenta))
                    return beleska;
            }
            return null;
        }
     
    }
}
