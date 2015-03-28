// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Theme.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the Theme type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Themes
{
    using System;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// A Theme
    /// </summary>
    [Serializable]
    public class Theme
    {
        #region Properties

        /// <summary>
        /// Gets or sets the name of the theme.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the preview color of the theme.
        /// </summary>
        public Brush PreviewColor { get; set; }


        /// <summary>
        /// Gets or sets the Uri to the ResourceDictionary that contains the theme definition.
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Gets the resource dictionary.
        /// </summary>
        public ResourceDictionary ResourceDictionary { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="Theme"/> class.
        /// </summary>
        public Theme()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Theme"/> class.
        /// </summary>
        /// <param name="name">
        /// The theme name.
        /// </param>
        /// <param name="uri">
        /// The resource dictionary uri.
        /// </param>
        public Theme(string name, Uri uri)
        {
            this.Name = name;
            this.Uri = uri;
            this.ResourceDictionary = (ResourceDictionary)Application.LoadComponent(uri);

            if (this.ResourceDictionary != null && this.ResourceDictionary.Contains("ThemeBrush"))
            {
                var solidColorBrush = this.ResourceDictionary["ThemeBrush"] as Brush;
                if (solidColorBrush != null)
                    this.PreviewColor = solidColorBrush;
            }
        }

        #endregion
    }
}
