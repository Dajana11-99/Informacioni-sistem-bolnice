/***********************************************************************
 * Module:  UpravljanjePacijentima.cs
 * Author:  filip
 * Purpose: Definition of the Class Model.UpravljanjePacijentima
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using ZdravoKorporacija;
using ZdravoKorporacija.Repozitorijum;

namespace Servis

{
    public class NaloziPacijenataServis
    {
        public static List<Pacijent> ListaPacijenata = new List<Pacijent>();
        private ZakazaniTerminiRepozitorijum terminRepozitorijum = new ZakazaniTerminiRepozitorijum();

        public static void TestMethod()
        {
            for (int i = 0; i < 30; i += 5)
                ListaPacijenata.Add(new Pacijent(i.ToString()));
        }

        public  Pacijent PretragaPoId(String Id)
        {
            foreach (Pacijent P in ListaPacijenata)
            {
                if (P.IdPacijenta.Equals(Id))
                {
                    return P;
                }
            }
            return null;
        }
        public static bool NapraviNoviNalogPacijentu(Model.Pacijent pacijentN)
        {

            ListaPacijenata.Add(pacijentN);

            return true;
        }


        public static void inic()
        {
            Karton k1 = new Karton("O1", "Jova", "Jovic", "Milan", new DateTime(1996, 10, 3), Pol.Muski, "555-222", "15624", BracniStatusE.Neozenjen, new Anamneza(),"Brufen");
            Pacijent p1 = new Pacijent("1", "Jova", "Jovic", "1234567891234", "jova@gmail.com", new AdresaStanovanja("Koste Pavlovica", "23"),new Korisnik("jova.jovic","jova.jovic"));
            p1.karton = k1; 
            Karton k2 = new Karton("O2", "Pera", "Peric", "Kosta", new DateTime(2000, 07, 12), Pol.Muski, "064 3575975", "12345", BracniStatusE.Udovac, new Anamneza(),"Brufen");
            Pacijent p2 = new Pacijent("2", "Pera", "Peric", "4321432143215", "pera@gmail.com", new AdresaStanovanja("Veselina Maslese", "24"),new Korisnik("pera.peric","pera.peric"));
            p2.karton = k2;
            Karton k3 = new Karton("03", "Dajana", "Zlokapa","Sinisa", new DateTime(1999,11,11),Pol.Zenski,"064 87956163","123",BracniStatusE.Neudata,new Anamneza(),"Brufen");
            Pacijent p3 = new Pacijent("P1", "Dajana", "Zlokapa", "2711999105018", "dajana.zlokapa@gmail.com", new AdresaStanovanja("Adresa", "4"), new Korisnik("dajana.zlokapa", "dajana.zlokapa"));
            p3.karton = k3;
            ListaPacijenata.Add(p1);
            ListaPacijenata.Add(p2);
            ListaPacijenata.Add(p3);
        }

        public static void IzmeniPostojeciNalog(string iDPacijent)
        {
          //  Pacijent P = PretragaPoId(iDPacijent);

            //int id = PrikazPacijenata.ListaPacijenataXMAL.IndexOf(P);
           // PrikazPacijenata.ListaPacijenataXMAL.RemoveAt(id);
           // PrikazPacijenata.ListaPacijenataXMAL.Insert(id, P);
            //return false;
        }

        public static bool ObriseNalog(Pacijent Pac)
        {
            // TODO: implement
            ListaPacijenata.Remove(Pac);
            PrikazPacijenata.ListaPacijenataXMAL.Remove(Pac);
            return false;
        }

        public static bool Blokira(String iDPacijenta)
        {
            // TODO: implement
            return false;
        }

      public  Pacijent PretraziPoKorisnickom(String korisnicko)
        {
            foreach(Pacijent pacijent in ListaPacijenata)
            {
                if (pacijent.korisnik.KorisnickoIme.Equals(korisnicko))
                {
                    return pacijent;
                }
            }
            return null;
        }

        public static List<Pacijent> PrikaziPacijente()
        {
            // TODO: implement
            return null;
        }

        private NaloziPacijenataRepozitorijum naloziPacijenataRepozitorijum = new NaloziPacijenataRepozitorijum();

        public static Karton pronadjiKarton(String brojKartona) 
        {
            foreach (Pacijent pacijent in ListaPacijenata) 
            {
                if (pacijent.karton.BrojKartona.Equals(brojKartona))
                    return pacijent.karton;
            }
            return null;
        }
        public  Karton DobaviKartonPacijenta(String korisnickoIme)
        {
            foreach (Pacijent pacijent in ListaPacijenata)
            {
                if (pacijent.korisnik.KorisnickoIme.Equals(korisnickoIme))
                    return pacijent.karton;
            }
            return null;
        }
        public void ProveriMalicioznostPacijenta(Termin termin)
        {
            int broj = termin.Pacijent.Zloupotrebio + 1;
            termin.Pacijent.Zloupotrebio = broj;
            if (termin.Pacijent.Zloupotrebio >5)
                termin.Pacijent.Maliciozan = true;
            naloziPacijenataRepozitorijum.UpisiPacijente(termin.Pacijent);
        }
        public bool DaLiJeNalogBlokiran(String idPacijenta)
        {
            if (PretragaPoId(idPacijenta).Maliciozan)
                return true;

            return false;
        }

        public void IzmeniPacijenta(Recept receptZaIzmenu)
        {

            Pacijent pacijent = PretragaPoId(receptZaIzmenu.idPacijenta);
            foreach(Recept recept in pacijent.karton.recepti)
            {
                if (recept.Lek1.ImeLeka.Equals(receptZaIzmenu.Lek1.ImeLeka))
                {
                    recept.obavestiMe =receptZaIzmenu.obavestiMe;
                }
            }
            NaloziPacijenataRepozitorijum.UpisiPacijente();
           
        }
    }
}