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
using Servis;

namespace ZdravoKorporacija.Repozitorijum
{
    public class TerminRepozitorijum
   {
        public static String imeFajla1 = "termini.xml";
        public static String imeFajla2 = "slobodniTermini.xml";
        public static List<Termin> ucitajTermine()
        {
            if (!File.Exists(imeFajla1) || File.ReadAllText(imeFajla1).Trim().Equals(""))
            {
                return TerminServis.zakazani;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla1);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                TerminServis.zakazani = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return TerminServis.zakazani;

            }

        }

        public static void upisiTermine()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter(imeFajla1);
            xmlSerializer.Serialize(tw, TerminServis.zakazani);
            tw.Close();

        }


        public static List<Termin> ucitajSlobodneTermine()
        {
            if (!File.Exists(imeFajla2) || File.ReadAllText(imeFajla2).Trim().Equals(""))
            {
                return TerminServis.SlobodniTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla2);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                TerminServis.SlobodniTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return TerminServis.SlobodniTermini;

            }

        }

        public static void upisiSlobodneTermine()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter(imeFajla2);
            xmlSerializer.Serialize(tw, TerminServis.SlobodniTermini);
            tw.Close();

        }




    }
}