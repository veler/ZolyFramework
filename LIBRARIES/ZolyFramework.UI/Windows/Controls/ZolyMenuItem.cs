// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyMenuItem.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyMenuItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.Windows.Controls;

    /// <summary>
    /// The zoly menu item.
    /// </summary>
    public class ZolyMenuItem : MenuItem
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyMenuItem"/> class.
        /// </summary>
        public ZolyMenuItem()
        {
            this.DefaultStyleKey = typeof(ZolyMenuItem);
        }

        #endregion
    }
}
