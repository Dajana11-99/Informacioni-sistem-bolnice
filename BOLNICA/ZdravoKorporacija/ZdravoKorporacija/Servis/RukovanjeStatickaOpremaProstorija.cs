/***********************************************************************
 * Module:  RukovanjeSalama.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.RukovanjeSalama
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Model;
using RadSaDatotekama;
using ZdravoKorporacija.RadSaDatotekama;

namespace PoslovnaLogika
{
    public class RukovanjeStatickaOpremaProstorija
    {
        public static List<StatickaOpremaProstorija> statickaOpremaProstorija = new List<StatickaOpremaProstorija>();
        public static ObservableCollection<StatickaOpremaProstorija> observableStatickaOpremaProstorija = new ObservableCollection<StatickaOpremaProstorija>();
        public static void inicijalizuj()
        {
            statickaOpremaProstorija = SkladisteStatickaOpremaProstorija.UcitajStatickaOpremaProstorija();
            OsveziKolekciju();
        }



        public static bool DodajStatickuOpremuProstorija(StatickaOpremaProstorija unetaStatickaOprema)
        {
            // da li je ta oprema vec u tom rasponu negde rasporedjena?
            // da li ima dovoljno kolicine prvo?
            // 
            var statickaOprema = RukovanjeStatickomOpremom.PretraziPoId(unetaStatickaOprema.Id);

            foreach (StatickaOpremaProstorija s in statickaOpremaProstorija)
            {

                if (!s.ProstorijaId.Equals(unetaStatickaOprema.ProstorijaId) || !s.StatickeOpremaId.Equals(unetaStatickaOprema.Id))
                {
                    continue;
                }

                if (unetaStatickaOprema.RasporedjenoOd > s.RasporedjenoDo)
                {
                    MessageBox.Show($"Uneto rasporedjivanje nije ok, oprema je vec rasoredjana u prostoriji toj do {s.RasporedjenoDo}");
                    return false;
                }

                if (statickaOprema.kolicina - unetaStatickaOprema.Kolicina < 0)
                {
                    MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                    return false;
                }

                return true;
            }

            statickaOprema.kolicina -= unetaStatickaOprema.Kolicina;
            RukovanjeStatickomOpremom.IzmeniStatickuOpremu(statickaOprema);
            statickaOpremaProstorija.Add(unetaStatickaOprema);
            OsveziKolekciju();
            SkladisteStatickaOpremaProstorija.UpisiStatickaOpremaProstorija();

            MessageBox.Show($"Oprema/prostorija par nije nadjen");
            return false;
        }

        public static ObservableCollection<StatickaOprema> NadjiRasporedjenuStatickuOpremuZaSalu(Sala salaCijaSeOpremaPrikazuje)
        {
            ObservableCollection<StatickaOprema> rasporedjenaOprema = new ObservableCollection<StatickaOprema>();
            List<string> spisakNadjeneOpreme = new List<string>();
                
            // vezna tabela koja govori 
            // AKO je datum raspodele u proslosti, onda to smatramo da je vec IZVRSEN zahtev / dodeljeno
            // AKO JE DATUM rasorelde u BUDUCNOSTI , onda ovaj zahtev tek treba da se "izvrsi" kobajagi
            foreach (StatickaOpremaProstorija s in statickaOpremaProstorija)
            {
                if (!salaCijaSeOpremaPrikazuje.Id.Equals(s.ProstorijaId))
                {
                    continue;
                }

                if (s.RasporedjenoOd <= DateTime.Now && s.RasporedjenoDo > DateTime.Now)
                {
                    spisakNadjeneOpreme.Add(s.StatickeOpremaId);
                }
            }

            foreach(StatickaOprema so in RukovanjeStatickomOpremom.observableStatickaOprema)
            {

            }




            return rasporedjenaOprema;
        }

    public static List<StatickaOpremaProstorija> PrikaziStatickuOpremu()
        {
            return statickaOpremaProstorija;
        }

        public static bool IzmeniStatickuOpremu(StatickaOpremaProstorija statickaOpremaZaIzmenu)
        {
            foreach (StatickaOpremaProstorija sProvera in statickaOpremaProstorija)
            {

                if (!sProvera.ProstorijaId.Equals(statickaOpremaZaIzmenu.ProstorijaId) || !sProvera.StatickeOpremaId.Equals(statickaOpremaZaIzmenu.Id))
                {
                    continue;
                }

                if (statickaOpremaZaIzmenu.RasporedjenoOd > sProvera.RasporedjenoDo)
                {
                    MessageBox.Show($"Uneto rasporedjivanje nije ok, oprema je vec rasoredjana u prostoriji toj do {sProvera.RasporedjenoDo}");
                    return false;
                }

            }

            var s = PretraziPoId(statickaOpremaZaIzmenu.Id);
            if (statickaOpremaZaIzmenu.RasporedjenoOd > s.RasporedjenoDo)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, oprema je vec rasoredjana u prostoriji toj do {s.RasporedjenoDo}");
                return false;
            }

            var statickaOprema = RukovanjeStatickomOpremom.PretraziPoId(s.Id);
            var dodato = statickaOpremaZaIzmenu.Kolicina > s.Kolicina;
            var razlikaUKoliciniDodato = statickaOpremaZaIzmenu.Kolicina - s.Kolicina;
            if (dodato)
            {
                if (statickaOprema.kolicina - razlikaUKoliciniDodato < 0)
                {
                    MessageBox.Show($"Uneto rasporedjivanje nije ok, oprema je vec rasoredjana u prostoriji toj do {s.RasporedjenoDo}");
                    return false;
                }
                statickaOprema.kolicina -= razlikaUKoliciniDodato;
            } else
            {
                // manja kolicina rasporedjna, ostatak se vraca u magacin
                var razlikaUKoliciniOduzeto = s.Kolicina - statickaOpremaZaIzmenu.Kolicina;
                statickaOprema.kolicina += razlikaUKoliciniOduzeto;
            }

            if (statickaOprema.kolicina - statickaOpremaZaIzmenu.Kolicina < 0)
            {
                MessageBox.Show($"Uneto rasporedjivanje nije ok, Nema dovoljno kolicine opreme");
                return false;
            }
            RukovanjeStatickomOpremom.IzmeniStatickuOpremu(statickaOprema);

            s.Kolicina = statickaOpremaZaIzmenu.Kolicina;
            s.ProstorijaId = statickaOpremaZaIzmenu.ProstorijaId;
            s.RasporedjenoDo = statickaOpremaZaIzmenu.RasporedjenoDo;
            s.RasporedjenoOd = statickaOpremaZaIzmenu.RasporedjenoOd;

            OsveziKolekciju();
            SkladisteStatickaOpremaProstorija.UpisiStatickaOpremaProstorija();
            return true;
        }

        public static bool ObrisiStatickuOpremu(String id)
        {
            List<StatickaOpremaProstorija> statickaOpremaBezIzbrisane = new List<StatickaOpremaProstorija>();
            bool nadjena = false;
            foreach (StatickaOpremaProstorija s in statickaOpremaProstorija)
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
            statickaOpremaProstorija = statickaOpremaBezIzbrisane;
            OsveziKolekciju();
            SkladisteStatickaOpremaProstorija.UpisiStatickaOpremaProstorija();
            return nadjena;
        }

        public static StatickaOpremaProstorija PretraziPoId(string id)
        {
            foreach (StatickaOpremaProstorija s in statickaOpremaProstorija)
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
            observableStatickaOpremaProstorija.Clear();
            foreach (StatickaOpremaProstorija so in statickaOpremaProstorija)
                observableStatickaOpremaProstorija.Add(so);
        }


        public static String pronadji()
        {

            bool postoji = false;
            int broj = 1;
            for (int i = 1; i <= statickaOpremaProstorija.Count; i++)
            {

                foreach (StatickaOpremaProstorija t in statickaOpremaProstorija)
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
    }
}