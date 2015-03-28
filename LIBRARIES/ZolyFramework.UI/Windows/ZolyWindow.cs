// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyWindow.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyWindow type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows
{
    using System;
    using System.Timers;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Interop;
    using System.Windows.Media;

    using ZolyFramework.UI.ComponentModel;

    /// <summary>
    /// The zoly window.
    /// </summary>
    public class ZolyWindow : ResponsiveWindow
    {
        #region Fields

        private int _clickNumber;

        private readonly Timer _timer = new Timer();

        #endregion

        #region Properties

        /// <summary>
        /// The show border property.
        /// </summary>
        public static readonly DependencyProperty ShowBorderProperty = DependencyProperty.Register("ShowBorder", typeof(bool), typeof(ZolyWindow), new FrameworkPropertyMetadata(true));

        /// <summary>
        /// Gets or sets a value indicating whether show border.
        /// </summary>
        public bool ShowBorder
        {
            get { return (bool)this.GetValue(ShowBorderProperty); }
            set { this.SetValue(ShowBorderProperty, value); }
        }

        /// <summary>
        /// The draggable zone grid property.
        /// </summary>
        public static readonly DependencyProperty DraggableZoneGridProperty = DependencyProperty.Register("DraggableZoneGrid", typeof(Grid), typeof(ZolyWindow), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the draggable zone grid.
        /// </summary>
        public Grid DraggableZoneGrid
        {
            get { return (Grid)this.GetValue(DraggableZoneGridProperty); }
            set { this.SetValue(DraggableZoneGridProperty, value); }
        }

        /// <summary>
        /// The close button property.
        /// </summary>
        public static readonly DependencyProperty CloseButtonProperty = DependencyProperty.Register("CloseButton", typeof(Button), typeof(ZolyWindow), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the close button.
        /// </summary>
        private Button CloseButton
        {
            get { return (Button)this.GetValue(CloseButtonProperty); }
            set { this.SetValue(CloseButtonProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyWindow"/> class.
        /// </summary>
        public ZolyWindow()
        {
            this.DefaultStyleKey = typeof(ZolyWindow);

            this._timer.Elapsed += this.TimerElapsed;

            this.SourceInitialized += this.ZolyWindowSourceInitialized;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// The on apply template.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var minimizeButton = (Button)Template.FindName("MinimizeButton", this);
            var restoreButton = (Button)Template.FindName("RestoreButton", this);
            var maximizeButton = (Button)Template.FindName("MaximizeButton", this);
            this.CloseButton = (Button)Template.FindName("CloseButton", this);

            for (var i = 1; i <= 8; i++)
                ((Thumb)Template.FindName("Thumb" + i, this)).DragDelta += this.ThumbDragDelta;

            if (this.DraggableZoneGrid == null)
                this.DraggableZoneGrid = (Grid)this.Template.FindName("DragZoneGrid", this);
            if (this.DraggableZoneGrid.Background == null)
                this.DraggableZoneGrid.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

            this.CloseButton.Click += this.CloseButtonClick;
            minimizeButton.Click += this.MinimizeButtonClick;
            restoreButton.Click += this.RestoreButtonClick;
            maximizeButton.Click += this.MaximizeButtonClick;
            this.DraggableZoneGrid.MouseDown += this.DraggableZoneGridMouseDown;
            this.DraggableZoneGrid.MouseRightButtonUp += this.DraggableZoneGridMouseRightButtonUp;
            this.Closing += this.ZolyWindowClosing;
            this.Closed += ZolyWindowClosed;
        }

        #endregion

        #region Handles Methods

        /// <summary>
        /// The zoly window source initialized.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyWindowSourceInitialized(object sender, EventArgs e)
        {
            var handle = (new WindowInteropHelper(this)).Handle;
            var hwndSource = HwndSource.FromHwnd(handle);
            if (hwndSource != null)
                hwndSource.AddHook(Core.Win32.Wm.WindowProc);
        }

        /// <summary>
        /// The zoly window closing.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageDialogManager.IsAnyMessageDialogOpened())
            {
                MessageDialogManager.GetCurrentMessageDialog().CancelAndClose();
                e.Cancel = true;
            }
            else if (FlyoutManager.IsAnyFlyoutOpened())
            {
                FlyoutManager.GetCurrentFlyout().Close();
                e.Cancel = true;
            }
        }

        /// <summary>
        /// The zoly window closed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyWindowClosed(object sender, EventArgs e)
        {
            this._timer.Elapsed -= this.TimerElapsed;
            this._timer.Stop();
        }

        /// <summary>
        /// The timer elapsed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            this._timer.Stop();
            this._clickNumber = 0;
        }

        /// <summary>
        /// The thumb drag delta.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ThumbDragDelta(object sender, DragDeltaEventArgs e)
        {
            if (this.ResizeMode == ResizeMode.CanMinimize || this.ResizeMode == ResizeMode.NoResize)
                return;

            var thumb = (Thumb)sender;
            var direction = (string)thumb.Tag;
            try
            {
                if (direction.Contains("T") || direction.Contains("B"))
                    if (this.Height > this.MinHeight)
                    {
                        if (direction.Contains("T"))
                        {
                            this.Height -= e.VerticalChange;
                            this.Top += e.VerticalChange;
                        }
                        else
                            this.Height += e.VerticalChange;
                    }
                    else
                    {
                        this.Height = this.MinHeight + 16;
                        thumb.ReleaseMouseCapture();
                    }

                if (direction.Contains("L") || direction.Contains("R"))
                    if (this.Width > this.MinWidth)
                    {
                        if (direction.Contains("L"))
                        {
                            this.Width -= e.HorizontalChange;
                            this.Left += e.HorizontalChange;
                        }
                        else
                            this.Width += e.HorizontalChange;
                    }
                    else
                    {
                        this.Width = this.Width + 16;
                        thumb.ReleaseMouseCapture();
                    }

                e.Handled = true;
            }
            catch (Exception)
            {
                e.Handled = false;
                thumb.ReleaseMouseCapture();
            }

            if (this.Height < this.MinHeight)
                this.Height = this.MinHeight;
            if (this.Width < this.MinWidth)
                this.Width = this.MinWidth;
        }

        /// <summary>
        /// The close button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// The minimize button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// The restore button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void RestoreButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        /// <summary>
        /// The maximize button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void MaximizeButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        /// <summary>
        /// The draggable zone grid mouse down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void DraggableZoneGridMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this._clickNumber++;
                if (!this._timer.Enabled)
                {
                    this._timer.Interval = Core.Win32.User32.GetDoubleClickTime(); // Set the double click time equal to system's setting.
                    this._timer.Start();
                }
                else if (this._clickNumber == 2 && (this.ResizeMode == ResizeMode.CanResize || this.ResizeMode == ResizeMode.CanResizeWithGrip))
                    this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

                this.DragMove();
            }
        }

        /// <summary>
        /// The draggable zone grid mouse right button up.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void DraggableZoneGridMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Core.Win32.Wm.ShowWindowSystemMenu(this);
        }

        #endregion
    }
}