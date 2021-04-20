using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Model;

using Servis;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for ZakaziPregledPacijent.xaml
    /// </summary>
    public partial class ZakaziPregledPacijent : Window
    {

       public List<Lekar> Lekari { get; set; }
        public ZakaziPregledPacijent()
        {

          

            InitializeComponent();
            bindcombo();
           




        }

        public void bindcombo()
        {
            List<Lekar> pomocna = new List<Lekar>();
        
            foreach(Lekar l in TerminServis.pom)
            {
                if (l.Specijalizacija.Equals(Specijalizacija.Ostapraksa))
                {
                    pomocna.Add(l);
                }
            }

            Lekari = pomocna;
            DataContext = Lekari;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String id =TerminServis.pronadji();
            string[] pom = lekar.Text.Split(' ');
            Lekar l = new Lekar(pom[0],pom[1]);
            Pacijent p = new Pacijent(pacijent.Text);

            Sala sala = SalaServis.PretraziPoTipu(TipSale.Pregled);
            Console.WriteLine("*************" + sala.Id);
            
            TipTermina tip = TipTermina.Pregled;
            DateTime? datum = this.datum.SelectedDate;
            String formatirano = null;
            if (datum.HasValue)
                formatirano = datum.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String v = vreme.Text;
            Double trajanje = 30;
            Termin t = new Termin(id, tip, v, trajanje, formatirano, sala, p, l);
            if(this.lekar.SelectedIndex == -1  || !datum.HasValue || vreme.SelectedIndex == -1 || pacijent.Equals(""))
            {
               
               System.Windows.Forms.MessageBox.Show("Sva polja su obavezna!!", "Upozorenje", (System.Windows.Forms.MessageBoxButtons)MessageBoxButton.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }
            TerminServis.ZakaziPregled(t);
            this.Close();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
