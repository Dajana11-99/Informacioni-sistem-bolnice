using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.ServisInterfejs
{
    public interface RukovanjeDinamickomOpremomServisInterfejs : GlavniServisInterfejs<DinamickaOprema>
    {
        void inicijalizuj();
        bool DodajDinamickuOpremu(DinamickaOprema unetaDinamickaOprema);
        bool IzmeniDinamickuOpremu(DinamickaOprema dinamickaOpremaZaIzmenu);
        bool ObrisiDinamickuOpremu(String id);
        DinamickaOprema PretraziPoId(String id);
    }
}
