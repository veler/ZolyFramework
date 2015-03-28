// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyTextBox.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyTextBox type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    /// The zoly text box.
    /// </summary>
    public class ZolyTextBox : TextBox
    {
        #region Fields

        private Viewbox _clearViewbox;

        private Grid _clearClickableZone;

        private TextBlock _placeHolderTextBlock;

        #endregion

        #region Properties

        /// <summary>
        /// The can clear property.
        /// </summary>
        public static readonly DependencyProperty CanClearProperty = DependencyProperty.Register("CanClear", typeof(bool), typeof(ZolyTextBox), new FrameworkPropertyMetadata(true));

        /// <summary>
        /// Gets or sets a value indicating whether can clear the text box.
        /// </summary>
        public bool CanClear
        {
            get { return (bool)this.GetValue(CanClearProperty); }
            set
            {
                this.SetValue(CanClearProperty, value);
                this.ZolyTextBoxTextChanged(this, null);
            }
        }

        /// <summary>
        /// The place holder property.
        /// </summary>
        public static readonly DependencyProperty PlaceHolderProperty = DependencyProperty.Register("PlaceHolder", typeof(string), typeof(ZolyTextBox), new FrameworkPropertyMetadata(string.Empty));

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
        public static readonly DependencyProperty PlaceHolderForegroundProperty = DependencyProperty.Register("PlaceHolderForeground", typeof(Brush), typeof(ZolyTextBox), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the place holder foreground.
        /// </summary>
        public Brush PlaceHolderForeground
        {
            get { return (Brush)this.GetValue(PlaceHolderForegroundProperty); }
            set { this.SetValue(PlaceHolderForegroundProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyTextBox"/> class.
        /// </summary>
        public ZolyTextBox()
        {
            this.DefaultStyleKey = typeof(ZolyTextBox);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// The on apply template.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this._clearViewbox = (Viewbox)Template.FindName("ClearViewbox", this);
            this._clearClickableZone = (Grid)Template.FindName("ClearClickableZone", this);
            this._placeHolderTextBlock = (TextBlock)Template.FindName("PlaceHolderTextBlock", this);

            this._clearClickableZone.MouseUp += this.ClearClickableZoneMouseUp;

            this.TextChanged += this.ZolyTextBoxTextChanged;
            this.GotFocus += this.ZolyTextBoxGotFocus;
            this.LostFocus += this.ZolyTextBoxLostFocus;
            this.GotKeyboardFocus += this.ZolyTextBoxGotKeyboardFocus;
            this.LostKeyboardFocus += this.ZolyTextBoxLostKeyboardFocus;

            this.ZolyTextBoxTextChanged(this, null);
        }

        #endregion

        #region Handled Methods

        /// <summary>
        /// The zoly text box lost keyboard focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyTextBoxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.ZolyTextBoxLostFocus(sender, null);
        }

        /// <summary>
        /// The zoly text box got keyboard focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyTextBoxGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.ZolyTextBoxGotFocus(sender, null);
        }

        /// <summary>
        /// The zoly text box lost focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            this._clearViewbox.Visibility = Visibility.Collapsed;

            if (string.IsNullOrEmpty(this.Text))
                this._placeHolderTextBlock.Visibility = Visibility.Visible;
            else
                this._placeHolderTextBlock.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// The zoly text box got focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            this._placeHolderTextBlock.Visibility = Visibility.Collapsed;

            if (this.CanClear && !string.IsNullOrEmpty(this.Text) && !this.IsReadOnly && this.IsEnabled)
                this._clearViewbox.Visibility = Visibility.Visible;
            else
                this._clearViewbox.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// The zoly text box text changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsFocused || this.IsKeyboardFocused)
                this.ZolyTextBoxGotFocus(sender, null);
            else
                this.ZolyTextBoxLostFocus(sender, null);
        }

        /// <summary>
        /// The clear clickable zone mouse up.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ClearClickableZoneMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Text = null;
        }

        #endregion
    }
}
