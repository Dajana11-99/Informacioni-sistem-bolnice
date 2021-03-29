/***********************************************************************
 * Module:  RukovanjeDatotekama.cs
 * Author:  filip
 * Purpose: Definition of the Class RadSaDatotekama.RukovanjeDatotekama
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Model;
using PoslovnaLogika;

namespace RadSaDatotekama
{
    public class RukovanjeDatotekama2
   {

      public List<ZahtevUpravniku> UcitajZahetev()
      {
         // TODO: implement
         return null;
      }
      
      public bool UpisiZahteve(List<ZahtevUpravniku> zahtevi)
      {
            // TODO: implement
            return false;
        }

        public static List<Sala> InicijalizujSale()
        {
            var inicijalneSale = new List<Sala>();
            var sala1 = new Sala();

            sala1.Id = "1";
            sala1.sprat = 1;
            sala1.Zauzeta = false;
            sala1.TipSale = TipSale.Operaciona;
            inicijalneSale.Add(sala1);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sala>));
            TextWriter tw = new StreamWriter("sale.xml");
            xmlSerializer.Serialize(tw, inicijalneSale);
            tw.Close();
            return inicijalneSale;
        }

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

        public bool UpisiSale(List<Sala> saleP)
      {
            // TODO: implement
            return false;
        }
      
      public List<Pacijent> UcitajPacijente()
      {
         // TODO: implement
         return null;
      }
      
      public bool UpisiPacijente(List<Pacijent> pacijentiP)
      {
            // TODO: implement
            return false;
        }


        public static List<Termin> ucitajTermine()
        {
            if (!File.Exists("termini.xml") || File.ReadAllText("termini.xml").Trim().Equals(""))
            {
                return RukovanjeTerminima.zakazani;
            }
            else
            {
                FileStream fileStream = File.OpenRead("termini.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                RukovanjeTerminima.zakazani = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return RukovanjeTerminima.zakazani;

            }

        }

        public static void upisiTermine()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter("termini.xml");
            xmlSerializer.Serialize(tw, RukovanjeTerminima.zakazani);
            tw.Close();

        }
      
   
   }
}