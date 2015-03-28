// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowStateToThicknessConverter.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the WindowStateToThicknessConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// The window state to thickness converter.
    /// </summary>
    public class WindowStateToThicknessConverter : IValueConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowStateToThicknessConverter"/> class.
        /// </summary>
        public WindowStateToThicknessConverter()
        {
            Maximized = new Thickness(0);
            Minimized = new Thickness(1);
            Normal = new Thickness(1);
        }

        /// <summary>
        /// Gets or sets the thickness to return when the WindowsState is on Maximized.
        /// </summary>
        public Thickness Maximized { get; set; }

        /// <summary>
        /// Gets or sets the thickness to return when the WindowsState is on Minimized.
        /// </summary>
        public Thickness Minimized { get; set; }

        /// <summary>
        /// Gets or sets the thickness to return when the WindowsState is on Normal.
        /// </summary>
        public Thickness Normal { get; set; }

        /// <summary>
        /// The convert.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// WindowState value needed
        /// </exception>
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

        /// <summary>
        /// (Not supported) The convert back.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="targetType">
        /// The target type.
        /// </param>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <param name="culture">
        /// The culture.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// Not supported
        /// </exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
