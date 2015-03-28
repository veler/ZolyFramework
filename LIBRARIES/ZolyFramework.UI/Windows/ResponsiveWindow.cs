// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponsiveWindow.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ResponsiveWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows
{
    using System.Windows;

    using ZolyFramework.UI.Layout;

    /// <summary>
    /// The responsive window.
    /// </summary>
    public class ResponsiveWindow : Window
    {
        #region Properties

        /// <summary>
        /// The responsive layout property.
        /// </summary>
        public static readonly DependencyProperty ResponsiveLayoutProperty = DependencyProperty.Register("ResponsiveLayout", typeof(ResponsiveLayoutManager), typeof(ResponsiveWindow), new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets the responsive layout.
        /// </summary>
        public ResponsiveLayoutManager ResponsiveLayout
        {
            get { return (ResponsiveLayoutManager)this.GetValue(ResponsiveLayoutProperty); }
            set { this.SetValue(ResponsiveLayoutProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsiveWindow"/> class.
        /// </summary>
        public ResponsiveWindow()
        {
            this.SizeChanged += this.ResponsiveWindowSizeChanged;
        }

        #endregion

        #region Handles Methods

        /// <summary>
        /// The responsive window size changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ResponsiveWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ResponsiveLayout != null)
                this.ResponsiveLayout.UpdateLayout(e, this);
        }

        #endregion
    }
}
