// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyFlyoutContentPanel.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyFlyoutContentPanel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// The zoly flyout content panel.
    /// </summary>
    public class ZolyFlyoutContentPanel : UserControl
    {
        #region Properties

        /// <summary>
        /// The title property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ZolyFlyoutContentPanel), new FrameworkPropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the title of the flyout.
        /// </summary>
        public string Title
        {
            get { return (string)this.GetValue(TitleProperty); }
            set { this.SetValue(TitleProperty, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyFlyoutContentPanel"/> class.
        /// </summary>
        public ZolyFlyoutContentPanel()
        {
            this.DefaultStyleKey = typeof(ZolyFlyoutContentPanel);
        }

        #endregion
    }
}
