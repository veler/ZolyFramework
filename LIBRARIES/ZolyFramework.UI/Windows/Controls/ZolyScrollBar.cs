// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyScrollBar.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyScrollBar type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.Windows.Controls.Primitives;

    /// <summary>
    /// The zoly scroll bar.
    /// </summary>
    public class ZolyScrollBar : ScrollBar
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyScrollBar"/> class.
        /// </summary>
        public ZolyScrollBar()
        {
            this.DefaultStyleKey = typeof(ZolyScrollBar);
        }

        #endregion
    }
}
