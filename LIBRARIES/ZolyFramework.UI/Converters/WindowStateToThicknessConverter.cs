using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ZolyFramework.UI.Converters
{
    public class WindowStateToThicknessConverter : IValueConverter
    {
        public WindowStateToThicknessConverter()
        {
            Maximized = new Thickness(0);
            Minimized = new Thickness(1);
            Normal = new Thickness(1);
        }

        public Thickness Maximized { get; set; }
        public Thickness Minimized { get; set; }
        public Thickness Normal { get; set; }

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
