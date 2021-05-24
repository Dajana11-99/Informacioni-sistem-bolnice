using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.Servis
{
   public class ObavestenjaServis
    {

        ObavestenjaRepozitorijum obavestenjaRepozitorijum = new ObavestenjaRepozitorijum();
        public  void DodajObavestenjePacijentu(Obavestenja obavestenje)
        {
            obavestenjaRepozitorijum.SacuvajObavestenje(obavestenje);
        }
        public Obavestenja PretraziPoId(String idObavestenja)
        {
            return obavestenjaRepozitorijum.PretraziPoId(idObavestenja);
        }
        public List<Obavestenja> DobaviSvaObavestenja()
        {
            return obavestenjaRepozitorijum.DobaviSvaObavestenja();
        }
        public List<Obavestenja> PretraziObavestenjaPoPacijentu(String idPacijenta)
        {
            return SortirajPoDatumu(obavestenjaRepozitorijum.PretraziObavestenjaPoPacijentu(idPacijenta));
        }
        private List<Obavestenja> SortirajPoDatumu(List<Obavestenja> nesortiranaObavestenja)
        {
            return nesortiranaObavestenja.OrderByDescending(user => user.Datum).ToList();
        }

        public void KreirajPodsetnik(ObavestenjeDTO obavestenja)
        {
            int brojDana = (int)(obavestenja.DatumDo - obavestenja.DatumOd).TotalDays;
            for (int i= 0; i < brojDana; i++)
            {
                DateTime datumObavestenja = obavestenja.DatumOd.AddDays(i);
            }
        }
     
    }
}
