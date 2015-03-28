// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuItemExtension.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the MenuItemExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Extension for menu items.
    /// </summary>
    public class MenuItemExtensions : DependencyObject
    {
        #region Properties

        /// <summary>
        /// Contains the list of menu item and their group name.
        /// </summary>
        public static Dictionary<MenuItem, String> ElementToGroupNames = new Dictionary<MenuItem, String>();

        /// <summary>
        /// Group name of a menu item
        /// </summary>
        public static readonly DependencyProperty GroupNameProperty = DependencyProperty.RegisterAttached("GroupName", typeof(String), typeof(MenuItemExtensions), new PropertyMetadata(String.Empty, OnGroupNameChanged));

        #endregion

        #region Getters/Setters

        /// <summary>
        /// Set the group name of a menu item
        /// </summary>
        /// <param name="element">the menu item</param>
        /// <param name="value">the group name</param>
        public static void SetGroupName(MenuItem element, String value)
        {
            element.SetValue(GroupNameProperty, value);
        }

        /// <summary>
        /// Returns the group name of a menu item
        /// </summary>
        /// <param name="element">the menu item</param>
        /// <returns>the group name</returns>
        public static String GetGroupName(MenuItem element)
        {
            return element.GetValue(GroupNameProperty).ToString();
        }

        #endregion

        #region Methods

        /// <summary>
        /// On group name changed.
        /// </summary>
        /// <param name="d">
        /// The object.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private static void OnGroupNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var menuItem = d as MenuItem;
            if (menuItem == null)
                return;

            var newGroupName = e.NewValue.ToString();
            var oldGroupName = e.OldValue.ToString();
            if (String.IsNullOrEmpty(newGroupName))
                RemoveCheckboxFromGrouping(menuItem);
            else if (newGroupName != oldGroupName)
            {
                if (!String.IsNullOrEmpty(oldGroupName))
                    RemoveCheckboxFromGrouping(menuItem);
                ElementToGroupNames.Add(menuItem, e.NewValue.ToString());
                menuItem.Checked += MenuItemChecked;
            }
        }

        /// <summary>
        /// Remove checkbox from grouping menu item.
        /// </summary>
        /// <param name="checkBox">
        /// The menu item.
        /// </param>
        private static void RemoveCheckboxFromGrouping(MenuItem checkBox)
        {
            ElementToGroupNames.Remove(checkBox);
            checkBox.Checked -= MenuItemChecked;
        }

        /// <summary>
        /// The menu item checked.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void MenuItemChecked(object sender, RoutedEventArgs e)
        {
            var menuItem = e.OriginalSource as MenuItem;
            foreach (var item in ElementToGroupNames)
                if (item.Key != menuItem && item.Value == GetGroupName(menuItem))
                    item.Key.IsChecked = false;
        }

        #endregion
    }
}
