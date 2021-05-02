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
        public static String zakazaniTerminiFajl = "zakazaniTermini.xml";
        public static String slobodniTerminiFajl = "slobodniTermini.xml";
        public static List<Termin> UcitajZakazaneTermine()
        {
            if (!File.Exists(zakazaniTerminiFajl) || File.ReadAllText(zakazaniTerminiFajl).Trim().Equals(""))
            {
                return TerminServis.zakazaniTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead(zakazaniTerminiFajl);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                TerminServis.zakazaniTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return TerminServis.zakazaniTermini;
            }

        }

        public static void UpisiZakazaneTermine()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter(zakazaniTerminiFajl);
            xmlSerializer.Serialize(tw, TerminServis.zakazaniTermini);
            tw.Close();

        }


        public static List<Termin> UcitajSlobodneTermine()
        {
            if (!File.Exists(slobodniTerminiFajl) || File.ReadAllText(slobodniTerminiFajl).Trim().Equals(""))
            {
                return TerminServis.slobodniTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead(slobodniTerminiFajl);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                TerminServis.slobodniTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return TerminServis.slobodniTermini;

            }

        }

        public static void UpisiSlobodneTermine()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter(slobodniTerminiFajl);
            xmlSerializer.Serialize(tw, TerminServis.slobodniTermini);
            tw.Close();

        }




    }
}