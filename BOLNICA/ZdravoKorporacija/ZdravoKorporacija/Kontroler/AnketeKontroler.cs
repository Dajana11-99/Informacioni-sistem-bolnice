using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Kontroler
{
    public class AnketeKontroler
    {
        public  List<Pitanje> DobaviSvaPitanjaOPregledu()
        {
            return anketeServis.DobaviSvaPitanjaOPregledu();
        }
        public  bool DostupnaAnketaOBolnici(Pacijent pacijent)
        {
            return anketeServis.DostupnaAnketaOBolnici(pacijent);
        }
        public  void DodajAnketu(Ankete anketa)
        {
             anketeServis.DodajAnketu(anketa);
        }
         AnketaServis anketeServis = new AnketaServis();
    }
}
