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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for ZakazivanjeSaPrioritetom.xaml
    /// </summary>
    public partial class ZakazivanjeSaPrioritetom : UserControl
    {

        public List<Lekar> Lekari { get; set; }
        public static List<Termin> slobodniDatumi = new List<Termin>();
        public ZakazivanjeSaPrioritetom()
        {
            InitializeComponent();
            bindcombo();
        }

        private void prikaziDatume_Click(object sender, RoutedEventArgs e)
        {

            Lekar l = TerminServis.PretragaLekaraPoID(((Lekar)lekar.SelectedItem).idZaposlenog);
            DateTime? datumOD = this.datumOd.SelectedDate;
            DateTime? datumDO = this.datumDo.SelectedDate;

           



            if(lekar.SelectedIndex==-1 || prioritet.SelectedIndex==-1 || !datumOD.HasValue || !datumDO.HasValue)
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }

            DateTime pocetak = (DateTime)datumOD;
            DateTime kraj = (DateTime)datumDO;

            if (DateTime.Compare(pocetak, kraj) > 0)
            {
                MessageBox.Show("Pocetni datum mora biti raniji od krajnjeg!");
                return;
            }

            List<Termin> pomocna = new List<Termin>();

            bool nasao = false;
            slobodniDatumi.Clear();

            pomocna = TerminKontroler.nadjiSlobodneDatumeLekarauIntervalu(pocetak, kraj, l.idZaposlenog);
            foreach(Termin t in pomocna)
            {
                nasao = false;
                foreach (Termin t1 in slobodniDatumi)
                {
                    if (t1.Datum.Equals(t.Datum))
                    {
                        nasao = true;
                        break;
                    }
                }
                if (!nasao)
                {
                    slobodniDatumi.Add(t);

                }



            }



            if (slobodniDatumi.Count == 0)
            {


                if (prioritet.SelectedIndex == 0)
                {
                    pomocna = TerminKontroler.nadjiDatumUIntervalu(pocetak, kraj);
                    foreach (Termin t1 in pomocna)
                    {
                        nasao = false;
                        foreach (Termin t2 in slobodniDatumi)
                        {
                            if (t2.Datum.Equals(t1.Datum) && t2.Lekar.idZaposlenog.Equals(t1.Lekar.idZaposlenog))
                            {
                                nasao = true;
                                break;
                            }
                        }
                        if (!nasao)
                        {
                            slobodniDatumi.Add(t1);
                        }



                    }

                    if (slobodniDatumi.Count == 0)
                    {
                        MessageBox.Show("Nema slobodnih datuma");
                        return;
                    }

                    DatumiKodSvihLekara dat = new DatumiKodSvihLekara();
                    dat.Show();

                }
                else if (prioritet.SelectedIndex == 1)
                {

                    DateTime noviPocetak = pocetak.AddDays(-7);
                    DateTime noviKraj = kraj.AddDays(7);



                    pomocna = TerminKontroler.nadjiSlobodneDatumeLekarauIntervalu(noviPocetak, noviKraj, l.idZaposlenog);
                    foreach (Termin t in pomocna)
                    {
                        nasao = false;
                        foreach (Termin t1 in slobodniDatumi)
                        {
                            if (t1.Datum.Equals(t.Datum))
                            {
                                nasao = true;

                                break;
                            }

                        }
                        if (!nasao)
                        {
                            slobodniDatumi.Add(t);
                        }
                    }
                    if (slobodniDatumi.Count == 0)
                    {
                        MessageBox.Show("Nema slobodnih datuma");
                        return;
                    }
                    DatumiKodIzabranogLekara da = new DatumiKodIzabranogLekara();
                    da.Show();








                }
            }
            else
            {
                DatumiKodIzabranogLekara dat = new DatumiKodIzabranogLekara();
                dat.Show();


            }






        }

        public void bindcombo()
        {
            List<Lekar> pomocna = new List<Lekar>();

            foreach (Lekar l in TerminServis.pom)
            {
                if (l.Specijalizacija.Equals(Specijalizacija.Ostapraksa))
                {
                    pomocna.Add(l);
                }
            }

            Lekari = pomocna;
            lekar.ItemsSource = Lekari;
        }
    }
}
