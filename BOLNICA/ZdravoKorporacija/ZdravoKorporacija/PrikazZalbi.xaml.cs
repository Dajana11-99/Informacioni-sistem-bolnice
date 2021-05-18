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
using Model;

using Servis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Servis;
using ZdravoKorporacija.Util;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for PrikazZalbi.xaml
    /// </summary>
    public partial class PrikazZalbi : Window
    {
        public static ObservableCollection<Zalba> zalbeObservable { get; set; }
        public static List<Zalba> zalbe = new List<Zalba>();
        private Lek lekZaIzmenu;
        private Lek lekPredKorekciju;
        private Zalba zalbaZaResavanje;
        public PrikazZalbi()
        {
            InitializeComponent();
            DataContext = this;
            zalbeObservable = ZalbaServis.zalbeObservable;
            zalbe = ZalbaServis.PrikaziSveZalbe();
        }

        private void BtnVratiSe_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void BtnIzmeniLek_Click(object sender, RoutedEventArgs e)
        {
            if (SpisakZalbi.SelectedIndex == -1)
                return;
            zalbaZaResavanje = (Zalba)SpisakZalbi.SelectedItem;
            lekZaIzmenu = LekServis.PretraziPoId(((Zalba)SpisakZalbi.SelectedItem).IdLeka);
            if (lekZaIzmenu is null)
            {
                MessageBox.Show($"Lek sa sifrom {lekZaIzmenu.IdLeka} nije vise dostupan");
                return;
            }
            PrikaziIzmenuZalbe();
        }

        private void PrikaziIzmenuZalbe()
        {
            lekPredKorekciju = CopyUtils.DeepCopy<Lek>(lekZaIzmenu);
            IzmeniLek izmeniLek = new IzmeniLek(lekZaIzmenu);
            izmeniLek.Show();
            izmeniLek.Closed += IzmeniLek_Closed;
        }

        private void IzmeniLek_Closed(object sender, EventArgs e)
        {
            if (!JeIzmenjeno())
                return;

            zalbaZaResavanje.resena = true;
            ZalbaServis.Izmena(zalbaZaResavanje);
        }

        private bool JeIzmenjeno()
        {
            lekZaIzmenu = LekServis.PretraziPoId(((Zalba)SpisakZalbi.SelectedItem).IdLeka);
            return ImeIzmenjeno(lekZaIzmenu, lekPredKorekciju) || KolicinaIzmenjena(lekZaIzmenu, lekPredKorekciju)
                || ListaSastojakaIzmenjena(lekZaIzmenu, lekPredKorekciju) || ListaZamenaIzmenjena(lekZaIzmenu, lekPredKorekciju);
        }

        private bool ImeIzmenjeno(Lek prviLek, Lek drugiLek)
        {
            if (prviLek.ImeLeka != null && !prviLek.ImeLeka.Equals(drugiLek.ImeLeka))
                return true;
            return false;
        }

        private bool KolicinaIzmenjena(Lek prviLek, Lek drugiLek)
        {
            if (prviLek.KolicinaLeka != null && !prviLek.KolicinaLeka.Equals(drugiLek.KolicinaLeka))
                return true;
            return false;
        }

        private bool ListaSastojakaIzmenjena(Lek prviLek, Lek drugiLek)
        {
            List<Sastojak> razlika = prviLek.ListaSastojaka.Except(drugiLek.ListaSastojaka).ToList();
            return razlika.Count > 0;
        }

        private bool ListaZamenaIzmenjena(Lek prviLek, Lek drugiLek)
        {
            List<Lek> razlika = prviLek.ListaZamenaZaLek.Except(drugiLek.ListaZamenaZaLek).ToList();
            return razlika.Count > 0;
        }



    }
}
