using System.Windows.Controls;
using KMAAndrusiv02.DataStorageTools;
using KMAAndrusiv02.Managers;
using KMAAndrusiv02.NavigationTools;

namespace KMAAndrusiv02
{
    /// <inheritdoc>
    ///     <cref></cref>
    /// </inheritdoc>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IContentOwner
    {
        public ContentControl ContentControl => _contentControl;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            StationManager.Initialize(new SerializedDataStorage());
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.List);
        }
    }
}
