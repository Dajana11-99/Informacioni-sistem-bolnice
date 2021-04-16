﻿using System;
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

using System.Collections.ObjectModel;
using PoslovnaLogika;
using Model;
using System.ComponentModel;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for PrikazPacijenata.xaml
    /// </summary>
    public partial class PrikazPacijenata : Window
    {
        public static ObservableCollection<Pacijent> ListaPacijenataXMAL { get; set; }


        public PrikazPacijenata()
        {
            InitializeComponent();
            ListaPacijenataXMAL = new ObservableCollection<Pacijent>(UpravljanjePacijentima.ListaPacijenata);
            //this.DataContext = this;
            //ListaPacijenataXMAL = (ObservableCollection)UpravljanjePacijentima.ListaPacijenata;
            /* foreach(Pacijent P in UpravljanjePacijentima.ListaPacijenata)
             {
                 ListaPacijenataXMAL.Add(P);
             }*/
            PacijenitXName.ItemsSource = ListaPacijenataXMAL;
            this.DataContext = this;
            //ItemsSource="{Binding ListaPacijenataXMAL}"
        }
        public void refresuje()
        {
            PacijenitXName.ItemsSource = ListaPacijenataXMAL;

        }
        public static void UbaciUListu(Model.Pacijent Pako)
        {
            ListaPacijenataXMAL.Add(Pako);
        }

        private void KreirajNalogAction(object sender, RoutedEventArgs e)
        {
            PacijentNoviNalog Pacijentnovi = new PacijentNoviNalog();
            Pacijentnovi.Show();
        }
        public static Pacijent PretragaPoId(string Id)
        {
            foreach (Pacijent P in ListaPacijenataXMAL)
            {
                if (P.idPacijenta.Equals(Id))
                {
                    return P;
                }
            }
            return null;
        }

        private void IzmenaNalogaAction(object sender, RoutedEventArgs e)
        {
            if (PacijenitXName.SelectedIndex != -1)
            {
                IzmenaNalogaPacijentu izmenaPac = new IzmenaNalogaPacijentu(((Pacijent)PacijenitXName.SelectedItem));

                izmenaPac.Show();



            }
            else
                System.Windows.MessageBox.Show("Izaberite termin pregleda za izmenu!", "Upozorenje", MessageBoxButton.OK);

            return;
        }

        private void BrisanjeNalogaAction(object sender, RoutedEventArgs e)
        {
            if (PacijenitXName.SelectedIndex != -1)
            {
                IzbrisiPacijenta brisanje = new IzbrisiPacijenta(((Pacijent)PacijenitXName.SelectedItem));

                brisanje.Show();

            }
            else
                System.Windows.MessageBox.Show("Izaberite termin pregleda za izmenu!", "Upozorenje", MessageBoxButton.OK);
            return;
        }

        private void VratiSeAction(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}