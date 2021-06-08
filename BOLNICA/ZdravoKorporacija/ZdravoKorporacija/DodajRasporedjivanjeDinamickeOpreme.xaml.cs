﻿using Model;

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
using PoslovnaLogika;
using ZdravoKorporacija.GrafZavisnosti;
using ZdravoKorporacija.ServisInterfejs;

namespace ZdravoKorporacija
{
    public partial class DodajRasporedjivanjeDinamickeOpreme : Window
    {
        RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs rukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis;

        public DodajRasporedjivanjeDinamickeOpreme()
        {
            InitializeComponent();
            cmbDinamicka.ItemsSource = RukovanjeDinamickomOpremomServis.dinamickaOprema;
            cmbProstorija.ItemsSource = SalaServis.sala;
            rukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis = Injektor.Instance.Get<RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs>(typeof(RukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServisInterfejs));
        }
        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            ZahtevZaRasporedjivanjeDinamickeOpreme zahtev = new ZahtevZaRasporedjivanjeDinamickeOpreme();
            zahtev.Id = rukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.pronadji();
            int kolicina = 0;
            try
            {
                kolicina = Int32.Parse(txtKolicina.Text);
            }
            catch
            {
                MessageBox.Show("Uneta kolciina mora biti >= 1");
                return;
            }
            if (kolicina <= 0)
            {
                MessageBox.Show("Uneta kolciina mora biti >= 1");
                return;
            }
            zahtev.Kolicina = kolicina;
            zahtev.ProstorijaId = (string)cmbProstorija.SelectedValue;
            zahtev.DinamickaOpremaId = (string)cmbDinamicka.SelectedValue;
            rukovanjeZahtevZaRasporedjivanjeDinamickeOpremeServis.DodajDinamickuOpremuProstorija(zahtev);
            Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
