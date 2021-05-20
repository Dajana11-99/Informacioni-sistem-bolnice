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
    /// <summary>
    /// Interaction logic for OceniBolnicu.xaml
    /// </summary>
    public partial class OceniBolnicu : Window
    {
       
        PitanjeKontroler pitanjeKontroler = new PitanjeKontroler();
        AnketeRepozitorijum anketeRepozitorijum = new AnketeRepozitorijum();
     
        public OceniBolnicu()
        {
            InitializeComponent();
        }

        private void VratiSe_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PosaljiAnketu_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < pitanjeKontroler.DobaviSvaPitanjaOBolnici().Count; i++)
            {
                
                    int indexCombo = i + 1;
                    postaviOcenuZaPitanje(((ComboBox)this.FindName("pitanje" + indexCombo)).SelectedIndex, i);
                
            }
            anketeRepozitorijum.DodajAnketu(new Ankete(dodatniKomentar.Text, pitanjeKontroler.DobaviSvaPitanjaOBolnici(), null, PacijentGlavniProzor.ulogovan,DateTime.Now.Date));
         
            this.Close();
        }
      
        private void postaviOcenuZaPitanje(int indexCombo, int indexPitanje)
        {
            switch(indexCombo)
            {

                case 0:
                    pitanjeKontroler.DobaviSvaPitanjaOBolnici()[indexPitanje].Ocena = OcenaAnkete.jedan;
                    break;
                case 1:
                    pitanjeKontroler.DobaviSvaPitanjaOBolnici()[indexPitanje].Ocena = OcenaAnkete.dva;
                    break;
                case 2:
                    pitanjeKontroler.DobaviSvaPitanjaOBolnici()[indexPitanje].Ocena = OcenaAnkete.tri;
                    break;
                case 3:
                    pitanjeKontroler.DobaviSvaPitanjaOBolnici()[indexPitanje].Ocena = OcenaAnkete.cetiri;
                    break;
                case 4:
                    pitanjeKontroler.DobaviSvaPitanjaOBolnici()[indexPitanje].Ocena = OcenaAnkete.pet;
                    break;
            }

        }
    }
}
