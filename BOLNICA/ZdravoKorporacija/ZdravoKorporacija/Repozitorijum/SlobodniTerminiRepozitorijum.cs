using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.RepozitorijumInterfejs;

namespace ZdravoKorporacija.Repozitorijum
{
   public class SlobodniTerminiRepozitorijum : GlavniRepozitorijum<Termin>,ISlobodniTerminiRepozitorijum
    {
        public SlobodniTerminiRepozitorijum()
        {
            imeFajla = "slobodniTermini.xml";
        }
        public Termin PretraziSlobodneTerminePoId(String idTermina)
        {

            return PretraziPoId("//ArrayOfTermin/Termin[IdTermina='" + idTermina + "']");
        }
        public void ObrisiSlobodanTermin(String terminZaBrisanje)
        {
            Obrisi("//ArrayOfTermin/Termin[IdTermina='" + terminZaBrisanje + "']");
        }

    }
}
