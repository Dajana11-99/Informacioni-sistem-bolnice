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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for Terapija.xaml
    /// </summary>
    public partial class Terapija : UserControl
    {
        public static ObservableCollection<Recept> ReceptiPropisani { get; set; }
        public Terapija()
        {
            InitializeComponent();
            this.DataContext = this;
            
            ReceptiPropisani = new ObservableCollection<Recept>();
            
            foreach (Recept r in PacijentGlavniProzor.ulogovan.karton.recepti)
            {
                
                ReceptiPropisani.Add(r);
            }
            

        }
    }
}
