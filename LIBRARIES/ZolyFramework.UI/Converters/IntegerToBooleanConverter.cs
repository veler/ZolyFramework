// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntegerToBooleanConverter.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the IntegerToBooleanConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// The integer to boolean converter.
    /// </summary>
    public class IntegerToBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerToBooleanConverter"/> class.
        /// </summary>
        public IntegerToBooleanConverter()
        {
            this.ResultValue = false;
            this.Value = 0;
        }

        /// <summary>
        /// Gets or sets a value indicating whether result value is True or False when the Value property is equal to the binded value.
        /// </summary>
        public bool ResultValue { get; set; }

        /// <summary>
        /// Gets or sets the value used to check if the binded value if correct or not.
        /// </summary>
        public int Value { get; set; }

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
        /// Integer value needed
        /// </exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
                return (int)value == this.Value ? this.ResultValue : !this.ResultValue;
            throw new ArgumentException("Integer value needed", "value");
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
