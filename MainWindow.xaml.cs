namespace Keedoozle_Fine_Food
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mainWindowViewModel;
        public MainWindow()
        {
            _mainWindowViewModel = new MainWindowViewModel(this);
            InitializeComponent();
            DataContext = _mainWindowViewModel;

        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _mainWindowViewModel.LoadAsync();
        }
    }

}
