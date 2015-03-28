// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZolyListBox.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ZolyListBox type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Windows.Controls
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using ZolyFramework.UI.Helper;

    /// <summary>
    /// The zoly list box.
    /// </summary>
    public class ZolyListBox : ListBox
    {
        #region Enums

        /// <summary>
        /// The item edit mode.
        /// </summary>
        public enum ItemEditMode
        {
            NotEditable = 0,
            EditOnSelect = 1,
            EditOnSelectAndAfterClick = 2
        }

        /// <summary>
        /// The item status.
        /// </summary>
        private enum ItemStatus
        {
            Normal = 0,
            Editing = 1
        }

        #endregion

        #region Fields

        private ControlTemplate _normalControlTemplate;

        private ItemStatus _itemStatus = ItemStatus.Normal;

        #endregion

        #region Events

        /// <summary>
        /// The preview selection changed event.
        /// </summary>
        public static readonly RoutedEvent PreviewSelectionChangedEvent = EventManager.RegisterRoutedEvent("PreviewSelectionChanged", RoutingStrategy.Bubble, typeof(SelectionChangedEventHandler), typeof(ZolyListBox));

        /// <summary>
        /// The preview selection changed.
        /// </summary>
        public event SelectionChangedEventHandler PreviewSelectionChanged
        {
            add { this.AddHandler(PreviewSelectionChangedEvent, value); }
            remove { this.RemoveHandler(PreviewSelectionChangedEvent, value); }
        }

        /// <summary>
        /// The editing started.
        /// </summary>
        public event HandledEventHandler EditingStarted;

        /// <summary>
        /// The editing stopped.
        /// </summary>
        public event HandledEventHandler EditingStopped;

        #endregion

        #region Properties

        /// <summary>
        /// The edit mode property.
        /// </summary>
        public static readonly DependencyProperty EditModeProperty = DependencyProperty.Register("EditMode", typeof(ItemEditMode), typeof(ZolyListBox), new FrameworkPropertyMetadata(ItemEditMode.NotEditable));

        /// <summary>
        /// Gets or sets the item edit mode.
        /// </summary>
        public ItemEditMode EditMode
        {
            get { return (ItemEditMode)this.GetValue(EditModeProperty); }
            set { this.SetValue(EditModeProperty, value); }
        }

        /// <summary>
        /// The item edit control template property.
        /// </summary>
        public static readonly DependencyProperty ItemEditControlTemplateProperty = DependencyProperty.Register("ItemEditControlTemplate", typeof(ControlTemplate), typeof(ZolyListBox), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the item edit control template.
        /// </summary>
        public ControlTemplate ItemEditControlTemplate
        {
            get { return (ControlTemplate)this.GetValue(ItemEditControlTemplateProperty); }
            set { this.SetValue(ItemEditControlTemplateProperty, value); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyListBox"/> class.
        /// </summary>
        public ZolyListBox()
        {
            this.DefaultStyleKey = typeof(ZolyListBox);

            this.SelectionChanged += this.ZolyListBoxSelectionChanged;
            this.KeyUp += this.ZolyListBoxKeyUp;
            this.LostFocus += this.ZolyListBoxLostFocus;
        }

        #endregion

        #region Handled Methods

        private void ZolyListBoxKeyUp(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Return || e.Key == Key.Escape) && this._itemStatus == ItemStatus.Editing)
                this.StopEditing(true);
        }

        private void ZolyListBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (!this.IsKeyboardFocusWithin && this._itemStatus == ItemStatus.Editing)
                this.StopEditing();
        }

        private void ZolyListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaisePreviewSelectionChangedEvent(this, e);

            if (this.SelectionMode != SelectionMode.Single || this.EditMode == ItemEditMode.NotEditable || this.ItemEditControlTemplate == null)
                return;

            if (e.RemovedItems.Count == 1)
            {
                var removedItem = this.ItemContainerGenerator.ContainerFromItem(e.RemovedItems[0]) as ListBoxItem;
                if (removedItem != null)
                {
                    removedItem.PreviewMouseLeftButtonDown -= this.SelectedItemPreviewMouseLeftButtonDown;
                    if (this._normalControlTemplate != null && this._itemStatus == ItemStatus.Editing)
                        this.StopEditing(removedItem, true);
                }
            }
            if (e.AddedItems.Count == 1)
            {
                this.UpdateLayout();
                var addedItem = this.ItemContainerGenerator.ContainerFromItem(e.AddedItems[0]) as ListBoxItem;
                if (addedItem != null && addedItem.Template != null)
                {
                    this._normalControlTemplate = addedItem.Template;
                    if (this.EditMode == ItemEditMode.EditOnSelect && this._itemStatus == ItemStatus.Normal)
                        this.StartEditing();
                    else if (this.EditMode == ItemEditMode.EditOnSelectAndAfterClick)
                        addedItem.PreviewMouseLeftButtonDown += this.SelectedItemPreviewMouseLeftButtonDown;
                }
            }
        }

        private void SelectedItemPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!this.IsKeyboardFocusWithin)
            {
                this.Focus();
                return;
            }

            if (((ListBoxItem)sender).IsSelected && this._itemStatus == ItemStatus.Normal)
                this.StartEditing();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The stop editing the specified item.
        /// </summary>
        /// <param name="item">
        /// The item to edit.
        /// </param>
        /// <param name="force">
        /// Force to stop the editing mode, even if the control has focus.
        /// </param>
        private void StopEditing(ListBoxItem item, bool force = false)
        {
            if (this.SelectionMode != SelectionMode.Single || this.EditMode == ItemEditMode.NotEditable || this.ItemEditControlTemplate == null || this._normalControlTemplate == null)
                return;

            if (item == null || this._itemStatus == ItemStatus.Normal)
                return;

            if (item == null || item.Template == null || (item.IsKeyboardFocusWithin && !force))
                return;

            if (!this.RaiseEditingStoppedEvent())
            {
                this._itemStatus = ItemStatus.Normal;
                item.Template = this._normalControlTemplate;
                item.MouseLeftButtonUp -= this.SelectedItemPreviewMouseLeftButtonDown;
            }
        }

        /// <summary>
        /// The stop editing the current item.
        /// </summary>
        /// <param name="force">
        /// Force to stop the editing mode, even if the control has focus
        /// </param>
        public void StopEditing(bool force = false)
        {
            if (this.SelectionMode != SelectionMode.Single || this.EditMode == ItemEditMode.NotEditable || this.ItemEditControlTemplate == null || this._normalControlTemplate == null)
                return;

            if (this.SelectedItem == null)
                return;

            var selectedItem = this.ItemContainerGenerator.ContainerFromItem(this.SelectedItem) as ListBoxItem;
            this.StopEditing(selectedItem, force);
        }

        /// <summary>
        /// Starts to edit the selected item.
        /// </summary>
        public void StartEditing()
        {
            if (this.SelectionMode != SelectionMode.Single || this.EditMode == ItemEditMode.NotEditable || this.ItemEditControlTemplate == null)
                return;

            if (this.SelectedItem == null || this._itemStatus == ItemStatus.Editing)
                return;

            var selectedItem = this.ItemContainerGenerator.ContainerFromItem(this.SelectedItem) as ListBoxItem;
            if (selectedItem == null || selectedItem.Template == null || selectedItem.Template == this.ItemEditControlTemplate)
                return;

            if (!this.RaiseEditingStartedEvent())
            {
                this._itemStatus = ItemStatus.Editing;
                this.Focus();
                this._normalControlTemplate = selectedItem.Template;
                selectedItem.Template = this.ItemEditControlTemplate;

                var textBox = VisualTreeHelper.FindVisualChild<TextBox>(selectedItem.Template.LoadContent());
                if (textBox != null)
                {
                    this.LostFocus -= this.ZolyListBoxLostFocus;
                    this.UpdateLayout();
                    textBox.Focus();
                    this.LostFocus += this.ZolyListBoxLostFocus;
                }
            }
        }

        /// <summary>
        /// The raise preview selection changed event.
        /// </summary>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void RaisePreviewSelectionChangedEvent(DependencyObject target, SelectionChangedEventArgs args)
        {
            if (target == null)
                return;

            args.RoutedEvent = PreviewSelectionChangedEvent;

            if (target is UIElement)
                (target as UIElement).RaiseEvent(args);
            else if (target is ContentElement)
                (target as ContentElement).RaiseEvent(args);
        }

        #endregion

        #region Functions

        /// <summary>
        /// The raise editing started event.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/> that indicate is the event has been handled.
        /// </returns>
        private bool RaiseEditingStartedEvent()
        {
            var args = new HandledEventArgs(false);
            if (this.EditingStarted != null)
                this.EditingStarted(this, args);
            return args.Handled;
        }

        /// <summary>
        /// The raise editing stopped event.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/> that indicate is the event has been handled.
        /// </returns>
        private bool RaiseEditingStoppedEvent()
        {
            var args = new HandledEventArgs(false);
            if (this.EditingStopped != null)
                this.EditingStopped(this, args);
            return args.Handled;
        }

        #endregion
    }
}
