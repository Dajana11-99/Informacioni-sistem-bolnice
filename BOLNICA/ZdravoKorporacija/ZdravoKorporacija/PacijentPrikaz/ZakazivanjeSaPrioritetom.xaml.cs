using Kontroler;
using Model;
using Servis;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdravoKorporacija.Kontroler;
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.PacijentPrikaz
{
    public partial class ZakazivanjeSaPrioritetom : UserControl
    {
        private ZakazivanjeSaPrioritetomViewModel zakazivanje;
        public ZakazivanjeSaPrioritetom(String pacijent)
        {
            zakazivanje = new ZakazivanjeSaPrioritetomViewModel(pacijent);
            InitializeComponent();
            this.DataContext = zakazivanje;
        }
        
    }
}
