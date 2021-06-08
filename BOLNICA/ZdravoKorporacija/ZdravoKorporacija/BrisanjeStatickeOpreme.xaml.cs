
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
using System.Windows.Shapes;
using ZdravoKorporacija.GrafZavisnosti;
using ZdravoKorporacija.ServisInterfejs;

namespace ZdravoKorporacija
{
    public partial class BrisanjeStatickeOpreme : Window
    {
        string statickaOpremaId;
        RukovanjeStatickomOpremomServisInterfejs rukovanjeStatickomOpremomServis;
        public BrisanjeStatickeOpreme(string idStatickeOpreme)
        {
            InitializeComponent();
            statickaOpremaId = idStatickeOpreme;
            rukovanjeStatickomOpremomServis = Injektor.Instance.Get<RukovanjeStatickomOpremomServisInterfejs>(typeof(RukovanjeStatickomOpremomServisInterfejs));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            rukovanjeStatickomOpremomServis.ObrisiStatickuOpremu(statickaOpremaId);
            this.Close();
        }
    }
}

