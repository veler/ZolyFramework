// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResizeModeToVisibilityConverter.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ResizeModeToVisibilityConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// The resize mode to visibility converter.
    /// </summary>
    public class ResizeModeToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResizeModeToVisibilityConverter"/> class.
        /// </summary>
        public ResizeModeToVisibilityConverter()
        {
            CanMinimize = Visibility.Visible;
            NoResize = Visibility.Collapsed;
            CanResize = Visibility.Visible;
            CanResizeWithGrip = Visibility.Visible;
        }

        /// <summary>
        /// Gets or sets the Visibility to apply when the ResizeMode is on CanMinimize.
        /// </summary>
        public Visibility CanMinimize { get; set; }

        /// <summary>
        /// Gets or sets the Visibility to apply when the ResizeMode is on NoResize.
        /// </summary>
        public Visibility NoResize { get; set; }

        /// <summary>
        /// Gets or sets the Visibility to apply when the ResizeMode is on CanResize.
        /// </summary>
        public Visibility CanResize { get; set; }

        /// <summary>
        /// Gets or sets the Visibility to apply when the ResizeMode is on CanResizeWithGrip.
        /// </summary>
        public Visibility CanResizeWithGrip { get; set; }

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
        /// ResizeMode value needed
        /// </exception>
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
