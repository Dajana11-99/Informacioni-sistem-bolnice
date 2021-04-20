using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Model;
using Servis;


namespace ZdravoKorporacija.Repozitorijum
{
    public class SalaRepozitorijum
    {
        public static List<Sala> UcitajSale()
        {
            if (!File.Exists("sale.xml") || File.ReadAllText("sale.xml").Trim().Equals(""))
            {
                return SalaServis.sala;
            }
            else
            {
                FileStream fileStream = File.OpenRead("sale.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sala>));
                SalaServis.sala = (List<Sala>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return SalaServis.sala;

            }

        }

        public static bool UpisiSale()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sala>));
            TextWriter tw = new StreamWriter("sale.xml");
            xmlSerializer.Serialize(tw, SalaServis.sala);
            tw.Close();
            return true;
        }

    }
}
