using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.Servis
{
    public class ZalbaServis
    {
        public static ObservableCollection<Zalba> zalbeObservable = new ObservableCollection<Zalba>();
        public static List<Zalba> zalbe = new List<Zalba>();

        public static void inicijalizuj()
        {
            zalbe = ZalbaRepozitorijum.ucitajZalbe();
            OsveziKolekciju();
        }
        public static void OsveziKolekciju()
        {
            zalbeObservable.Clear();
            foreach (Zalba zalba in zalbe)
                zalbeObservable.Add(zalba);
        }
        public static Zalba PretraziZalbe(String idZalbe)
        {
            foreach (Zalba zalba in zalbe)
            {
                if (zalba.IdZalbe.Equals(idZalbe))
                    return zalba;     
            }
            return null;
        }
        public static List<Zalba> PrikaziSveZalbe()
        {
            return zalbe;
        }

        public static Zalba UpisiNovuZalbu(Zalba zalba)
        {
            return ZalbaRepozitorijum.upisiNovuZalbu(zalba);
        }
        public static bool Izmena(Zalba zalbaZaIzmenu)
        {
            IzmenaZalbe(zalbaZaIzmenu);
            ZalbaRepozitorijum.upisiZalbe();
            OsveziKolekciju();
            return true;
        }
        private static void IzmenaZalbe(Zalba zalbaZaIzmenu)
        {
            foreach (Zalba zalba in zalbeObservable)
            {
                if (zalba.IdZalbe.Equals(zalbaZaIzmenu.IdZalbe))
                {
                    zalba.TextZalbe = zalbaZaIzmenu.TextZalbe;
                    zalba.IdLeka = zalbaZaIzmenu.IdLeka;
                    zalba.resena = zalbaZaIzmenu.resena;
                }
            }
        }
    }
}
