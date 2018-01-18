using System.Threading.Tasks;
using System.Windows;
using FriendOrganizer.UI.ViewModel;
using MahApps.Metro.Controls;

namespace FriendOrganizer.UI
{
    public partial class MainWindow : MetroWindow
    {
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            Loaded += MainWindows_Loaded;
        }

        private async void MainWindows_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
    }
}