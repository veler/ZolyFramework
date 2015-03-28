// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyPasswordBox.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyPasswordBox type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    /// The zoly password box.
    /// </summary>
    public class ZolyPasswordBox : TextBox
    {
        #region Fields

        private ZolyFlatButton _viewPasswordZolyFlatButton;

        private TextBlock _placeHolderTextBlock;

        private int _tempCaretIndex;

        [SecurityCritical]
        private SecureString _password;

        #endregion

        #region Properties

        /// <summary>
        /// The place holder property.
        /// </summary>
        public static readonly DependencyProperty PlaceHolderProperty = DependencyProperty.Register("PlaceHolder", typeof(string), typeof(ZolyPasswordBox), new FrameworkPropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the water mark.
        /// </summary>
        public string PlaceHolder
        {
            get { return (string)this.GetValue(PlaceHolderProperty); }
            set { this.SetValue(PlaceHolderProperty, value); }
        }

        /// <summary>
        /// The place holder foreground property.
        /// </summary>
        public static readonly DependencyProperty PlaceHolderForegroundProperty = DependencyProperty.Register("PlaceHolderForeground", typeof(Brush), typeof(ZolyPasswordBox), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the place holder foreground.
        /// </summary>
        public Brush PlaceHolderForeground
        {
            get { return (Brush)this.GetValue(PlaceHolderForegroundProperty); }
            set { this.SetValue(PlaceHolderForegroundProperty, value); }
        }

        /// <summary>
        /// The password char property.
        /// </summary>
        public static readonly DependencyProperty PasswordCharProperty = DependencyProperty.Register("PasswordChar", typeof(char), typeof(ZolyPasswordBox), new FrameworkPropertyMetadata('•'));

        /// <summary>
        /// Gets or sets the password char.
        /// </summary>
        public char PasswordChar
        {
            [SecurityCritical]
            get { return (char)this.GetValue(PasswordCharProperty); }
            [SecurityCritical]
            set
            {
                this.SetValue(PasswordCharProperty, value);
                base.Text = new string(value, this._password.Length);
            }
        }

        /// <summary>
        /// The can see password property.
        /// </summary>
        public static readonly DependencyProperty CanSeePasswordProperty = DependencyProperty.Register("CanSeePassword", typeof(bool), typeof(ZolyPasswordBox), new FrameworkPropertyMetadata(true));

        /// <summary>
        /// Gets or sets a value indicating whether can see password thanks to a button.
        /// </summary>
        public bool CanSeePassword
        {
            [SecurityCritical]
            get { return (bool)this.GetValue(CanSeePasswordProperty); }
            [SecurityCritical]
            set { this.SetValue(CanSeePasswordProperty, value); }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password
        {
            [SecurityCritical]
            get
            {
                if (this._password == null)
                    return string.Empty;

                var unmanagedString = IntPtr.Zero;
                try
                {
                    unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(this._password);
                    return Marshal.PtrToStringUni(unmanagedString);
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
                }
            }
            [SecurityCritical]
            set
            {
                if (value == null)
                    value = String.Empty;

                var securePassword = new SecureString();
                foreach (var t in value.ToCharArray())
                    securePassword.AppendChar(t);

                this._password = securePassword;
                base.Text = new string(this.PasswordChar, value.Length);
            }
        }

        /// <summary>
        /// The text property.
        /// </summary>
        [Browsable(false),
        EditorBrowsable(EditorBrowsableState.Never)]
        private static new readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(ZolyPasswordBox), new FrameworkPropertyMetadata(string.Empty));

        /// <summary>
        /// Sets the text.
        /// </summary>
        /// <exception cref="NotSupportedException">
        /// Unable to set this property manually
        /// </exception>
        [Browsable(false),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new string Text
        {
            set
            {
                this.SetValue(TextProperty, string.Empty);
                throw new NotSupportedException();
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyPasswordBox"/> class.
        /// </summary>
        public ZolyPasswordBox()
        {
            this.DefaultStyleKey = typeof(ZolyPasswordBox);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// The on apply template.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this._viewPasswordZolyFlatButton = (ZolyFlatButton)Template.FindName("ViewPasswordZolyFlatButton", this);
            this._placeHolderTextBlock = (TextBlock)Template.FindName("PlaceHolderTextBlock", this);

            this._viewPasswordZolyFlatButton.PreviewMouseDown += this.ViewPasswordZolyFlatButtonMouseDown;
            this._viewPasswordZolyFlatButton.PreviewMouseUp += this.ViewPasswordZolyFlatButtonMouseUp;

            this.TextChanged += this.ZolyPasswordBoxTextChanged;
            this.GotFocus += this.ZolyPasswordBoxGotFocus;
            this.LostFocus += this.ZolyPasswordBoxLostFocus;
            this.GotKeyboardFocus += this.ZolyPasswordBoxGotKeyboardFocus;
            this.LostKeyboardFocus += this.ZolyPasswordBoxLostKeyboardFocus;
            this.PreviewKeyDown += this.ZolyPasswordBoxPreviewKeyDown;
            this.PreviewTextInput += this.ZolyPasswordBoxPreviewTextInput;

            CommandManager.AddPreviewCanExecuteHandler(this, this.HandleCanExecute);
            DataObject.AddPastingHandler(this, this.OnPaste);

            this.ZolyPasswordBoxTextChanged(this, null);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The insert text.
        /// </summary>
        /// <param name="text">
        /// The text to insert.
        /// </param>
        private void InsertText(string text)
        {
            if (text == null)
                text = string.Empty;

            var newCaret = this.CaretIndex;
            var password = this.Password;
            var selectionLength = this.SelectionLength;
            if (selectionLength > 0)
            {
                password = password.Remove(this.CaretIndex, selectionLength);
                this.CaretIndex = newCaret;
            }

            this.Password = password.Insert(this.CaretIndex, text);
            newCaret += text.Length;
            this.CaretIndex = newCaret;
        }

        #endregion

        #region Handled Methods

        /// <summary>
        /// The handle can execute.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void HandleCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Cut || e.Command == ApplicationCommands.Copy || e.Command == ApplicationCommands.Redo || e.Command == ApplicationCommands.Undo)
            {
                e.CanExecute = false;
                e.Handled = true;
            }
        }

        /// <summary>
        /// The on paste.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            var isText = e.SourceDataObject.GetDataPresent(DataFormats.Text, true);
            if (!isText) 
                return;

            var text = e.SourceDataObject.GetData(DataFormats.Text) as string;
            this.InsertText(text);
            e.Handled = true;
            e.CancelCommand();
        }

        /// <summary>
        /// The view password zoly flat button mouse down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ViewPasswordZolyFlatButtonMouseDown(object sender, MouseButtonEventArgs e)
        {
            this._tempCaretIndex = this.CaretIndex;
            base.Text = this.Password;
            this.CaretIndex = this._tempCaretIndex;
        }

        /// <summary>
        /// The view password zoly flat button mouse up.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ViewPasswordZolyFlatButtonMouseUp(object sender, MouseButtonEventArgs e)
        {
            base.Text = new string(this.PasswordChar, this._password.Length);
            this.CaretIndex = this._tempCaretIndex;
        }

        /// <summary>
        /// The zoly password box lost keyboard focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyPasswordBoxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.ZolyPasswordBoxLostFocus(sender, null);
        }

        /// <summary>
        /// The zoly password box got keyboard focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyPasswordBoxGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.ZolyPasswordBoxGotFocus(sender, null);
        }

        /// <summary>
        /// The zoly password box lost focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyPasswordBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(base.Text))
                this._placeHolderTextBlock.Visibility = Visibility.Visible;
            else
                this._placeHolderTextBlock.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// The zoly password box got focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyPasswordBoxGotFocus(object sender, RoutedEventArgs e)
        {
            this._placeHolderTextBlock.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// The zoly password box text changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyPasswordBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(base.Text) && !DesignerProperties.GetIsInDesignMode(this))
                this._viewPasswordZolyFlatButton.Visibility = Visibility.Collapsed;
            else
                this._viewPasswordZolyFlatButton.Visibility = Visibility.Visible;

            if (this.IsFocused || this.IsKeyboardFocused)
                this.ZolyPasswordBoxGotFocus(sender, null);
            else
                this.ZolyPasswordBoxLostFocus(sender, null);
        }

        /// <summary>
        /// The zoly password box preview text input.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyPasswordBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            this.InsertText(e.Text);
            e.Handled = true;
        }

        /// <summary>
        /// The zoly password box preview key down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyPasswordBoxPreviewKeyDown(object sender, KeyEventArgs e)
        {
            var newCaret = this.CaretIndex;
            var password = this.Password;
            var selectionLength = this.SelectionLength;

            if (this.CaretIndex < 0 || this.CaretIndex > password.Length)
                return;
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
                return;

            if (e.Key == Key.Delete && this.CaretIndex < password.Length)
            {
                if (selectionLength == 0)
                    selectionLength = 1;
                this.Password = password.Remove(this.CaretIndex, selectionLength);
                this.CaretIndex = newCaret;
                e.Handled = true;
            }
            else if (e.Key == Key.Back && this.CaretIndex >= 0)
            {
                if (selectionLength == 0 && this.CaretIndex > 0)
                {
                    newCaret--;
                    selectionLength = 1;
                }
                this.Password = password.Remove(newCaret, selectionLength);
                this.CaretIndex = newCaret;
                e.Handled = true;
            }
            else if ((e.Key == Key.Enter || e.Key == Key.Return) && !this.AcceptsReturn)
                e.Handled = true;
            else if (e.Key == Key.Space)
            {
                // special case. PreviewTextInput is not fired with a space
                e.Handled = true;
                this.InsertText(" ");
            }
        }

        #endregion
    }
}
