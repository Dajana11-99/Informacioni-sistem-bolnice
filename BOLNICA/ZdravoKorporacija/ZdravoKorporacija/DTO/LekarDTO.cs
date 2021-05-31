using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.DTO
{
   public class LekarDTO
    {
        private String celoIme;
        private  String idZaposlenog;
        private Specijalizacija specijalizacija;

        public String CeloIme
        {
            get { return celoIme; }
            set
            {
                celoIme = value;
               
            }
        }
        public String IdZaposlenog
        {
            get { return idZaposlenog; }
            set
            {
                idZaposlenog = value;

            }
        }


        public LekarDTO(string celoIme, string idZaposlenog, Specijalizacija specijalizacija)
        {
            this.celoIme = celoIme;
            this.idZaposlenog = idZaposlenog;
            this.specijalizacija = specijalizacija;
        }
    }
}
