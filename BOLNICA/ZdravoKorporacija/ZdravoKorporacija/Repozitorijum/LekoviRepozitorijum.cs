using Model;
using Servis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Repozitorijum
{
    public class LekoviRepozitorijum
    {
        public static String imeFajla = "lek.xml";
        public static List<Lek> ucitajLekove()
        {
            if (!File.Exists(imeFajla) || File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return LekServis.lekovii;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lek>));
                LekServis.lekovii = (List<Lek>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return LekServis.lekovii;
            }
        }

        public static void upisiLekove()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lek>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, LekServis.lekovii);
            tw.Close();
        }

        public static Lek IzmeniLek(Lek lek)
        {
            Lek originalniLek = PronadjiLek(lek.IdLeka);
            LekServis.lekovii.Remove(originalniLek);
            LekServis.lekovii.Add(lek);
            upisiLekove();
            return lek;
        }

        public static Lek PronadjiLek(String idLeka)
        {
            foreach (Lek lek in ucitajLekove())
            {
                if (lek.IdLeka.Equals(idLeka))
                    return lek;
            }
            return null;
        }
    }
}
