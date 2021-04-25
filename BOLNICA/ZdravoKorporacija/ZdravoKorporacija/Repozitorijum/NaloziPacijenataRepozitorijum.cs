using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Model;
using Servis;

namespace ZdravoKorporacija.Repozitorijum
{
   public class NaloziPacijenataRepozitorijum
    {
        public static String imeFajla = "pacijenti.xml";
        public static List<Pacijent> UcitajPacijente()
        {
            if (!File.Exists(imeFajla) || File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return NaloziPacijenataServis.ListaPacijenata;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pacijent>));
                NaloziPacijenataServis.ListaPacijenata = (List<Pacijent>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return NaloziPacijenataServis.ListaPacijenata;
            }
        }

        public static void UpisiPacijente()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pacijent>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, NaloziPacijenataServis.ListaPacijenata);
            tw.Close();
        }

    }
}
