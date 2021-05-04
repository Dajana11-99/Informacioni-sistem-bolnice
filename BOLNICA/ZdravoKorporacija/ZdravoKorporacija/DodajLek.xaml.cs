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
            
            ListaLekova = LekServis.PrikaziLekove();
            SastojciCheckboxItems = new List<CheckBoxListItem>();
            LekoviZamenaCheckboxItems = new List<CheckBoxListItem>();
            foreach (Sastojak sastojak in LekServis.listaSvihSastojaka)
            {
                CheckBoxListItem item = new CheckBoxListItem();
                item.Data = sastojak;
                item.Name = sastojak.Ime;
                SastojciCheckboxItems.Add(item);
            }
            foreach(Lek lek in ListaLekova)
            {
                CheckBoxListItem item = new CheckBoxListItem();
                item.Data = lek;
                item.Name = lek.ImeLeka;
                LekoviZamenaCheckboxItems.Add(item);
            }
            cboxlistSastojci.CheckBoxItems = SastojciCheckboxItems;
            cboxlistLekovi.CheckBoxItems = LekoviZamenaCheckboxItems;

        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            String id = txtId.Text;
            Lek postojeciLek = LekServis.PretraziPoId(id);
            if (postojeciLek != null)
            {
                MessageBox.Show($"Postoji vec lek sa ID-em:{id}");
                return;
            }

            String imeLeka = txtImeLeka.Text;

            Lek l = new Lek(id, imeLeka);

            List<Sastojak> sastojci = new List<Sastojak>();
            foreach(var item in SastojciCheckboxItems)
            {
                if(item.IsChecked)
                {
                    sastojci.Add(item.Data as Sastojak);
                }
            }

            List<Lek> lekovi = new List<Lek>();
            foreach (var item in LekoviZamenaCheckboxItems)
            {
                if (item.IsChecked)
                {
                    lekovi.Add(item.Data as Lek);
                }
            }

            l.ListaSastojaka = sastojci;
            l.ListaZamenaZaLek = lekovi;
            LekServis.DodajLek(l);
            LekRepozitorijum.UpisiLekove();
            Close();
        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
