using KMAAndrusiv02.NavigationTools;
using System.Windows.Controls;

namespace KMAAndrusiv02
{
    /// <inheritdoc>
    ///     <cref></cref>
    /// </inheritdoc>
    /// <summary>
    /// Interaction logic for ResultsControl.xaml
    /// </summary>
    public partial class ResultsControl : UserControl, INavigatable
    {
        public ResultsControl()
        {
            InitializeComponent();
            DataContext = new ResultsViewModel();
        }
    }
}
