// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponsiveLayoutManager.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Provide a manager for the responsive layout
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Layout
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media.Animation;

    /// <summary>
    /// Provide a manager for the responsive layout
    /// </summary>
    public class ResponsiveLayoutManager : ObservableCollection<ResponsiveLayoutState>
    {
        #region Fields

        private bool _reverseTransitions = true;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the current layout state
        /// </summary>
        public ResponsiveLayoutState CurrentLayoutState { get; private set; }

        /// <summary>
        /// Gets or sets a value that define if we should play the storyboard in reverse when the layout is resized.
        /// </summary>
        public bool ReverseTransitions
        {
            get
            {
                return _reverseTransitions;
            }
            set
            {
                if (Equals(value, _reverseTransitions))
                    return;
                _reverseTransitions = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("ReverseTransitions"));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Update the layout
        /// </summary>
        /// <param name="sizeChanged">Size changed event arguments</param>
        /// <param name="window">the window</param>
        /// <exception cref="ArgumentNullException">sizeChanged or window argument is null</exception>
        public void UpdateLayout(SizeChangedEventArgs sizeChanged, Window window)
        {
            if (sizeChanged == null)
                throw new ArgumentNullException("sizeChanged");
            if (window == null)
                throw new ArgumentNullException("window");

            ResponsiveLayoutState responsiveLayoutStateChoosed = null;
            var currentLayoutStateIsTheHighest = this.CurrentLayoutState != null;

            if (currentLayoutStateIsTheHighest)
                currentLayoutStateIsTheHighest = this.CurrentLayoutState.MaxWidth > -1;

            if (Items.Any(ite => ite.MaxWidth == -1))
                responsiveLayoutStateChoosed = Items.Single(ite => ite.MaxWidth == -1);

            foreach (var item in this.Items)
            {
                item.IsCorrect();
                if (currentLayoutStateIsTheHighest && !this.CurrentLayoutState.Equals(item) && this.CurrentLayoutState.MaxWidth > -1 && item.MaxWidth > this.CurrentLayoutState.MaxWidth)
                    currentLayoutStateIsTheHighest = false;
                if (sizeChanged.NewSize.Width <= item.MaxWidth && (responsiveLayoutStateChoosed == null || (item.MaxWidth < responsiveLayoutStateChoosed.MaxWidth || (responsiveLayoutStateChoosed.MaxWidth == -1 && item.MaxWidth > responsiveLayoutStateChoosed.MaxWidth))))
                    responsiveLayoutStateChoosed = item;
            }

            if (window.WindowState == WindowState.Maximized)
                this.PlayStoryboard(window, responsiveLayoutStateChoosed.Storyboard, false);
            if (this.ReverseTransitions && this.CurrentLayoutState != null && !this.CurrentLayoutState.Equals(responsiveLayoutStateChoosed) && (responsiveLayoutStateChoosed == null || (responsiveLayoutStateChoosed.MaxWidth > this.CurrentLayoutState.MaxWidth && this.CurrentLayoutState.MaxWidth > -1)))
                this.PlayStoryboard(window, this.CurrentLayoutState.Storyboard, true);
            else if (responsiveLayoutStateChoosed != null && !responsiveLayoutStateChoosed.Equals(this.CurrentLayoutState))
            {
                if (currentLayoutStateIsTheHighest && responsiveLayoutStateChoosed.MaxWidth == -1) // responsiveLayoutStateChoosed.MaxWidth > CurrentLayoutState.MaxWidth)
                    this.PlayStoryboard(window, this.CurrentLayoutState.Storyboard, true);
                else
                    this.PlayStoryboard(window, responsiveLayoutStateChoosed.Storyboard, false);
            }

            this.CurrentLayoutState = responsiveLayoutStateChoosed;
        }

        /// <summary>
        /// Play storyboard.
        /// </summary>
        /// <param name="window">
        /// The window.
        /// </param>
        /// <param name="storyboard">
        /// The storyboard.
        /// </param>
        /// <param name="reverse">
        /// The reverse.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// storyboard argument is null
        /// </exception>
        private void PlayStoryboard(Window window, Storyboard storyboard, bool reverse)
        {
            if (storyboard == null)
                throw new ArgumentNullException("storyboard");

            if (reverse)
            {
                var oldAutoReverse = storyboard.AutoReverse;
                storyboard.AutoReverse = true;
                storyboard.Begin(window, true);
                storyboard.Seek(window, new TimeSpan(0, 0, 0), TimeSeekOrigin.Duration);
                storyboard.AutoReverse = oldAutoReverse;
            }
            else
                storyboard.Begin(window);
        }

        #endregion
    }
}
