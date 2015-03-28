// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanToThicknessConverter.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the BooleanToThicknessConverter type.
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
    /// The boolean to thickness converter.
    /// </summary>
    public class BooleanToThicknessConverter : IValueConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanToThicknessConverter"/> class.
        /// </summary>
        public BooleanToThicknessConverter()
        {
            True = new Thickness(1);
            False = new Thickness(0);
        }

        /// <summary>
        /// Gets or sets the thickness to return when the value is True.
        /// </summary>
        public Thickness True { get; set; }

        /// <summary>
        /// Gets or sets the thickness to return when the value is False.
        /// </summary>
        public Thickness False { get; set; }

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
        /// Thickness value needed for True property
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thickness value needed
        /// </exception>
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
