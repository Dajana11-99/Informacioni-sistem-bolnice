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
using ZdravoKorporacija;
using ZdravoKorporacija.GrafZavisnosti;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.ServisInterfejs;

namespace Servis
{
   public class SalaServis: SalaServisInterfejs
   {
        public void inicijalizuj() 
        {
            sala = SalaRepozitorijum.UcitajSale();
            OsveziKolekciju();
        }
        public static Sala PretraziPoTipu(TipSale tip)
        {
            Sala sala = null;
            foreach (Sala s in SalaServis.sala)
            {

                if (s.TipSale.Equals(tip))
                    sala = s;
                break;
               
            }
            return sala;
        }
        public bool DodajSalu(Model.Sala unetaSala)
        {
            if (sala.Contains(unetaSala))
            {
                return false;
            }
            else
            {
                sala.Add(unetaSala);
                SalaRepozitorijum.UpisiSale();
                SalaServisInterfejs salaServis = Injektor.Instance.Get<SalaServisInterfejs>(typeof(SalaServisInterfejs));
                salaServis.OsveziKolekciju();
                return true;
            }
        }
        public List<Sala> PrikaziSale()
        {
            return sala;
        }
        public bool DaLiJeSalaSlobodna(Sala sala, DateTime termin)
        {
            if(sala.Renoviranje == null)
            {
                return true;
            }
            Renoviranje renoviranje = sala.Renoviranje;
            return !(renoviranje.RenoviranjeOd >= termin && renoviranje.RenoviranjeDo <= termin);
        }
        public bool Izmena(Sala salaZaIzmenu)
        {
            IzmenaSale(salaZaIzmenu);
            SalaRepozitorijum.UpisiSale();
            OsveziKolekciju();
            return true;
        }
        private void IzmenaSale(Sala salaZaIzmenu)
        {
            foreach (Sala s in sala)
            {
                if (s.Id.Equals(salaZaIzmenu.Id))
                {
                    s.sprat = salaZaIzmenu.sprat;
                    s.TipSale = salaZaIzmenu.TipSale;
                    s.Zauzeta = salaZaIzmenu.Zauzeta;
                    s.RasporedjenaDinamickaOprema = salaZaIzmenu.RasporedjenaDinamickaOprema;
                    s.RasporedjenaStatickaOprema = salaZaIzmenu.RasporedjenaStatickaOprema;
                    s.Renoviranje = salaZaIzmenu.Renoviranje;
                }
            }
        }

        public bool BrisanjeSala(String id)
        {
            List<Sala> filtrirane = FiltrirajPoId(id);
            int stariCount = sala.Count;
            sala = filtrirane;
            OsveziKolekciju();
            SalaRepozitorijum.UpisiSale();
            return sala.Count < stariCount;
        }

        private List<Sala> FiltrirajPoId(string id)
        {
            List<Sala> saleBezIzbrisane = new List<Sala>();
            foreach (Sala s in sala)
            {
                if (s.Id.Equals(id))
                    continue;

                saleBezIzbrisane.Add(s);
            }
            return saleBezIzbrisane;
        }

        public  Sala PretraziPoId(String id)
        {
            foreach(Sala s in sala)
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
        public void OsveziKolekciju()
        {
            observableSala.Clear();
            foreach (Sala sala in sala)
                observableSala.Add(sala);
        }
        public String pronadji()
        {

            bool postoji = false;
            int broj = 1;
            for (int i = 1; i <= sala.Count; i++)
            {
                foreach (Sala t in sala)
                {
                    if (t.Id.Equals(broj.ToString()))
                    {
                        postoji = true;
                        break;                   
                    }
                }
                if (!postoji)
                    return broj.ToString();
                postoji = false;
                broj++;
            }
            return broj.ToString();
        }

        public void RenovirajSalu(Sala sala)
        {
            if (sala.Renoviranje.Spajanje)
                RenoviranjeSpajanje(sala);
            else if (sala.Renoviranje.Razdvajanje)
                RenoviranjeRazdvajanje(sala);
            else
                RegularnoRenoviranje(sala); 
        }

        private  void RegularnoRenoviranje(Sala sala)
        {
            Izmena(sala);
        }

        private static void RenoviranjeRazdvajanje(Sala sala)
        {
            Sala prva = new Sala() { Id = sala.Renoviranje.NazivPrveNoveSale, kvadratura = (sala.kvadratura / 2), sprat = sala.sprat, TipSale = sala.TipSale, Zauzeta = sala.Zauzeta, RasporedjenaStatickaOprema=sala.RasporedjenaStatickaOprema, RasporedjenaDinamickaOprema=sala.RasporedjenaDinamickaOprema };
            Sala druga = new Sala() { Id = sala.Renoviranje.NazivDrugeNoveSale, kvadratura = (sala.kvadratura / 2), sprat = sala.sprat, TipSale = sala.TipSale, Zauzeta = sala.Zauzeta};
            SalaServisInterfejs salaServis = Injektor.Instance.Get<SalaServisInterfejs>(typeof(SalaServisInterfejs));
            salaServis.BrisanjeSala(sala.Id);
            salaServis.DodajSalu(prva);
            salaServis.DodajSalu(druga);
        }

        private  void RenoviranjeSpajanje(Sala sala)
        {
            if(sala.RasporedjenaStatickaOprema is null)
            {
                sala.RasporedjenaStatickaOprema = new List<RasporedjenaStatickaOprema>();
            }
            if (sala.RasporedjenaDinamickaOprema is null)
            {
                sala.RasporedjenaDinamickaOprema = new List<RasporedjenaDinamickaOprema>();
            }
            List<RasporedjenaStatickaOprema> statickaOprema = sala.RasporedjenaStatickaOprema.Union(sala.Renoviranje.SalaZaSpajanje.RasporedjenaStatickaOprema).ToList();
            List<RasporedjenaDinamickaOprema> dinamickaOprema = sala.RasporedjenaDinamickaOprema.Union(sala.Renoviranje.SalaZaSpajanje.RasporedjenaDinamickaOprema).ToList();
            Sala nova = new Sala() { Id = sala.Renoviranje.NazivPrveNoveSale, kvadratura = (sala.kvadratura + sala.Renoviranje.SalaZaSpajanje.kvadratura), sprat = sala.sprat, TipSale = sala.TipSale, Zauzeta = sala.Zauzeta, RasporedjenaStatickaOprema = statickaOprema, RasporedjenaDinamickaOprema = dinamickaOprema };
            SalaServisInterfejs salaServis = Injektor.Instance.Get<SalaServisInterfejs>(typeof(SalaServisInterfejs));
            salaServis.BrisanjeSala(sala.Id);
            salaServis.BrisanjeSala(sala.Renoviranje.SalaZaSpajanje.Id);
            salaServis.DodajSalu(nova);
        }

        public ZdravoKorporacija.Repozitorijum.SalaRepozitorijum salaRepozitorijum;

    }
}