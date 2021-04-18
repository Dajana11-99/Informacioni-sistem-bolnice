using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Model;
using PoslovnaLogika;

namespace ZdravoKorporacija.RadSaDatotekama
{
    class SkladisteStatickeOpreme
    {
        public static List<StatickaOprema> UcitajStatickuOpremu()
        {
            if (!File.Exists("statickaOprema.xml") || File.ReadAllText("statickaOprema.xml").Trim().Equals(""))
            {
                return new List<StatickaOprema>();
            }
            else
            {
                FileStream fileStream = File.OpenRead("statickaOprema.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StatickaOprema>));
                var sale = (List<StatickaOprema>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sale;

            }

        }

        public static bool UpisiStatickuOpremu()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StatickaOprema>));
            TextWriter tw = new StreamWriter("statickaOprema.xml");
            xmlSerializer.Serialize(tw, RukovanjeStatickomOpremom.statickaOprema);
            tw.Close();
            return true;
        }

    }
}
