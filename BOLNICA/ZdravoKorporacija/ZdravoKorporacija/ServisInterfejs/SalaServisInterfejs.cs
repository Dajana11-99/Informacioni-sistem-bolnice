using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.ServisInterfejs
{
    public interface SalaServisInterfejs: GlavniServisInterfejs<Sala>
    {
        void inicijalizuj();
        bool DaLiJeSalaSlobodna(Sala sala, DateTime termin);
        bool Izmena(Sala salaZaIzmenu);
        void RenovirajSalu(Sala sala);
        bool BrisanjeSala(String id);
        Sala PretraziPoId(String id);
        void OsveziKolekciju();
        bool DodajSalu(Sala unetaSala);
        String pronadji();
    }
}
