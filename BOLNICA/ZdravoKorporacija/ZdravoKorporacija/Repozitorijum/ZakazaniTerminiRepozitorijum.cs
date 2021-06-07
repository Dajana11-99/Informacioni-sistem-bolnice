/***********************************************************************
 * Module:  RukovanjeDatotekama.cs
 * Author:  filip
 * Purpose: Definition of the Class RadSaDatotekama.RukovanjeDatotekama
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using Model;
using Servis;
using ZdravoKorporacija.GrafZavisnosti;
using ZdravoKorporacija.Interfejs;
using ZdravoKorporacija.PacijentPrikaz;
using ZdravoKorporacija.ServisInterfejs;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.Repozitorijum
{
    public class ZakazaniTerminiRepozitorijum:GlavniRepozitorijum<Termin>, IZakazaniTerminiRepozitorijum
    {
        public ZakazaniTerminiRepozitorijum()
        {
            imeFajla = "zakazaniTermini.xml";
        }

        public Termin PretraziZakazanePoId(String idTermina)
        {
            return PretraziPoId("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']");
        }
        public void ObrisiZakazanTermin(String terminZaBrisanje)
        {
       
            Obrisi("//ArrayOfTermin/Termin[IdTermina='" + terminZaBrisanje + "']");
        }
       
        public void IzmeniTermin(Termin termin)
        {
            Obrisi("//ArrayOfTermin/Termin[IdTermina='" + termin.IdTermina + "']");
            Dodaj(termin);
        }

        public List<Termin> DobaviSveZakazaneTerminePacijenta(String idPacijenta)
        {
            List<Termin> sviTerminiPacijenta = new List<Termin>();
            foreach (Termin termin in DobaviSve())
            {
                if (termin.Pacijent.IdPacijenta.Equals(idPacijenta))
                    sviTerminiPacijenta.Add(termin);
            }
            return sviTerminiPacijenta;
        }










        public  bool ZakaziTermin(Termin termin)
        {
            if (NijeDostupnaSala(termin))
                return false;
            Dodaj(termin);
            return true;
        }
        private static bool NijeDostupnaSala(Termin termin)
        {
            SalaServisInterfejs salaServis = Injektor.Instance.Get<SalaServisInterfejs>(typeof(SalaServisInterfejs));
            return !salaServis.DaLiJeSalaSlobodna(termin.Sala, termin.Datum);
        }
        public Termin  IzmenaTermina(TerminDTO terminDTO)
        {
            Termin termin = PretraziZakazanePoId(terminDTO.IdTermina);
            int ind = LekarWindow.TerminiLekara.IndexOf(termin);
            LekarWindow.TerminiLekara.RemoveAt(ind);
            LekarWindow.TerminiLekara.Insert(ind, termin);
            return termin;
        }
       
    }
}