using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ZdravoKorporacija.GrafZavisnosti;
using ZdravoKorporacija.ServisInterfejs;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Startup startup;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            startup = new Startup();
            startup.RegistrujKontrolere();
            startup.RegistrujRepozitorijuma();
            startup.RegistrujServise();
            startup.InicijalizujKomponente();
           
        }
    }
}
