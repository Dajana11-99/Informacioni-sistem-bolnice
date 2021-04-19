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
    public class SkladisteZahtevZaRasporedjivanjeDinamickeOpreme
    {
        public static List<ZahtevZaRasporedjivanjeDinamickeOpreme> UcitajZahtevZaRasporedjivanjeDinamickeOpreme()
        {
            if (!File.Exists("ZahtevZaRasporedjivanjeDinamickeOpreme.xml") || File.ReadAllText("ZahtevZaRasporedjivanjeDinamickeOpreme.xml").Trim().Equals(""))
            {
                return new List<ZahtevZaRasporedjivanjeDinamickeOpreme>();
            }
            else
            {
                FileStream fileStream = File.OpenRead("ZahtevZaRasporedjivanjeDinamickeOpreme.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ZahtevZaRasporedjivanjeDinamickeOpreme>));
                var sale = (List<ZahtevZaRasporedjivanjeDinamickeOpreme>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sale;

            }

        }

        public static bool UpisiZahtevZaRasporedjivanjeDinamickeOpreme()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StatickaOprema>));
            TextWriter tw = new StreamWriter("ZahtevZaRasporedjivanjeDinamickeOpreme.xml");
            xmlSerializer.Serialize(tw, RukovanjeStatickomOpremom.statickaOprema);
            tw.Close();
            return true;
        }

    }
}
