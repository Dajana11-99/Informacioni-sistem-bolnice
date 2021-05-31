/***********************************************************************
 * Module:  NaloziPacijenataKontroler.cs
 * Author:  dajan
 * Purpose: Definition of the Class Kontroler.NaloziPacijenataKontroler
 ***********************************************************************/

using Model;
using Servis;
using System;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.ViewModel;

namespace Kontroler
{
    public class NaloziPacijenataKontroler
    {
        private NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        public Pacijent PretraziPoKorisnickom(String korisnickoIme)
        {
            return naloziPacijenataServis.PretraziPoKorisnickom(korisnickoIme);
        }
        public Pacijent PretragaPoId(String Id)
        {
            return naloziPacijenataServis.PretragaPoId(Id);
        }
        public void IzmeniPacijenta(ReceptDTO receptZaIzmenu)
        {
            Recept recept = new Recept(receptZaIzmenu.KolicinaTerapije, receptZaIzmenu.PocetakTerapije, receptZaIzmenu.KrajTerapije, receptZaIzmenu.PeriodUzimanjaTerapije, new Lek(receptZaIzmenu.IdLeka, receptZaIzmenu.NazivLeka), receptZaIzmenu.IdPacijenta, receptZaIzmenu.ObavestiMe);
            naloziPacijenataServis.IzmeniPacijenta(recept);
        }
        public Karton DobaviKartonPacijenta(String korisnickoIme)
        {
            return naloziPacijenataServis.DobaviKartonPacijenta(korisnickoIme);
        }
        public bool DaLiJeNalogBlokiran(String idPacijenta)
        {
            return naloziPacijenataServis.DaLiJeNalogBlokiran(idPacijenta);
        }

    }
}