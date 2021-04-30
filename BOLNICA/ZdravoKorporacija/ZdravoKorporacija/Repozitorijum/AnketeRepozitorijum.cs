using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Repozitorijum
{
   public class AnketeRepozitorijum
    {
        public static String pitanjaFajl = "pitanjaOBolnici.xml";
        public static String sveAnketeFajl = "sveAnkete.xml";
 

        public static List<Pitanje> ucitajPitanjaOBolnici()
        {
            if (!File.Exists(pitanjaFajl) || File.ReadAllText(pitanjaFajl).Trim().Equals(""))
            {
                return AnketaServis.pitanja;
            }
            else
            {
                FileStream fileStream = File.OpenRead(pitanjaFajl);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pitanje>));
                AnketaServis.pitanja = (List<Pitanje>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return AnketaServis.pitanja;

            }

        }

        public static void upisiPitanjaOBolnici()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pitanje>));
            TextWriter tw = new StreamWriter(pitanjaFajl);
            xmlSerializer.Serialize(tw, AnketaServis.pitanja);
            tw.Close();

        }

        public static List<Ankete> ucitajAnkete()
        {
            if (!File.Exists(sveAnketeFajl) || File.ReadAllText(sveAnketeFajl).Trim().Equals(""))
            {
                return AnketaServis.popunjeneAnkete;
            }
            else
            {
                FileStream fileStream = File.OpenRead(sveAnketeFajl);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Ankete>));
                AnketaServis.popunjeneAnkete = (List<Ankete>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return AnketaServis.popunjeneAnkete;

            }

        }

        public static void upisiAnkete()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Ankete>));
            TextWriter tw = new StreamWriter(sveAnketeFajl);
            xmlSerializer.Serialize(tw, AnketaServis.popunjeneAnkete);
            tw.Close();

        }
    }
}
