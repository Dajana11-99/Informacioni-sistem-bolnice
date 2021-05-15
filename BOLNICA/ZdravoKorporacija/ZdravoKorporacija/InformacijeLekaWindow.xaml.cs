using Model;
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
using ZdravoKorporacija.Servis;
using Kontroler;
using ZdravoKorporacija.Kontroler;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for InformacijeLekaWindow.xaml
    /// </summary>
    public partial class InformacijeLekaWindow : Window
    {

        public Lek lek = null;
        public InformacijeLekaWindow(string idLeka)
        {
            InitializeComponent();
            lek = Kontroler.LekKontroler.PretraziLekove(idLeka);
            PopuniInfomacijeOLeku();
        }

        public void PopuniInfomacijeOLeku()
        {
            txtIdLeka.Text = lek.IdLeka;
            txtNazivLeka.Text = lek.ImeLeka;
            txtKolicinaLeka.Text = lek.KolicinaLeka;
            txtSastojci.Text = lek.SastojciLeka;
        }

        private void BtnPosaljiZalbu_Click(object sender, RoutedEventArgs e)
        {
            ZalbaWindow zalba = new ZalbaWindow(lek.IdLeka);
            zalba.ShowDialog();

        }

        private void BtnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            Lek izmenjenLek = new Lek(lek.IdLeka, txtNazivLeka.Text, txtKolicinaLeka.Text, txtSastojci.Text);
            LekKontroler.IzmeniLek(izmenjenLek);
            this.Close();
        }

        private void BtnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
