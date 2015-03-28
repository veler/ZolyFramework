// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessageDialogManager.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the MessageDialogManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.ComponentModel
{
    using ZolyFramework.UI.Windows.Controls;

    /// <summary>
    /// Manager the only one message dialog displayed on screen
    /// </summary>
    public static class MessageDialogManager
    {
        #region Fields

        /// <summary>
        /// The current message dialog.
        /// </summary>
        private static ZolyMessageDialog _currentMessageDialog;

        #endregion

        #region Methods

        /// <summary>
        /// Set the current message dialog.
        /// </summary>
        /// <param name="messageDialog">
        /// The message dialog.
        /// </param>
        internal static void SetCurrentMessageDialog(ZolyMessageDialog messageDialog)
        {
            _currentMessageDialog = messageDialog;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Get the current message dialog.
        /// </summary>
        /// <returns>
        /// The <see cref="ZolyMessageDialog"/>.
        /// </returns>
        public static ZolyMessageDialog GetCurrentMessageDialog()
        {
            return _currentMessageDialog;
        }

        /// <summary>
        /// Check if any message dialog is already opened.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsAnyMessageDialogOpened()
        {
            return _currentMessageDialog != null;
        }

        #endregion
    }
}
