// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyListView.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyListView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// The zoly list view.
    /// </summary>
    public class ZolyListView : ListView
    {
        #region Properties

        /// <summary>
        /// The is columns visible property.
        /// </summary>
        public static readonly DependencyProperty IsColumnsVisibleProperty = DependencyProperty.Register("IsColumnsVisible", typeof(bool), typeof(ZolyListView), new FrameworkPropertyMetadata(true));

        /// <summary>
        /// Gets or sets a value indicating whether columns are visible.
        /// </summary>
        public bool IsColumnsVisible
        {
            get { return (bool)this.GetValue(IsColumnsVisibleProperty); }
            set { this.SetValue(IsColumnsVisibleProperty, value); }
        }
        
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyListView"/> class.
        /// </summary>
        public ZolyListView()
        {
            this.DefaultStyleKey = typeof(ZolyListView);
        }

        #endregion
    }
}
