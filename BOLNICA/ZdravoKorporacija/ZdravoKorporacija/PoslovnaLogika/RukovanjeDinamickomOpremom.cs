/***********************************************************************
 * Module:  RukovanjeSalama.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.RukovanjeSalama
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model;
using RadSaDatotekama;
using ZdravoKorporacija.RadSaDatotekama;

namespace PoslovnaLogika
{
    public class RukovanjeDinamickomOpremom
    {
        public static List<DinamickaOprema> dinamickaOprema = new List<DinamickaOprema>();
        public static ObservableCollection<DinamickaOprema> observableDinamickaOprema = new ObservableCollection<DinamickaOprema>();
        public static void inicijalizuj()
        {
            dinamickaOprema = SkladisteDinamickeOpreme.UcitajDinamickuOpremu();
            OsveziKolekciju();
        }

        /*
        public static Sala PretraziPoTipu(TipSale tip)
        {
            Sala salaa = null;
            foreach (Sala s in sala)
            {

                if (s.TipSale.Equals(tip))
                    salaa = s;
                break;

            }

            return salaa;
        }

        */


        public static bool DodajDinamickuOpremu(DinamickaOprema unetaDinamickaOprema)
        {
            if (dinamickaOprema.Contains(unetaDinamickaOprema))
            {
                return false;
            }
            else
            {
                dinamickaOprema.Add(unetaDinamickaOprema);
                SkladisteDinamickeOpreme.UpisiDinamickuOpremu();
                OsveziKolekciju();
                return true;
            }
        }


        public static List<DinamickaOprema> PrikaziDinamickuOpremu()
        {
            return dinamickaOprema;
        }

        public static bool IzmeniDinamickuOpremu(DinamickaOprema dinamickaOpremaZaIzmenu)
        {
            foreach (DinamickaOprema s in dinamickaOprema)
            {
                if (s.Id.Equals(dinamickaOpremaZaIzmenu.Id))
                {
                    s.kolicina = dinamickaOpremaZaIzmenu.kolicina;
                    s.naziv = dinamickaOpremaZaIzmenu.naziv;
                }

            }
            SkladisteDinamickeOpreme.UpisiDinamickuOpremu();
            OsveziKolekciju();

            return true;
        }

        public static bool ObrisiDinamickuOpremu(String id)
        {
            List<DinamickaOprema> dinamickaOpremaBezIzbrisane = new List<DinamickaOprema>();
            bool nadjena = false;
            foreach (DinamickaOprema s in dinamickaOprema)
            {
                if (s.Id.Equals(id))
                {
                    nadjena = true;
                }
                else
                {
                    dinamickaOpremaBezIzbrisane.Add(s);
                }
            }
            dinamickaOprema = dinamickaOpremaBezIzbrisane;
            OsveziKolekciju();
            SkladisteDinamickeOpreme.UpisiDinamickuOpremu();
            return nadjena;
        }

        public static DinamickaOprema PretraziPoId(String id)
        {
            foreach (DinamickaOprema s in dinamickaOprema)
            {
                if (s.Id.Equals(id))
                {
                    return s;
                }
            }
            return null;
        }

        

        public static void OsveziKolekciju()
        {
            observableDinamickaOprema.Clear();
            foreach (DinamickaOprema so in dinamickaOprema)
                observableDinamickaOprema.Add(so);
        }
    }
}
