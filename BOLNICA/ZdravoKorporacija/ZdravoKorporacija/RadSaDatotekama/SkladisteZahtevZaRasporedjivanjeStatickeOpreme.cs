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
    public class SkladisteZahtevZaRasporedjivanjeStatickeOpreme
    {
        public static List<ZahtevZaRasporedjivanjeStatickeOpreme> UcitajZahtevZaRasporedjivanjeStatickeOpreme()
        {
            if (!File.Exists("ZahtevZaRasporedjivanjeStatickeOpreme.xml") || File.ReadAllText("ZahtevZaRasporedjivanjeStatickeOpreme.xml").Trim().Equals(""))
            {
                return new List<ZahtevZaRasporedjivanjeStatickeOpreme>();
            }
            else
            {
                FileStream fileStream = File.OpenRead("ZahtevZaRasporedjivanjeStatickeOpreme.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ZahtevZaRasporedjivanjeStatickeOpreme>));
                var sale = (List<ZahtevZaRasporedjivanjeStatickeOpreme>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sale;

            }

        }

        public static bool UpisiZahtevZaRasporedjivanjeStatickeOpreme()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ZahtevZaRasporedjivanjeStatickeOpreme>));
            TextWriter tw = new StreamWriter("ZahtevZaRasporedjivanjeStatickeOpreme.xml");
            xmlSerializer.Serialize(tw, RukovanjeZahtevZaRasporedjivanjeStatickeOpreme.ZahtevZaRasporedjivanjeStatickeOpreme);
            tw.Close();
            return true;
        }

    }
}
