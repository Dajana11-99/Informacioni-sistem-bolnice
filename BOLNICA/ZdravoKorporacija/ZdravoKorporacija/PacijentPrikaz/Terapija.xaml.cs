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
        public static DateTime nowTime;
        public static void schedule_Timer()
        {
           
            sadrzaj1 = "Terapija: " + r.Lek1.ImeLeka +
           "\ndnevna količina: " + r.KolicinaTerapije + ",\nvremenski interval između doza: " + r.PeroidUzimanjaUSatima + "h.";
            nowTime = DateTime.Now;
            DateTime scheduledTime = DateTime.Now.AddSeconds(r.PeroidUzimanjaUSatima); //Specify your scheduled time HH,MM,SS [8am and 42 minutes]
            DateTime krajnji = r.KrajTerapije;

           

             if (DateTime.Compare(nowTime.Date, krajnji.Date)==0)
             {

                 kraj();
             }


             Console.WriteLine("KONNNN" + krajnji.Date);
             Console.WriteLine("NOWW" + nowTime.Date);

            double tickTime = (double)(scheduledTime - DateTime.Now).TotalMilliseconds;
            timer = new Timer(tickTime);

            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();

        }

        public static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Obavestenja o = new Obavestenja(ObavestenjaServis.generisiIdObavestenja(), "Terapija", sadrzaj1, nowTime, PacijentGlavniProzor.ulogovan.idPacijenta);
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
          if (r.obavestiMe.Equals("DA"))
            {
                MessageBox.Show("Vec primate obavestenja o ovoj terapiji!!");
                return;
            }
            r.obavestiMe = "DA";
            CollectionViewSource.GetDefaultView(ReceptiPropisani).Refresh();
            MessageBox.Show("USPESNO STE UKLJUCILI OBAVESTENJA");

           
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            r = (Recept)ReceptiPropisanii.SelectedItem;
            if (r.obavestiMe.Equals("NE"))
            {
                MessageBox.Show("Vec ste iskljucili obavestenja o ovoj terapiji!!");
                return;
            }
            r.obavestiMe = "NE";
            CollectionViewSource.GetDefaultView(ReceptiPropisani).Refresh();
            MessageBox.Show("USPESNO STE ISKLJUCILI OBAVESTENJA");

        }
    }
}
