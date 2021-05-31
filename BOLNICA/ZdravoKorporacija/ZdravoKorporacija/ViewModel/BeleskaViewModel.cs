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
    public class BeleskaViewModel:ViewModel
    {
        private BeleskaDTO beleska;
        private String tekstBeleske;
        private TerminDTO izabraniTermin;
        private String poruka;
        private BeleskaKontroler beleskaKontroler = new BeleskaKontroler();
        
        public BeleskaViewModel(TerminDTO izabraniTermin)
        {
            
            this.izabraniTermin = izabraniTermin;
            vratiSeKomanda = new RelayCommand(VratiSe);
            sacuvajBeleskuKomanda = new RelayCommand(Sacuvaj);
            TekstBeleske = beleskaKontroler.PronadjiTekstBeleske(izabraniTermin.IdPacijenta);
            kreirajPodsetnikKomanda = new RelayCommand(Kreiraj);
        }
        public BeleskaDTO Beleska
        {
            get { return beleska; }
            set
            {
                beleska = value;
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

        public String TekstBeleske
        {
            get { return tekstBeleske; }
            set
            {
                tekstBeleske = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand vratiSeKomanda;

        public RelayCommand VratiSeKomanda
        {
            get { return vratiSeKomanda; }
        }
        private void VratiSe()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IzvestajSaPregleda(izabraniTermin));
        }

        private RelayCommand sacuvajBeleskuKomanda;

        public RelayCommand SacuvajBeleskuKomanda
        {
            get { return sacuvajBeleskuKomanda; }
        }
        private void Sacuvaj()
        {
          
            Beleska = new BeleskaDTO(TekstBeleske, DateTime.Now, new Guid().ToString(), izabraniTermin.IdPacijenta);
            beleskaKontroler.SacuvajBelesku(Beleska);
            Poruka = "*Beleska uspesno sacuvana";
        }

        private RelayCommand kreirajPodsetnikKomanda;

        public RelayCommand KreirajPodsetnikKomanda
        {
            get { return kreirajPodsetnikKomanda; }
        }
        private void Kreiraj()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new Podsetnik(izabraniTermin));
        }

    }
}
