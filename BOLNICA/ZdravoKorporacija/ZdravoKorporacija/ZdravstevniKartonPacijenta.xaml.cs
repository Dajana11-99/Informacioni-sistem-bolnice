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
using System.Windows.Shapes;
using ZdravoKorporacija.Repozitorijum;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for ZdravstevniKartonPacijenta.xaml
    /// </summary>
    public partial class ZdravstevniKartonPacijenta : Window
    {
        public static Pacijent pacijent = null;
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        public ZdravstevniKartonPacijenta(String idPacijenta)
        {
            InitializeComponent();
            pacijent = naloziPacijenataKontroler.PretragaPoId(idPacijenta);
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
        private void BtnAnamneza_Click(object sender, RoutedEventArgs e)
        {
            AnamnezaWindow anamnezaWindow = new AnamnezaWindow(pacijent.karton.BrojKartona);
            anamnezaWindow.ShowDialog();
            pacijent.karton.Anamneza = anamnezaWindow.Anamneza;
        }
        private void BtnIzdavanjeRecepta_Click(object sender, RoutedEventArgs e)
        {
            IzdavanjeRecepataWindow izdavanjeReceptaProzor = new IzdavanjeRecepataWindow(pacijent);
            izdavanjeReceptaProzor.ShowDialog();
            if (izdavanjeReceptaProzor.recept != null)
            {
                pacijent.karton.recepti.Add(izdavanjeReceptaProzor.recept);
            }
        }
    }
}
