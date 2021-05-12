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
    public partial class AnamnezaWindow : Window
    {
        public Anamneza Anamneza { get; internal set; }
        public AnamnezaWindow(String brojKartona)
        {
            InitializeComponent();
            Anamneza = NaloziPacijenataServis.pronadjiKarton(brojKartona).Anamneza;

            txtSImptomi.Text = Anamneza.Simptomi;
            txtIzvestaj.Text = Anamneza.IzvestajLekara;
        }

        private void btnPotvrdi_Click(object sender, RoutedEventArgs e)
        {
            Anamneza = new Anamneza(txtSImptomi.Text, txtIzvestaj.Text);
            this.Close();

        }

        private void btnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
