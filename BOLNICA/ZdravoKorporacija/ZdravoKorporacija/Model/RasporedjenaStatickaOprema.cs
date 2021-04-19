using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RasporedjenaStatickaOprema
    {
        public int Kolicina { get; set; }
        public StatickaOprema statickaOprema { get; set; }
        public DateTime RasporedjenaOd { get; set; }
    }
}
