// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextBoxInputMaskBehavior.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the TextBoxInputMaskBehavior type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Behaviors.TextBoxInputMask
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interactivity;

    /// <summary>
    /// Provide a mask input for a TextBox.
    /// Mask Character  Accepts  Required?  
    /// 0  Digit (0-9)  Required  
    /// 9  Digit (0-9) or space  Optional  
    /// #  Digit (0-9) or space  Required  
    /// L  Letter (a-z, A-Z)  Required  
    /// ?  Letter (a-z, A-Z)  Optional  
    /// &  Any character  Required  
    /// C  Any character  Optional  
    /// A  Alphanumeric (0-9, a-z, A-Z)  Required  
    /// a  Alphanumeric (0-9, a-z, A-Z)  Optional  
    ///    Space separator  Required 
    /// .  Decimal separator  Required  
    /// ,  Group (thousands) separator  Required  
    /// :  Time separator  Required  
    /// /  Date separator  Required  
    /// $  Currency symbol  Required  
    ///
    /// In addition, the following characters have special meaning:
    ///
    /// Mask Character  Meaning  
    /// \  Escape: treat the next character in the mask as literal text rather than a mask symbol 
    /// </summary>
    public class TextBoxInputMaskBehavior : Behavior<TextBox>
    {
        #region Properties

        /// <summary>
        /// The input mask property.
        /// </summary>
        public static readonly DependencyProperty InputMaskProperty = DependencyProperty.Register("InputMask", typeof(string), typeof(TextBoxInputMaskBehavior), null);

        /// <summary>
        /// Gets or sets the input mask.
        /// </summary>
        public string InputMask
        {
            get { return (string)this.GetValue(InputMaskProperty); }
            set { this.SetValue(InputMaskProperty, value); }
        }

        /// <summary>
        /// The prompt char property.
        /// </summary>
        public static readonly DependencyProperty PromptCharProperty = DependencyProperty.Register("PromptChar", typeof(char), typeof(TextBoxInputMaskBehavior), new PropertyMetadata('_'));

        /// <summary>
        /// Gets or sets the prompt char.
        /// </summary>
        public char PromptChar
        {
            get { return (char)this.GetValue(PromptCharProperty); }
            set { this.SetValue(PromptCharProperty, value); }
        }

        /// <summary>
        /// Gets the masked text provider.
        /// </summary>
        public MaskedTextProvider Provider { get; private set; }

        #endregion

        #region Overrides

        /// <summary>
        /// On attached.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += this.AssociatedObjectLoaded;
            this.AssociatedObject.PreviewTextInput += this.AssociatedObjectPreviewTextInput;
            this.AssociatedObject.PreviewKeyDown += this.AssociatedObjectPreviewKeyDown;

            DataObject.AddPastingHandler(this.AssociatedObject, this.Pasting);
        }

        /// <summary>
        /// On detaching.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Loaded -= this.AssociatedObjectLoaded;
            this.AssociatedObject.PreviewTextInput -= this.AssociatedObjectPreviewTextInput;
            this.AssociatedObject.PreviewKeyDown -= this.AssociatedObjectPreviewKeyDown;

            DataObject.RemovePastingHandler(this.AssociatedObject, this.Pasting);
        }

        #endregion

        #region Handled Methods

        /*
        Mask Character  Accepts  Required?  
        0  Digit (0-9)  Required  
        9  Digit (0-9) or space  Optional  
        #  Digit (0-9) or space  Required  
        L  Letter (a-z, A-Z)  Required  
        ?  Letter (a-z, A-Z)  Optional  
        &  Any character  Required  
        C  Any character  Optional  
        A  Alphanumeric (0-9, a-z, A-Z)  Required  
        a  Alphanumeric (0-9, a-z, A-Z)  Optional  
           Space separator  Required 
        .  Decimal separator  Required  
        ,  Group (thousands) separator  Required  
        :  Time separator  Required  
        /  Date separator  Required  
        $  Currency symbol  Required  

        In addition, the following characters have special meaning:

        Mask Character  Meaning  
        <  All subsequent characters are converted to lower case  
        >  All subsequent characters are converted to upper case  
        |  Terminates a previous < or >  
        \  Escape: treat the next character in the mask as literal text rather than a mask symbol  

        */

        /// <summary>
        /// The associated object loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AssociatedObjectLoaded(object sender, RoutedEventArgs e)
        {
            this.Provider = new MaskedTextProvider(this.InputMask, CultureInfo.CurrentCulture);
            this.Provider.Set(this.AssociatedObject.Text);
            this.Provider.PromptChar = this.PromptChar;
            this.AssociatedObject.Text = this.Provider.ToDisplayString();

            //seems the only way that the text is formatted correct, when source is updated
            var textProp = DependencyPropertyDescriptor.FromProperty(TextBox.TextProperty, typeof(TextBox));
            if (textProp != null)
                textProp.AddValueChanged(this.AssociatedObject, (s, args) => this.UpdateText());
        }

        /// <summary>
        /// The associated object preview text input.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AssociatedObjectPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            this.TreatSelectedText();

            var position = this.GetNextCharacterPosition(this.AssociatedObject.SelectionStart);

            if (Keyboard.IsKeyToggled(Key.Insert))
            {
                if (this.Provider.Replace(e.Text, position))
                    position++;
            }
            else
            {
                if (this.Provider.InsertAt(e.Text, position))
                    position++;
            }

            position = this.GetNextCharacterPosition(position);

            this.RefreshText(position);

            e.Handled = true;
        }

        /// <summary>
        /// The associated object preview key down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AssociatedObjectPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                this.TreatSelectedText();

                var position = this.GetNextCharacterPosition(this.AssociatedObject.SelectionStart);

                if (this.Provider.InsertAt(" ", position))
                    this.RefreshText(position);

                e.Handled = true;
            }

            if (e.Key == Key.Back)
            {
                if (this.TreatSelectedText())
                    this.RefreshText(this.AssociatedObject.SelectionStart);
                else if (this.AssociatedObject.SelectionStart != 0)
                {
                    if (this.Provider.RemoveAt(this.AssociatedObject.SelectionStart - 1))
                        this.RefreshText(this.AssociatedObject.SelectionStart - 1);
                }

                e.Handled = true;
            }

            if (e.Key == Key.Delete)
            {
                if (this.TreatSelectedText())
                    this.RefreshText(this.AssociatedObject.SelectionStart);
                else
                {
                    if (this.Provider.RemoveAt(this.AssociatedObject.SelectionStart))
                        this.RefreshText(this.AssociatedObject.SelectionStart);
                }

                e.Handled = true;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// When pasting a text
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = (string)e.DataObject.GetData(typeof(string));

                this.TreatSelectedText();

                var position = this.GetNextCharacterPosition(this.AssociatedObject.SelectionStart);

                if (this.Provider.InsertAt(pastedText, position))
                    this.RefreshText(position);
            }

            e.CancelCommand();
        }

        /// <summary>
        /// Update text.
        /// </summary>
        private void UpdateText()
        {
            if (this.Provider.ToDisplayString().Equals(this.AssociatedObject.Text))
                return;

            var success = this.Provider.Set(this.AssociatedObject.Text);

            this.SetText(success ? this.Provider.ToDisplayString() : this.AssociatedObject.Text);
        }

        /// <summary>
        /// Refresh text.
        /// </summary>
        /// <param name="position">
        /// The position.
        /// </param>
        private void RefreshText(int position)
        {
            this.SetText(this.Provider.ToDisplayString());
            this.AssociatedObject.SelectionStart = position;
        }

        /// <summary>
        /// Set the text of the textBox.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        private void SetText(string text)
        {
            this.AssociatedObject.Text = String.IsNullOrWhiteSpace(text) ? String.Empty : text;
        }

        #endregion

        #region Functions

        private bool TreatSelectedText()
        {
            if (this.AssociatedObject.SelectionLength > 0)
                return this.Provider.RemoveAt(this.AssociatedObject.SelectionStart, this.AssociatedObject.SelectionStart + this.AssociatedObject.SelectionLength - 1);
            return false;
        }

        private int GetNextCharacterPosition(int startPosition)
        {
            var position = this.Provider.FindEditPositionFrom(startPosition, true);

            if (position == -1)
                return startPosition;
            return position;
        }

        #endregion
    }
}
