// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyComboBox.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyComboBox type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    /// The zoly combo box.
    /// </summary>
    public class ZolyComboBox : ComboBox
    {
        #region Fields

        private ToggleButton _placeHolderToggleButton;

        #endregion

        #region Properties

        /// <summary>
        /// The place holder property.
        /// </summary>
        public static readonly DependencyProperty PlaceHolderProperty = DependencyProperty.Register("PlaceHolder", typeof(string), typeof(ZolyComboBox), new FrameworkPropertyMetadata(string.Empty));

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
        public static readonly DependencyProperty PlaceHolderForegroundProperty = DependencyProperty.Register("PlaceHolderForeground", typeof(Brush), typeof(ZolyComboBox), new FrameworkPropertyMetadata(null));

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
        /// Initializes a new instance of the <see cref="ZolyComboBox"/> class.
        /// </summary>
        public ZolyComboBox()
        {
            this.DefaultStyleKey = typeof(ZolyComboBox);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// The on apply template.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this._placeHolderToggleButton = (ToggleButton)Template.FindName("PlaceHolderToggleButton", this);

            this.SelectionChanged += this.ZolyComboBoxSelectionChanged;
            this.LostFocus += this.ZolyComboBoxLostFocus;
            this.LostKeyboardFocus += this.ZolyComboBoxLostKeyboardFocus;

            this.ZolyComboBoxSelectionChanged(this, null);
        }

        #endregion

        #region Handled Methods

        /// <summary>
        /// The zoly combo box lost keyboard focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyComboBoxLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.ZolyComboBoxLostFocus(sender, null);
        }

        /// <summary>
        /// The zoly combo box lost focus.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyComboBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (this.SelectedValue == null)
                this._placeHolderToggleButton.Tag = Visibility.Visible;
            else
                this._placeHolderToggleButton.Tag = Visibility.Collapsed;
        }

        /// <summary>
        /// The zoly combo box selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsFocused && !this.IsKeyboardFocused)
                this.ZolyComboBoxLostFocus(sender, null);
        }

        #endregion
    }
}
