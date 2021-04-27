using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ZdravoKorporacija
{
    /// <summary>
    /// Interaction logic for CheckboxList.xaml
    /// </summary>
    /// 

    // https://stackoverflow.com/questions/4527286/how-to-implement-a-listbox-of-checkboxes-in-wpf

    public class CheckBoxListItem: INotifyPropertyChanged
    {
        private object data;

        public object Data
        {
            get { return data; }
            set { data = value;
                OnPropertyChanged("Data");
            }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;
                OnPropertyChanged("Name");
            
            }
        }



        private bool isChecked;

        public bool IsChecked
        {
            get { return isChecked; }
            set {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public partial class CheckboxList : UserControl
    {

      

        public List<CheckBoxListItem> CheckBoxItems
        {
            get { return (List<CheckBoxListItem>)GetValue(CheckBoxItemsProperty); }
            set { SetValue(CheckBoxItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckBoxItemsProperty =
            DependencyProperty.Register("CheckBoxItems", typeof(List<CheckBoxListItem>), typeof(CheckboxList), new PropertyMetadata(null));


        public CheckboxList()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
