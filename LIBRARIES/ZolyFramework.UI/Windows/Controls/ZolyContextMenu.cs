// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyContextMenu.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyContextMenu type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.Windows.Controls;

    /// <summary>
    /// The zoly context menu.
    /// </summary>
    public class ZolyContextMenu : ContextMenu
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyContextMenu"/> class.
        /// </summary>
        public ZolyContextMenu()
        {
            this.DefaultStyleKey = typeof(ZolyContextMenu);
        }

        #endregion
    }
}
