// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyDatePicker.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyDatePicker type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.Windows.Controls;

    /// <summary>
    /// The zoly date picker.
    /// </summary>
    public class ZolyDatePicker : DatePicker
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyDatePicker"/> class.
        /// </summary>
        public ZolyDatePicker()
        {
            this.DefaultStyleKey = typeof(ZolyDatePicker);
        }

        #endregion
    }
}
