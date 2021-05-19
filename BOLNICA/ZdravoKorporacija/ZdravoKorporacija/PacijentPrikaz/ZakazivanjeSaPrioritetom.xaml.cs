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
using ZdravoKorporacija.Kontroler;

namespace ZdravoKorporacija.PacijentPrikaz
{
    public partial class ZakazivanjeSaPrioritetom : UserControl
    {

        public List<Lekar> Lekari { get; set; }
        public static List<Termin> slobodniDatumi = new List<Termin>();
        public LekarKontroler lekarKontorler = new LekarKontroler();
        TerminKontroler terminKontroler = new TerminKontroler();
        public ZakazivanjeSaPrioritetom()
        {
            InitializeComponent();
            Lekari = lekarKontorler.PretraziPoSpecijalizaciji();
            DataContext = Lekari;
        }

        private void prikaziDatume_Click(object sender, RoutedEventArgs e)
        {

            Lekar l = lekarKontorler.PretragaLekaraPoID(((Lekar)lekar.SelectedItem).idZaposlenog);
          /*  if(lekar.SelectedIndex==-1 || prioritet.SelectedIndex==-1 || !this.datumOd.SelectedDate.HasValue || !datumDo.SelectedDate.HasValue)
            {
                MessageBox.Show("Popunite sva polja!");
                return;
            }
           if (DateTime.Compare(((DateTime)datumOd.SelectedDate).Date, DateTime.Now.Date) <= 0)
            {
                MessageBox.Show("Ne možete izabrati datum u prošlosti!");
                return;
            }

            if (DateTime.Compare(((DateTime)datumDo.SelectedDate).Date, ((DateTime)datumOd.SelectedDate).Date) < 0)
            {
                MessageBox.Show("Početni datum mora biti raniji od krajnjeg!");
                return;
            }*/

            DateTime pocetak = (DateTime)datumOd.SelectedDate;
            DateTime kraj = (DateTime)datumDo.SelectedDate;

            if (PacijentGlavniProzor.ulogovan.Maliciozan==true)
            {
                MessageBox.Show("Vas nalog je blokiran!");
                return;
            }

            List<Termin> pomocna = new List<Termin>();

            bool nasao = false;
            slobodniDatumi.Clear();

            pomocna = terminKontroler.NadjiDatumUIntervalu(pocetak, kraj);
            foreach(Termin t in TerminKontroler.NadjiSlobodneTermineLekara(l.idZaposlenog,pomocna))
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
                    pomocna = terminKontroler.NadjiDatumUIntervalu(pocetak, kraj);
                    foreach (Termin t1 in pomocna)
                    {
                        nasao = false;
                        foreach (Termin t2 in slobodniDatumi)
                        {
                            if (t2.Datum.Equals(t1.Datum) && t2.Lekar.idZaposlenog.Equals(t1.Lekar.idZaposlenog) )
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
                    int razlikaDana = DateTime.Compare(DateTime.Now.Date, pocetak.Date);
                    if (razlikaDana < 7)
                    {
                        noviPocetak = pocetak.AddDays(-razlikaDana);
                    }


                    pomocna = terminKontroler.NadjiDatumUIntervalu(noviPocetak, noviKraj);
                    foreach (Termin t in TerminKontroler.NadjiSlobodneTermineLekara(l.idZaposlenog,pomocna))
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
    }
}
