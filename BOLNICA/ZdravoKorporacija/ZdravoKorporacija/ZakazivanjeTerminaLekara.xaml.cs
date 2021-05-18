﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using Model;
using Servis;
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for ZakazivanjeTerminaLekara.xaml
    /// </summary>
    public partial class ZakazivanjeTerminaLekara : Window
    {
        public List<Pacijent> Pacijenti { get; set; }
        public List<Lekar> Lekari { get; set; }
        public LekarKontroler lekarKontroler = new LekarKontroler();

        public ZakazivanjeTerminaLekara()
        {
            InitializeComponent();
            PreuzmiSvePacijente();
        }
        private void PreuzmiSvePacijente()
        {
            List<Pacijent> pacijenti = NaloziPacijenataServis.ListaPacijenata;
            foreach (Pacijent p in pacijenti)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Tag = p.IdPacijenta;
                cbi.Content = p.IdPacijenta;
                cmbPacijent.Items.Add(cbi);
            }
        }
        private void btnPotvrdiZakazivanjeTermina_Click(object sender, RoutedEventArgs e)
        {
            String id = Guid.NewGuid().ToString();
            string[] pom = cmbLekar.Text.Split(' ');
            Lekar l = lekarKontroler.PretragaPoLekaru(pom[0], pom[1]);
            Pacijent p = NaloziPacijenataServis.PretragaPoId(cmbPacijent.Text);
            String idSale = brojSale.Text;
            String vr = cmbZakazivanjeTerminaVreme.Text;
            TipTermina tipP;
            String tip = cmbVrstaTermina.Text;
            if (tip.Equals(TipTermina.Pregled))
            {
                tipP = TipTermina.Pregled;
            }
            else
            {
                tipP = TipTermina.Operacija;
            }

            Sala s = null;
            if (tipP.Equals(TipTermina.Pregled))
            {
                s = new Sala(TipSale.Pregled, brojSale.Text);
            }else
            {
                s = new Sala(TipSale.Operaciona, brojSale.Text);
            }

            String hmin = cmbHMin.Text;
            String vreme = txtPredvidjenoVremeTermina.Text;
            Double predvidjenoVreme = 0;
            if (hmin.Equals("h"))
            {
                predvidjenoVreme = double.Parse(vreme) * 60;

            }
            else
            {
                predvidjenoVreme = double.Parse(vreme);
            }
            bool hitno = (bool)checkBoxHitno.IsChecked;
            Termin t = new Termin(id, tipP, vr, predvidjenoVreme, (DateTime)datePickerZakazivanjeTermina.SelectedDate, s, p, l, hitno);

            bool uspesno = TerminServis.ZakaziTermin(t);
            if (!uspesno)
            {
                MessageBox.Show("Neuspesno zakzivanje, sala se tada renovira");
                return;
            }

            this.Close();
        }
        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
