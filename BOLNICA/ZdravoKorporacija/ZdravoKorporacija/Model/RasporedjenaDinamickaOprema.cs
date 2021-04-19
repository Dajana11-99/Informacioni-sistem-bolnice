using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RasporedjenaDinamickaOprema
    {
        public int Kolicina { get; set; }
        public DinamickaOprema dinamickaOprema { get; set; }
        public DateTime RasporedjenaOd { get; set; }
    }
}
