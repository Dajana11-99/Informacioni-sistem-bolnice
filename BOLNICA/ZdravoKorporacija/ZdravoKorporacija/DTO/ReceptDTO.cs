using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.DTO
{
   public  class ReceptDTO
    {
        private String nazivLeka;
        private String idLeka;
        private String kolicinaTerapije;
        private DateTime pocetakTerapije;
        private DateTime krajTerapije;
        private double peroidUzimanjaUSatima;
        private String obavestiMe;
        private String idPacijenta;

        public String NazivLeka
        {
            get { return nazivLeka; }
            set { nazivLeka = value; }
        }
        public String IdLeka
        {
            get { return idLeka; }
            set { idLeka = value; }
        }
        public String KolicinaTerapije
        {
            get { return kolicinaTerapije; }
            set { kolicinaTerapije = value; }
        }
        public DateTime PocetakTerapije
        {
            get { return pocetakTerapije; }
            set { pocetakTerapije = value; }
        }
        public DateTime KrajTerapije
        {
            get { return krajTerapije; }
            set { krajTerapije = value; }
        }
        public double PeriodUzimanjaTerapije
        {
            get { return peroidUzimanjaUSatima; }
            set { peroidUzimanjaUSatima = value; }
        }
        public String ObavestiMe
        {
            get { return obavestiMe; }
            set { obavestiMe = value; }
        }
        public String IdPacijenta
        {
            get { return idPacijenta; }
            set { idPacijenta = value; }
        }

        public ReceptDTO(string nazivLeka, string idLeka, string kolicinaTerapije, DateTime pocetakTerapije, DateTime krajTerapije, double peroidUzimanjaUSatima, string obavestiMe, string idPacijenta)
        {
            this.nazivLeka = nazivLeka;
            this.idLeka = idLeka;
            this.kolicinaTerapije = kolicinaTerapije;
            this.pocetakTerapije = pocetakTerapije;
            this.krajTerapije = krajTerapije;
            this.peroidUzimanjaUSatima = peroidUzimanjaUSatima;
            this.obavestiMe = obavestiMe;
            this.idPacijenta = idPacijenta;
        }
    }
}
