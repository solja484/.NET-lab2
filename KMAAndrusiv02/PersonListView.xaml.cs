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
using KMAAndrusiv02.NavigationTools;

namespace KMAAndrusiv02
{
    /// <summary>
    /// Interaction logic for PersonListView.xaml
    /// </summary>
    public partial class PersonListView : UserControl, INavigatable
    {
        public PersonListView()
        {
            InitializeComponent();
            DataContext = new PersonListViewModel();
        }

        public void TriggerPropertyChanged(string s)
        {
            ((BaseViewModel)DataContext).OnPropertyChanged(s);
        }
    }
}
