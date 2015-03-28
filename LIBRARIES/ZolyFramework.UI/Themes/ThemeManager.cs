// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThemeManager.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ThemeManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Themes
{
    using System;
    using System.Collections.Generic;
    using System.Windows;

    /// <summary>
    /// The theme manager.
    /// </summary>
    public static class ThemeManager
    {
        #region Properties

        /// <summary>
        /// Gets the default theme (blue).
        /// </summary>
        public static Theme DefaultTheme { get; private set; }

        /// <summary>
        /// Gets the amber theme.
        /// </summary>
        public static Theme AmberTheme { get; private set; }

        /// <summary>
        /// Gets the blue grey theme.
        /// </summary>
        public static Theme BlueGreyTheme { get; private set; }

        /// <summary>
        /// Gets the blue theme.
        /// </summary>
        public static Theme BlueTheme { get; private set; }

        /// <summary>
        /// Gets the brown theme.
        /// </summary>
        public static Theme BrownTheme { get; private set; }

        /// <summary>
        /// Gets the cyan theme.
        /// </summary>
        public static Theme CyanTheme { get; private set; }

        /// <summary>
        /// Gets the deep orange theme.
        /// </summary>
        public static Theme DeepOrangeTheme { get; private set; }

        /// <summary>
        /// Gets the deep purple theme.
        /// </summary>
        public static Theme DeepPurpleTheme { get; private set; }

        /// <summary>
        /// Gets the green theme.
        /// </summary>
        public static Theme GreenTheme { get; private set; }

        /// <summary>
        /// Gets the grey theme.
        /// </summary>
        public static Theme GreyTheme { get; private set; }

        /// <summary>
        /// Gets the indigo theme.
        /// </summary>
        public static Theme IndigoTheme { get; private set; }

        /// <summary>
        /// Gets the light blue theme.
        /// </summary>
        public static Theme LightBlueTheme { get; private set; }

        /// <summary>
        /// Gets the light green theme.
        /// </summary>
        public static Theme LightGreenTheme { get; private set; }

        /// <summary>
        /// Gets the lime theme.
        /// </summary>
        public static Theme LimeTheme { get; private set; }

        /// <summary>
        /// Gets the orange theme.
        /// </summary>
        public static Theme OrangeTheme { get; private set; }

        /// <summary>
        /// Gets the pink theme.
        /// </summary>
        public static Theme PinkTheme { get; private set; }

        /// <summary>
        /// Gets the purple theme.
        /// </summary>
        public static Theme PurpleTheme { get; private set; }

        /// <summary>
        /// Gets the red theme.
        /// </summary>
        public static Theme RedTheme { get; private set; }

        /// <summary>
        /// Gets the teal theme.
        /// </summary>
        public static Theme TealTheme { get; private set; }

        /// <summary>
        /// Gets the yellow theme.
        /// </summary>
        public static Theme YellowTheme { get; private set; }

        /// <summary>
        /// Gets or sets the generic resource dictionary that contains the controls styles.
        /// </summary>
        private static ResourceDictionary Generic { get; set; }

        /// <summary>
        /// Gets the themes.
        /// </summary>
        public static List<Theme> Themes { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes static members of the <see cref="ThemeManager"/> class.
        /// </summary>
        static ThemeManager()
        {
            if (DefaultTheme != null && Generic != null)
                return;
            DefaultTheme = new Theme("Default", new Uri(@"ZolyFramework.UI;component\Themes/Themes/BlueTheme.xaml", UriKind.Relative));

            AmberTheme = new Theme("Amber", new Uri(@"ZolyFramework.UI;component\Themes/Themes/AmberTheme.xaml", UriKind.Relative));
            BlueGreyTheme = new Theme("Blue Grey", new Uri(@"ZolyFramework.UI;component\Themes/Themes/BlueGreyTheme.xaml", UriKind.Relative));
            BlueTheme = new Theme("Blue", new Uri(@"ZolyFramework.UI;component\Themes/Themes/BlueTheme.xaml", UriKind.Relative));
            BrownTheme = new Theme("Brown", new Uri(@"ZolyFramework.UI;component\Themes/Themes/BrownTheme.xaml", UriKind.Relative));
            CyanTheme = new Theme("Cyan", new Uri(@"ZolyFramework.UI;component\Themes/Themes/CyanTheme.xaml", UriKind.Relative));
            DeepOrangeTheme = new Theme("Deep Orange", new Uri(@"ZolyFramework.UI;component\Themes/Themes/DeepOrangeTheme.xaml", UriKind.Relative));
            DeepPurpleTheme = new Theme("Deep Purple", new Uri(@"ZolyFramework.UI;component\Themes/Themes/DeepPurpleTheme.xaml", UriKind.Relative));
            GreenTheme = new Theme("Green", new Uri(@"ZolyFramework.UI;component\Themes/Themes/GreenTheme.xaml", UriKind.Relative));
            GreyTheme = new Theme("Grey", new Uri(@"ZolyFramework.UI;component\Themes/Themes/GreyTheme.xaml", UriKind.Relative));
            IndigoTheme = new Theme("Indigo", new Uri(@"ZolyFramework.UI;component\Themes/Themes/IndigoTheme.xaml", UriKind.Relative));
            LightBlueTheme = new Theme("Light Blue", new Uri(@"ZolyFramework.UI;component\Themes/Themes/LightBlueTheme.xaml", UriKind.Relative));
            LightGreenTheme = new Theme("Light Green", new Uri(@"ZolyFramework.UI;component\Themes/Themes/LightGreenTheme.xaml", UriKind.Relative));
            LimeTheme = new Theme("Lime", new Uri(@"ZolyFramework.UI;component\Themes/Themes/LimeTheme.xaml", UriKind.Relative));
            OrangeTheme = new Theme("Orange", new Uri(@"ZolyFramework.UI;component\Themes/Themes/OrangeTheme.xaml", UriKind.Relative));
            PinkTheme = new Theme("Pink", new Uri(@"ZolyFramework.UI;component\Themes/Themes/PinkTheme.xaml", UriKind.Relative));
            PurpleTheme = new Theme("Purple", new Uri(@"ZolyFramework.UI;component\Themes/Themes/PurpleTheme.xaml", UriKind.Relative));
            RedTheme = new Theme("Red", new Uri(@"ZolyFramework.UI;component\Themes/Themes/RedTheme.xaml", UriKind.Relative));
            TealTheme = new Theme("Teal", new Uri(@"ZolyFramework.UI;component\Themes/Themes/TealTheme.xaml", UriKind.Relative));
            YellowTheme = new Theme("Yellow", new Uri(@"ZolyFramework.UI;component\Themes/Themes/YellowTheme.xaml", UriKind.Relative));

            var themes = new List<Theme>();
            themes.Add(AmberTheme);
            themes.Add(BlueGreyTheme);
            themes.Add(BlueTheme);
            themes.Add(BrownTheme);
            themes.Add(CyanTheme);
            themes.Add(DeepOrangeTheme);
            themes.Add(DeepPurpleTheme);
            themes.Add(GreenTheme);
            themes.Add(GreyTheme);
            themes.Add(IndigoTheme);
            themes.Add(LightBlueTheme);
            themes.Add(LightGreenTheme);
            themes.Add(LimeTheme);
            themes.Add(OrangeTheme);
            themes.Add(PinkTheme);
            themes.Add(PurpleTheme);
            themes.Add(RedTheme);
            themes.Add(TealTheme);
            themes.Add(YellowTheme);
            Themes = themes;

            if (Application.Current != null)
            {
                foreach (var resourceDictionary in Application.Current.Resources.MergedDictionaries)
                {
                    if (resourceDictionary.Source != null && resourceDictionary.Source.OriginalString.Replace("/", string.Empty).Replace(@"\", string.Empty).Contains("ZolyFramework.UI;componentThemesGeneric.xaml"))
                        Generic = resourceDictionary;
                }

                if (Generic == null)
                {
                    Generic = (ResourceDictionary)Application.LoadComponent(new Uri(@"ZolyFramework.UI;component\Themes/Generic.xaml", UriKind.Relative));
                    Application.Current.Resources.MergedDictionaries.Add(Generic);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Apply the specified theme.
        /// </summary>
        /// <param name="theme">
        /// The theme.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// theme argument is null
        /// </exception>
        public static void ApplyTheme(Theme theme)
        {
            if (theme == null)
                throw new ArgumentNullException("theme");

            if (Application.Current != null)
            {
                Generic.MergedDictionaries.RemoveAt(0);
                Generic.MergedDictionaries.Insert(0, theme.ResourceDictionary);

                for (var i = 0; i < Application.Current.Windows.Count; i++)
                    Application.Current.Windows[i].UpdateDefaultStyle();
            }
        }

        #endregion
    }
}
