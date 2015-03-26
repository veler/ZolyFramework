using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ZolyFramework.UI.Converters
{
    public class WindowStateToVisibilityConverter : IValueConverter
    {
        public WindowStateToVisibilityConverter()
        {
            Maximized = Visibility.Collapsed;
            Minimized = Visibility.Visible;
            Normal = Visibility.Visible;
        }

        public Visibility Maximized { get; set; }
        public Visibility Minimized { get; set; }
        public Visibility Normal { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is WindowState)
                switch ((WindowState)value)
                {
                    case WindowState.Maximized:
                        return Maximized;
                    case WindowState.Minimized:
                        return Minimized;
                    case WindowState.Normal:
                        return Normal;
                }
            throw new ArgumentException("WindowState value needed", "value");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
