using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Kontroler
{
   public class ObavestenjaKontroler
    {
        public static List<Obavestenja> svaObavestenja()
        {
            return ObavestenjaServis.SvaObavestenja();
        }

    }
}
