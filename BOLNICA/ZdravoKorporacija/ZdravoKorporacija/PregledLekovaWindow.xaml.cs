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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for PregledLekovaWindow.xaml
    /// </summary>
    public partial class PregledLekovaWindow : Window
    {
        public static ObservableCollection<Lek> lekovi { get; set; }
        public PregledLekovaWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            lekovi = new ObservableCollection<Lek>(LekKontroler.PrikaziSveLekove());
        }
        private void BtnPregledInfo_Click(object sender, RoutedEventArgs e)
        {
            if (dgPregledLekova.SelectedIndex == -1)
            {
                System.Windows.MessageBox.Show("Morate selektovati lek!", "Informacije o leku", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Warning);
                return;
            }

            Lek lek = ((Lek)(dgPregledLekova.SelectedItem));
            InformacijeLekaWindow informacijeLeka = new InformacijeLekaWindow(lek.IdLeka);
            informacijeLeka.ShowDialog();
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            dgPregledLekova.ItemsSource = null;
            dgPregledLekova.ItemsSource = new ObservableCollection<Lek>(LekKontroler.PrikaziSveLekove());
        }
        private void BtnVratiSe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
