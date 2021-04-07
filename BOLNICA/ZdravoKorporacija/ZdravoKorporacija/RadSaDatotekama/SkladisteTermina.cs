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
    public class SkladisteTermina
   {

     
       

       
     

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