using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.Servis
{
    public class AnketaServis
    {
        PitanjeRepozitorijum pitanjeRepozitorijum = new PitanjeRepozitorijum();
        public  List<Pitanje> DobaviSvaPitanjaOPregledu()
        {
            return pitanjeRepozitorijum.DobaviSvaPitanjaOPregledu();
        }


        public  List<Pitanje> DobaviSvaPitanjaOBolnici()
        {
            return pitanjeRepozitorijum.DobaviSvaPitanjaOBolnici();
        }
        public void DodajAnketu(Ankete anketa)
        {
            anketeRepozitorijum.DodajAnketu(anketa);
            

        }
        public  bool DostupnaAnketaOBolnici(Pacijent pacijent)
        {
            DateTime novaAnketa=NadjiDatumPoslednjeAnketeOBolnici(pacijent).AddMonths(3);
            if (DateTime.Compare(DateTime.Now.Date, novaAnketa.Date) >= 0)
                return true;
            
            return false;
        }

        public  DateTime NadjiDatumPoslednjeAnketeOBolnici(Pacijent pacijent)
        {
            List<Ankete> anketePacijenta = anketeRepozitorijum.NadjiPoslednjuAnketuOBolnici(pacijent);
            if (anketePacijenta.Count == 0)
                return DateTime.Now.Date.AddMonths(-3);

            return SortirajTerminePoDatumu(anketePacijenta)[0].ocenioBolnicu;
        }
    
        private  List<Ankete> SortirajTerminePoDatumu(List<Ankete> nesortiraniDatumi)
        {
            return nesortiraniDatumi.OrderByDescending(user => user.ocenioBolnicu).ToList();
        }

        public AnketeRepozitorijum anketeRepozitorijum = new AnketeRepozitorijum();
    }
}
