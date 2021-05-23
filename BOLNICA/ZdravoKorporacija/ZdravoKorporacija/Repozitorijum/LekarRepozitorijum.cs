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
    public class LekarRepozitorijum
    {
       
        public  String imeFajla = "lekari.xml";
        public List<Lekar> DobaviSveLekare()
        {
            List<Lekar> sviLekari = new List<Lekar>();
            if (!File.Exists(imeFajla) || File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return sviLekari;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lekar>));
                sviLekari = (List<Lekar>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return sviLekari;
            }
        }
        public Lekar PretragaLekaraPoID(String idLekara)
        {
            foreach (Lekar lekar in DobaviSveLekare())
            {
                if (lekar.idZaposlenog.Equals(idLekara))
                    return lekar;
            }
            return null;
        }
        public Lekar PretragaPoLekaru(String imeLekara, String prezimeLekara)
        {
            foreach (Lekar lekar in DobaviSveLekare())
            {
                if (lekar.Ime.Equals(imeLekara) && lekar.Prezime.Equals(prezimeLekara))
                    return lekar;
            }
            return null;
        }

        public Lekar PretraziPoKorisnickomImenu(String korisnickoIme)
        {
            foreach (Lekar lekar in DobaviSveLekare())
            {
                if (lekar.korisnik.KorisnickoIme.Equals(korisnickoIme))
                    return lekar;
            }
            return null;
        }

        public Lekar PretraziPoImenuIPrezimenu(String imeIPrezime) 
        {
            foreach(Lekar lekar in DobaviSveLekare())
            {
                if (lekar.CeloIme.Equals(imeIPrezime)) 
                    return lekar;
            }
            return null;
        }
        public List<Lekar> DobaviLekareOpstePrakse()
        {
            List<Lekar> listaSvihLekara = new List<Lekar>();

            foreach (Lekar l in DobaviSveLekare())
            {
                if (l.Specijalizacija.Equals(Specijalizacija.Ostapraksa))
                    listaSvihLekara.Add(l);
            }
            return listaSvihLekara;
        }
    }
}
