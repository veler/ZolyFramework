// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToVerticalAlignmentConverter.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the BooleanToVerticalAlignmentConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// The boolean to vertical alignment converter.
    /// </summary>
    public class BooleanToVerticalAlignmentConverter : IValueConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanToVerticalAlignmentConverter"/> class.
        /// </summary>
        public BooleanToVerticalAlignmentConverter()
        {
            True = VerticalAlignment.Stretch;
            False = VerticalAlignment.Center;
        }

        /// <summary>
        /// Gets or sets the VerticalAlignment to return when the value is True.
        /// </summary>
        public VerticalAlignment True { get; set; }

        /// <summary>
        /// Gets or sets the VerticalAlignment to return when the value is False.
        /// </summary>
        public VerticalAlignment False { get; set; }

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
        /// Boolean value needed
        /// </exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
                return ((bool)value) ? True : False;
            throw new ArgumentException("Boolean value needed", "value");
        }

        /// <summary>
        /// The convert back.
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
        /// VerticalAlignment value needed
        /// </exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is VerticalAlignment)
                return (VerticalAlignment)value == True;
            throw new ArgumentException("VerticalAlignment value needed", "value");
        }
    }
}
