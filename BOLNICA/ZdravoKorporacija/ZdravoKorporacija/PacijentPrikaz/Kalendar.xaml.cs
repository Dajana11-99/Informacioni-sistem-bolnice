using Kontroler;
using Model;
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
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.PacijentPrikaz
{



    public partial class Kalendar : UserControl
    {
      
        private NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        private List<DateTime> daniTerapije = new List<DateTime>();
        List<String> imeLeka = new List<string>();
        public Kalendar(String id)
        {
            InitializeComponent();
            ucitaj(id);
            foreach (DateTime dani in daniTerapije)
            {
                foreach(String st in imeLeka)
                Calendar.Days[dani.Day].Notes = st;
            }
         

        }

        public void ucitaj(String idPacijenta) {
            foreach (Recept recept in naloziPacijenataKontroler.PretraziPoKorisnickom(idPacijenta).karton.recepti)
            {
                int razlika = (int)(recept.KrajTerapije - recept.PocetakTerapije).TotalDays;
                for (int i = 0; i <= razlika; i++)
                {
                    daniTerapije.Add(recept.PocetakTerapije.AddDays(i));
                    imeLeka.Add(recept.Lek1.ImeLeka);
                }
            } 
        } 
    }
 }

