using Kontroler;
using Model;
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
using ZdravoKorporacija.ViewModel;

namespace ZdravoKorporacija.PacijentPrikaz
{ 
    public partial class IstorijaPregleda : UserControl
    {
        
        TerminKontroler terminKontroler = new TerminKontroler();
        private IstorijaPregledaViewModel istorijaPregledaViewModel;
        public IstorijaPregleda(String korisnickoIme)
        {
            istorijaPregledaViewModel = new IstorijaPregledaViewModel(korisnickoIme);
            InitializeComponent();
            this.DataContext = istorijaPregledaViewModel;
         
            
        }

     /*   private void IzvestajSaPregleda_Click(object sender, RoutedEventArgs e)
        {
            if(TerminiPacijentaa.SelectedIndex== -1)
            {
                MessageBox.Show("Morate izabrati termin da biste videli izveštaj o istom!");
                return;
            }
           
            IzvestajSaPregleda izvestaj = new IzvestajSaPregleda((Termin)TerminiPacijentaa.SelectedItem);
            izvestaj.Show();
            this.Close();
        }

        private void VratiSe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }*/
    }
}
