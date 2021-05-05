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


namespace ZdravoKorporacija
{
    [ValueConversion(typeof(List<Sastojak>), typeof(string))]
    public class ListSastojakaToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(string))
                throw new InvalidOperationException("The target must be a String");
            List<string> asString = new List<string>();
            var sastojci = (List<Sastojak>)value;
            foreach(Sastojak sastojak in sastojci)
            {
                asString.Add(sastojak.Ime);
            }
            return String.Join(", ", asString.ToArray());
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public partial class PrikazLekova : Window
    {
        public static ObservableCollection<Lek> ListLekova { get; set; }
        public PrikazLekova()
        {
            InitializeComponent();
            DataContext = this;
            ListLekova = LekServis.observableLek;
        }
        private void btnVratiSe_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void btnDodajLek_Click(object sender, RoutedEventArgs e)
        {
            DodajLek dodajLek = new DodajLek();
            dodajLek.Show();
        }
        private void btnIzmeniLek_Click(object sender, RoutedEventArgs e)
        {
            if (SpisakLekova.SelectedIndex != -1)
            {
                IzmeniLek izmeniLek = new IzmeniLek((Lek)SpisakLekova.SelectedItem);
                izmeniLek.Show();
            }
            
        }
        private void btnIzbrisiLek_Click(object sender, RoutedEventArgs e)
        {
            if (SpisakLekova.SelectedIndex != -1)
            {
                BrisanjeLeka brisanjeLeka = new BrisanjeLeka(((Lek)SpisakLekova.SelectedItem).IdLeka);
                brisanjeLeka.Show();
            } 
        }
    }
}
