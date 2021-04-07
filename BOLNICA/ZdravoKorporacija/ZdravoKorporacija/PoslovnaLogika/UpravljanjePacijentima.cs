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


namespace PoslovnaLogika
{
    public class UpravljanjePacijentima
    {
        public static List<Pacijent> ListaPacijenata = new List<Pacijent>();

        public static void TestMethod()
        {
            for (int i = 0; i < 30; i += 5)
                ListaPacijenata.Add(new Pacijent(i.ToString()));
        }

        public static Pacijent PretragaPoId(string Id)
        {
            foreach (Pacijent P in ListaPacijenata)
            {
                if (P.idPacijenta.Equals(Id))
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

        public static bool IzmeniPostojeciNalog(string iDPacijent)
        {

            //Pacijent P = PrikazPacijenata.ListaPacijenataXMAL.Items.Refresh();
            //PrikazPacijenata.UbaciUListu(iDPacijent);

            Pacijent P = PretragaPoId(iDPacijent);

            int id = PrikazPacijenata.ListaPacijenataXMAL.IndexOf(P);
            PrikazPacijenata.ListaPacijenataXMAL.RemoveAt(id);
            PrikazPacijenata.ListaPacijenataXMAL.Insert(id, P);

            //PrikazPacijenata.ListaPacijenataXMAL.Remove(iDPacijent);

            return false;
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

        public static Pacijent PretragaPoId(int iDPacijenta)
        {
            // TODO: implement
            return null;
        }

        public static List<Pacijent> PrikaziPacijente()
        {
            // TODO: implement
            return null;
        }


    }
}