using Kontroler;
using Model;
using Servis;
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
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for ZakazivanjeVremena.xaml
    /// </summary>
    /// 
    public partial class ZakazivanjeVremena : Window
    {
        public static ObservableCollection<Termin> VremenaTermina { get; set; }
        TerminKontroler terminKontroler = new TerminKontroler();
        public ZakazivanjeVremena(Termin izabraniTermin)
        {
            InitializeComponent();
            VremenaTermina = new ObservableCollection<Termin>();
            foreach (Termin t in terminKontroler.NadjiVremeTermina(izabraniTermin))
            {
               
                    VremenaTermina.Add(t);
            }
            slobodnaVremenaLista.ItemsSource = VremenaTermina;
        }

        private void vratiSe_Click(object sender, RoutedEventArgs e)
        {
            DatumiKodIzabranogLekara da = new DatumiKodIzabranogLekara();
            da.Show();
            this.Close();
        }

        private void nastavi_Click(object sender, RoutedEventArgs e)
        {
            PotvrdiZakazivanje potvrdi = new PotvrdiZakazivanje((Termin)slobodnaVremenaLista.SelectedItem);
            potvrdi.Show();
            this.Close();
        }
    }
}
