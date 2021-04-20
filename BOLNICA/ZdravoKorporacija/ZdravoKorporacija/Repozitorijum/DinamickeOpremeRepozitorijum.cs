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
        public static List<DinamickaOprema> UcitajDinamickuOpremu()
        {
            if (!File.Exists("dinamickaOprema.xml") || File.ReadAllText("dinamickaOprema.xml").Trim().Equals(""))
            {
                return new List<DinamickaOprema>();
            }
            else
            {
                FileStream fileStream = File.OpenRead("dinamickaOprema.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DinamickaOprema>));
                var op = (List<DinamickaOprema>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return op;

            }

        }

        public static bool UpisiDinamickuOpremu()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DinamickaOprema>));
            TextWriter tw = new StreamWriter("dinamickaOprema.xml");
            xmlSerializer.Serialize(tw, RukovanjeDinamickomOpremomServis.dinamickaOprema);
            tw.Close();
            return true;
        }

    }
}

