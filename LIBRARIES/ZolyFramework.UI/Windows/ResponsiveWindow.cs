using System.Windows;
using ZolyFramework.UI.Layout;

namespace ZolyFramework.UI.Windows
{
    public class ResponsiveWindow : Window
    {

        #region Properties

        public static readonly DependencyProperty ResponsiveLayoutProperty = DependencyProperty.Register("ResponsiveLayout", typeof(ResponsiveLayoutManager), typeof(ResponsiveWindow), new PropertyMetadata(null));
        public ResponsiveLayoutManager ResponsiveLayout
        {
            get { return (ResponsiveLayoutManager)GetValue(ResponsiveLayoutProperty); }
            set { SetValue(ResponsiveLayoutProperty, value); }
        }

        #endregion

        #region Constructor

        public ResponsiveWindow()
        {
            SizeChanged += ResponsiveWindow_SizeChanged;
        }

        #endregion

        #region Handles Methods

        private void ResponsiveWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ResponsiveLayout != null)
                ResponsiveLayout.UpdateLayout(e, this);
        }

        #endregion
    }
}
