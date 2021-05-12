using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.Kontroler
{
    public class LekarKontroler
    {
        private LekarServis lekarServis = new LekarServis();
        public Lekar PretragaLekaraPoID(String idLekara)
        {
            return lekarServis.PretragaLekaraPoID(idLekara);
        }
        public Lekar PretragaPoLekaru(String imeLekara, String prezimeLekara)
        {
            return lekarServis.PretragaPoLekaru(imeLekara, prezimeLekara);
        }

        public Lekar PretraziPoKorisnickomImenu(String korisnickoIme)
        {
            return lekarServis.PretraziPoKorisnickomImenu(korisnickoIme);
        }

        public Lekar PretraziPoImenuIPrezimenu(String imeIPrezime)
        {
            return lekarServis.PretraziPoImenuIPrezimenu(imeIPrezime);
        }
        public List<Lekar> PretraziPoSpecijalizaciji()
        {
            return lekarServis.PretraziPoSpecijalizaciji();
        }
        public void Inicijalizuj()
        {
            lekarServis.Inicijalizuj();
        }
    }
}
