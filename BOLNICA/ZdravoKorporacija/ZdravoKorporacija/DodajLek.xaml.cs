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

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for DodajLek.xaml
    /// </summary>
    public partial class DodajLek : Window
    {
        public static List<CheckBoxListItem> SastojciCheckboxItems { get; set; }
        public static List<CheckBoxListItem> LekoviZamenaCheckboxItems { get; set; }
        // https://stackoverflow.com/questions/4527286/how-to-implement-a-listbox-of-checkboxes-in-wpf
        public static List<String> ListaImenaSastojaka { get; set; }
        public static List<Lek> ListaLekova { get; set; }
        public DodajLek()
        {
            InitializeComponent();
            DataContext = this;
            SastojciCheckboxItems = new List<CheckBoxListItem>();
            LekoviZamenaCheckboxItems = new List<CheckBoxListItem>();
            ListaSastojakaChechBoxItems();
            ListaLekovaChechBoxItems();
            cboxlistSastojci.CheckBoxItems = SastojciCheckboxItems;
            cboxlistLekovi.CheckBoxItems = LekoviZamenaCheckboxItems;
        }
        private static void ListaLekovaChechBoxItems()
        {
            foreach (Lek lek in LekServis.PrikaziLekove())
            {
                CheckBoxListItem item = new CheckBoxListItem();
                item.Data = lek;
                item.Name = lek.ImeLeka;
                LekoviZamenaCheckboxItems.Add(item);
            }
        }
        private static void ListaSastojakaChechBoxItems()
        {
            foreach (Sastojak sastojak in LekServis.listaSvihSastojaka)
            {
                CheckBoxListItem item = new CheckBoxListItem();
                item.Data = sastojak;
                item.Name = sastojak.Ime;
                SastojciCheckboxItems.Add(item);
            }
        }
        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            if (LekPostoji(txtId.Text))
                return;
            Lek lek = new Lek(txtId.Text, txtImeLeka.Text);
            ListaSastojaka(lek);
            NovaListaLekova(lek);
            LekServis.DodajLek(lek);
            LekRepozitorijum.UpisiLekove();
            Close();
        }
        private static void NovaListaLekova(Lek lek)
        {
            List<Lek> lekovi = new List<Lek>();
            foreach (var item in LekoviZamenaCheckboxItems)
            {
                if (item.IsChecked)
                    lekovi.Add(item.Data as Lek);
            }
            lek.ListaZamenaZaLek = lekovi;
        }
        public static void ListaSastojaka(Lek lek)
        {
            List<Sastojak> sastojci = new List<Sastojak>();
            foreach (var item in SastojciCheckboxItems)
            {
                if (item.IsChecked)
                    sastojci.Add(item.Data as Sastojak);
            }
            lek.ListaSastojaka = sastojci;
        }
        public static bool LekPostoji(string id)
        {
            Lek postojeciLek = LekServis.PretraziPoId(id);
            if (postojeciLek != null)
            {
                MessageBox.Show($"Postoji vec lek sa ID-em:{id}");
                return true;
            }
            return false;
        }
        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
