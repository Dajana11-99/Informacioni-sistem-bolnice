using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Interfejs;

namespace ZdravoKorporacija.RepozitorijumInterfejs
{
    public interface ISlobodniTerminiRepozitorijum : IRepozitorijum<Termin>
    {
        Termin PretraziSlobodneTerminePoId(String idTermina);
         void ObrisiSlobodanTermin(String terminZaBrisanje);


    }
}
