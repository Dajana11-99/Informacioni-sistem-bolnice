using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Interfejs;
using ZdravoKorporacija.IRepozitorijum;
using ZdravoKorporacija.Maper;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.Servis
{
   public class ObavestenjaServis
    {

        private IObavestenjeRepozitorijum obavestenjaRepozitorijum = new ObavestenjaRepozitorijum();
        private ObavestenjeMaper obavestenjeMaper = new ObavestenjeMaper();
        public  void DodajObavestenjePacijentu(ObavestenjeDTO obavestenje)
        {
            obavestenjaRepozitorijum.Dodaj(obavestenjeMaper.ObavestenjeDtoUModel(obavestenje));
        }
        public List<ObavestenjeDTO> PretraziObavestenjaPoPacijentu(String idPacijenta)
        {
           
            List<ObavestenjeDTO> obavestenjaPacijenta = new List<ObavestenjeDTO>();
            foreach(Obavestenja obavestenje in obavestenjaRepozitorijum.DobaviObavestenjaPacijenta(idPacijenta))
            {
                obavestenjaPacijenta.Add(obavestenjeMaper.ObavestenjeModelUDto(obavestenje));
            }
           return SortirajPoDatumu(obavestenjaPacijenta);
        }
        private List<ObavestenjeDTO> SortirajPoDatumu(List<ObavestenjeDTO> nesortiranaObavestenja)
        {
            return nesortiranaObavestenja.OrderByDescending(user => user.Datum).ToList();
        }
        public void DodajObavestenjeOZakazanomPregledu(String idPacijenta, TerminDTO termin)
        {
            String TekstObavestenja = "Termin pregleda kod lekara \n " + termin.Lekar.Ime + " " + termin.Lekar.Prezime
                + " \n biće održan " + termin.Datum.ToString("dd/MM/yyyy") + " u " + termin.Vreme + "h. ";
             ObavestenjeDTO obavestenje= new ObavestenjeDTO(Guid.NewGuid().ToString(),"Obaveštenje o zakazanom pregledu", 
                 TekstObavestenja, termin.Datum.AddDays(-2), idPacijenta);
        }
        public void DodajObavestenjeOPomerenomPregledu(TerminDTO noviTermin, TerminDTO stariTermin)
        {
            String TekstObavestenja = "Upravo ste pomerili pregled \nkod lekara " + stariTermin.Lekar.Ime + " " + stariTermin.Lekar.Prezime
                + "\n" + stariTermin.Datum.ToString("dd/MM/yyyy") + " u " + stariTermin.Vreme + "h. \nNovi pregled je zakazan kod\nlekara "
                + noviTermin.Lekar.Ime + " " + noviTermin.Lekar.Prezime + "\n" + noviTermin.Datum.ToString("dd/MM/yyyy") + " u " + noviTermin.Vreme + " h.";
            DodajObavestenjePacijentu(new ObavestenjeDTO(Guid.NewGuid().ToString(),"Obaveštenje o pomerenom pregledu", TekstObavestenja,
                DateTime.Now, noviTermin.IdPacijenta));
        }

    }
}
