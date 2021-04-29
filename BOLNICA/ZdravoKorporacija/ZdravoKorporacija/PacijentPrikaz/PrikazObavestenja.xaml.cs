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
    /// <summary>
    /// Interaction logic for PrikazObavestenja.xaml
    /// </summary>
    public partial class PrikazObavestenja : Window
    {
        public static ObservableCollection<Obavestenja> obavestenjaPacijenta { get; set; }
        public PrikazObavestenja()
        {
            InitializeComponent();
            obavestenjaPacijenta = new ObservableCollection<Obavestenja>();

            List<Obavestenja> datumi = ObavestenjaKontroler.svaObavestenja().OrderByDescending(user => user.Datum).ToList();

            foreach (Obavestenja o in datumi)
            {
                if (o.IdPrimaoca.Equals(PacijentGlavniProzor.ulogovan.idPacijenta))
                {



                    if (DateTime.Compare(o.Datum.Date, DateTime.Now.Date) <= 0)
                    {
                        obavestenjaPacijenta.Add(o);
                    }

                }
              

            }

            obavestenjaPacijentaLista.ItemsSource = obavestenjaPacijenta;
        }
    }
}
