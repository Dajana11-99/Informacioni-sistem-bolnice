using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ZahtevZaRasporedjivanjeStatickeOpreme
    {

        public string Id { get; set; }
        public string StatickeOpremaId { get; set; }
        public string ProstorijaId { get; set; }
        public DateTime RasporedjenoOd { get; set; } // 18.4.2021 // 20.4.2021
        // daj mi spisak stvari koje su u Sali4
        // daj mi sve StatickaOpremaProstorija Gde je RasporedjenaOd <= Danas 

        public int Kolicina { get; set; }

        public string IzProstorijaId { get; set; }

    }
}
