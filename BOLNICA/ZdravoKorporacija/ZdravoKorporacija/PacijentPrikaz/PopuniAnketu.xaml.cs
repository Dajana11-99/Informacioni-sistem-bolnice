using Model;
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
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.PacijentPrikaz
{
    public partial class PopuniAnketu : Window
    {
       
        public static Termin izabraniZaAnketu;
        public PopuniAnketu(Termin izabraniTermin)
        {
            InitializeComponent();
            izabraniZaAnketu = izabraniTermin;
        }

        private void VratiSe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PosaljiAnketu_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < AnketaServis.pitanjaOPregledu.Count; i++)
            {
                    int indexCombo = i + 1;
                    postaviOcenuZaPitanje(((ComboBox)grid.FindName("pitanje" + indexCombo)).SelectedIndex, i);
            }
            izabraniZaAnketu.OcenjenTermin = true;

            AnketeKontroler.DodajAnketu(new Ankete(dodatniKomentar.Text, AnketaServis.pitanjaOPregledu, izabraniZaAnketu, PacijentGlavniProzor.ulogovan)); 

            OsveziPrikazAnketa();
            this.Close();
        }

        private static void OsveziPrikazAnketa()
        { 
            AnketeRepozitorijum.UpisiAnkete();

            PrikazAnketa.Ankete.Remove(izabraniZaAnketu);

        }


        private void postaviOcenuZaPitanje(int indexCombo,int indexPitanje)
        {
            switch (indexCombo)
            {

                case 0:
                    AnketaServis.pitanjaOPregledu[indexPitanje].Ocena = OcenaAnkete.jedan;
                    break;
                case 1:
                    AnketaServis.pitanjaOPregledu[indexPitanje].Ocena = OcenaAnkete.dva;
                    break;
                case 2:
                    AnketaServis.pitanjaOPregledu[indexPitanje].Ocena = OcenaAnkete.tri;
                    break;
                case 3:
                    AnketaServis.pitanjaOPregledu[indexPitanje].Ocena = OcenaAnkete.cetiri;
                    break;
                case 4:
                    AnketaServis.pitanjaOPregledu[indexPitanje].Ocena = OcenaAnkete.pet;
                    break;
            }

        }
    }
}
