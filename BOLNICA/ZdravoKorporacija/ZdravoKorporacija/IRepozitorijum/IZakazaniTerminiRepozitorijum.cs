using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.Interfejs
{
   public  interface IZakazaniTerminiRepozitorijum:IRepozitorijum<Termin>
    {
         Termin PretraziZakazanePoId(String idTermina);
         List<Termin> DobaviSveZakazaneTerminePacijenta(String idPacijenta);
         void ObrisiZakazanTermin(String terminZaBrisanje);
         void IzmeniTermin(Termin termin);
       
       
    }
}
