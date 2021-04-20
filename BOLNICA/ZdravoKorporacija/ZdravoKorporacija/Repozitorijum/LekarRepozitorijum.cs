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
        public static List<Lekar> ucitajLekare()
        {
            if (!File.Exists("lekari.xml") || File.ReadAllText("lekari.xml").Trim().Equals(""))
            {
                return TerminServis.pom;
            }
            else
            {
                FileStream fileStream = File.OpenRead("lekari.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lekar>));
                TerminServis.pom = (List<Lekar>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return TerminServis.pom;

            }

        }

        public static void upisiLekare()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lekar>));
            TextWriter tw = new StreamWriter("lekari.xml");
            xmlSerializer.Serialize(tw, TerminServis.pom);
            tw.Close();

        }

    }
}
