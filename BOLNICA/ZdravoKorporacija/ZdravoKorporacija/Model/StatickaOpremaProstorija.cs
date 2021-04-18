using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StatickaOpremaProstorija
    {
        public string Id { get; set; }
        public string StatickeOpremaId { get; set; }
        public string ProstorijaId { get; set; }
        public DateTime RasporedjenoOd { get; set; }
        public DateTime RasporedjenoDo { get; set; }

        public int Kolicina { get; set; }


    }
}
