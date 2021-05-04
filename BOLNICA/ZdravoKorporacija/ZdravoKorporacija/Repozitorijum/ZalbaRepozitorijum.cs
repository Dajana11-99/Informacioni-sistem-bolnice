using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Repozitorijum
{
    class ZalbaRepozitorijum
    {

        public static String zalbaFile = "zalba.xml" ;
        public static List<Zalba> ucitajZalbe()
        {
            if (!File.Exists(zalbaFile) || File.ReadAllText(zalbaFile).Trim().Equals(""))
            {
                return ZalbaServis.zalbe;
            }
            else
            {
                FileStream fileStream = File.OpenRead(zalbaFile);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Zalba>));
                ZalbaServis.zalbe = (List<Zalba>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return ZalbaServis.zalbe;
            }

        }

        public static void upisiZalbe()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Zalba>));
            TextWriter tw = new StreamWriter(zalbaFile);
            xmlSerializer.Serialize(tw, ZalbaServis.zalbe);
            tw.Close();
        }

        public static Zalba upisiNovuZalbu(Zalba zalba)
        {
            zalba.IdZalbe = Guid.NewGuid().ToString();
            ZalbaServis.zalbe.Add(zalba);
            upisiZalbe();
            return zalba;
        }

       
    }
}
