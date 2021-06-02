using Kontroler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.ViewModel
{
   public class KalendarViewModel:ViewModel
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        List<DateTime> daniTerapije = new List<DateTime>();
        List<String> imeLeka = new List<string>();
        public KalendarViewModel(String idPacijenta)
        {
            UcitajUKolekciju(idPacijenta);
        }

        public List<DateTime> DaniTerapije
        {
            get { return daniTerapije; }
            set
            {
                daniTerapije = value;
                OnPropertyChanged();
            }
        }
        private void UcitajUKolekciju(String idPacijenta)
        {
           
            foreach (Recept recept in naloziPacijenataKontroler.PretragaPoId(idPacijenta).karton.recepti)
            {
                int razlika = (int)(recept.KrajTerapije - recept.PocetakTerapije).TotalDays;
                    for(int i=0; i<= razlika; i++)
                {
                    daniTerapije.Add(recept.PocetakTerapije.AddDays(i));
                    imeLeka.Add(recept.Lek1.ImeLeka);
                }
            }
        }

    }
}
