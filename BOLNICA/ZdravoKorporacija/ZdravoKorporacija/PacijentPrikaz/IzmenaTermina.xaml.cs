﻿using Kontroler;
using Model;
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

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for IzmenaTermina.xaml
    /// </summary>
    public partial class IzmenaTermina : Window
    {
        public static List<Termin> datumiZaIzmenu = new List<Termin>();
        public string idTermina = null;
        public IzmenaTermina(Termin termin)
        {
            InitializeComponent();
            lekar.Text = termin.Lekar.CeloIme;
            datum.Text = termin.Datum.ToString("MM/dd/yyyy");
            vreme.Text = termin.Vreme;
            idTermina = termin.IdTermina;
        }

        private void prikaziDatume_Click(object sender, RoutedEventArgs e)
        {
 
            if (DateTime.Compare(DateTime.Now.Date, DateTime.Parse(datum.Text).Date) == 0)
            {
                MessageBox.Show("Termin je za manje od 24h ne mozete ga pomeriti!");
                return;
            }
    
            bool dostupanDatum = TerminKontroler.ProveriMogucnostPomeranjaDatum(DateTime.Parse(datum.Text).Date);
            
            if (dostupanDatum)
            {
                bool dostupnoVreme = TerminKontroler.ProveriMogucnostPomeranjaVreme(TerminServis.PretragaZakazanihTerminaPoId(idTermina).Vreme);
             
                if (!dostupnoVreme)
                {
                    MessageBox.Show("Datum pregleda je za manje od 24h! Ne mozete pomeriti!", "Datum pregleda!");
                    return;
                }
            }

            Termin termin = TerminKontroler.PretragaPoId(idTermina);
            List<Termin> datumiIntervala = new List<Termin>();
            datumiZaIzmenu.Clear();
            datumiIntervala = TerminKontroler.nadjiDatumUIntervalu(termin.Datum.AddDays(-2), termin.Datum.AddDays(2));
            foreach (Termin terminiLekara in TerminKontroler.nadjiSlobodneTermineLekara(termin.Lekar.idZaposlenog,datumiIntervala))
            {
                 UkloniDupleDatume(terminiLekara);
            }
            if (datumiZaIzmenu.Count == 0)
            {
                MessageBox.Show("Nema datuma za izmenu");
            }else
            {
                PrikazDatumaZaPomeranjeKodLekara prikaz = new PrikazDatumaZaPomeranjeKodLekara();
                prikaz.Show();
                this.Close();
            }





        }

        private static bool UkloniDupleDatume(Termin termin)
        {
            bool nasao = false;
            foreach (Termin t1 in datumiZaIzmenu)
            {
                if (t1.Datum.Equals(termin.Datum))
                {
                    nasao = true;
                    break;
                }
            }
            if (!nasao)
            {
                datumiZaIzmenu.Add(termin);
            }

            return nasao;
        }
    }
}
