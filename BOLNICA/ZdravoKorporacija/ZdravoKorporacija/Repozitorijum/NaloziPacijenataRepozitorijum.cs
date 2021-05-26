using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Model;
using Servis;

namespace ZdravoKorporacija.Repozitorijum
{
   public class NaloziPacijenataRepozitorijum
    {
        public static String imeFajla = "pacijenti.xml";
        public static List<Pacijent> UcitajPacijente()
        {
            if (!File.Exists(imeFajla) || File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return NaloziPacijenataServis.ListaPacijenata;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pacijent>));
                NaloziPacijenataServis.ListaPacijenata = (List<Pacijent>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return NaloziPacijenataServis.ListaPacijenata;
            }
        }
        public Pacijent PretragaPoId(String Id)
        {
            foreach (Pacijent P in NaloziPacijenataServis.ListaPacijenata)
            {
                if (P.IdPacijenta.Equals(Id))
                {
                    return P;
                }
            }
            return null;
        }
        public static void UpisiPacijente()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pacijent>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, NaloziPacijenataServis.ListaPacijenata);
            tw.Close();
        }

        public void UpisiPacijente(Pacijent pacijent)
        {
          
            foreach(Pacijent p in NaloziPacijenataServis.ListaPacijenata)
            {
                if (p.IdPacijenta.Equals(pacijent.IdPacijenta))
                {
                    p.Maliciozan = pacijent.Maliciozan;
                    p.Zloupotrebio = pacijent.Zloupotrebio;
                }
              
            }
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pacijent>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, NaloziPacijenataServis.ListaPacijenata);
            tw.Close();
           
        }

    }
}
