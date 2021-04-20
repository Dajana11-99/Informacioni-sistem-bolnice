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
                return TerminServis.zakazani;
            }
            else
            {
                FileStream fileStream = File.OpenRead("termini.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                TerminServis.zakazani = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return TerminServis.zakazani;

            }

        }

        public static void upisiTermine()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter("termini.xml");
            xmlSerializer.Serialize(tw, TerminServis.zakazani);
            tw.Close();

        }


        public static List<Termin> ucitajSlobodneTermine()
        {
            if (!File.Exists("slobodniTermini.xml") || File.ReadAllText("slobodniTermini.xml").Trim().Equals(""))
            {
                return TerminServis.SlobodniTermini;
            }
            else
            {
                FileStream fileStream = File.OpenRead("slobodniTermini.xml");
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
                TerminServis.SlobodniTermini = (List<Termin>)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return TerminServis.SlobodniTermini;

            }

        }

        public static void upisiSlobodneTermine()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Termin>));
            TextWriter tw = new StreamWriter("slobodniTermini.xml");
            xmlSerializer.Serialize(tw, TerminServis.SlobodniTermini);
            tw.Close();

        }




    }
}