using Kontroler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Komande;
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.PacijentPrikaz;

namespace ZdravoKorporacija.ViewModel
{
   public class ZakazivanjeSaPrioritetomViewModel:ViewModel
    {
      
        private ZakazivanjeDTO podaci;
        private List<LekarDTO> sviLekari;
        private LekarKontroler lekarKontroler = new LekarKontroler();
        private TerminKontroler terminKontroler = new TerminKontroler();
       

        private String poruka;
     
        public ZakazivanjeSaPrioritetomViewModel(String pacijent)
        {
            Podaci = new ZakazivanjeDTO();
            Podaci.KorisnickoImePacijenta = pacijent;
           Podaci.DatumOd = DateTime.Now.Date.AddDays(1);
           Podaci.DatumDo = DateTime.Now.Date.AddDays(3);
            UcitajUKolekciju();
            prikaziDatume = new RelayCommand(Prikazi);
        }
        private void UcitajUKolekciju()
        {
            SviLekari = new List<LekarDTO>();
            foreach(LekarDTO lekar in lekarKontroler.DobaviLekareOpstePrakse())
            {
                SviLekari.Add(lekar);
            }
         
            
        }
        public List<LekarDTO> SviLekari
        {
            get { return sviLekari; }
            set
            {
                sviLekari = value;
                OnPropertyChanged();
            }
        }
        public ZakazivanjeDTO Podaci
        {
            get { return podaci; }
            set
            {
                podaci = value;
                OnPropertyChanged();
            }
        }

       
        public String Poruka
        {
            get { return poruka; }
            set
            {
                poruka = value;
                OnPropertyChanged();
            }
        }

       

        private RelayCommand prikaziDatume;

        public RelayCommand PrikaziDatume
        {
            get { return prikaziDatume; }
        }

        private void Prikazi()
        {
           
            if (Validacija())
            {
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new DatumiKodIzabranogLekara(podaci));
            }
          
            
     
        }

        private bool Validacija()
        {
            DateTime? pocetak = Podaci.DatumOd;
            DateTime? kraj = Podaci.DatumDo;
            if (Podaci.IzabraniLekar==null || Podaci.Prioritet == -1 || !pocetak.HasValue || !kraj.HasValue)
            {
                Poruka = "*Popunite sva polja!";
                return false;
            }
            else if (DateTime.Compare(Podaci.DatumOd.Date, DateTime.Now.Date) <= 0)
            {
                Poruka = "*Izaberite datum u budućnosti!";
                return false;
            }
            else if (DateTime.Compare(Podaci.DatumOd.Date, Podaci.DatumDo.Date) >= 0)
            {
                Poruka = "*Početni datum mora biti raniji od krajnjeg!";
                return false;
            }

            return true;
        }
    }
}
