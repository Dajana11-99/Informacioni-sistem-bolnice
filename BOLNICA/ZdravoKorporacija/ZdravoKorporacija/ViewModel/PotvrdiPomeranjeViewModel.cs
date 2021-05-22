﻿using Kontroler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Komande;
using ZdravoKorporacija.PacijentPrikaz;

namespace ZdravoKorporacija.ViewModel
{
    public class PotvrdiPomeranjeViewModel
    {
        private TerminViewModel stariTermin;
        private TerminViewModel noviTermin;
        private TerminKontroler terminKontroler = new TerminKontroler();

        public PotvrdiPomeranjeViewModel(TerminViewModel stariTermin, TerminViewModel noviTermin)
        {
            
            this.stariTermin = stariTermin;
            this.noviTermin = noviTermin;
            pomeriTerminKomanda = new RelayCommand(PomeriPregled);
            vratiSe = new RelayCommand(VratiSeNazad);
        }

        private RelayCommand pomeriTerminKomanda;

        public RelayCommand PomeriTerminKomanda
        {
            get { return pomeriTerminKomanda; }
        }

        private RelayCommand vratiSe;

        public RelayCommand VratiSe
        {
            get { return vratiSe; }
        }
        public void VratiSeNazad()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new PrikazVremenaZaPomeranje(stariTermin,noviTermin));
        }

        public TerminViewModel NoviTermin
        {
            get { return noviTermin; }
        }

        public void PomeriPregled()
        {
            Console.WriteLine("USAOOOOOOOOOOO");
            terminKontroler.PomeriPregled(stariTermin.TerminDTO, noviTermin.TerminDTO);
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new RasporedTermina());
        }

    }
}