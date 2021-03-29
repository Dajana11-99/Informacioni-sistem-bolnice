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
using System.Windows.Shapes;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for PriakzSala.xaml
    /// </summary>
    public partial class PriakzSala : Window
    {

        public static ObservableCollection<Sala> ListSala { get; set; }
        public PriakzSala()
        {
            InitializeComponent();
            DataContext = this;

            ListSala = new ObservableCollection<Sala>();
            foreach (Sala sala in MainWindow.RukovanjeSalama.GetSala())
                ListSala.Add(sala);

        }
    }
}
