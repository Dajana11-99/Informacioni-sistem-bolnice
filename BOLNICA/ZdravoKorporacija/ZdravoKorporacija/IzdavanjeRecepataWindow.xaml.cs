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
using ZdravoKorporacija.Model;
using ZdravoKorporacija.PacijentPrikaz;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for IzdavanjeRecepataWindow.xaml
    /// </summary>
    public partial class IzdavanjeRecepataWindow : Window
    {
        public Recept recept { get; set; }
        public IzdavanjeRecepataWindow()
        {
            InitializeComponent();
        }

        private void BtnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            recept = new Recept(txtKolicinaLeka.Text, (DateTime)this.datePickerPocetak.SelectedDate, 
                (DateTime)this.datePickerKraj.SelectedDate, double.Parse(txtPeriodUzimanja.Text),
                new Lek(idLeka.Text,txtNazivLeka.Text), ZdravstevniKartonPacijenta.pacijent.IdPacijenta);
            this.Close();
        }

        private void BtnOdustani_Click(object sender, RoutedEventArgs e)
        {
            recept = null;
            this.Close();
        }
    }
}
