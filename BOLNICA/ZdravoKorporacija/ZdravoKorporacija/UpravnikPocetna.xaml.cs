﻿using Model;
using PoslovnaLogika;
using Servis;
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
    /// <summary>
    /// Interaction logic for UpravnikPocetna.xaml
    /// </summary>
    public partial class UpravnikPocetna : Window
    {
        public static List<ZahtevUpravniku> ZahteviZaSlobodneDane { get; set; }

        public UpravnikPocetna()
        {
            InitializeComponent();
            var sviZahtevi = ZahtevServis.zahtevi;

            ZahteviZaSlobodneDane = new List<ZahtevUpravniku>();
            foreach (var zahtev in sviZahtevi)
            {
                ZahteviZaSlobodneDane.Add(zahtev);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PriakzSala prikaz = new PriakzSala();
            prikaz.Show();
        }

        private void btnIzvrsiZahteve_Odmah(object sender, RoutedEventArgs e)
        {
           // RukovanjeZahtevZaRasporedjivanjeStatickeOpremeServis.IzvrsiZahteveZaDanas();
           // RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.IzvrsiZahteveZaDanas();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrikazStatickeOpreme prikaz = new PrikazStatickeOpreme();
            prikaz.Show();
        }

        private void btnPrikaziDinamicke_Click(object sender, RoutedEventArgs e)
        {
            RasporedjivanjeDinamickeOpreme rasporedjivanje = new RasporedjivanjeDinamickeOpreme();
            rasporedjivanje.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            RasporedjivanjeStatickeOpreme rasporedjivanje = new RasporedjivanjeStatickeOpreme();
            rasporedjivanje.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PrikazDinamickeOpreme prikazDinamickeOpreme = new PrikazDinamickeOpreme();
            prikazDinamickeOpreme.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void btnPrikaziLekove_Click(object sender, RoutedEventArgs e)
        {
            PrikazLekova prikazLekova = new PrikazLekova();
            prikazLekova.Show();
        }

        private void btnPretragaOpreme_Click(object sender, RoutedEventArgs e)
        { 
        
            PretragaOpreme pretragaOpreme = new PretragaOpreme();
            pretragaOpreme.Show();
        }
    }
}
