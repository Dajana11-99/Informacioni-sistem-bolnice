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
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for ZalbaWindow.xaml
    /// </summary>
    public partial class ZalbaWindow : Window
    {
        private String idLeka;
        public ZalbaWindow(String idLeka)
        {
            this.idLeka = idLeka;
            InitializeComponent();
            Lek lek = Kontroler.LekKontroler.PretraziLekove(idLeka);
            PrikaziInformacijeOLeku(lek);
        }

        private void PrikaziInformacijeOLeku(Lek lek)
        {
            lblNazivLeka.Content = lek.ImeLeka;
        }

        private void BtnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            Zalba zalba = new Zalba(idLeka, txtRazlogZalbe.Text);
            ZalbaKontroler.UpisiNovuZalbu(zalba);
            this.Close();
        }
    }
}
