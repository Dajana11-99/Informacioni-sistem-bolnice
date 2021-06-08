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
using ZdravoKorporacija.GrafZavisnosti;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.ServisInterfejs;

namespace Servis
{
    public class RukovanjeStatickomOpremomServis : RukovanjeStatickomOpremomServisInterfejs
    {
        public static List<StatickaOprema> statickaOprema = new List<StatickaOprema>();
        public static ObservableCollection<StatickaOprema> observableStatickaOprema = new ObservableCollection<StatickaOprema>();
        public void inicijalizuj()
        {
            statickaOprema = StatickeOpremeRepozitorijum.UcitajStatickuOpremu();
            OsveziKolekciju();
        }
        public bool DodajStatickuOpremu(Model.StatickaOprema unetaStatickaOprema)
        {
            if (statickaOprema.Contains(unetaStatickaOprema))
            {
                return false;
            }
            else
            {
                statickaOprema.Add(unetaStatickaOprema);
                StatickeOpremeRepozitorijum.UpisiStatickuOpremu();
                OsveziKolekciju();
                return true;
            }
        }
        public List<StatickaOprema> PrikaziStatickuOpremu()
        {
            return statickaOprema;
        }
        public bool IzmeniStatickuOpremu(StatickaOprema statickaOpremaZaIzmenu)
        {
            foreach (StatickaOprema s in statickaOprema)
            {
                if (s.Id.Equals(statickaOpremaZaIzmenu.Id))
                {
                    s.kolicina = statickaOpremaZaIzmenu.kolicina;
                    s.naziv = statickaOpremaZaIzmenu.naziv;
                }
            }
            StatickeOpremeRepozitorijum.UpisiStatickuOpremu();
            OsveziKolekciju();
            return true;
        }
        public bool ObrisiStatickuOpremu(String id)
        {
            List<StatickaOprema> statickaOpremaBezIzbrisane = new List<StatickaOprema>();
            bool nadjena = false;
            foreach (StatickaOprema s in statickaOprema)
            {
                if (s.Id.Equals(id))
                {
                    nadjena = true;
                }
                else
                {
                    statickaOpremaBezIzbrisane.Add(s);
                }
            }
            statickaOprema = statickaOpremaBezIzbrisane;
            OsveziKolekciju();
            StatickeOpremeRepozitorijum.UpisiStatickuOpremu();
            return nadjena;
        }
        public StatickaOprema PretraziPoId(String id)
        {
            foreach (StatickaOprema s in statickaOprema)
            {
                if (s.Id.Equals(id))
                {
                    return s;
                }
            }
            return null;
        }
        public static List<Sala> sala = new List<Sala>();
        public static ObservableCollection<Sala> observableSala = new ObservableCollection<Sala>();
        public static void OsveziKolekciju()
        {
            observableStatickaOprema.Clear();
            foreach (StatickaOprema oprema in statickaOprema)
                observableStatickaOprema.Add(oprema);
        }   
        public static List<RasporedjenaStatickaOprema> NadjiSvuRasporedjenuPoSalama()
        {
            List<RasporedjenaStatickaOprema> rasoredjeno = new List<RasporedjenaStatickaOprema>();
            foreach(Sala s in SalaServis.sala)
            {
                rasoredjeno.AddRange(s.RasporedjenaStatickaOprema);
            }

            return rasoredjeno;
        }
        public ZdravoKorporacija.Repozitorijum.StatickeOpremeRepozitorijum statickeOpremeRepozitorijum;
    }
}