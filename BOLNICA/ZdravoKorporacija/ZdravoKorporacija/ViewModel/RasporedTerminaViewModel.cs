using Kontroler;
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
        private ObservableCollection<TerminDTO> zakazaniTerminiPacijenta;
        private TerminKontroler terminKontroler = new TerminKontroler();
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        private TerminDTO selektovaniTermin;
        private string poruka;
        private String idPacijenta;
        public RasporedTerminaViewModel(String idPacijenta)
        {
            UcitajUKolekciju(idPacijenta);
            this.idPacijenta = idPacijenta;
            otkaziPregledKomanda = new RelayCommand(OtkaziPregled);
            izvestajKomanda = new RelayCommand(Izvestaj);
            pomeriPregledKomanda = new RelayCommand(PomeriPregled);
        }
       
        public RasporedTerminaViewModel(TerminDTO izabraniTermin)
        {
            selektovaniTermin = izabraniTermin;
            this.potvrdiOtkazivanje = new RelayCommand(Potvrdi);

        }

        public void UcitajUKolekciju(String idPacijenta)
        {
            ZakazaniTerminiPacijenta = new ObservableCollection<TerminDTO>();
            foreach (TerminDTO termin in terminKontroler.DobaviZakazaneTerminePacijenta(idPacijenta))
            {
                this.ZakazaniTerminiPacijenta.Add(termin);
            }
          
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
        public ObservableCollection<TerminDTO> ZakazaniTerminiPacijenta
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
            
           terminKontroler.OtkaziPregled(SelektovaniTermin);
           String korisnickoIme= naloziPacijenataKontroler.PretragaPoId(SelektovaniTermin.IdPacijenta).korisnik.KorisnickoIme;
           PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
           PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new RasporedTermina(korisnickoIme));
          
        }
        private bool Validacija()
        {
            if (DateTime.Compare(SelektovaniTermin.Datum.Date, DateTime.Now.Date) < 0)
            {
                return false;
            }
            else if (DateTime.Compare(SelektovaniTermin.Datum.Date, DateTime.Now.AddDays(1).Date) == 0)
            {
                if (!terminKontroler.ProveriMogucnostPomeranjeVreme(SelektovaniTermin.Vreme))
                {
                    return false;
                }
            }
            return true;
        }
        public void OtkaziPregled()
        {
            if (SelektovaniTermin != null)
            {
                if (Validacija())
                {
                    if (!naloziPacijenataKontroler.DaLiJeNalogBlokiran(idPacijenta))
                    {
                        OtkazivanjeTermina otkazivanje = new OtkazivanjeTermina(SelektovaniTermin);
                        otkazivanje.Show();
                    }else
                    {
                        Poruka = "*Vas nalog je blokiran";
                    }
                }
                else
                {
                    Poruka = "*Ne mozete otkazati termin koji je za manje od 24h!";
                }

            }else
            {
                Poruka = "*Morate izabrati termin!";
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
                if (Validacija())
                {
                    if (!naloziPacijenataKontroler.DaLiJeNalogBlokiran(idPacijenta))
                    {
                        PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
                        PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IzmenaTermina(selektovaniTermin));
                    }else
                    {
                        Poruka = "*Vas nalog je blokiran";
                    }
                }
                else
                {
                    Poruka = "*Ne mozete pomeriti termin koji je za manje od 24h!";
                  
                }
                
            }else
            {
                Poruka = "*Morate izabrati termin da biste pomerili pregled!";
            }

        }
        private RelayCommand izvestajKomanda;
        public RelayCommand IzvestajKomanda
        {
            get { return izvestajKomanda; }
        }

        private void Izvestaj()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new IzvestajOPregledima(idPacijenta));
        }


    }
}
