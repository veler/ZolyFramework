// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyFlyout.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyFlyout type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using ZolyFramework.UI.ComponentModel;

    using VisualTreeHelper = ZolyFramework.UI.Helper.VisualTreeHelper;

    /// <summary>
    /// The zoly flyout.
    /// </summary>
    public class ZolyFlyout : ContentControl, IDisposable
    {
        #region Fields

        private TaskCompletionSource<bool> _showFlyoutTaskCompleteSource;

        #endregion

        #region Events

        /// <summary>
        /// The opened event.
        /// </summary>
        public static readonly RoutedEvent OpenedEvent = EventManager.RegisterRoutedEvent("Opened", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ZolyFlyout));

        /// <summary>
        /// The opened.
        /// </summary>
        public event RoutedEventHandler Opened
        {
            add { this.AddHandler(OpenedEvent, value); }
            remove { this.RemoveHandler(OpenedEvent, value); }
        }

        /// <summary>
        /// The closed event.
        /// </summary>
        public static readonly RoutedEvent ClosedEvent = EventManager.RegisterRoutedEvent("Closed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ZolyFlyout));

        /// <summary>
        /// The closed.
        /// </summary>
        public event RoutedEventHandler Closed
        {
            add { this.AddHandler(ClosedEvent, value); }
            remove { this.RemoveHandler(ClosedEvent, value); }
        }

        #endregion

        #region Properties

        /// <summary>
        /// The container property.
        /// </summary>
        private static readonly DependencyProperty ContainerProperty = DependencyProperty.Register("Container", typeof(Panel), typeof(ZolyFlyout), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the container that will contains the flyout (usually a grid of a window).
        /// </summary>
        private Panel Container
        {
            get { return (Panel)this.GetValue(ContainerProperty); }
            set { this.SetValue(ContainerProperty, value); }
        }

        /// <summary>
        /// Gets or sets the container grid.
        /// </summary>
        private Grid ContainerGrid { get; set; }

        /// <summary>
        /// Gets or sets the close button.
        /// </summary>
        private ZolyFlatButton CloseZolyFlatButton { get; set; }

        /// <summary>
        /// Gets a value indicating whether the flyout is open.
        /// </summary>
        public bool IsOpen { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyFlyout"/> class.
        /// </summary>
        /// <param name="container">
        /// The container that will contains the flyout (usually a grid of a window).
        /// </param>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        /// <param name="flyoutContent">
        /// The flyout content.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// container or flyoutContent argument is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The container argument should have a parent that can receive several children (like Grid, Panel, but not Border for example).
        /// </exception>
        public ZolyFlyout(Panel container, object dataContext, ZolyFlyoutContentPanel flyoutContent)
        {
            this.DefaultStyleKey = typeof(ZolyFlyout);

            if (container == null)
                throw new ArgumentNullException("container");
            if (container.Parent as Panel == null)
                throw new ArgumentException("The container argument should have a parent that can receive several children (like Grid, Panel, but not Border for example).", "container");

            if (flyoutContent == null)
                throw new ArgumentNullException("flyoutContent");

            this.Container = container;

            ((Panel)this.Container.Parent).Children.Add(this);

            this.Visibility = Visibility.Collapsed;

            this.Content = flyoutContent;
            this.DataContext = dataContext;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// The on apply template.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.ContainerGrid = GetTemplateChild("ContainerGrid") as Grid;
            this.CloseZolyFlatButton = GetTemplateChild("CloseZolyFlatButton") as ZolyFlatButton;

            if (this.ContainerGrid != null)
                this.ContainerGrid.MouseUp += this.CloseZolyFlatButtonClick;
            if (this.CloseZolyFlatButton != null)
                this.CloseZolyFlatButton.Click += this.CloseZolyFlatButtonClick;
        }

        #endregion

        #region Handled Methods

        /// <summary>
        /// The close zoly flat button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void CloseZolyFlatButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.IsOpen)
            {
                FlyoutManager.SetCurrentFlyout(null);
                this.IsOpen = false;
                this._showFlyoutTaskCompleteSource.SetResult(true);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Close the flyout.
        /// </summary>
        public void Close()
        {
            if (FlyoutManager.IsAnyFlyoutOpened())
                this.CloseZolyFlatButtonClick(null, null);
        }

        /// <summary>
        /// The raise opened event.
        /// </summary>
        /// <param name="target">
        /// The target.
        /// </param>
        private static void RaiseOpenedEvent(DependencyObject target)
        {
            if (target == null)
                return;

            var args = new RoutedEventArgs();
            args.RoutedEvent = OpenedEvent;

            if (target is UIElement)
                (target as UIElement).RaiseEvent(args);
            else if (target is ContentElement)
                (target as ContentElement).RaiseEvent(args);
        }

        /// <summary>
        /// The raise closed event.
        /// </summary>
        /// <param name="target">
        /// The target.
        /// </param>
        private static void RaiseClosedEvent(DependencyObject target)
        {
            if (target == null)
                return;

            var args = new RoutedEventArgs();
            args.RoutedEvent = ClosedEvent;

            if (target is UIElement)
                (target as UIElement).RaiseEvent(args);
            else if (target is ContentElement)
                (target as ContentElement).RaiseEvent(args);
        }

        #endregion

        #region Functions

        /// <summary>
        /// Display the flyout.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">
        /// Another Flyout is already opened.
        /// OR
        /// Unable to open a Flyout when a ZolyMessageDialog is actually opened. Close the ZolyMessageDialog first, and then open the Flyout.
        /// </exception>
        public async Task ShowFlyoutAsync()
        {
            if (FlyoutManager.IsAnyFlyoutOpened())
                throw new UnauthorizedAccessException("Another Flyout is already opened.");
            if (MessageDialogManager.IsAnyMessageDialogOpened())
                throw new UnauthorizedAccessException("Unable to open a Flyout when a ZolyMessageDialog is actually opened. Close the ZolyMessageDialog first, and then open the Flyout.");


            var keyboardNavigationMode = KeyboardNavigationMode.Cycle;
            var window = VisualTreeHelper.FindVisualParent<Window>(((Panel)this.Container.Parent));
            if (window != null)
            {
                keyboardNavigationMode = KeyboardNavigation.GetTabNavigation(window);
                KeyboardNavigation.SetTabNavigation(window, KeyboardNavigationMode.None);
                KeyboardNavigation.SetTabNavigation((ZolyFlyoutContentPanel)Content, KeyboardNavigationMode.Cycle);
                ((ZolyFlyoutContentPanel)Content).MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            }

            this._showFlyoutTaskCompleteSource = new TaskCompletionSource<bool>();
            FlyoutManager.SetCurrentFlyout(this);
            this.IsOpen = true;
            this.Visibility = Visibility.Visible;
            this.UpdateLayout();
            RaiseOpenedEvent(this);

            await this._showFlyoutTaskCompleteSource.Task;

            this.Visibility = Visibility.Collapsed;
            this.IsOpen = false;
            FlyoutManager.SetCurrentFlyout(null);

            if (window != null)
                KeyboardNavigation.SetTabNavigation(window, keyboardNavigationMode);

            RaiseClosedEvent(this);
        }

        #endregion

        #region Implements

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            if (this.ContainerGrid != null)
                this.ContainerGrid.MouseUp -= this.CloseZolyFlatButtonClick;
            if (this.CloseZolyFlatButton != null)
                this.CloseZolyFlatButton.Click -= this.CloseZolyFlatButtonClick;

            ((Panel)this.Container.Parent).Children.Remove(this);
            this._showFlyoutTaskCompleteSource = null;
        }

        #endregion
    }
}
