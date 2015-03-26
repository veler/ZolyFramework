using System;
using System.Windows;

namespace ZolyFramework.UI.Themes
{
    public class Theme
    {
        #region Properties

        public string Name { get; set; }

        public Uri Uri { get; set; }

        public ResourceDictionary ResourceDictionary { get; private set; }

        #endregion

        #region Constructor

        public Theme(string name, Uri uri)
        {
            Name = name;
            Uri = uri;
            ResourceDictionary = (ResourceDictionary)Application.LoadComponent(uri);
        }

        #endregion
    }
}
