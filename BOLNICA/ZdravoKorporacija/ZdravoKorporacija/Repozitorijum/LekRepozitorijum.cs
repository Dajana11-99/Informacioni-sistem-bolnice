using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Model;
using Servis;


namespace ZdravoKorporacija.Repozitorijum
{
    class LekRepozitorijum
    {
        public static List<Lek> UcitajLekove()
        {
            if (!File.Exists("lekovi.xml") || File.ReadAllText("lekovi.xml").Trim().Equals(""))
            {
                return LekServis.lek;
            }
            else
            {
                FileStream fileStream = File.OpenRead("lekovi.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lek>));
                LekServis.lek = (List<Lek>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return LekServis.lek;

            }

        }

        public static bool UpisiLekove()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lek>));
            TextWriter tw = new StreamWriter("lekovi.xml");
            xmlSerializer.Serialize(tw, LekServis.lek);
            tw.Close();
            return true;
        }
    }
}
