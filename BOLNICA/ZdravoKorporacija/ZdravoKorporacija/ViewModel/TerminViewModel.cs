using Kontroler;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Komande;

namespace ZdravoKorporacija.ViewModel
{
   public class TerminViewModel:ViewModel
    {
        private TerminKontroler terminKontroler = new TerminKontroler();
        private TerminDTO terminDTO;
      
        public TerminViewModel()
        {
            
        }
       public TerminDTO TerminDTO

        {
            get { return terminDTO; }
            set
            {
                terminDTO = value;
                OnPropertyChanged();
            }
        }

        public TerminViewModel(TerminDTO terminDTO)
        {

            this.terminDTO = terminDTO;
         
            
        }

       
    }
}
