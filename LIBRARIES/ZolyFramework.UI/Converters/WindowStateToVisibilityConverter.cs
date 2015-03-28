// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WindowStateToVisibilityConverter.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the WindowStateToVisibilityConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// The window state to visibility converter.
    /// </summary>
    public class WindowStateToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowStateToVisibilityConverter"/> class.
        /// </summary>
        public WindowStateToVisibilityConverter()
        {
            Maximized = Visibility.Collapsed;
            Minimized = Visibility.Visible;
            Normal = Visibility.Visible;
        }

        /// <summary>
        /// Gets or sets the visibility to return when the WindowsState is on Maximized.
        /// </summary>
        public Visibility Maximized { get; set; }

        /// <summary>
        /// Gets or sets the visibility to return when the WindowsState is on Minimized.
        /// </summary>
        public Visibility Minimized { get; set; }

        /// <summary>
        /// Gets or sets the visibility to return when the WindowsState is on Normal.
        /// </summary>
        public Visibility Normal { get; set; }

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
