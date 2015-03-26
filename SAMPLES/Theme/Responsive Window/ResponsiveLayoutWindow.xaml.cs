using ZolyFramework.UI.Windows;

namespace ThemeSample.Responsive_Window
{
    /// <summary>
    /// Interaction logic for ResponsiveWindow.xaml
    /// </summary>
    public partial class ResponsiveLayoutWindow : ZolyWindow
    {
        public ResponsiveLayoutWindow()
        {
            InitializeComponent();

            DraggableZoneGrid = DragGrid;
        }
    }
}
