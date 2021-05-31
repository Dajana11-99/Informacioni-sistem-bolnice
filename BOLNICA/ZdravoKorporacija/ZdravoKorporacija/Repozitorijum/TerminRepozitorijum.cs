/***********************************************************************
 * Module:  RukovanjeDatotekama.cs
 * Author:  filip
 * Purpose: Definition of the Class RadSaDatotekama.RukovanjeDatotekama
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using Model;
using Servis;
using ZdravoKorporacija.Interfejs;
using ZdravoKorporacija.PacijentPrikaz;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.Repozitorijum
{
    public class TerminRepozitorijum
    {
        public  String zakazaniTerminiFajl = "zakazaniTermini.xml";
        public  String slobodniTerminiFajl = "slobodniTermini.xml";
    
        public  List<Termin> DobaviZakazaneTermine()
        {
            List<Termin> sviZakazaniTermini = new List<Termin>();
            if (!File.Exists(zakazaniTerminiFajl) || File.ReadAllText(zakazaniTerminiFajl).Trim().Equals(""))
            {
                return sviZakazaniTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead(zakazaniTerminiFajl);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                sviZakazaniTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sviZakazaniTermini;
            }
        }
        public  List<Termin> DobaviSlobodneTermine()
        {
            List<Termin> sviSlobodniTermini = new List<Termin>();
            if (!File.Exists(slobodniTerminiFajl) || File.ReadAllText(slobodniTerminiFajl).Trim().Equals(""))
            {
                return sviSlobodniTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead(slobodniTerminiFajl);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                sviSlobodniTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sviSlobodniTermini;
            }
        }

        public  Termin PretraziZakazanePoId(String idTermina)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(zakazaniTerminiFajl);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']", nsmgr);
            Termin termin = KonvertujCvorUObjekat(node);
            return termin;
        }

        private List<Termin> ConvertujSveCvoroveUObjekte(XmlNodeList cvoroviTermina)
        {
            List<Termin> objektiTermina = new List<Termin>();
            foreach (XmlNode node in cvoroviTermina)
            {
                objektiTermina.Add(KonvertujCvorUObjekat(node));
            }
            return objektiTermina;
        }

        public void ObrisiZakazanTermin(Termin terminZaBrisanje)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(zakazaniTerminiFajl);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfTermin/Termin[IdTermina='" + terminZaBrisanje.IdTermina + "']", nsmgr);
            XmlNode parent = node.ParentNode;
            parent.RemoveChild(node);
            doc.Save(@zakazaniTerminiFajl);
        }
        public void ObrisiSlobodanTermin(Termin terminZaBrisanje)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(slobodniTerminiFajl);
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfTermin/Termin[IdTermina='" + terminZaBrisanje.IdTermina + "']", nsmgr);
           XmlNode parent  = node.ParentNode;
            parent.RemoveChild(node);
            doc.Save(slobodniTerminiFajl);

        }
        public void SacuvajSlobodanTermin(Termin terminZaUpis)
        {
            List<Termin> termini = DobaviSlobodneTermine();
            termini.Add(terminZaUpis);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter(slobodniTerminiFajl);
            xmlSerializer.Serialize(tw, termini);
            tw.Close();

        }
        public void SacuvajZakazanTermin(Termin terminZaUpis)
        {
            List<Termin> termini = DobaviZakazaneTermine();
            termini.Add(terminZaUpis);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter(zakazaniTerminiFajl);
            xmlSerializer.Serialize(tw, termini);
            tw.Close();
        }
        private  Termin KonvertujCvorUObjekat(XmlNode node)
        {
            MemoryStream stm = new MemoryStream();
            StreamWriter stw = new StreamWriter(stm);
            stw.Write(node.OuterXml);
            stw.Flush();
            stm.Position = 0;
            XmlSerializer ser = new XmlSerializer(typeof(Termin));
           return (ser.Deserialize(stm) as Termin);
        }
        public  void UpisiZakazaneTermine()
        {
            List<Termin> sviZakazaniTermini = DobaviZakazaneTermine();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter(zakazaniTerminiFajl);
            xmlSerializer.Serialize(tw, sviZakazaniTermini);
            tw.Close();

        }
        public  Termin PretraziSlobodneTerminePoId(String idTermina)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("slobodniTermini.xml");
            XmlNode root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            XmlNode node = root.SelectSingleNode("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']", nsmgr);
            Termin termin = KonvertujCvorUObjekat(node);
            return termin;
        }
        public List<Termin> DobaviSveZakazaneTerminePacijenta(String idPacijenta)
        {
            List<Termin> sviTerminiPacijenta = new List<Termin>();
            foreach (Termin termin in DobaviZakazaneTermine())
            {
                if (termin.Pacijent.IdPacijenta.Equals(idPacijenta))
                    sviTerminiPacijenta.Add(termin);
            }
            return sviTerminiPacijenta;
        }
        public  void ZakaziPregled(Termin termin)
        {
            SacuvajZakazanTermin(termin);
            ObrisiSlobodanTermin(termin);
        }
        public  bool ZakaziTermin(Termin termin)
        {
            if (NijeDostupnaSala(termin))
                return false;
            SacuvajZakazanTermin(termin);
            return true;
        }
        private static bool NijeDostupnaSala(Termin termin)
        {
            return !SalaServis.DaLiJeSalaSlobodna(termin.Sala, termin.Datum);
        }

        public  void OtkaziTermin(String idTermina)
        {
            List<Termin> zakazaniTermini = DobaviZakazaneTermine();
            Termin termin = PretraziZakazanePoId(idTermina);
            zakazaniTermini.Remove(termin);
            UpisiZakazaneTermine();
            LekarWindow.TerminiLekara.Remove(termin);
        }

        public  void ZameniTermine(Termin stariTermin, Termin noviTermin)
        {
            SacuvajSlobodanTermin(stariTermin);
            SacuvajZakazanTermin(noviTermin);
            ObrisiSlobodanTermin(noviTermin);
            ObrisiZakazanTermin(stariTermin);
        }
        

        public  void OtkazivanjePregleda(Termin termin)
        {
            ObrisiZakazanTermin(termin);
            termin.Pacijent = null;
            SacuvajSlobodanTermin(termin);
        }
        public Termin  IzmenaTermina(TerminDTO terminDTO)
        {
            Termin termin = PretraziZakazanePoId(terminDTO.IdTermina);
            int ind = LekarWindow.TerminiLekara.IndexOf(termin);
            LekarWindow.TerminiLekara.RemoveAt(ind);
            LekarWindow.TerminiLekara.Insert(ind, termin);
            return termin;
        }
        public void RefresujZakazaneTermine(Termin termin)
        {
            ObrisiZakazanTermin(termin);
            SacuvajZakazanTermin(termin);
        }
    }
}