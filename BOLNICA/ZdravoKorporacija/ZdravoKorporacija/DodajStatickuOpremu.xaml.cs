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
using ZdravoKorporacija.GrafZavisnosti;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.ServisInterfejs;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for DodajSalu.xaml
    /// </summary>
    public partial class DodajStatickuOpremu : Window
    {
        RukovanjeStatickomOpremomServisInterfejs rukovanjeStatickomOpremomServis;
        public DodajStatickuOpremu()
        {
            InitializeComponent();
            rukovanjeStatickomOpremomServis = Injektor.Instance.Get<RukovanjeStatickomOpremomServisInterfejs>(typeof(RukovanjeStatickomOpremomServisInterfejs));
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            
            String id = txtId.Text;
            StatickaOprema postojecaStatickaOprema = rukovanjeStatickomOpremomServis.PretraziPoId(id);
            if (postojecaStatickaOprema != null)
            {
                MessageBox.Show($"Postoji vec oprema sa ID-em:{id}");
                return;
            }

            String naziv = txtNaziv.Text;

            int kolicina;
            
            try
            {
                kolicina = Int32.Parse(txtKolicina.Text);
            } catch
            {
                MessageBox.Show($"Kolicina mora biti coe broj!!");
                return;
            }
            
            

            StatickaOprema so = new StatickaOprema(id);
            so.naziv = naziv;
            so.kolicina = kolicina;
            rukovanjeStatickomOpremomServis.DodajStatickuOpremu(so);
            StatickeOpremeRepozitorijum.UpisiStatickuOpremu();
            Close();


        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
