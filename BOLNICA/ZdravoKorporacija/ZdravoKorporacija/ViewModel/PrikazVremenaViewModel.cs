using Kontroler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.ViewModel
{
    public class PrikazVremenaViewModel:ViewModel
    {
        private ObservableCollection<TerminViewModel> slobodniTermini;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private TerminViewModel izabraniTermin;

        public ObservableCollection<TerminViewModel> SlobodniTermini
        {
            get { return slobodniTermini; }
            set
            {
                slobodniTermini = value;
                OnPropertyChanged();
            }
        }

        public PrikazVremenaViewModel(TerminViewModel terminViewModel)
        {
            izabraniTermin = terminViewModel;
            UcitajUKolekciju(izabraniTermin);
        }

        private void UcitajUKolekciju(TerminViewModel izabraniTermin)
        {
            SlobodniTermini = new ObservableCollection<TerminViewModel>();
            foreach(TerminViewModel termin in terminKontroler.NadjiVremeTermina(izabraniTermin.TerminDTO))
            {
                SlobodniTermini.Add(termin);
            }
        }
    }
}
