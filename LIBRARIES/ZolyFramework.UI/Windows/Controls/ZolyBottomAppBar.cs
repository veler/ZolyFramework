// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyBottomAppBar.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyBottomAppBar type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    /// The zoly bottom app bar.
    /// </summary>
    public class ZolyBottomAppBar : ContentControl
    {
        #region Properties

        /// <summary>
        /// Gets or sets the open text block.
        /// </summary>
        private TextBlock OpenTextBlock { get; set; }

        /// <summary>
        /// Gets or sets the container grid.
        /// </summary>
        private Grid ContainerGrid { get; set; }

        /// <summary>
        /// The is open property.
        /// </summary>
        public static readonly DependencyProperty IsOpenProperty = DependencyProperty.Register("IsOpen", typeof(bool), typeof(ZolyBottomAppBar), new UIPropertyMetadata(IsOpenPropertyChangedCallback));

        /// <summary>
        /// Gets or sets a value indicating whether the app bar is open.
        /// </summary>
        public bool IsOpen
        {
            get { return (bool)this.GetValue(IsOpenProperty); }
            set { this.SetValue(IsOpenProperty, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyBottomAppBar"/> class.
        /// </summary>
        public ZolyBottomAppBar()
        {
            this.DefaultStyleKey = typeof(ZolyBottomAppBar);

            this.LostFocus += this.ZolyBottomAppBarLostFocus;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// The on apply template.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.OpenTextBlock = GetTemplateChild("OpenTextBlock") as TextBlock;
            this.ContainerGrid = GetTemplateChild("ContainerGrid") as Grid;

            if (this.OpenTextBlock != null)
                this.OpenTextBlock.MouseUp += this.OpenTextBlockMouseUp;

            this.UpdateDesignView();
        }

        #endregion

        #region Handled Methods

        /// <summary>
        /// The is open property changed callback.
        /// </summary>
        /// <param name="dependencyObject">
        /// The zoly bottom app bar.
        /// </param>
        /// <param name="dependencyPropertyChangedEventArgs">
        /// The dependency property changed event args.
        /// </param>
        private static void IsOpenPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if ((bool)dependencyPropertyChangedEventArgs.NewValue == (bool)dependencyPropertyChangedEventArgs.OldValue)
                return;

            var appbar = (ZolyBottomAppBar)dependencyObject;
            if (appbar.ContainerGrid == null)
                return;

            if ((bool)dependencyPropertyChangedEventArgs.NewValue)
            {
                appbar.Focus();
                appbar.ContainerGrid.Background = Brushes.Transparent;
                appbar.ContainerGrid.MouseUp += appbar.ContainerBorderMouseUp;
            }
            else
            {
                appbar.ContainerGrid.MouseUp -= appbar.ContainerBorderMouseUp;
                appbar.ContainerGrid.Background = null;
            }

            appbar.UpdateDesignView();
        }

        /// <summary>
        /// The zoly bottom app bar lost focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyBottomAppBarLostFocus(object sender, RoutedEventArgs e)
        {
            var mouseEventArs = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Left);
            mouseEventArs.RoutedEvent = UIElement.MouseUpEvent;
            this.ContainerGrid.RaiseEvent(mouseEventArs);
        }


        /// <summary>
        /// The open text block mouse up.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void OpenTextBlockMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!this.IsOpen)
                this.IsOpen = true;
        }


        /// <summary>
        /// The container border mouse up.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ContainerBorderMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (this.IsOpen)
                this.IsOpen = false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The update design view.
        /// </summary>
        private void UpdateDesignView()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                this.VerticalAlignment = VerticalAlignment.Bottom;
                if (this.IsOpen)
                    this.Height = 105;
                else
                    this.Height = 15;
            }
        }

        #endregion
    }
}
