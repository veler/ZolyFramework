using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;

namespace ZolyFramework.UI.Layout
{
    public class ResponsiveLayoutManager : ObservableCollection<ResponsiveLayoutState>
    {
        #region Fields

        private bool _reverseTransitions = true;

        #endregion

        #region Properties

        public ResponsiveLayoutState CurrentLayoutState { get; private set; }

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
                OnPropertyChanged(new PropertyChangedEventArgs("ReverseTransitions"));
            }
        }

        #endregion

        #region Methods

        public void UpdateLayout(SizeChangedEventArgs sizeChanged, Window window)
        {
            if (sizeChanged == null)
                throw new ArgumentNullException("sizeChanged");
            if (window == null)
                throw new ArgumentNullException("window");

            ResponsiveLayoutState responsiveLayoutStateChoosed = null;

            if (Items.Any(ite => ite.MaxWidth == -1))
                responsiveLayoutStateChoosed = Items.Single(ite => ite.MaxWidth == -1);

            foreach (var item in Items)
            {
                item.IsCorrect();
                if (sizeChanged.NewSize.Width <= item.MaxWidth && (responsiveLayoutStateChoosed == null || (item.MaxWidth < responsiveLayoutStateChoosed.MaxWidth || (responsiveLayoutStateChoosed.MaxWidth == -1 && item.MaxWidth > responsiveLayoutStateChoosed.MaxWidth))))
                    responsiveLayoutStateChoosed = item;
            }

            if (ReverseTransitions && CurrentLayoutState != null && !CurrentLayoutState.Equals(responsiveLayoutStateChoosed) && (responsiveLayoutStateChoosed == null || responsiveLayoutStateChoosed.MaxWidth > CurrentLayoutState.MaxWidth))
                PlayStoryboard(window, CurrentLayoutState.StoryboardName, true);
            else if (responsiveLayoutStateChoosed != null && !responsiveLayoutStateChoosed.Equals(CurrentLayoutState))
                PlayStoryboard(window, responsiveLayoutStateChoosed.StoryboardName, false);

            CurrentLayoutState = responsiveLayoutStateChoosed;
        }

        private void PlayStoryboard(Window window, string storyboardName, bool revsere)
        {
            var storyboard = window.Resources[storyboardName] as Storyboard;
            if (storyboard == null)
                throw new NullReferenceException(string.Format("Unable to find the storyboard '{0}' in Window.Resources.", storyboardName));

            if (revsere)
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
