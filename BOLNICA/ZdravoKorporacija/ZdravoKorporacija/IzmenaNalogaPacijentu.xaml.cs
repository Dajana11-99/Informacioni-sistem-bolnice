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
    /// Interaction logic for IzmenaNalogaPacijentu.xaml
    /// </summary>
    public partial class IzmenaNalogaPacijentu : Window
    {
        private Pacijent KojegMenjam;


        public IzmenaNalogaPacijentu(Pacijent P)
        {
            InitializeComponent();

            ImeTEXTBOX1.Text = P.Ime;
            PrezimeTEXTBOX1.Text = P.Prezime;
            JmbgTEXTBOX1.Text = P.Jmbg;
            EmailTEXTBOX1.Text = P.Email;
       
            AdresaTEXTBOX1.Text = P.adresaStanovanja.Ulica;

            KojegMenjam = P;

        }

        private void PotvrdaAction(object sender, RoutedEventArgs e)
        {
            KojegMenjam.Ime = ImeTEXTBOX1.Text;
            KojegMenjam.Prezime = PrezimeTEXTBOX1.Text;
            KojegMenjam.Jmbg = JmbgTEXTBOX1.Text;

            KojegMenjam.Email = EmailTEXTBOX1.Text;
            KojegMenjam.adresaStanovanja.Ulica = AdresaTEXTBOX1.Text;
           NaloziPacijenataServis.IzmeniPostojeciNalog(KojegMenjam.IdPacijenta);


            this.Close();


        }

        private void OdustaniAction(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
