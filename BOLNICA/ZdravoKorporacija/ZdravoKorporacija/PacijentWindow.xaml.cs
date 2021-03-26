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
using Model;
using PoslovnaLogika;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for PacijentWindow.xaml
    /// </summary>
    public partial class PacijentWindow : Window
    {
        public ObservableCollection<Termin> Termini
        {
            get;
            set;
        }
          public List<Termin> sviT = new List<Termin>();

        public PacijentWindow()
        {
          
           
            InitializeComponent();
            this.DataContext = this;
            Termini = new ObservableCollection<Termin>();
            ZakaziPregled zakazz = new ZakaziPregled();

          
            sviT.Add(new Termin() {idTrmina="A5G7" ,tipTermina=TipTermina.Pregled, vreme=new DateTime(2021,03,26 ,12,30,00)});
            sviT.Add(item: new Termin() { idTrmina = "A5G8", tipTermina = TipTermina.Pregled, vreme = zakazz.Datum.CustomFormat });
           
     
            dgSimple.ItemsSource = sviT;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ZakaziPregled zakazi = new ZakaziPregled();
            zakazi.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}