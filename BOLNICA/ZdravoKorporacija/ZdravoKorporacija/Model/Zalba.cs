using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.Model
{
    public class Zalba
    {
        public String IdZalbe { get; set; }
        public String TextZalbe { get; set; }
        public String IdLeka { get; set; }

        public Zalba() { }

        public Zalba(String id, String idLeka, String text)
        {
            IdZalbe = id;
            TextZalbe = text;
            IdLeka = idLeka;
        }

        public Zalba(String idLeka, String text)
        {
            TextZalbe = text;
            IdLeka = idLeka;
        }
    }
}
