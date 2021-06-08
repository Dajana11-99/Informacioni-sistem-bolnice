
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
    public partial class BrisanjeDinamickeOpreme : Window
    {
        string dinamickaOpremaId;
        RukovanjeDinamickomOpremomServisInterfejs rukovanjeDinamickomOpremomServis;
        public BrisanjeDinamickeOpreme(string id)
        {
            InitializeComponent();
            dinamickaOpremaId = id;
            rukovanjeDinamickomOpremomServis = Injektor.Instance.Get<RukovanjeDinamickomOpremomServisInterfejs>(typeof(RukovanjeDinamickomOpremomServisInterfejs));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            rukovanjeDinamickomOpremomServis.ObrisiDinamickuOpremu(dinamickaOpremaId);
            this.Close();
        }
    }
}

