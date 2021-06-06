using Kontroler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Izvestaj;
using ZdravoKorporacija.Komande;
using ZdravoKorporacija.PacijentPrikaz;

namespace ZdravoKorporacija.ViewModel
{
    public class IzvestajViewModel:ViewModel
    {
        private DateTime datumOd;
        private DateTime datumDo;
        private List<DateTime> interval;
        private String idPacijenta;
        private String poruka;
        private String porukaNeuspeh;
        private IzvestajOTerminima izvestaj = new IzvestajOTerminima();
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        public IzvestajViewModel(String idPacijenta)
        {
            this.idPacijenta = idPacijenta;
            datumOd = DateTime.Now.Date;
            datumDo = DateTime.Now.AddDays(6).Date;
            vratiSe = new RelayCommand(vratiNaRaspored);
            kreiraj = new RelayCommand(KreirajIzvestaj);

        }

        public List<DateTime> Interval
        {
            get { return interval; }
            set
            {
                interval = value;
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
        public String PorukaNeuspeh
        {
            get { return porukaNeuspeh; }
            set
            {
                porukaNeuspeh = value;
                OnPropertyChanged();
            }
        }
        public DateTime DatumOd
        {
            get { return datumOd; }
            set
            {
                datumOd = value;
                OnPropertyChanged();
            }
        }
        public DateTime DatumDo
        {
            get { return datumDo; }
            set
            {
                datumDo = value;
                OnPropertyChanged();
            }
        }
        public String IdPacijenta
        {
            get { return idPacijenta; }
            set
            {
                idPacijenta = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand vratiSe;
        public RelayCommand VratiSe
        {
            get { return vratiSe; }
        }


        private RelayCommand kreiraj;
        public RelayCommand Kreiraj
        {
            get { return kreiraj; }
        }
        public void vratiNaRaspored()
        {
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Clear();
            PacijentGlavniProzor.GetGlavniSadrzaj().Children.Add(new RasporedTermina(naloziPacijenataKontroler.PretragaPoId(IdPacijenta).korisnik.KorisnickoIme));
        }
        public void KreirajIzvestaj()
        {
            if (Validacija())
            {
                interval = new List<DateTime>();
                interval.Add(DatumOd);
                interval.Add(DatumDo);
                izvestaj.KreirajIzvestaj(interval, IdPacijenta);
                PorukaNeuspeh = "";
                Poruka = "*Vaš izveštaj se nalazi u folderu IzveštajiPacijenta!";

            }
        }

        private bool Validacija()
        {

            DateTime? pocetak = DatumOd;
            DateTime? kraj = DatumDo;
            Poruka = "";

            if (!pocetak.HasValue || !kraj.HasValue)
            {
                PorukaNeuspeh = "*Popunite sva polja!";
                return false;
            }
            else if (DateTime.Compare(DatumOd.Date, DatumDo.Date) >= 0)
            {
                PorukaNeuspeh = "*Početni datum mora biti raniji od krajnjeg!";
                return false;
            }


            return true;
        }
    }
}
