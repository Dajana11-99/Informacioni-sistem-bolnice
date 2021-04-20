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
using System.Windows.Shapes;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for PacijentNoviNalog.xaml
    /// </summary>
    public partial class PacijentNoviNalog : Window
    {
        private static long IDPacijenta = 1;
        public PacijentNoviNalog()
        {
            InitializeComponent();
        }

        private void PotvrdaAction(object sender, RoutedEventArgs e)
        {
            AdresaStanovanja adresa = new AdresaStanovanja(AdresaTEXTBOX.Text, null);
            Pacijent novi = new Pacijent(IDPacijenta.ToString(), ImeTEXTBOX.Text, PrezimeTEXTBOX.Text, JmbgTEXTBOX.Text, EmailTEXTBOX.Text, adresa);
            IDPacijenta++;
            PrikazPacijenata.UbaciUListu(novi);
            NaloziPacijenataServis.NapraviNoviNalogPacijentu(novi);

        }

        private void OdustaniAction(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
