﻿using Kontroler;
using NPOI.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using ZdravoKorporacija.Komande;
using ZdravoKorporacija.PacijentPrikaz;

namespace ZdravoKorporacija.ViewModel
{
   public class RasporedTerminaViewModel:ViewModel
    {
      

        private ObservableCollection<TerminViewModel> zakazaniTerminiPacijenta;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private TerminViewModel selektovaniTermin;
        private string poruka;
      

        public RasporedTerminaViewModel(String idPacijenta)
        {
            UcitajUKolekciju(idPacijenta);
            otkaziPregledKomanda = new RelayCommand(OtkaziPregled);

            pomeriPregledKomanda = new RelayCommand(PomeriPregled);
          
          
        
        }
       
        public RasporedTerminaViewModel(TerminViewModel izabraniTermin)
        {
            selektovaniTermin = izabraniTermin;
            this.potvrdiOtkazivanje = new RelayCommand(Potvrdi);

        }

        public void UcitajUKolekciju(String idPacijenta)
        {
            ZakazaniTerminiPacijenta = new ObservableCollection<TerminViewModel>();
            foreach (TerminViewModel termin in terminKontroler.DobaviZakazaneTerminePacijenta(idPacijenta))
            {
                this.ZakazaniTerminiPacijenta.Add(termin);
            }
          
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

        private RelayCommand potvrdiOtkazivanje;

        public RelayCommand PotvrdiOtkazivanje
        {
            get { return potvrdiOtkazivanje; }
        }

        public void Potvrdi()
        {
            terminKontroler.OtkaziPregled(SelektovaniTermin.TerminDTO); 

        }
        public void OtkaziPregled()
        {
            if (SelektovaniTermin != null)
            {
                OtkazivanjeTermina otkazivanje = new OtkazivanjeTermina(SelektovaniTermin);
                otkazivanje.Show();
            }else
            {
                Poruka = "*Morate izabrati termin da biste ga mogli otkazati!";
            }
        }
        public string Poruka
        {
            get { return poruka; }
            set { poruka = value; OnPropertyChanged("Poruka"); }
        }
        private RelayCommand pomeriPregledKomanda;
        public RelayCommand PomeriPregledKomanda
        {
            get { return pomeriPregledKomanda; }
        }

  

      
        public void PomeriPregled()
        {
            if (selektovaniTermin != null)
            {
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IzmenaTermina(selektovaniTermin));
            }else
            {
                Poruka = "*Morate izabrati termin da biste pomerili pregled!";
            }
        }

       
    }
}