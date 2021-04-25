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
    public class DinamickeOpremeRepozitorijum
    {
        public static String imeFajla = "dinamickaOprema.xml";
        public static List<DinamickaOprema> UcitajDinamickuOpremu()
        {
            if (!File.Exists(imeFajla) || File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return new List<DinamickaOprema>();
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DinamickaOprema>));
                var op = (List<DinamickaOprema>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return op;

            }

        }

        public static bool UpisiDinamickuOpremu()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DinamickaOprema>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, RukovanjeDinamickomOpremomServis.dinamickaOprema);
            tw.Close();
            return true;
        }

    }
}

