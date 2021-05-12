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
        public static List<Lekar> sviLekari = new List<Lekar>();
        public  String imeFajla = "lekari.xml";

       /* public static void Inicijalizuj()
        {
            sviLekari.Add(new Lekar("L1", false, Specijalizacija.Ostapraksa, "Pera", "Peric", "2711999105018", "dajanazlokapa@gmail.com", new AdresaStanovanja("Ljubice Ravasi", "2A"), new Korisnik("pera.peric", "pera.peric")));
            sviLekari.Add(new Lekar("L2", false, Specijalizacija.Ostapraksa, "Stefan", "Markovic", "3008997181967", "stefan.markovic@gmail.com", new AdresaStanovanja("Laze Lazarevica", " 43"), new Korisnik("stefan.markovic", "stefan.markovic")));
            sviLekari.Add(new Lekar("L3", false, Specijalizacija.Ostapraksa, "Nikola", "Nikolic", "2401965194820", "nikola.nikolic@gmail.com", new AdresaStanovanja("Patrijarha Pavla", " 23"), new Korisnik("nikola.markovic", "nikola.markovic")));
            sviLekari.Add(new Lekar("L4", false, Specijalizacija.Ostapraksa, "Marko", "Markovic", "65395728557", "marko.markovic@gmail.com", new AdresaStanovanja("Mihajla Pupina", " 12"), new Korisnik("marko.markovic", "marko.markovic")));
            sviLekari.Add(new Lekar("L5", false, Specijalizacija.Kardiolog, "Milan", "Djenic", "5686323676", "milan.djenic@gmail.com", new AdresaStanovanja("Narodnih heroja", "32"), new Korisnik("milan.markovic", "milan.markovic")));
            sviLekari.Add(new Lekar("l6", false, Specijalizacija.Stomatolog, "Petar", "Petrovic", "6583892377523", "petar.petrovic@gmail.com", new AdresaStanovanja("Ustanicka", "8"), new Korisnik("petar.markovic", "petar.markovic")));
        }*/
        public List<Lekar> ucitajLekare()
        {
          
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

        public void upisiLekare()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Lekar>));
            TextWriter tw = new StreamWriter(imeFajla);
            xmlSerializer.Serialize(tw, sviLekari);
            tw.Close();
        }
        public Lekar PretragaLekaraPoID(String idLekara)
        {
            foreach (Lekar lekar in sviLekari)
            {
                if (lekar.idZaposlenog.Equals(idLekara))
                    return lekar;
            }
            return null;
        }
        public Lekar PretragaPoLekaru(String imeLekara, String prezimeLekara)
        {
            foreach (Lekar lekar in sviLekari)
            {
                if (lekar.Ime.Equals(imeLekara) && lekar.Prezime.Equals(prezimeLekara))
                    return lekar;
            }
            return null;
        }

        public Lekar PretraziPoKorisnickomImenu(String korisnickoIme)
        {
            foreach (Lekar lekar in sviLekari)
            {
                if (lekar.korisnik.KorisnickoIme.Equals(korisnickoIme))
                    return lekar;
            }
            return null;
        }

        public Lekar PretraziPoImenuIPrezimenu(String imeIPrezime) 
        {
            foreach(Lekar lekar in sviLekari)
            {
                if (lekar.CeloIme.Equals(imeIPrezime)) 
                    return lekar;
            }
            return null;
        }
        public List<Lekar> PretraziPoSpecijalizaciji()
        {
            List<Lekar> pomocna = new List<Lekar>();

            foreach (Lekar l in sviLekari)
            {
                if (l.Specijalizacija.Equals(Specijalizacija.Ostapraksa))
                {
                    pomocna.Add(l);
                }
            }
            return pomocna;
        }
    }
}
