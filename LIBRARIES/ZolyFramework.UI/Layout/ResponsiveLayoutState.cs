// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResponsiveLayoutState.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ResponsiveLayoutState type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Layout
{
    using System.Data;
    using System.Windows;
    using System.Windows.Media.Animation;

    /// <summary>
    /// Responsive Layout State
    /// </summary>
    public class ResponsiveLayoutState : DependencyObject
    {
        #region Properties

        /// <summary>
        /// Storyboard corresponding to the layout
        /// </summary>
        public static readonly DependencyProperty StoryboardProperty = DependencyProperty.Register("Storyboard", typeof(Storyboard), typeof(ResponsiveLayoutState), new FrameworkPropertyMetadata(null));
       
        /// <summary>
        /// Gets or Sets the storyboard corresponding to the layout
        /// </summary>
        public Storyboard Storyboard
        {
            get { return (Storyboard)this.GetValue(StoryboardProperty); }
            set { this.SetValue(StoryboardProperty, value); }
        }


        /// <summary>
        /// Max width of the layout state
        /// </summary>
        public static readonly DependencyProperty MaxWidthProperty = DependencyProperty.Register("MaxWidth", typeof(double), typeof(ResponsiveLayoutState), new FrameworkPropertyMetadata(null));
    
        /// <summary>
        /// Gets or Sets the max width of the layout state
        /// </summary>
        public double MaxWidth
        {
            get { return (double)this.GetValue(MaxWidthProperty); }
            set { this.SetValue(MaxWidthProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponsiveLayoutState"/> class. 
        /// </summary>
        public ResponsiveLayoutState()
        {
            this.MaxWidth = -1;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Check if this responsive layout state is correct.
        /// </summary>
        /// <exception cref="NoNullAllowedException">
        /// Invalid ResponsiveLayoutState. You should give a value to Name and MaxWidth.
        /// </exception>
        internal void IsCorrect()
        {
            if (Storyboard == null && this.MaxWidth != -1)
                throw new NoNullAllowedException("Invalid ResponsiveLayoutState. You should give a value to Name and MaxWidth.");
        }

        #endregion

        #region Override

        /// <summary>
        /// Returns a value that determine if the current responsive layout sate is equal to another one.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public new bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            var value = (ResponsiveLayoutState)obj;
            return value.MaxWidth == MaxWidth && Storyboard.Equals(value.Storyboard, this.Storyboard);
        }

        #endregion
    }
}
