// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyMessageDialog.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyMessageDialog type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System;
    using System.Data;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using ZolyFramework.UI.ComponentModel;
    using ZolyFramework.UI.Helper;

    /// <summary>
    /// The zoly message dialog.
    /// </summary>
    public class ZolyMessageDialog : ContentControl, IDisposable
    {
        #region Fields

        private MessageBoxResult _result = MessageBoxResult.Cancel;

        private TaskCompletionSource<bool> _showMessageDialogTaskCompleteSource;

        #endregion

        #region Events

        /// <summary>
        /// The opened event.
        /// </summary>
        public static readonly RoutedEvent OpenedEvent = EventManager.RegisterRoutedEvent("Opened", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ZolyMessageDialog));

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
        public static readonly RoutedEvent ClosedEvent = EventManager.RegisterRoutedEvent("Closed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ZolyMessageDialog));

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
        private static readonly DependencyProperty ContainerProperty = DependencyProperty.Register("Container", typeof(Panel), typeof(ZolyMessageDialog), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the container that will contains the message dialog (usually a grid of a window).
        /// </summary>
        private Panel Container
        {
            get { return (Panel)this.GetValue(ContainerProperty); }
            set { this.SetValue(ContainerProperty, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyMessageDialog"/> class.
        /// </summary>
        /// <param name="container">
        /// The container that will contains the message dialog (usually a grid of a window).
        /// </param>
        /// <param name="dataContext">
        /// The data context.
        /// </param>
        /// <param name="messageDialogContent">
        /// The message dialog content.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// container or messageDialogContent argument is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The container argument should have a parent that can receive several children (like Grid, Panel, but not Border for example).
        /// </exception>
        /// <exception cref="NoNullAllowedException">
        /// MessageDialog's Cancel button is not defined
        /// </exception>
        public ZolyMessageDialog(Panel container, object dataContext, ZolyMessageDialogContentPanel messageDialogContent)
        {
            this.DefaultStyleKey = typeof(ZolyMessageDialog);

            if (container == null)
                throw new ArgumentNullException("container");
            if (container.Parent as Panel == null)
                throw new ArgumentException("The container argument should have a parent that can receive several children (like Grid, Panel, but not Border for example).", "container");

            if (messageDialogContent == null)
                throw new ArgumentNullException("messageDialogContent");

            var okButton = messageDialogContent.GetOkButton();
            var cancelButton = messageDialogContent.GetCancelButton();

            if (cancelButton == null)
                throw new NoNullAllowedException("MessageDialog's Cancel button is not defined");

            this.Container = container;

            ((Panel)this.Container.Parent).Children.Add(this);

            this.Visibility = Visibility.Collapsed;

            if (okButton != null)
                okButton.Click += this.OkButtonClick;
            cancelButton.Click += this.CancelButtonClick;

            this.Content = messageDialogContent;
            this.DataContext = dataContext;
        }

        #endregion

        #region Handled Methods

        /// <summary>
        /// The cancel button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this._result = MessageBoxResult.Cancel;
            MessageDialogManager.SetCurrentMessageDialog(null);
            this._showMessageDialogTaskCompleteSource.SetResult(true);
        }

        /// <summary>
        /// The ok button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void OkButtonClick(object sender, RoutedEventArgs e)
        {
            this._result = MessageBoxResult.OK;
            MessageDialogManager.SetCurrentMessageDialog(null);
            this._showMessageDialogTaskCompleteSource.SetResult(true);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Cancel and close the message dialog.
        /// </summary>
        public void CancelAndClose()
        {
            if (MessageDialogManager.IsAnyMessageDialogOpened())
                this.CancelButtonClick(null, null);
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
        /// Show the message dialog and return a MessageBoxResult.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> that contains a MessageBoxResult.
        /// </returns>
        /// <exception cref="UnauthorizedAccessException">
        /// Another MessageDialog is already opened.
        /// </exception>
        public async Task<MessageBoxResult> ShowMessageDialogAsync()
        {
            if (MessageDialogManager.IsAnyMessageDialogOpened())
                throw new UnauthorizedAccessException("Another MessageDialog is already opened.");

            var keyboardNavigationMode = KeyboardNavigationMode.Cycle;
            var window = VisualTreeHelper.FindVisualParent<Window>(((Panel)this.Container.Parent));
            if (window != null)
            {
                keyboardNavigationMode = KeyboardNavigation.GetTabNavigation(window);
                KeyboardNavigation.SetTabNavigation(window, KeyboardNavigationMode.None);
                KeyboardNavigation.SetTabNavigation((ZolyMessageDialogContentPanel)Content, KeyboardNavigationMode.Cycle);
                ((ZolyMessageDialogContentPanel)Content).MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            }

            this._result = MessageBoxResult.Cancel;
            this._showMessageDialogTaskCompleteSource = new TaskCompletionSource<bool>();
            MessageDialogManager.SetCurrentMessageDialog(this);
            this.Visibility = Visibility.Visible;
            this.UpdateLayout();
            RaiseOpenedEvent(this);

            await this._showMessageDialogTaskCompleteSource.Task;

            this.Visibility = Visibility.Collapsed;
            MessageDialogManager.SetCurrentMessageDialog(null);

            if (window != null)
                KeyboardNavigation.SetTabNavigation(window, keyboardNavigationMode);

            RaiseClosedEvent(this);
            return _result;
        }

        /// <summary>
        /// The get result value.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/> corresponding to the result of the message (it can be anything, like what the user prompt for exemple).
        /// </returns>
        public object GetResultValue()
        {
            return ((ZolyMessageDialogContentPanel)Content).GetResult();
        }

        #endregion

        #region Implements

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            ((Panel)this.Container.Parent).Children.Remove(this);
            this._result = MessageBoxResult.None;
            this._showMessageDialogTaskCompleteSource = null;
        }

        #endregion
    }
}
