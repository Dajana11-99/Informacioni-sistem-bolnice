using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.Model
{
    public class Obavestenja:INotifyPropertyChanged {
        public String IdObavestenja { get; set; }
        public String Naslov { get; set; }
        public String Tekst { get; set; }
        public String Datum { get; set; }
        public bool JeProcitano { get; set; }

        public String IdPrimaoca { get; set; }

        public Obavestenja(string idObavestenja, string naslov, string tekst, DateTime datum, string idPrimaoca)
        {
            IdObavestenja = idObavestenja;
            Naslov = naslov;
            Tekst = tekst;
            Datum = datum.ToString();
            JeProcitano = false;
            IdPrimaoca = idPrimaoca;
        }

        public Obavestenja() { }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

