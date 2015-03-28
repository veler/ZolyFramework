// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyProgressBar.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyProgressBar type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.Windows.Controls;

    /// <summary>
    /// The zoly progress bar.
    /// </summary>
    public class ZolyProgressBar : ProgressBar
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyProgressBar"/> class.
        /// </summary>
        public ZolyProgressBar()
        {
            this.DefaultStyleKey = typeof(ZolyProgressBar);
        }

        #endregion
    }
}
