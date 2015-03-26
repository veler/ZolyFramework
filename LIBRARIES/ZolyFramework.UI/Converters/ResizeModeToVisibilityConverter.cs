using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ZolyFramework.UI.Converters
{
    public class ResizeModeToVisibilityConverter : IValueConverter
    {
        public ResizeModeToVisibilityConverter()
        {
            CanMinimize = Visibility.Visible;
            NoResize = Visibility.Collapsed;
            CanResize = Visibility.Visible;
            CanResizeWithGrip = Visibility.Visible;
        }

        public Visibility CanMinimize { get; set; }
        public Visibility NoResize { get; set; }
        public Visibility CanResize { get; set; }
        public Visibility CanResizeWithGrip { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ResizeMode)
                switch ((ResizeMode)value)
                {
                    case ResizeMode.CanMinimize:
                        return CanMinimize;
                    case ResizeMode.NoResize:
                        return NoResize;
                    case ResizeMode.CanResize:
                        return CanResize;
                    case ResizeMode.CanResizeWithGrip:
                        return CanResizeWithGrip;
                }
            throw new ArgumentException("ResizeMode value needed", "value");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
