using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Repozitorijum
{
    public class PitanjeRepozitorijum
    {

        public String pitanjaOBolniciFajl = "pitanjaOBolnici.xml";
        public String pitanjaOPregleduFajl = "pitanjaOPregledu.xml";

        public List<Pitanje> DobaviSvaPitanjaOBolnici()
        {
            List<Pitanje> pitanjaOBolnici = new List<Pitanje>();
            if (!File.Exists(pitanjaOBolniciFajl) || File.ReadAllText(pitanjaOBolniciFajl).Trim().Equals(""))
            {
                return pitanjaOBolnici;
            }
            else
            {
                FileStream fileStream = File.OpenRead(pitanjaOBolniciFajl);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pitanje>));
                pitanjaOBolnici = (List<Pitanje>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return pitanjaOBolnici;
            }

        }
     
        public List<Pitanje> DobaviSvaPitanjaOPregledu()
        {
            List<Pitanje> pitanjaOPregledu = new List<Pitanje>();
            if (!File.Exists(pitanjaOPregleduFajl) || File.ReadAllText(pitanjaOPregleduFajl).Trim().Equals(""))
            {
                return pitanjaOPregledu;
            }
            else
            {
                FileStream fileStream = File.OpenRead(pitanjaOPregleduFajl);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pitanje>));
                pitanjaOPregledu = (List<Pitanje>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return pitanjaOPregledu;
            }

        }
      
    }
}
