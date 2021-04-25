using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Repozitorijum
{
    class ObavestenjaRepozitorijum
    {

        public static String imeFajla = "obavestenja.txt";

        public static List<Obavestenja> Ucitaj()
        {
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return new List<Obavestenja>();
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Obavestenja>));
                ObavestenjaServis.svaObavestenja = (List<Obavestenja>)serializer.Deserialize(fileStream);
                fileStream.Close();
                return ObavestenjaServis.svaObavestenja;
            }
        }

        public static void Sacuvaj()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Obavestenja>));
            TextWriter fileStream = new StreamWriter(imeFajla);
            serializer.Serialize(fileStream, ObavestenjaServis.svaObavestenja);
            fileStream.Close();
        }
    }
}
