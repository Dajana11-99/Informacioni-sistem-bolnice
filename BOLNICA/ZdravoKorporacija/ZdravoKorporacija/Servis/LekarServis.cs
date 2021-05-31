using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.Servis
{
    public class LekarServis
    {
        public LekarRepozitorijum lekarRepozitorijum = new LekarRepozitorijum();
        public Lekar PretragaLekaraPoID(String idLekara)
        {
            return lekarRepozitorijum.PretragaLekaraPoID(idLekara);
        }
        public Lekar PretragaPoLekaru(String imeLekara, String prezimeLekara)
        {
            return lekarRepozitorijum.PretragaPoLekaru(imeLekara, prezimeLekara);
        }

        public Lekar PretraziPoKorisnickomImenu(String korisnickoIme)
        {
            return lekarRepozitorijum.PretraziPoKorisnickomImenu(korisnickoIme);
        }

        public Lekar PretraziPoImenuIPrezimenu(String imeIPrezime)
        {
            return lekarRepozitorijum.PretraziPoImenuIPrezimenu(imeIPrezime);
        }

        public List<Lekar> DobaviLekareOpstePrakse()
        {
            return lekarRepozitorijum.DobaviLekareOpstePrakse();
        }
    }
}
        
