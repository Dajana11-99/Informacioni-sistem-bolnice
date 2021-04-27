using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model;
using ZdravoKorporacija;
using ZdravoKorporacija.Repozitorijum;

namespace Servis
{
    public class RenoviranjeServis
    {
        public static List<Renoviranje> renoviranje = new List<Renoviranje>();
        public static ObservableCollection<Renoviranje> observableRenoviranje = new ObservableCollection<Renoviranje>();
        public static void inicijalizuj()
        {
            renoviranje = RenoviranjeRepozitorijum.UcitajRenoviranja();
            OsveziKolekciju();
        }

        public static void OsveziKolekciju()
        {
            observableRenoviranje.Clear();
            foreach (Renoviranje r in renoviranje)
                observableRenoviranje.Add(r);
        }

    }
}
