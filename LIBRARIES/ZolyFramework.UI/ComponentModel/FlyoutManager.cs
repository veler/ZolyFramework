// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlyoutManager.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the FlyoutManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.ComponentModel
{
    using ZolyFramework.UI.Windows.Controls;

    /// <summary>
    /// Manager the only one fly out displayed on screen
    /// </summary>
    public static class FlyoutManager
    {
        #region Fields

        /// <summary>
        /// The current fly out.
        /// </summary>
        private static ZolyFlyout _currentFlyout;

        #endregion

        #region Methods

        /// <summary>
        /// Set the current fly out.
        /// </summary>
        /// <param name="flyout">
        /// The fly out.
        /// </param>
        internal static void SetCurrentFlyout(ZolyFlyout flyout)
        {
            _currentFlyout = flyout;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Get the current fly out.
        /// </summary>
        /// <returns>
        /// The <see cref="ZolyFlyout"/>.
        /// </returns>
        public static ZolyFlyout GetCurrentFlyout()
        {
            return _currentFlyout;
        }

        /// <summary>
        /// Check if any fly out is already opened.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsAnyFlyoutOpened()
        {
            return _currentFlyout != null;
        }

        #endregion
    }
}
