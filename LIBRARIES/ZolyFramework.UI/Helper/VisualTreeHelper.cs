// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisualTreeHelper.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Provide some functions to help to fin a visual component
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Helper
{
    using System.Windows;

    /// <summary>
    /// Provide some functions to help to fin a visual component
    /// </summary>
    public static class VisualTreeHelper
    {
        /// <summary>
        /// Find the next visual child corresponding to the wanted type
        /// </summary>
        /// <param name="depObj">the container</param>
        /// <typeparam name="T">the type of control that we are searching for</typeparam>
        /// <returns>Null if no control is found. Else, the first finded control.</returns>
        public static T FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null)
                return null;

            for (var i = 0; i < System.Windows.Media.VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = System.Windows.Media.VisualTreeHelper.GetChild(depObj, i);
                if (child is T)
                    return (T)child;

                var childItem = FindVisualChild<T>(child);
                if (childItem != null)
                    return childItem;
            }

            return null;
        }

        /// <summary>
        /// Find the next visual parent corresponding to the wanted type
        /// </summary>
        /// <param name="depObj">the child</param>
        /// <typeparam name="T">the type of control that we are searching for</typeparam>
        /// <returns>Null if no control is found. Else, the first finded control.</returns>
        public static T FindVisualParent<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null)
                return null;
            var parentObject = System.Windows.Media.VisualTreeHelper.GetParent(depObj);
            if (parentObject == null)
                return null;
            var parent = parentObject as T;
            return parent ?? FindVisualParent<T>(parentObject);
        }
    }
}
