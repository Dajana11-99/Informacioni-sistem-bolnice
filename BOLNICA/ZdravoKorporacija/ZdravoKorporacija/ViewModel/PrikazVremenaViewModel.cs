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
    public class PrikazVremenaViewModel : ViewModel
    {
        private ObservableCollection<TerminViewModel> slobodniTermini;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private TerminViewModel stariTermin;
        private TerminViewModel noviTermin;
        private TerminViewModel selektovaniTermin;
        private String poruka;

        public ObservableCollection<TerminViewModel> SlobodniTermini
        {
            get { return slobodniTermini; }
            set
            {
                slobodniTermini = value;
                OnPropertyChanged();
            }
        }

        public PrikazVremenaViewModel(TerminViewModel stariTermin, TerminViewModel noviTermin )
        {
            this.stariTermin = stariTermin;
            this.noviTermin = noviTermin;
            UcitajUKolekciju(noviTermin);
            nastaviKomanda = new RelayCommand(Nastavi);
            vratiSeKomanda = new RelayCommand(VratiSe);
        }

        private void UcitajUKolekciju(TerminViewModel izabraniTermin)
        {
            SlobodniTermini = new ObservableCollection<TerminViewModel>();
            foreach (TerminViewModel termin in terminKontroler.NadjiVremeTermina(izabraniTermin.TerminDTO))
            {
                SlobodniTermini.Add(termin);
            }
        }


        private RelayCommand nastaviKomanda;

        public RelayCommand NastaviKomanda
        {
            get { return nastaviKomanda; }
        }

        private RelayCommand vratiSeKomanda;

        public RelayCommand VratiSeKomanda
        {
            get { return vratiSeKomanda; }
        }

        public TerminViewModel SelektovaniTermin
        {
            get { return selektovaniTermin; }
            set
            {
                selektovaniTermin = value;
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

        public void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazDatumaZaPomeranjeKodLekara(stariTermin));
        }

        public void Nastavi()
        {
            if (SelektovaniTermin != null) {
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PotvrdiPomeranje(stariTermin, noviTermin));
            }else
            {
                Poruka = "*Morate izabrati vreme!";
            }
        }
    }
}
