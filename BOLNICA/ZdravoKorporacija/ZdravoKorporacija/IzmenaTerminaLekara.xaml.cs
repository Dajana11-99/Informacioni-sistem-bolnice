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
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija
{
    public partial class IzmenaTerminaLekara : Window
    {
        public List<Lekar> Lekari { get; set; }
        public String idTermina = null;
        public LekarRepozitorijum lekarRepozitorijum = new LekarRepozitorijum();
        public LekarKontroler lekarKontroler = new LekarKontroler();
        public TerminKontroler terminKontroler = new TerminKontroler();
        public IzmenaTerminaLekara(Termin termin)
        {
            InitializeComponent();
           
            idTermina = termin.IdTermina;
            Lekari = lekarKontroler.PretraziPoSpecijalizaciji();
            DataContext = Lekari;
            PopuniTermin(termin);
        }
        private void PopuniTermin(Termin termin)
        {
            cmbLekar.SelectedIndex = Konstruisi_comboBox(termin.Lekar.CeloIme);
            datePickerZakazivanjeTermina.SelectedDate = termin.Datum;
            cmbZakazivanjeTerminaVreme.Text = termin.Vreme;
            cmbPacijent.Text = termin.Pacijent.IdPacijenta;
            txtPredvidjenoVremeTermina.Text = termin.TrajanjeTermina.ToString();
            brojSale.Text = termin.Sala.Id;
            cmbVrstaTermina.Text = termin.TipTermina.ToString();
        }

        private void BtnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnPotvrdiZakazivanjeTermina_Click(object sender, RoutedEventArgs e)
        {
            terminKontroler.IzmenaTermina(KreirajTerminZaIzmenu());
            this.Close();
        }

        public TerminDTO KreirajTerminZaIzmenu()
        {
            Lekar lekar = lekarRepozitorijum.PretraziPoImenuIPrezimenu(cmbLekar.Text);
            TerminDTO termin = new TerminDTO(idTermina, (DateTime)datePickerZakazivanjeTermina.SelectedDate,
              cmbZakazivanjeTerminaVreme.Text, lekar, txtPredvidjenoVremeTermina.Text, brojSale.Text, cmbVrstaTermina.Text);
            return termin;
        }

        public int Konstruisi_comboBox(String imeIPrezimeLekara)
        {
            for (int i = 0; i < Lekari.Count; i++)
            {
                if (Lekari[i].CeloIme.Equals(imeIPrezimeLekara))
                    return i;
            }
            return 0;
        }
    }
}
