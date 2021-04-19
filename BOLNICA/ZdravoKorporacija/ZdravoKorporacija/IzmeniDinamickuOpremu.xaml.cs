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
    /// Interaction logic for IzmeniSalu.xaml
    /// </summary>
    public partial class IzmeniDinamickuOpremu : Window
    {
        DinamickaOprema dinamickaOpremaZaIzmenu;
        public IzmeniDinamickuOpremu(DinamickaOprema dinamicka)
        {
            InitializeComponent();
            dinamickaOpremaZaIzmenu = dinamicka;
            txtNaziv.Text = "" + dinamicka.naziv;
            txtKolicina.Text = "" + dinamicka.kolicina;

        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {

            String naziv = txtNaziv.Text;

            int kolicina;

            try
            {
                kolicina = Int32.Parse(txtKolicina.Text);
            }
            catch
            {
                MessageBox.Show($"Kolicina mora biti ceo broj!!");
                return;
            }

            dinamickaOpremaZaIzmenu.naziv = naziv;
            dinamickaOpremaZaIzmenu.kolicina = kolicina;

            RukovanjeDinamickomOpremom.IzmeniDinamickuOpremu(dinamickaOpremaZaIzmenu);
            Close();

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

