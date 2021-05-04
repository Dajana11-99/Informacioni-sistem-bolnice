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
    
    public partial class IzmeniLek : Window
    {
        Lek lekZaIzmenu;
        public static List<CheckBoxListItem> SastojciCheckboxItems { get; set; }
        public static List<CheckBoxListItem> LekoviZamenaCheckboxItems { get; set; }
        public static List<String> ListaImenaSastojaka { get; set; }
        public static List<Lek> ListaLekova { get; set; }
        public IzmeniLek(Lek lek)
        {
            InitializeComponent();
            DataContext = this;
            lekZaIzmenu = lek;
            txtImeLeka.Text = "" + lek.ImeLeka;
            List<Sastojak> sastojci = new List<Sastojak>();
            SastojciCheckboxItems = new List<CheckBoxListItem>();
            LekoviZamenaCheckboxItems = new List<CheckBoxListItem>();
            ListaLekova = LekServis.PrikaziLekove();
            LekoviZamenaCheckboxItems = new List<CheckBoxListItem>();
            foreach (Sastojak sastojak in LekServis.listaSvihSastojaka)
            {
                CheckBoxListItem item = new CheckBoxListItem();
                item.Data = sastojak;
                item.Name = sastojak.Ime;
                var vecChekiran = lek.ListaSastojaka.SingleOrDefault(sastojakLeka => sastojakLeka.Id == sastojak.Id);
                item.IsChecked = vecChekiran != null;
                SastojciCheckboxItems.Add(item);
            }
            foreach (Lek sviLekovi in ListaLekova)
            {
                if (sviLekovi.IdLeka == lekZaIzmenu.IdLeka)
                {
                    continue;
                }
                CheckBoxListItem item = new CheckBoxListItem();
                item.Data = sviLekovi;
                item.Name = sviLekovi.ImeLeka;
                var vecChekiran = lek.ListaZamenaZaLek.SingleOrDefault(lekZaZamenu => lekZaZamenu.IdLeka == sviLekovi.IdLeka);
                item.IsChecked = vecChekiran != null;
                LekoviZamenaCheckboxItems.Add(item);
            }
            cboxlistSastojci.CheckBoxItems = SastojciCheckboxItems;
            cboxlistLekovi.CheckBoxItems = LekoviZamenaCheckboxItems;
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            String imeLeka = txtImeLeka.Text;
            Lek l = lekZaIzmenu;
            List<Sastojak> sastojci = new List<Sastojak>();
            foreach (var item in SastojciCheckboxItems)
            {
                if (item.IsChecked)
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
            l.ImeLeka = imeLeka;
            LekServis.Izmena(lekZaIzmenu);
            LekRepozitorijum.UpisiLekove();
            Close();
        }
        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
