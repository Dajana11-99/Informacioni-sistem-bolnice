using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Repozitorijum
{
   public class ObavestenjaRepozitorijum
    {

        public  String imeFajla = "obavestenja.xml";

        public  List<Obavestenja> DobaviSvaObavestenja()
        {
            List<Obavestenja> svaObavestenja = new List<Obavestenja>();
            if (!File.Exists(imeFajla) || File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return new List<Obavestenja>();
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Obavestenja>));
                svaObavestenja = (List<Obavestenja>)serializer.Deserialize(fileStream);
                fileStream.Close();
                return svaObavestenja;
            }
        }

        public  void SacuvajObavestenje(Obavestenja obavestenjeZaUpis)
        {
            List<Obavestenja> svaObavestenja = DobaviSvaObavestenja();
            svaObavestenja.Add(obavestenjeZaUpis);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Obavestenja>));
            TextWriter fileStream = new StreamWriter(imeFajla);
            serializer.Serialize(fileStream, svaObavestenja);
            fileStream.Close();
        }
       
        public Obavestenja PretraziPoId(String idObavestenja)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfObavestenja/Obavestenje[IdObavestenja='" + idObavestenja + "']", nsmgr);
            return ConvertujCvorUObjekat(node);
        }
        private Obavestenja ConvertujCvorUObjekat(XmlNode node)
        {
            MemoryStream stm = new MemoryStream();
            StreamWriter stw = new StreamWriter(stm);
            stw.Write(node.OuterXml);
            stw.Flush();
            stm.Position = 0;
            XmlSerializer ser = new XmlSerializer(typeof(Obavestenja));
            return (ser.Deserialize(stm) as Obavestenja);
        }
        public List<Obavestenja> PretraziObavestenjaPoPacijentu(String idPacijenta)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNodeList nodes = root.SelectNodes("//ArrayOfObavestenja/Obavestenja[IdPrimaoca='" + idPacijenta + "']", nsmgr);
            return KonvertujSveCvoroveUObjekte(nodes);
        }
        private List<Obavestenja> KonvertujSveCvoroveUObjekte(XmlNodeList obavestenja)
        {
            List<Obavestenja> obavestenjaPacijenta = new List<Obavestenja>();
            foreach (XmlNode node in obavestenja)
            {
               
                obavestenjaPacijenta.Add(ConvertujCvorUObjekat(node));
            }
            return obavestenjaPacijenta;

        }
    }
}
