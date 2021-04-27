using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Model;
using Servis;


namespace ZdravoKorporacija.Repozitorijum
{
    public class RenoviranjeRepozitorijum
    {
        public static List<Renoviranje> UcitajRenoviranja()
        {
            if (!File.Exists("renoviranja.xml") || File.ReadAllText("renoviranja.xml").Trim().Equals(""))
            {
                return RenoviranjeServis.renoviranje;
            }
            else
            {
                FileStream fileStream = File.OpenRead("renoviranja.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Renoviranje>));
                RenoviranjeServis.renoviranje = (List<Renoviranje>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return RenoviranjeServis.renoviranje;

            }

        }

        public static bool UpisiRenoviranja()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Renoviranje>));
            TextWriter tw = new StreamWriter("renoviranja.xml");
            xmlSerializer.Serialize(tw, RenoviranjeServis.renoviranje);
            tw.Close();
            return true;
        }

    }
}
