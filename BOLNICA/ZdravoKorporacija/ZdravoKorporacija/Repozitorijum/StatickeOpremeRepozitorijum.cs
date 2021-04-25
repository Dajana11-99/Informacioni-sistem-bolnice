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
    public class StatickeOpremeRepozitorijum
    {
        public static String imeFajla = "statickaOprema.xml";
        public static List<StatickaOprema> UcitajStatickuOpremu()
        {
            if (!File.Exists(imeFajla) || File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return new List<StatickaOprema>();
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StatickaOprema>));
                var sale = (List<StatickaOprema>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sale;

            }

        }

        public static bool UpisiStatickuOpremu()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StatickaOprema>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, RukovanjeStatickomOpremomServis.statickaOprema);
            tw.Close();
            return true;
        }

    }
}
