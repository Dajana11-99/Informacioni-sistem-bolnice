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
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for OceniBolnicu.xaml
    /// </summary>
    public partial class OceniBolnicu : Window
    {
       
        public OceniBolnicu()
        {
            InitializeComponent();
           
          
        }

        private void VratiSe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PosaljiAnketu_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < AnketaServis.pitanja.Count; i++)
            {
                if (!AnketaServis.pitanja[i].pitanjeOBolnici)
                {
                    int indexCombo = i + 1;
                    postaviOcenuZaPitanje(((ComboBox)grid.FindName("pitanje" + indexCombo)).SelectedIndex, i);
                }
            }
            AnketaServis.DodajAnketu(new Ankete(dodatniKomentar.Text, AnketaServis.pitanja, null, PacijentGlavniProzor.ulogovan,DateTime.Now.Date));
            AnketeRepozitorijum.upisiAnkete();
            this.Close();
        }

        private void postaviOcenuZaPitanje(int indexCombo, int indexPitanje)
        {
            switch (((ComboBox)grid.FindName("pitanje" + indexCombo)).SelectedIndex)
            {

                case 0:
                    AnketaServis.pitanja[indexPitanje].Ocena = OcenaAnkete.jedan;
                    break;
                case 1:
                    AnketaServis.pitanja[indexPitanje].Ocena = OcenaAnkete.dva;
                    break;
                case 2:
                    AnketaServis.pitanja[indexPitanje].Ocena = OcenaAnkete.tri;
                    break;
                case 3:
                    AnketaServis.pitanja[indexPitanje].Ocena = OcenaAnkete.cetiri;
                    break;
                case 4:
                    AnketaServis.pitanja[indexPitanje].Ocena = OcenaAnkete.pet;
                    break;
            }

        }
    }
}
