using Kontroler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using ZdravoKorporacija.Komande;

namespace ZdravoKorporacija.ViewModel
{
   public class RasporedTerminaViewModel:ViewModel
    {
      

        private ObservableCollection<TerminViewModel> zakazaniTerminiPacijenta;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private TerminViewModel terminViewModel;
        public RasporedTerminaViewModel(String idPacijenta,TerminViewModel terminViewModel)
        {
            this.terminViewModel = terminViewModel;
            otkaziPregledKomanda = new RelayCommand(OtkaziPregled);
        }
        public RasporedTerminaViewModel(String idPacijenta)
        {
          
            UcitajUKolekciju(idPacijenta);

        }
        public ObservableCollection<TerminViewModel> UcitajUKolekciju(String idPacijenta)
        {
            ZakazaniTerminiPacijenta = new ObservableCollection<TerminViewModel>();
            foreach (TerminViewModel termin in terminKontroler.DobaviZakazaneTerminePacijenta(idPacijenta))
            {
                this.ZakazaniTerminiPacijenta.Add(termin);
            }
            return ZakazaniTerminiPacijenta;
        }
        public ObservableCollection<TerminViewModel> ZakazaniTerminiPacijenta
        {
            get { return zakazaniTerminiPacijenta; }
            set
            {
                zakazaniTerminiPacijenta = value;
              OnPropertyChanged();
            }
        }

        private RelayCommand otkaziPregledKomanda;

        public RelayCommand OtkaziPregledKomanda
        {
            get { return otkaziPregledKomanda; }
        }

        public void OtkaziPregled()
        {
            
            terminKontroler.OtkaziPregled(terminViewModel.TerminDTO.IdTermina);
        }
      
    }
}
