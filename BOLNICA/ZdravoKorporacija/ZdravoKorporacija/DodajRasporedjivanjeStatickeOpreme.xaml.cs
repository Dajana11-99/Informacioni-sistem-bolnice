﻿using Model;
using PoslovnaLogika;
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

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for DodajRasporedjivanjeStatickeOpreme.xaml
    /// </summary>
    public partial class DodajRasporedjivanjeStatickeOpreme : Window
    {
        public List<StatickaOprema> StatickaOprema;
        public List<Sala> Prostorija;


        public DodajRasporedjivanjeStatickeOpreme()
        {
            InitializeComponent();
            cmbStatickaOprema.ItemsSource = RukovanjeStatickomOpremom.statickaOprema;
            cmbProstorija.ItemsSource = RukovanjeSalama.sala;
            cmbProstorijaIz.ItemsSource = RukovanjeSalama.sala;
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            DateTime? rasporedjenoOd = datePickerRasporedjenoOd.SelectedDate;
            if (!rasporedjenoOd.HasValue)
            {
                MessageBox.Show("Datum od nije unet");
                return;
            }


                ZahtevZaRasporedjivanjeStatickeOpreme zahtev = new ZahtevZaRasporedjivanjeStatickeOpreme();
            zahtev.Id = RukovanjeZahtevZaRasporedjivanjeStatickeOpreme.pronadji();
            int kolicina = 0;
            try
            {
                kolicina = Int32.Parse(txtKolicina.Text);
            } catch
            {
                MessageBox.Show("Uneta kolciina mora biti >= 1");
                return;
            }
            if (kolicina <=0 )
            {
                MessageBox.Show("Uneta kolciina mora biti >= 1");
                return;
            }
            zahtev.Kolicina = kolicina; 
            zahtev.RasporedjenoOd = rasporedjenoOd.Value;
            zahtev.ProstorijaId = (string)cmbProstorija.SelectedValue;
            zahtev.IzProstorijaId = (string)cmbProstorijaIz.SelectedValue;
            zahtev.StatickeOpremaId = (string)cmbStatickaOprema.SelectedValue;
            RukovanjeZahtevZaRasporedjivanjeStatickeOpreme.DodajStatickuOpremuProstorija(zahtev);
            Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
