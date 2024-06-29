using System.Windows;
using MainTestingApp.VM;

namespace MainTestingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();
        }

        private void OnPopupClosed(object o, RoutedEventArgs e)
        {
            InfoPopup.IsOpen = false;
        }
    }
}