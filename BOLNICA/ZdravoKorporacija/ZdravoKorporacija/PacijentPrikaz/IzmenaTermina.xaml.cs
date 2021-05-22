﻿using Kontroler;
using Model;
using MoreLinq;
using Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for IzmenaTermina.xaml
    /// </summary>
    public partial class IzmenaTermina : UserControl
    {
     
        TerminKontroler terminKontroler = new TerminKontroler();
        PrikazDatumaViewModel prikazDatumaViewModel;
       
        public IzmenaTermina(TerminViewModel termin)
        {
            prikazDatumaViewModel = new PrikazDatumaViewModel(termin);
            InitializeComponent();
            this.DataContext = prikazDatumaViewModel;
           
        }

        private void prikaziDatume_Click(object sender, RoutedEventArgs e)
        {

            /*  if (DateTime.Compare(DateTime.Now.Date, DateTime.Parse(datum.Text).Date) == 0)
              {
                  MessageBox.Show("Termin je za manje od 24h ne mozete ga pomeriti!");
                  return;
              }

              bool dostupanDatum = TerminKontroler.ProveriMogucnostPomeranjaDatum(DateTime.Parse(datum.Text).Date);

              if (dostupanDatum)
              {
                  bool dostupnoVreme = TerminKontroler.ProveriMogucnostPomeranjaVreme(terminKontroler.PretragaZakazanihTerminaPoId(Termin.IdTermina).Vreme);

                  if (!dostupnoVreme)
                  {
                      MessageBox.Show("Datum pregleda je za manje od 24h! Ne mozete pomeriti!", "Datum pregleda!");
                      return;
                  }
              }

              Termin termin = terminKontroler.PretragaZakazanihTerminaPoId(Termin.IdTermina);
              List<Termin> datumiIntervala = new List<Termin>();
              datumiZaIzmenu.Clear();
              datumiIntervala = terminKontroler.NadjiDatumUIntervalu(termin.Datum.AddDays(-2), termin.Datum.AddDays(2));
             UkloniDupleDatume(TerminKontroler.NadjiSlobodneTermineLekara(termin.Lekar.idZaposlenog, datumiIntervala));

              if (datumiZaIzmenu.Count == 0)
              {
                  MessageBox.Show("Nema datuma za izmenu");
              }else
              {
                  /*PrikazDatumaZaPomeranjeKodLekara prikaz = new PrikazDatumaZaPomeranjeKodLekara();
                  prikaz.Show();
                  this.Close();

           }
            */



        }

    
    }
}
