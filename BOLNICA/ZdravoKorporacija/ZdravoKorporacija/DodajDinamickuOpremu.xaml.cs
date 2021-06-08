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
    public partial class DodajDinamickuOpremu : Window
    {
        RukovanjeDinamickomOpremomServisInterfejs rukovanjeDinamickomOpremomServis;
        public DodajDinamickuOpremu()
        {
            InitializeComponent();
            rukovanjeDinamickomOpremomServis = Injektor.Instance.Get<RukovanjeDinamickomOpremomServisInterfejs>(typeof(RukovanjeDinamickomOpremomServisInterfejs));
        }
        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            String id = txtId.Text;
            if (PostojiDinamickaOprema(id))
                return;
            String naziv = txtNaziv.Text;
            int kolicina;
            try
            {
                kolicina = Int32.Parse(txtKolicina.Text);
            }
            catch
            {
                MessageBox.Show($"Kolicina mora biti ceo broj!!");
                return;
            }
            DinamickaOprema oprema = new DinamickaOprema(id);
            oprema.naziv = naziv;
            oprema.kolicina = kolicina;
            rukovanjeDinamickomOpremomServis.DodajDinamickuOpremu(oprema);
            DinamickeOpremeRepozitorijum.UpisiDinamickuOpremu();
            Close();
        }
        private bool PostojiDinamickaOprema(string id)
        {
            DinamickaOprema postojecaDinamickaOprema = rukovanjeDinamickomOpremomServis.PretraziPoId(id);
            if (postojecaDinamickaOprema != null)
            {
                MessageBox.Show($"Postoji vec oprema sa ID-em:{id}");
                return true;
            }
            return false;
        }
        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
