// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyCopyableTextBlock.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyCopyableTextBlock type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// The zoly copyable text block.
    /// </summary>
    public class ZolyCopyableTextBlock : Control
    {
        #region Fields

        private ZolyTextBlock _textBlock;
        private ZolyFlatButton _copyZolyFlatButton;

        #endregion

        #region Events

        /// <summary>
        /// The on copy event.
        /// </summary>
        public event HandledEventHandler OnCopy;

        #endregion

        #region Properties

        /// <summary>
        /// The is copyable property.
        /// </summary>
        public static readonly DependencyProperty IsCopyableProperty = DependencyProperty.Register("IsCopyable", typeof(bool), typeof(ZolyCopyableTextBlock), new FrameworkPropertyMetadata(true));

        /// <summary>
        /// Gets or sets a value indicating if the text is copyable.
        /// </summary>
        public bool IsCopyable
        {
            get { return (bool)this.GetValue(IsCopyableProperty); }
            set { this.SetValue(IsCopyableProperty, value); }
        }

        /// <summary>
        /// The text empty property.
        /// </summary>
        internal static readonly DependencyProperty TextEmptyProperty = DependencyProperty.Register("TextEmpty", typeof(bool), typeof(ZolyCopyableTextBlock), new FrameworkPropertyMetadata(false));

        /// <summary>
        /// Gets or sets a value indicating whether text is empty.
        /// </summary>
        internal bool TextEmpty
        {
            get { return (bool)this.GetValue(TextEmptyProperty); }
            set { this.SetValue(TextEmptyProperty, value); }
        }

        /// <summary>
        /// The text property.
        /// </summary>
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(ZolyCopyableTextBlock), new FrameworkPropertyMetadata(string.Empty, TextPropertyChangedCallback));

        /// <summary>
        /// Gets or sets the text to display.
        /// </summary>
        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        /// <summary>
        /// The text trimming property.
        /// </summary>
        public static readonly DependencyProperty TextTrimmingProperty = DependencyProperty.Register("TextTrimming", typeof(TextTrimming), typeof(ZolyCopyableTextBlock), new FrameworkPropertyMetadata(TextTrimming.CharacterEllipsis));

        /// <summary>
        /// Gets or sets the text trimming.
        /// </summary>
        public TextTrimming TextTrimming
        {
            get { return (TextTrimming)this.GetValue(TextTrimmingProperty); }
            set { this.SetValue(TextTrimmingProperty, value); }
        }

        /// <summary>
        /// The text wrapping property.
        /// </summary>
        public static readonly DependencyProperty TextWrappingProperty = DependencyProperty.Register("TextWrapping", typeof(TextWrapping), typeof(ZolyCopyableTextBlock), new FrameworkPropertyMetadata(TextWrapping.NoWrap));

        /// <summary>
        /// Gets or sets the text wrapping.
        /// </summary>
        public TextWrapping TextWrapping
        {
            get { return (TextWrapping)this.GetValue(TextWrappingProperty); }
            set { this.SetValue(TextWrappingProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyCopyableTextBlock"/> class.
        /// </summary>
        public ZolyCopyableTextBlock()
        {
            this.DefaultStyleKey = typeof(ZolyCopyableTextBlock);

            this.TextEmpty = string.IsNullOrWhiteSpace(this.Text);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// The on apply template.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this._textBlock = (ZolyTextBlock)Template.FindName("ZolyTextBlock", this);
            this._copyZolyFlatButton = (ZolyFlatButton)Template.FindName("CopyZolyFlatButton", this);

            this._copyZolyFlatButton.Click += this.CopyZolyFlatButtonClick;
            this.SizeChanged += this.ZolyCopyableTextBlockSizeChanged;
        }

        #endregion

        #region Handled Methods

        /// <summary>
        /// The text property changed callback.
        /// </summary>
        /// <param name="d">
        /// The text block.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private static void TextPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null || string.IsNullOrWhiteSpace(e.NewValue.ToString()))
                d.SetValue(TextEmptyProperty, true);
            else
                d.SetValue(TextEmptyProperty, false);
        }

        /// <summary>
        /// The zoly copyable text block size changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyCopyableTextBlockSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
                this._textBlock.MaxWidth = e.NewSize.Width - e.NewSize.Height;
        }

        /// <summary>
        /// The copy zoly flat button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void CopyZolyFlatButtonClick(object sender, RoutedEventArgs e)
        {
            if (!this.RaiseOnCopyEvent())
                Clipboard.SetText(this.Text);
        }

        #endregion

        #region Functions

        /// <summary>
        /// The raise on copy event.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool RaiseOnCopyEvent()
        {
            var args = new HandledEventArgs(false);
            if (this.OnCopy != null)
                this.OnCopy(this, args);
            return args.Handled;
        }

        #endregion
    }
}
