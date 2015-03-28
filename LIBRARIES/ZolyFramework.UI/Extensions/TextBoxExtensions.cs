// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextBoxExtensions.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the TextBoxExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Extensions
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Extension for text box
    /// </summary>
    public class TextBoxExtensions : DependencyObject
    {
        #region Properties

        /// <summary>
        /// Set or Get if a text box is numeric only or not
        /// </summary>
        public static readonly DependencyProperty IsNumericProperty = DependencyProperty.RegisterAttached("IsNumeric", typeof(bool), typeof(TextBoxExtensions), new PropertyMetadata(false, OnIsNumericChanged));

        #endregion

        #region Getters/Setters

        /// <summary>
        /// Returns a value that define if the specified text box is numeric
        /// </summary>
        /// <param name="obj">the TextBox</param>
        /// <returns>True if it is numeric</returns>
        public static bool GetIsNumeric(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsNumericProperty);
        }

        /// <summary>
        /// Set if a text box is numeric
        /// </summary>
        /// <param name="obj">the text box</param>
        /// <param name="value">True if it is numeric</param>
        public static void SetIsNumeric(DependencyObject obj, bool value)
        {
            obj.SetValue(IsNumericProperty, value);
        }

        #endregion

        #region Methods

        /// <summary>
        /// On IsNumeric changed.
        /// </summary>
        /// <param name="d">
        /// The text box.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private static void OnIsNumericChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;
            if (textBox == null)
                return;

            if ((bool)e.OldValue && !((bool)e.NewValue))
                textBox.PreviewTextInput -= TextboxPreviewTextInput;
            if ((bool)e.NewValue)
            {
                textBox.PreviewTextInput += TextboxPreviewTextInput;
                textBox.PreviewKeyDown += TextboxPreviewKeyDown;
            }
        }

        #endregion

        #region Handled Methods

        /// <summary>
        /// The textbox preview key down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void TextboxPreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        /// <summary>
        /// The textbox preview text input.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void TextboxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var newChar = e.Text[0];
            e.Handled = !Char.IsNumber(newChar);
        }

        #endregion
    }
}
