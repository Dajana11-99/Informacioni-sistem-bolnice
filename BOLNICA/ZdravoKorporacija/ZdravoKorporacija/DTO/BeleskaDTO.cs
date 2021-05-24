using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.DTO
{
  public  class BeleskaDTO
    {
        private String tekstBeleske;
        private DateTime datumBeleske;
        private String idBeleske;
        private String idPacijenta;

        public String TekstBeleske
        {
            get { return tekstBeleske; }
            set { tekstBeleske = value; }
        }
        public DateTime DatumBeleske
        {
            get { return datumBeleske; }
            set { datumBeleske = value; }
        }
        public String IdBeleske
        {
            get { return idBeleske; }
            set { idBeleske = value; }
        }
        public String IdPacijenta
        {
            get { return idPacijenta; }
            set { idPacijenta = value; }
        }

        public BeleskaDTO(string tekstBeleske, DateTime datumBeleske, string idBeleske, string idPacijenta)
        {
            this.tekstBeleske = tekstBeleske;
            this.datumBeleske = datumBeleske;
            this.idBeleske = idBeleske;
            this.idPacijenta = idPacijenta;
        }
    }
}
