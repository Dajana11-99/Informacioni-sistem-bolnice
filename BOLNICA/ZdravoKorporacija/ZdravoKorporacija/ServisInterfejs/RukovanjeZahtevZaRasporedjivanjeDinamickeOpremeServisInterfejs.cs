﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoKorporacija.ServisInterfejs
{
    public interface RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs : GlavniServisInterfejs<ZahtevZaRasporedjivanjeDinamickeOpreme>
    {
        void Inicijalizuj();
        bool DodajDinamickuOpremuProstorija(ZahtevZaRasporedjivanjeDinamickeOpreme zahtev);
        bool DovoljnoKolicineDinamickeOpreme(ZahtevZaRasporedjivanjeDinamickeOpreme zahtev);
        String pronadji();
    }
}