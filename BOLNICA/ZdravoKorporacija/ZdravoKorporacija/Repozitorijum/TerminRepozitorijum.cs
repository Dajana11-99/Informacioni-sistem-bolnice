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

     
       

       
     

        public static List<Termin> ucitajTermine()
        {
            if (!File.Exists("termini.xml") || File.ReadAllText("termini.xml").Trim().Equals(""))
            {
                return TerminServis.zakazaniTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead("termini.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                TerminServis.zakazaniTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return TerminServis.zakazaniTermini;

            }

        }

        public static void upisiTermine()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter("termini.xml");
            xmlSerializer.Serialize(tw, TerminServis.zakazaniTermini);
            tw.Close();

        }


        public static List<Termin> ucitajSlobodneTermine()
        {
            if (!File.Exists("slobodniTermini.xml") || File.ReadAllText("slobodniTermini.xml").Trim().Equals(""))
            {
                return TerminServis.slobodniTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead("slobodniTermini.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                TerminServis.slobodniTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return TerminServis.slobodniTermini;

            }

        }

        public static void upisiSlobodneTermine()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter("slobodniTermini.xml");
            xmlSerializer.Serialize(tw, TerminServis.slobodniTermini);
            tw.Close();

        }




    }
}