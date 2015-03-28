// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyScrollViewer.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyScrollViewer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.Windows.Controls;

    /// <summary>
    /// The zoly scroll viewer.
    /// </summary>
    public class ZolyScrollViewer : ScrollViewer
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyScrollViewer"/> class.
        /// </summary>
        public ZolyScrollViewer()
        {
            this.DefaultStyleKey = typeof(ZolyScrollViewer);
        }

        #endregion
    }
}
