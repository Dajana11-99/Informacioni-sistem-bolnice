using Model;
using Servis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdravoKorporacija.Model;
using ZdravoKorporacija.Repozitorijum;
using ZdravoKorporacija.Servis;

namespace ZdravoKorporacija.PacijentPrikaz
{
    /// <summary>
    /// Interaction logic for Terapija.xaml
    /// </summary>
    public partial class Terapija : UserControl
    {
        public static Timer timer;
        public static ObservableCollection<Recept> ReceptiPropisani { get; set; }
        public Terapija()
        {
            InitializeComponent();
            this.DataContext = this;
            
            ReceptiPropisani = new ObservableCollection<Recept>();
            
            foreach (Recept r in PacijentGlavniProzor.ulogovan.karton.recepti)
            {
                
                ReceptiPropisani.Add(r);
            }
            

        }

        public static void schedule_Timer()
        {
            if (DateTime.Compare(DateTime.Now.Date, r.KrajTerapije.Date) == 0)
                kraj();
            double tickTime = (double)(DateTime.Now.AddSeconds(r.PeroidUzimanjaUSatima) - DateTime.Now).TotalMilliseconds;
            timer = new Timer(tickTime);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();

        }

        private static String Sadrzaj()
        {
           return sadrzaj1 = "Lek: " + r.Lek1.ImeLeka + ".\nIsteklo je " + r.PeroidUzimanjaUSatima + "h od poslednje doze." +
           "\nKoličina u sledećoj dozi: " + r.KolicinaTerapije + ".";
        }

        public static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Obavestenja o = new Obavestenja(Guid.NewGuid().ToString(), "Terapija", Sadrzaj(), DateTime.Now, PacijentGlavniProzor.ulogovan.IdPacijenta);
            ObavestenjaServis.DodajObavestenjePacijentu(o);
            timer.Stop();
            schedule_Timer();
        }


        public static void kraj()
        {
            return;
        }

        public static Recept r;


        public static String sadrzaj1;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
             r = (Recept)ReceptiPropisanii.SelectedItem;
            schedule_Timer();
            if (r.obavestiMe.Equals("DA"))
            {
                MessageBox.Show("Vec primate obavestenja o ovoj terapiji!!","Terapija",MessageBoxButton.OK,MessageBoxImage.Information);
                return;
            }
                    r.obavestiMe = "DA";
            CollectionViewSource.GetDefaultView(ReceptiPropisani).Refresh();
            MessageBox.Show("Uspešno ste uključili obaveštenja o terapiji!","Terapija",MessageBoxButton.OK,MessageBoxImage.Exclamation);

           
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            r = (Recept)ReceptiPropisanii.SelectedItem;
            if (r.obavestiMe.Equals("NE"))
            {
                MessageBox.Show("Vec ste iskljucili obavestenja o ovoj terapiji!!","Terapija",MessageBoxButton.OK,MessageBoxImage.Information);
                return;
            }
             r.obavestiMe = "NE";
            NaloziPacijenataRepozitorijum.UpisiPacijente();
            CollectionViewSource.GetDefaultView(ReceptiPropisani).Refresh();
            MessageBox.Show("Uspešno ste isključili obaveštenja o terapiji!", "Terapija", MessageBoxButton.OK, MessageBoxImage.Exclamation);

        }
    }
}
