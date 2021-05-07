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
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.PacijentPrikaz
{
  
    public partial class PrikazObavestenja : Window
    {
        public static ObservableCollection<Obavestenja> obavestenjaPacijenta { get; set; }
        public PrikazObavestenja()
        {
            InitializeComponent();
            obavestenjaPacijenta = new ObservableCollection<Obavestenja>();
            List<Obavestenja> datumi = ObavestenjaKontroler.svaObavestenja().OrderByDescending(user => user.Datum).ToList();
            PodesavanjePrikaza(datumi);
            obavestenjaPacijentaLista.ItemsSource = obavestenjaPacijenta;
        }

        private static void PodesavanjePrikaza(List<Obavestenja> datumi)
        {
            foreach (Obavestenja o in datumi)
            {
                if (o.IdPrimaoca.Equals(PacijentGlavniProzor.ulogovan.IdPacijenta))
                {
                    if (DateTime.Compare(o.Datum.Date, DateTime.Now.Date) <= 0)
                        obavestenjaPacijenta.Add(o);
                }
            }
        }

        private void VratiSe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
