// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyAppBarButton.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyAppBarButton type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;

    /// <summary>
    /// The zoly app bar button.
    /// </summary>
    public class ZolyAppBarButton : Button
    {
        #region Properties

        /// <summary>
        /// The icon property.
        /// </summary>
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(object), typeof(ZolyAppBarButton), new FrameworkPropertyMetadata("\uE115"));

        /// <summary>
        /// Gets or sets the icon of the button.
        /// </summary>
        public object Icon
        {
            get { return this.GetValue(IconProperty); }
            set { this.SetValue(IconProperty, value); }
        }

        /// <summary>
        /// The placement mode property.
        /// </summary>
        public static readonly DependencyProperty PlacementModeProperty = DependencyProperty.Register("PlacementMode", typeof(PlacementMode), typeof(ZolyAppBarButton), new FrameworkPropertyMetadata(PlacementMode.Top));

        /// <summary>
        /// Gets or sets the placement mode.
        /// </summary>
        public PlacementMode PlacementMode
        {
            get { return (PlacementMode)this.GetValue(PlacementModeProperty); }
            set { this.SetValue(PlacementModeProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyAppBarButton"/> class.
        /// </summary>
        public ZolyAppBarButton()
        {
            this.DefaultStyleKey = typeof(ZolyAppBarButton);

            this.Click += this.ZolyAppBarButtonClick;
            this.Loaded += this.ZolyAppBarButtonLoaded;
        }


        #endregion

        #region Handled Methods

        /// <summary>
        /// The zoly app bar button loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyAppBarButtonLoaded(object sender, RoutedEventArgs e)
        {
            if (this.ContextMenu != null)
                this.ContextMenu.Closed += this.ContextMenuClosed;
        }

        /// <summary>
        /// The zoly app bar button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyAppBarButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.ContextMenu != null)
            {
                this.ContextMenu.Placement = this.PlacementMode;
                this.ContextMenu.PlacementTarget = this;
                this.ContextMenu.IsOpen = true;
            }
            else
                this.TryCloseAppBar();
        }

        /// <summary>
        /// The context menu closed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ContextMenuClosed(object sender, RoutedEventArgs e)
        {
            this.TryCloseAppBar();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Try to close the app bar.
        /// </summary>
        private void TryCloseAppBar()
        {
            var old = this.Focusable;
            this.Focusable = true;
            this.Focus();
            this.Focusable = old;
        }

        #endregion
    }
}
