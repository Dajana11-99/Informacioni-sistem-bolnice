using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ZdravoKorporacija.Model;

namespace ZdravoKorporacija.Repozitorijum
{
  public  class BeleskaRepozitorijum
    {
        private String nazivFajla = "beleska.xml";
        public List<Beleska> DobaviSveBeleske()
        {
            List<Beleska> sveBeleske = new List<Beleska>();
            if (!File.Exists(nazivFajla) || File.ReadAllText(nazivFajla).Trim().Equals(""))
            {
                return sveBeleske;
            }
            else
            {
                FileStream fileStream = File.OpenRead(nazivFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Beleska>));
                sveBeleske = (List<Beleska>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sveBeleske;
            }
        }

        public Beleska PretraziBeleskuPoId(String idPacijenta)
        {
           
            foreach(Beleska beleska in DobaviSveBeleske())
            {
                if (beleska.Anamneza.idPacijenta.Equals(idPacijenta))
                    return beleska;
            }
            return null;
        }
        private Beleska KonvertujCvorUObjekat(XmlNode node)
        {
            MemoryStream stm = new MemoryStream();
            StreamWriter stw = new StreamWriter(stm);
            stw.Write(node.OuterXml);
            stw.Flush();
            stm.Position = 0;
            XmlSerializer ser = new XmlSerializer(typeof(Beleska));
            return (ser.Deserialize(stm) as Beleska);
        }
        public void SacuvajBelesku(Beleska beleska)
        {
            List<Beleska> termini = DobaviSveBeleske();
            termini.Add(beleska);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Beleska>));
            TextWriter tw = new StreamWriter(nazivFajla);
            xmlSerializer.Serialize(tw, termini);
            tw.Close();
        }
    }
}
