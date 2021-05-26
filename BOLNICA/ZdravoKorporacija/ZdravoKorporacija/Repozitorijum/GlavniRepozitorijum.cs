﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ZdravoKorporacija.Interfejs;

namespace ZdravoKorporacija.Repozitorijum
{
    public class GlavniRepozitorijum<T> : GlavniRepozitorijumInterfejs<T>
    {
        protected String imeFajla { get; set; }

        public List<T> DobaviSve()
        {
            List<T> sviObjekti = new List<T>();
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return sviObjekti;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                sviObjekti = (List<T>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sviObjekti;
            }

        }

        public T PretraziPoId(String obrazacPretrage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode(obrazacPretrage, nsmgr);
            T objekat = KonvertujCvorUObjekat(node);
            return objekat;
        }
        public List<T> PretraziPoIdObjekta(String obrazacPretrage)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNodeList nodes = root.SelectNodes(obrazacPretrage, nsmgr);
            List<T> objekti = KonvertujSveCvoroveUObjekte(nodes);
            return objekti;
        }

        public T KonvertujCvorUObjekat(XmlNode cvor)
        {
            MemoryStream stm = new MemoryStream();
            StreamWriter stw = new StreamWriter(stm);
            stw.Write(cvor.OuterXml);
            stw.Flush();
            stm.Position = 0;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            return (T)ser.Deserialize(stm);
        }

        public List<T> KonvertujSveCvoroveUObjekte(XmlNodeList cvorovi)
        {
            List<T> objekti = new List<T>();
            foreach (XmlNode c in cvorovi)
            {
                objekti.Add(KonvertujCvorUObjekat(c));
            }
            return objekti;
        }

        public void Obrisi(String obrazacZaBrisanje)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(imeFajla);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode(obrazacZaBrisanje, nsmgr);
            XmlNode parent = node.ParentNode;
            parent.RemoveChild(node);
            doc.Save(imeFajla);
        }

        public void Dodaj(T objekatZaDodavanje)
        {
            List<T> sviObjekti = DobaviSve();
            sviObjekti.Add(objekatZaDodavanje);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, sviObjekti);
            tw.Close();

        }

    }
}