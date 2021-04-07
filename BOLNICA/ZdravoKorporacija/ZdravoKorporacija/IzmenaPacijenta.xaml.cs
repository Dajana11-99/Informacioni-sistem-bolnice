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
using Model;
using PoslovnaLogika;

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for IzmenaPacijenta.xaml
    /// </summary>
    public partial class IzmenaPacijenta : Window
    {
        public List<Lekar> Lekari { get; set; }

        public String id = null;
        public String idpom = null;
        public IzmenaPacijenta(Termin t)
        {
           
            InitializeComponent();
            bindcombo();
            id = t.IdTermina;
            lekar.SelectedIndex = konstruisi_combo(t.Lekar.CeloIme);
            pacijent.Text = t.Pacijent.idPacijenta;
            datum.SelectedDate = DateTime.ParseExact(t.Datum, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            vreme.Text = t.Vreme;

        }
    
        public int konstruisi_combo(String id)
        {
            for(int i = 0; i < Lekari.Count; i++)
            {
                if (Lekari[i].CeloIme.Equals(id)) 
                   
                    return i;
             
                

            }
            return 0;

        }
        public void bindcombo()
        {
            List<Lekar> pomocna = new List<Lekar>();
           
            foreach (Lekar l in RukovanjeTerminima.pom)
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
            DateTime? datum = this.datum.SelectedDate;
            String formatirano = null;
            if (datum.HasValue)
                formatirano = datum.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (this.lekar.SelectedIndex == -1 || !datum.HasValue || vreme.SelectedIndex == -1 || pacijent.Equals(""))
            {

                System.Windows.Forms.MessageBox.Show("Sva polja su obavezna!!", "Upozorenje", (System.Windows.Forms.MessageBoxButtons)MessageBoxButton.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            RukovanjeTerminima.IzmenaPregleda(id, lekar.Text, formatirano, vreme.Text);
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
