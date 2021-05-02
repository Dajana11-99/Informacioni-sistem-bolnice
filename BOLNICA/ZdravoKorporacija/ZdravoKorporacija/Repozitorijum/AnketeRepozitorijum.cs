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
        public static String sveAnketeFajl = "sveAnkete.xml";
        public static List<Ankete> UcitajAnkete()
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

        public static void UpisiAnkete()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Ankete>));
            TextWriter tw = new StreamWriter(sveAnketeFajl);
            xmlSerializer.Serialize(tw, AnketaServis.popunjeneAnkete);
            tw.Close();

        }
    }
}
