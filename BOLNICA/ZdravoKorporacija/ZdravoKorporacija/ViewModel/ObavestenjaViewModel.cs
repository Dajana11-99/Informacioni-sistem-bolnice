using Kontroler;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.DTO;
using ZdravoKorporacija.Kontroler;

namespace ZdravoKorporacija.ViewModel
{
   public class ObavestenjaViewModel:ViewModel
    {
        private ObservableCollection<ObavestenjeDTO> svaObavestenjaPacijenta;
        private ObavestenjaKontroler obavestenjaKontroler = new ObavestenjaKontroler();
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();

        private String idPacijenta;
        public ObavestenjaViewModel(String pacijent)
        {
            idPacijenta = naloziPacijenataKontroler.PretraziPoKorisnickom(pacijent).IdPacijenta;
            UcitajUKolekciju();
        }
        private void UcitajUKolekciju()
        {
            SvaObavestenjaPacijenta = new ObservableCollection<ObavestenjeDTO>();
            foreach(ObavestenjeDTO obavestenje in obavestenjaKontroler.PretraziObavestenjaPoPacijentu(idPacijenta))
            {
                SvaObavestenjaPacijenta.Add(obavestenje);
            }
        }
        public ObservableCollection<ObavestenjeDTO> SvaObavestenjaPacijenta
        {
            get { return svaObavestenjaPacijenta; }
            set
            {
                svaObavestenjaPacijenta = value;
                OnPropertyChanged();
            }
        }



    }
}
