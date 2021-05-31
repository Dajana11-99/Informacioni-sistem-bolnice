
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Repozitorijum
{
   public class AnketeRepozitorijum
    {
        public String sveAnketeFajl = "sveAnkete.xml";
        TerminRepozitorijum terminRepozitorijum = new TerminRepozitorijum();

        private  List<Ankete> DobaviSveAnkete()
        {
            List<Ankete> popunjeneAnkete = new List<Ankete>();
            if (!File.Exists(sveAnketeFajl) || File.ReadAllText(sveAnketeFajl).Trim().Equals(""))
            {
                return popunjeneAnkete;
            }
            else
            {
                FileStream fileStream = File.OpenRead(sveAnketeFajl);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Ankete>));
               popunjeneAnkete = (List<Ankete>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return popunjeneAnkete;
            }

        }
        private void SacuvajAnkete(Ankete anketaZaUpis)
        {
            List<Ankete> termini = DobaviSveAnkete();
            termini.Add(anketaZaUpis);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Ankete>));
            TextWriter tw = new StreamWriter(sveAnketeFajl);
            xmlSerializer.Serialize(tw, termini);
            tw.Close();

        }

        public List<Ankete> NadjiPoslednjuAnketuOBolnici(Pacijent pacijent)
        {
            List<Ankete> anketePacijenta = new List<Ankete>();
            foreach (Ankete anketa in DobaviSveAnkete())
            {
                if (anketa.Pacijent.IdPacijenta.Equals(pacijent.IdPacijenta) && anketa.Termin == null)
                    anketePacijenta.Add(anketa);
            }
            return anketePacijenta;
        }
        public  void DodajAnketu(Ankete anketa)
        {
            SacuvajAnkete(anketa);
            if(anketa.Termin!=null)
                terminRepozitorijum.RefresujZakazaneTermine(anketa.Termin);
        }
      
    }
}
