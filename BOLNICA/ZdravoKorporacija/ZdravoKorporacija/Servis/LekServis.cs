using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model;
using ZdravoKorporacija;
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.Repozitorijum;


namespace Servis
{
    public class LekServis
    {
        LekKontroler lekKontroler = new LekKontroler();
        public static List<Lek> lek = new List<Lek>();
        public static ObservableCollection<Lek> observableLek = new ObservableCollection<Lek>();
        public static List<Sastojak> listaSvihSastojaka = new List<Sastojak>
        
        {
            new Sastojak{Id="1", Ime="Voda"},
            new Sastojak{Id="2", Ime="Ibrufen"},
            new Sastojak{Id="3", Ime="Lavanda"}
        };
        public static List<Lek> lekovii = new List<Lek>();
        public static void inicijalizujLekove()
        {
            lekovii.Add(new Lek("1", "Brufen", "20", "Sastojci1"));
            lekovii.Add(new Lek("2", "Andol", "250", "Sastojci2"));
            lekovii.Add(new Lek("3", "Pentraxil", "120", "Sastojci3"));
            lekovii.Add(new Lek("4", "Palitex", "100", "Sastojci4"));
            lekovii.Add(new Lek("5", "Bromazepam", "30", "Sastojci5"));
            lekovii.Add(new Lek("6", "Febricet", "300", "Sastojci6"));
        }
        public static void inicijalizuj()
        {
            lek = LekRepozitorijum.UcitajLekove();
            OsveziKolekciju();
        }
        private static void OsveziKolekciju()
        {
            observableLek.Clear();
            foreach (Lek lek in lek)
                observableLek.Add(lek);
        }
        public static bool DodajLek(Lek unetiLek)
        {
            if (lek.Contains(unetiLek))
            {
                return false;
            }
            else
            {
                lek.Add(unetiLek);
                LekRepozitorijum.UpisiLekove();
                OsveziKolekciju();
                return true;
            }
        }
        public static Lek PretraziPoId(String id)
        {
            foreach (Lek l in lek)
            {
                if (l.IdLeka.Equals(id))
                {
                    return l;
                }
            }
            return null;
        }
        public static List<Lek> PrikaziLekove()
        {
            return lek;
        }
        public static List<string> PrikaziImenaSastojaka() 
        {
            List<string> imenaSastojaka = new List<string>();
            foreach (Sastojak sastojak in listaSvihSastojaka)
            {
                imenaSastojaka.Add(sastojak.Ime);
            }
            return imenaSastojaka;
        }
        public static bool Izmena(Lek lekZaIzmenu)
        {
            foreach (Lek l in lek)
            {
                if (l.Equals(lekZaIzmenu.IdLeka))
                {
                    l.ImeLeka = lekZaIzmenu.ImeLeka;
                }

            }
            LekRepozitorijum.UpisiLekove();
            OsveziKolekciju();
            return true;
        }
        public static bool BrisanjeLeka(String idLeka)
        {
            List<Lek> lekoviBezIzbrisanog = new List<Lek>();
            bool nadjena = false;
            foreach (Lek l in lek)
            {
                if (l.IdLeka.Equals(idLeka))
                {
                    nadjena = true;
                } else
                {
                    lekoviBezIzbrisanog.Add(l);
                }
            }
            lek = lekoviBezIzbrisanog;
            OsveziKolekciju();
            LekRepozitorijum.UpisiLekove();
            return nadjena;
        }
        public static Lek PretraziSveLekove(String idLeka)
        {
            return LekoviRepozitorijum.PronadjiLek(idLeka);
        }
        public static List<Lek> PrikaziSveLekove()
        {
            return lekovii;
        }
        public static Lek IzmeniSelektovaniLek(Lek lek)
        {
            return LekoviRepozitorijum.IzmeniLek(lek);
        }
    }
}
