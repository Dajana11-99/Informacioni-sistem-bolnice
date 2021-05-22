using Kontroler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Komande;
using ZdravoKorporacija.PacijentPrikaz;

namespace ZdravoKorporacija.ViewModel
{
   
    public class PrikazDatumaViewModel:ViewModel
    {
        private ObservableCollection<TerminViewModel> slobodniDatumi;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private TerminViewModel terminZaPomeranje;

        public ObservableCollection<TerminViewModel> SlobodniDatumi
        {
            get { return slobodniDatumi; }
            set
            {
                slobodniDatumi = value;
                OnPropertyChanged();
            }
        }
        public PrikazDatumaViewModel(TerminViewModel terminZaPomeranje)
        {
            this.terminZaPomeranje = terminZaPomeranje;
            UcitajUKolekciju();
            vratiSeKomanda = new RelayCommand(VratiSe);
            prikaziDatumeKomanda = new RelayCommand(PrikaziDatume);

        }

        public TerminViewModel TerminZaPomeranje
        {
            get { return terminZaPomeranje; }
        }
        private void UcitajUKolekciju()
        {
            SlobodniDatumi = new ObservableCollection<TerminViewModel>();
            foreach (TerminViewModel termin in terminKontroler.DobaviSveSlobodneDatumeZaPomeranje(terminZaPomeranje.TerminDTO))
            {
                this.SlobodniDatumi.Add(termin);
            }
        }

        private RelayCommand prikaziDatumeKomanda;

        public RelayCommand PrikaziDatumeKomanda
        {
            get { return prikaziDatumeKomanda; }
        }

        private RelayCommand vratiSeKomanda;

        public RelayCommand VratiSeKomanda
        {
            get { return vratiSeKomanda; }
        }

        public void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new RasporedTermina());
        }

        public void PrikaziDatume()
        {

            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazDatumaZaPomeranjeKodLekara(terminZaPomeranje));
        }


    }
}
