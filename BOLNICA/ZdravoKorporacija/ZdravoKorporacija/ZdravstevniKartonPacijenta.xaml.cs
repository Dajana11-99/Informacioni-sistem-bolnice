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
    /// Interaction logic for ZdravstevniKartonPacijenta.xaml
    /// </summary>
    public partial class ZdravstevniKartonPacijenta : Window
    {
      public static  Pacijent pacijent=null;
        public ZdravstevniKartonPacijenta(String idPacijenta)
        {
            InitializeComponent();
            pacijent = NaloziPacijenataServis.PretragaPoId(idPacijenta);
            PopuniPodatkeOPacijentu();
        }

        private void PopuniPodatkeOPacijentu()
        {
            Karton karton = pacijent.karton;
            txtPacijent.Text = karton.Ime + " " + karton.Prezime;
            txtJMBG.Text = pacijent.Jmbg;
            txtBrojKartona.Text = karton.BrojKartona;
            txtImeRoditelja.Text = karton.ImeRoditelja;
            txtDatumRodjenja.Text = karton.DatumRodjenja.ToString();
            txtPol.Text = karton.Pol.ToString();
            txtBrTel.Text = karton.Telefon;
            txtBracniStatus.Text = karton.BracniStatus.ToString();

        }

        private void btnAnamneza_Click(object sender, RoutedEventArgs e)
        {
            AnamnezaWindow anamnezaWindow = new AnamnezaWindow(pacijent.karton.BrojKartona);
            anamnezaWindow.ShowDialog();

            pacijent.karton.Anamneza = anamnezaWindow.Anamneza;
        }

        private void btnIzdavanjeRecepta_Click(object sender, RoutedEventArgs e)
        {
            IzdavanjeRecepataWindow irw = new IzdavanjeRecepataWindow();
            irw.ShowDialog();
            if (irw.recept != null)
                pacijent.karton.recepti.Add(irw.recept);
        }
    }
}
