using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Model;
using PoslovnaLogika;
using Servis;

namespace ZdravoKorporacija.Repozitorijum
{
    public class SkladisteZahtevZaRasporedjivanjeDinamickeOpreme
    {
        public static String imeFajla = "ZahtevZaRasporedjivanjeDinamickeOpreme.xml";
        public static List<ZahtevZaRasporedjivanjeDinamickeOpreme> UcitajZahtevZaRasporedjivanjeDinamickeOpreme()
        {
            if (!File.Exists(imeFajla) || File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return new List<ZahtevZaRasporedjivanjeDinamickeOpreme>();
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ZahtevZaRasporedjivanjeDinamickeOpreme>));
                var sale = (List<ZahtevZaRasporedjivanjeDinamickeOpreme>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sale;

            }

        }

        public static bool UpisiZahtevZaRasporedjivanjeDinamickeOpreme()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ZahtevZaRasporedjivanjeDinamickeOpreme>));
            TextWriter tw = new StreamWriter(imeFajla);
           // xmlSerializer.Serialize(tw, RukovanjeStatickomOpremomServis.statickaOprema);
            xmlSerializer.Serialize(tw, RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.rasporedjivanjeDinamickeOpremeZahtev);
            tw.Close();
            return true;
        }

    }
}
