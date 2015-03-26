using System.Windows.Controls;
using ZolyFramework.UI.Themes;

namespace ZolyFramework.UI.Windows.Controls
{
    public class ZolyRaisedButton : Button
    {
        #region Fields

        private ThemeManager _themeManager = new ThemeManager();

        #endregion

        #region Constructor

        public ZolyRaisedButton()
        {
            DefaultStyleKey = typeof(ZolyRaisedButton);
        }

        #endregion
    }
}
