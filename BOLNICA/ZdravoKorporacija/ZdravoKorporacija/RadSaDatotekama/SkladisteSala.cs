using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Model;
using PoslovnaLogika;

namespace ZdravoKorporacija.RadSaDatotekama
{
    class SkladisteSala
    {
        public static List<Sala> UcitajSale()
        {
            if (!File.Exists("sale.xml") || File.ReadAllText("sale.xml").Trim().Equals(""))
            {
                return new List<Sala>();
            }
            else
            {
                FileStream fileStream = File.OpenRead("sale.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sala>));
                var sale = (List<Sala>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sale;

            }

        }

        public static bool UpisiSale()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sala>));
            TextWriter tw = new StreamWriter("sale.xml");
            xmlSerializer.Serialize(tw, RukovanjeSalama.sala);
            tw.Close();
            return true;
        }

    }
}
