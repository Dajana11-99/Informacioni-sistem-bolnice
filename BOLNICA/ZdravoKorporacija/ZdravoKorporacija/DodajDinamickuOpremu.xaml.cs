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

using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for DodajSalu.xaml
    /// </summary>
    public partial class DodajDinamickuOpremu : Window
    {
        public DodajDinamickuOpremu()
        {
            InitializeComponent();

        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {

            String id = txtId.Text;
            DinamickaOprema postojecaDinamickaOprema = RukovanjeDinamickomOpremomServis.PretraziPoId(id);
            if (postojecaDinamickaOprema != null)
            {
                MessageBox.Show($"Postoji vec oprema sa ID-em:{id}");
                return;
            }

            String naziv = txtNaziv.Text;

            int kolicina;

            try
            {
                kolicina = Int32.Parse(txtKolicina.Text);
            }
            catch
            {
                MessageBox.Show($"Kolicina mora biti coe broj!!");
                return;
            }



            DinamickaOprema so = new DinamickaOprema(id);
            so.naziv = naziv;
            so.kolicina = kolicina;
            RukovanjeDinamickomOpremomServis.DodajDinamickuOpremu(so);
            DinamickeOpremeRepozitorijum.UpisiDinamickuOpremu();
            Close();


        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
