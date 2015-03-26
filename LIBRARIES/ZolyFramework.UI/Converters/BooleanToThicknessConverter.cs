using System;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ZolyFramework.UI.Converters
{
    public class BooleanToThicknessConverter : IValueConverter
    {
        public BooleanToThicknessConverter()
        {
            True = new Thickness(1);
            False = new Thickness(0);
        }

        public Thickness True { get; set; }
        public Thickness False { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
                return ((bool)value) ? True : False;
            throw new ArgumentException("Boolean value needed", "value");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (True == null)
                throw new NoNullAllowedException("Thickness value needed for True property");
            if (value is Thickness)
                return (Thickness)value == True;
            throw new ArgumentException("Thickness value needed", "value");
        }
    }
}
