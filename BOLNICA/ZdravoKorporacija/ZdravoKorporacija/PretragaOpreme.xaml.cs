﻿using Servis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ZdravoKorporacija
{


    public class RezultatPretrage
    {
        public string Id { get; set; }

        public string Naziv { get; set; }

        public int Kolicina { get; set; }
        public string UKojimJeSalama { get; set; }
    }

    /// <summary>
    /// Interaction logic for PretragaOpreme.xaml
    /// </summary>
    /// 


    public partial class PretragaOpreme : Window
    {


      public static ObservableCollection<RezultatPretrage> RezultatiPretrage { get; set; }
      public static ObservableCollection<RezultatPretrage> SveZajedno { get; set; }
        public PretragaOpreme()
        {
            InitializeComponent();
            RezultatiPretrage = new ObservableCollection<RezultatPretrage>();
            DataContext = this;
            var listaDinamicke = RukovanjeDinamickomOpremomServis.dinamickaOprema;
            var listaStaticke = RukovanjeStatickomOpremomServis.statickaOprema;
            var listaSvihSala = SalaServis.sala;

            foreach (var sala in listaSvihSala)
            {
                if (sala.RasporedjenaStatickaOprema == null || sala.RasporedjenaStatickaOprema.Count == 0)
                {
                    continue;
                }
                foreach (var staticka in sala.RasporedjenaStatickaOprema)
                {
                    RezultatPretrage rezSala = new RezultatPretrage();
                    rezSala.Id = staticka.statickaOprema.Id;
                    rezSala.Kolicina = staticka.Kolicina;
                    rezSala.Naziv = staticka.statickaOprema.naziv;
                    rezSala.UKojimJeSalama = $"{sala.Id}";
                    RezultatiPretrage.Add(rezSala);
                }

                foreach (var staticka in sala.RasporedjenaDinamickaOprema)
                {
                    RezultatPretrage rezSala = new RezultatPretrage();
                    rezSala.Id = staticka.dinamickaOprema.Id;
                    rezSala.Kolicina = staticka.Kolicina;
                    rezSala.Naziv = staticka.dinamickaOprema.naziv;
                    rezSala.UKojimJeSalama = $"{sala.Id}";
                    RezultatiPretrage.Add(rezSala);
                }

            }

            foreach (var staticka in listaStaticke)
            {
                RezultatPretrage rez = new RezultatPretrage();
                rez.Id = staticka.Id;
                rez.Naziv = staticka.naziv;
                rez.Kolicina = staticka.kolicina;
                rez.UKojimJeSalama = "SKLADISTE";
                RezultatiPretrage.Add(rez);
            }

            foreach (var dinamicka in listaDinamicke)
            {
                RezultatPretrage rez = new RezultatPretrage();
                rez.Id = dinamicka.Id;
                rez.Naziv = dinamicka.naziv;
                rez.Kolicina = dinamicka.kolicina;
                rez.UKojimJeSalama = "SKLADISTE";
                RezultatiPretrage.Add(rez);
            }

            SveZajedno = new ObservableCollection<RezultatPretrage>(RezultatiPretrage);
        }

        private void txtNaziv_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RezultatiPretrage == null)
            {
                return;
            }
            RezultatiPretrage.Clear();
            foreach(var rez in SveZajedno)
            {
                if (rez.Naziv.Contains(txtNaziv.Text))
                {
                    RezultatiPretrage.Add(rez);
                }
            }
        }

        private void txtIdSale_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (RezultatiPretrage == null)
            {
                return;
            }
            RezultatiPretrage.Clear();
            foreach (var rez in SveZajedno)
            {
                if (rez.UKojimJeSalama.Contains(txtIdSale.Text))
                {
                    RezultatiPretrage.Add(rez);
                }
            }
        }
    }
}