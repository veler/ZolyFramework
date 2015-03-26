using System.Data;
using System.Windows;

namespace ZolyFramework.UI.Layout
{
    public class ResponsiveLayoutState : DependencyObject
    {
        #region Properties

        public static readonly DependencyProperty StoryboardNameProperty = DependencyProperty.Register("StoryboardName", typeof(string), typeof(ResponsiveLayoutState), new FrameworkPropertyMetadata(null));
        public string StoryboardName
        {
            get { return (string)GetValue(StoryboardNameProperty); }
            set { SetValue(StoryboardNameProperty, value); }
        }


        public static readonly DependencyProperty MaxWidthProperty = DependencyProperty.Register("MaxWidth", typeof(double), typeof(ResponsiveLayoutState), new FrameworkPropertyMetadata(null));
        public double MaxWidth
        {
            get { return (double)GetValue(MaxWidthProperty); }
            set { SetValue(MaxWidthProperty, value); }
        }

        #endregion

        #region Constructor

        public ResponsiveLayoutState()
        {
            MaxWidth = -1;
        }

        #endregion

        #region Functions

        internal void IsCorrect()
        {
            if (string.IsNullOrEmpty(StoryboardName) && MaxWidth != -1)
                throw new NoNullAllowedException("Invalid ResponsiveLayoutState. You should give a value to Name and MaxWidth.");
        }

        #endregion

        #region Override
        public new bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var value = (ResponsiveLayoutState)obj;
            return value.MaxWidth == MaxWidth && value.StoryboardName == StoryboardName;
        }

        #endregion
    }
}
