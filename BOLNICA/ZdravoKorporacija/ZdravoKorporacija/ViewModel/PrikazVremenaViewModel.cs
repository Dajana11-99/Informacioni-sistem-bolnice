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
        private ObservableCollection<TerminDTO> slobodniTermini;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private TerminDTO stariTermin;
        private TerminDTO noviTermin;
        private TerminDTO selektovaniTermin;
        private String poruka;

        public ObservableCollection<TerminDTO> SlobodniTermini
        {
            get { return slobodniTermini; }
            set
            {
                slobodniTermini = value;
                OnPropertyChanged();
            }
        }

        public PrikazVremenaViewModel(TerminDTO stariTermin, TerminDTO noviTermin )
        {
            this.stariTermin = stariTermin;
            this.noviTermin = noviTermin;
            UcitajUKolekciju(noviTermin);
            nastaviKomanda = new RelayCommand(Nastavi);
            vratiSeKomanda = new RelayCommand(VratiSe);
        }

        private void UcitajUKolekciju(TerminDTO izabraniTermin)
        {
            SlobodniTermini = new ObservableCollection<TerminDTO>();
            foreach (TerminDTO termin in terminKontroler.NadjiVremeTermina(izabraniTermin))
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

        public TerminDTO SelektovaniTermin
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
