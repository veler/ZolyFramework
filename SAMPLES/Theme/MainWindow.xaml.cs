using ThemeSample.Responsive_Window;
using ZolyFramework.UI.Windows;

namespace ThemeSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ZolyWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var window = new ResponsiveLayoutWindow();
            window.ShowDialog();
        }
    }
}
