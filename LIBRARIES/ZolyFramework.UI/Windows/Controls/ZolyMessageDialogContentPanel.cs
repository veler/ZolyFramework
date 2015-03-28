// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyMessageDialogContentPanel.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyMessageDialogContentPanel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// The zoly message dialog content panel.
    /// </summary>
    public class ZolyMessageDialogContentPanel : UserControl
    {
        #region Properties

        /// <summary>
        /// The result property.
        /// </summary>
        public static readonly DependencyProperty ResultProperty = DependencyProperty.Register("Result", typeof(object), typeof(ZolyMessageDialogContentPanel), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the result of the message dialog.
        /// </summary>
        public object Result
        {
            get { return (object)this.GetValue(ResultProperty); }
            set { this.SetValue(ResultProperty, value); }
        }

        /// <summary>
        /// The title property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(ZolyMessageDialogContentPanel), new FrameworkPropertyMetadata(string.Empty));

        /// <summary>
        /// Gets or sets the title of the message dialog.
        /// </summary>
        public string Title
        {
            get { return (string)this.GetValue(TitleProperty); }
            set { this.SetValue(TitleProperty, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyMessageDialogContentPanel"/> class.
        /// </summary>
        public ZolyMessageDialogContentPanel()
        {
            this.DefaultStyleKey = typeof(ZolyMessageDialogContentPanel);

            this.Loaded += this.ZolyMessageDialogContentPanelLoaded;
        }

        #endregion

        #region Handled Methods

        /// <summary>
        /// The zoly message dialog content panel loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyMessageDialogContentPanelLoaded(object sender, RoutedEventArgs e)
        {
            var cancelButton = this.GetCancelButton();
            if (cancelButton != null)
                cancelButton.Focus();
        }

        #endregion

        #region Functions

        /// <summary>
        /// The get ok button.
        /// </summary>
        /// <returns>
        /// The <see cref="ZolyFlatButton"/>.
        /// </returns>
        public virtual ZolyFlatButton GetOkButton()
        {
            return null;
        }

        /// <summary>
        /// The get cancel button.
        /// </summary>
        /// <returns>
        /// The <see cref="ZolyFlatButton"/>.
        /// </returns>
        public virtual ZolyFlatButton GetCancelButton()
        {
            return null;
        }

        /// <summary>
        /// The get result.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/> corresponding to the result of the message (it can be anything, like what the user prompt for exemple).
        /// </returns>
        public virtual object GetResult()
        {
            return this.Result;
        }

        #endregion
    }
}
