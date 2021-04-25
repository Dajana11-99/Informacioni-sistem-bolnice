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
    class LekarRepozitorijum
    {
        public static String imeFajla = "lekari.xml";
        public static List<Lekar> ucitajLekare()
        {
            if (!File.Exists(imeFajla) || File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return TerminServis.pom;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lekar>));
                TerminServis.pom = (List<Lekar>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return TerminServis.pom;

            }

        }

        public static void upisiLekare()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lekar>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, TerminServis.pom);
            tw.Close();

        }

    }
}
