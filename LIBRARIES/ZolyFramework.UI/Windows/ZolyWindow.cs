using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using ZolyFramework.UI.Themes;

namespace ZolyFramework.UI.Windows
{
    public class ZolyWindow : ResponsiveWindow
    {
        #region Fields

        private ThemeManager _themeManager = new ThemeManager();
        private int _clickNumber;

        private readonly Timer _timer = new Timer();

        #endregion

        #region Properties

        public static readonly DependencyProperty ShowBorderProperty = DependencyProperty.Register("ShowBorder", typeof(bool), typeof(ZolyWindow), new FrameworkPropertyMetadata(true));
        public bool ShowBorder
        {
            get { return (bool)GetValue(ShowBorderProperty); }
            set { SetValue(ShowBorderProperty, value); }
        }

        public static readonly DependencyProperty DraggableZoneGridProperty = DependencyProperty.Register("DraggableZoneGrid", typeof(Grid), typeof(ZolyWindow), new FrameworkPropertyMetadata(null));
        public Grid DraggableZoneGrid
        {
            get { return (Grid)GetValue(DraggableZoneGridProperty); }
            set { SetValue(DraggableZoneGridProperty, value); }
        }

        public static readonly DependencyProperty CloseButtonProperty = DependencyProperty.Register("CloseButton", typeof(Button), typeof(ZolyWindow), new FrameworkPropertyMetadata(null));
        public Button CloseButton
        {
            get { return (Button)GetValue(CloseButtonProperty); }
            set { SetValue(CloseButtonProperty, value); }
        }

        #endregion

        #region Constructor

        public ZolyWindow()
        {
            DefaultStyleKey = typeof(ZolyWindow);

            _timer.Elapsed += Timer_Elapsed;

            SourceInitialized += ZolyWindow_SourceInitialized;
            Loaded += ZolyWindow_Loaded;
        }

        #endregion

        #region Handles Methods

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            _clickNumber = 0;
        }

        private void ZolyWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var minimizeButton = (Button)Template.FindName("MinimizeButton", this);
            var restoreButton = (Button)Template.FindName("RestoreButton", this);
            var maximizeButton = (Button)Template.FindName("MaximizeButton", this);
            CloseButton = (Button)Template.FindName("CloseButton", this);

            for (var i = 1; i <= 8; i++)
                ((Thumb)Template.FindName("Thumb" + i, this)).DragDelta += Thumb_DragDelta;

            if (DraggableZoneGrid == null)
                DraggableZoneGrid = (Grid)Template.FindName("DragZoneGrid", this);
            if (DraggableZoneGrid.Background == null)
                DraggableZoneGrid.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

            CloseButton.Click += CloseButton_Click;
            minimizeButton.Click += MinimizeButton_Click;
            restoreButton.Click += RestoreButton_Click;
            maximizeButton.Click += MaximizeButton_Click;
            DraggableZoneGrid.MouseDown += DraggableZoneGrid_MouseDown;
            DraggableZoneGrid.MouseRightButtonUp += DraggableZoneGrid_MouseRightButtonUp;
        }

        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (ResizeMode == ResizeMode.CanMinimize || ResizeMode == ResizeMode.NoResize)
                return;

            var thumb = (Thumb)sender;
            var direction = (string)thumb.Tag;
            try
            {
                if (direction.Contains("T") || direction.Contains("B"))
                    if (Height > MinHeight)
                    {
                        if (direction.Contains("T"))
                        {
                            Height -= e.VerticalChange;
                            Top += e.VerticalChange;
                        }
                        else
                            Height += e.VerticalChange;
                    }
                    else
                    {
                        Height = MinHeight + 8;
                        thumb.ReleaseMouseCapture();
                    }

                if (direction.Contains("L") || direction.Contains("R"))
                    if (Width > MinWidth)
                    {
                        if (direction.Contains("L"))
                        {
                            Width -= e.HorizontalChange;
                            Left += e.HorizontalChange;
                        }
                        else
                            Width += e.HorizontalChange;
                    }
                    else
                    {
                        Width = Width + 8;
                        thumb.ReleaseMouseCapture();
                    }

                e.Handled = true;
            }
            catch (Exception)
            {
                e.Handled = false;
                thumb.ReleaseMouseCapture();
            }
        }

        private void ZolyWindow_SourceInitialized(object sender, EventArgs e)
        {
            var handle = (new WindowInteropHelper(this)).Handle;
            var hwndSource = HwndSource.FromHwnd(handle);
            if (hwndSource != null)
                hwndSource.AddHook(ZolyFramework.Core.Win32.Wm.WindowProc);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }

        private void DraggableZoneGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                _clickNumber++;
                if (!_timer.Enabled)
                {
                    _timer.Interval = Core.Win32.User32.GetDoubleClickTime(); // Set the double click time equal to system's setting.
                    _timer.Start();
                }
                else if (_clickNumber == 2 && (ResizeMode == ResizeMode.CanResize || ResizeMode == ResizeMode.CanResizeWithGrip))
                    WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;

                DragMove();
            }
        }

        private void DraggableZoneGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Core.Win32.Wm.ShowWindowSystemMenu(this);
        }

        #endregion
    }
}