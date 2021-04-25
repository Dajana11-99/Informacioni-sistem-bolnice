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
    public class SkladisteZahtevZaRasporedjivanjeStatickeOpreme
    {
        public static String imeFajla = "ZahtevZaRasporedjivanjeStatickeOpreme.xml";
        public static List<ZahtevZaRasporedjivanjeStatickeOpreme> UcitajZahtevZaRasporedjivanjeStatickeOpreme()
        {
            if (!File.Exists(imeFajla) || File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return new List<ZahtevZaRasporedjivanjeStatickeOpreme>();
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ZahtevZaRasporedjivanjeStatickeOpreme>));
                var sale = (List<ZahtevZaRasporedjivanjeStatickeOpreme>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sale;

            }

        }

        public static bool UpisiZahtevZaRasporedjivanjeStatickeOpreme()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ZahtevZaRasporedjivanjeStatickeOpreme>));
            TextWriter tw = new StreamWriter(imeFajla);
           // xmlSerializer.Serialize(tw, RukovanjeStatickomOpremomServis.statickaOprema);
            xmlSerializer.Serialize(tw, RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis.ZahtevZaRasporedjivanjeStatickeOpreme);
            tw.Close();
            return true;
        }

    }
}
