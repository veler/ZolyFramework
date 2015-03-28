// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToStyleConverter.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the BooleanToStyleConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Converters
{
    using System;
    using System.Data;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// The boolean to style converter.
    /// </summary>
    public class BooleanToStyleConverter : IValueConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanToStyleConverter"/> class.
        /// </summary>
        public BooleanToStyleConverter()
        {
            True = null;
            False = null;
        }

        /// <summary>
        /// Gets or sets the style to return when the value is True.
        /// </summary>
        public Style True { get; set; }

        /// <summary>
        /// Gets or sets the style to return when the value is False.
        /// </summary>
        public Style False { get; set; }

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
        /// <exception cref="NoNullAllowedException">
        /// Style value needed for True property
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Style value needed
        /// </exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (True == null)
                throw new NoNullAllowedException("Style value needed for True property");
            if (value is Style)
                return (Style)value == True;
            throw new ArgumentException("Style value needed", "value");
        }
    }
}
