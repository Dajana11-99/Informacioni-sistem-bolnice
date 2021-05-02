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

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for IzmenaTerminaLekara.xaml
    /// </summary>
    public partial class IzmenaTerminaLekara : Window
    {

        public List<Lekar> Lekari { get; set; }
        public String id = null;
        public IzmenaTerminaLekara(Termin t)
        {
            InitializeComponent();
            bindcombo();
            id = t.IdTermina;

            cmbLekar.SelectedIndex = konstruisi_combo(t.Lekar.CeloIme);
            datePickerZakazivanjeTermina.SelectedDate = t.Datum;
            cmbZakazivanjeTerminaVreme.Text = t.Vreme;
            cmbPacijent.Text = t.Pacijent.IdPacijenta;
            txtPredvidjenoVremeTermina.Text = t.TrajanjeTermina.ToString();
           // cmbHMin.Text = 
            brojSale.Text= t.Sala.Id;
            
            cmbVrstaTermina.Text = t.TipTermina.ToString();
            



        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPotvrdiZakazivanjeTermina_Click(object sender, RoutedEventArgs e)
        {
           


            TerminServis.IzmenaTermina(id, (DateTime)this.datePickerZakazivanjeTermina.SelectedDate,cmbZakazivanjeTerminaVreme.Text,cmbLekar.Text,txtPredvidjenoVremeTermina.Text, brojSale.Text, cmbVrstaTermina.Text);
            this.Close();
        }

        public int konstruisi_combo(String id)
        {
            for (int i = 0; i < Lekari.Count; i++)
            {
                if (Lekari[i].CeloIme.Equals(id))
                    return i;
            }
            return 0;

        }
        public void bindcombo()
        {
            List<Lekar> pomocna = new List<Lekar>();

            foreach (Lekar l in TerminServis.sviLekari)
            {
                if (!l.Specijalizacija.Equals(Specijalizacija.Ostapraksa))
                {
                    pomocna.Add(l);
                }
            }
            Lekari = pomocna;
            DataContext = Lekari;
        }
    }
}
