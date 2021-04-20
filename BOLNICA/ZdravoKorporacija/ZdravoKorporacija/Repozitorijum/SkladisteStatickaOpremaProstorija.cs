using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Model;
using PoslovnaLogika;

namespace RadSaDatotekama
{
    class SkladisteStatickaOpremaProstorija
    {
        public static List<StatickaOpremaProstorija> UcitajStatickaOpremaProstorija()
        {
            if (!File.Exists("statickaOpremaProstorija.xml") || File.ReadAllText("statickaOpremaProstorija.xml").Trim().Equals(""))
            {
                return new List<StatickaOpremaProstorija>();
            }
            else
            {
                FileStream fileStream = File.OpenRead("statickaOpremaProstorija.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StatickaOpremaProstorija>));
                var sale = (List<StatickaOpremaProstorija>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sale;

            }

        }

        public static bool UpisiStatickaOpremaProstorija()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StatickaOprema>));
            TextWriter tw = new StreamWriter("statickaOprema.xml");
            xmlSerializer.Serialize(tw, RukovanjeStatickomOpremom.statickaOprema);
            tw.Close();
            return true;
        }

    }
}
