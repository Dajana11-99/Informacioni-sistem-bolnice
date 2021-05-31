using Kontroler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.PacijentPrikaz
{
    public partial class RasporedTermina : UserControl
    {
        private RasporedTerminaViewModel rasporedTerminaViewModel;
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        public RasporedTermina(String pacijent)
        {

            String idPacijenta = naloziPacijenataKontroler.PretraziPoKorisnickom(pacijent).IdPacijenta;
            rasporedTerminaViewModel = new RasporedTerminaViewModel(idPacijenta);
            InitializeComponent();
            this.DataContext = rasporedTerminaViewModel;
        }
    }
}

