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
    public partial class IzvestajSaPregleda : UserControl
    {
        private ViseInformacijaViewModel viseInformacijaViewModel;
        public IzvestajSaPregleda(TerminDTO terminPregleda)
        {
            viseInformacijaViewModel = new ViseInformacijaViewModel(terminPregleda);
            InitializeComponent();
            this.DataContext = viseInformacijaViewModel;

        }
      /*  private void PodesavanjeParametara(Termin terminPregleda)
        {
            Dijagnoza.Text = terminPregleda.Pacijent.karton.Anamneza.Simptomi.ToString();
            Anamneza.Text = terminPregleda.Pacijent.karton.Anamneza.IzvestajLekara;
            foreach (Recept recept in terminPregleda.Pacijent.karton.recepti)
                Terapija.Text = recept.Lek1.ImeLeka + " " + "Svakih" + recept.PeroidUzimanjaUSatima + "h";
            Kontrola.Text = "Po potrebi";
        }*/
       /* private void VratiSe_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }*/

        private void NapraviBelesku_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
