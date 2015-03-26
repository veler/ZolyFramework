using System;
using System.Windows;
using ZolyFramework.UI.ComponentModel;

namespace ZolyFramework.UI.Themes
{
    public class ThemeManager : NotifyPropertyChangedClass
    {

        #region Properties

        private static Theme Generic { get; set; }

        public static Theme DefaultTheme { get; private set; }

        public Theme CurrentTheme { get; private set; }

        #endregion

        #region Constructor

        static ThemeManager()
        {
            if (DefaultTheme != null && Generic != null)
                return;
            DefaultTheme = new Theme("DefaultTheme", new Uri(@"ZolyFramework.UI;component\Themes/RedTheme.xaml", UriKind.Relative));
            Generic = new Theme("GenericTheme", new Uri(@"ZolyFramework.UI;component\Themes/Generic.xaml", UriKind.Relative));
            ApplyDefaultTheme();
        }

        public ThemeManager()
        {
            ApplyDefaultTheme();
        }

        public ThemeManager(Theme theme)
        {
            ApplyTheme(theme);
        }

        #endregion

        #region Methods

        public void ApplyTheme(Theme theme)
        {
            if (theme == null)
                throw new ArgumentNullException("theme");

            if (Application.Current != null)
            {
                if (CurrentTheme != null)
                    Application.Current.Resources.MergedDictionaries.Remove(CurrentTheme.ResourceDictionary);

                if (!Application.Current.Resources.MergedDictionaries.Contains(theme.ResourceDictionary))
                    Application.Current.Resources.MergedDictionaries.Add(theme.ResourceDictionary);
            }

            CurrentTheme = theme;
        }

        private static void ApplyDefaultTheme()
        {
            if (Application.Current == null)
                return;
            if (!Application.Current.Resources.MergedDictionaries.Contains(DefaultTheme.ResourceDictionary))
                Application.Current.Resources.MergedDictionaries.Add(DefaultTheme.ResourceDictionary);
            if (!Application.Current.Resources.MergedDictionaries.Contains(Generic.ResourceDictionary))
                Application.Current.Resources.MergedDictionaries.Add(Generic.ResourceDictionary);
        }

        #endregion
    }
}
