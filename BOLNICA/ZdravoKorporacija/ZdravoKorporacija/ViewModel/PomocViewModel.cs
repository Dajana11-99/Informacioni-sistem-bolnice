using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Komande;
using ZdravoKorporacija.PacijentPrikaz;

namespace ZdravoKorporacija.ViewModel
{
   public class PomocViewModel
    {
        public PomocViewModel()
        {
            pomocJedan = new RelayCommand(PrikaziPomocJedan);
            vratiSeNaPocetnu = new RelayCommand(VratiSeNaPocetnuPomoc);
            pomocDva = new RelayCommand(PrikaziPomocDva);
            vratiSeNaPomocJedan = new RelayCommand(VratiSeNaPOmocJedan);
            pomocTri = new RelayCommand(PrikaziPomocTri);
            pomocCetiri = new RelayCommand(PrikaziPomocCetiri);
            pomocPet = new RelayCommand(PrikaziPomocPet);
            pomocSest = new RelayCommand(PrikaziPomocSest);
            vratiSeNaPomocDva = new RelayCommand(VratiSeNaPOmocDva);
            vratiSeNaPomocTri = new RelayCommand(VratiSeNaPOmocTri);
            vratiSeNaPomocCetri = new RelayCommand(VratiSeNaPOmocCetri);
            vratiSeNaPomocPet = new RelayCommand(VratiSeNaPOmocPet);
            kraj = new RelayCommand(KrajPomoci);
        }
        private RelayCommand vratiSeNaPomocDva;

        public RelayCommand VratiSeNaPomocDva
        {
            get { return vratiSeNaPomocDva; }
        }
        private void VratiSeNaPOmocDva()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocDva());
        }
        private RelayCommand vratiSeNaPomocTri;

        public RelayCommand VratiSeNaPomocTri
        {
            get { return vratiSeNaPomocTri; }
        }
        private void VratiSeNaPOmocTri()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocTri());
        }

        private RelayCommand vratiSeNaPomocCetri;

        public RelayCommand VratiSeNaPomocCetri
        {
            get { return vratiSeNaPomocCetri; }
        }
        private void VratiSeNaPOmocCetri()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocCetri());
        }

        private RelayCommand vratiSeNaPomocPet;

        public RelayCommand VratiSeNaPomocPet
        {
            get { return vratiSeNaPomocPet; }
        }
        private void VratiSeNaPOmocPet()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocPet());
        }
        private RelayCommand kraj;

        public RelayCommand Kraj
        {
            get { return kraj; }
        }
        private void KrajPomoci()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PocetnaStrana());
        }

        private RelayCommand pomocJedan;

        public RelayCommand PomocJedan
        {
            get { return pomocJedan; }
        }
        private void PrikaziPomocJedan()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocJedan());
        }
        private RelayCommand vratiSeNaPocetnu;

        public RelayCommand VratiSeNaPocetnu
        {
            get { return vratiSeNaPocetnu; }
        }
        private void VratiSeNaPocetnuPomoc()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PocetnaPomoc());
        }
        private RelayCommand pomocDva;

        public RelayCommand PomocDva
        {
            get { return pomocDva; }
        }
        private void PrikaziPomocDva()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocDva());
        }
        private RelayCommand vratiSeNaPomocJedan;

        public RelayCommand VratiSeNaPomocJedan
        {
            get { return vratiSeNaPomocJedan; }
        }
        private void VratiSeNaPOmocJedan()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocJedan());
        }
        private RelayCommand pomocTri;

        public RelayCommand PomocTri
        {
            get { return pomocTri; }
        }
        private void PrikaziPomocTri()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocTri());
        }
        private RelayCommand pomocCetiri;

        public RelayCommand PomocCetiri
        {
            get { return pomocCetiri; }
        }
        private void PrikaziPomocCetiri()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocCetri());
        }
        private RelayCommand pomocPet;

        public RelayCommand PomocPet
        {
            get { return pomocPet; }
        }
        private void PrikaziPomocPet()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocPet());
        }
        private RelayCommand pomocSest;

        public RelayCommand PomocSest
        {
            get { return pomocSest; }
        }
        private void PrikaziPomocSest()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PomocSest());
        }
    }
}
