using System;

namespace ZolyFramework.UI.Windows.Controls
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;

    public class ZolyFlipView : Selector
    {
        #region Fields

        private int _oldSelectedIndex;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the previous content.
        /// </summary>
        private ContentControl PreviousContent { get; set; }

        /// <summary>
        /// Gets or sets the current content.
        /// </summary>
        private ContentControl CurrentContent { get; set; }

        /// <summary>
        /// Gets or sets the next content.
        /// </summary>
        private ContentControl NextContent { get; set; }

        /// <summary>
        /// Gets or sets the content grid.
        /// </summary>
        private Grid ContentGrid { get; set; }

        /// <summary>
        /// Gets or sets the slide storyboard.
        /// </summary>
        private Storyboard SlideStoryboard { get; set; }

        /// <summary>
        /// The can go next property.
        /// </summary>
        public static readonly DependencyProperty CanGoNextProperty = DependencyProperty.Register("CanGoNext", typeof(bool), typeof(ZolyFlipView), new FrameworkPropertyMetadata(true));

        /// <summary>
        /// Gets or sets a value indicating whether can go next.
        /// </summary>
        public bool CanGoNext
        {
            get { return (bool)this.GetValue(CanGoNextProperty); }
            set { this.SetValue(CanGoNextProperty, value); }
        }

        /// <summary>
        /// The can go back property.
        /// </summary>
        public static readonly DependencyProperty CanGoBackProperty = DependencyProperty.Register("CanGoBack", typeof(bool), typeof(ZolyFlipView), new FrameworkPropertyMetadata(true));

        /// <summary>
        /// Gets or sets a value indicating whether can go back.
        /// </summary>
        public bool CanGoBack
        {
            get { return (bool)this.GetValue(CanGoBackProperty); }
            set { this.SetValue(CanGoBackProperty, value); }
        }

        /// <summary>
        /// The next button is visible property.
        /// </summary>
        public static readonly DependencyProperty NextButtonIsVisibleProperty = DependencyProperty.Register("NextButtonIsVisible", typeof(bool), typeof(ZolyFlipView), new FrameworkPropertyMetadata(true));

        /// <summary>
        /// Gets or sets a value indicating whether next button is visible.
        /// </summary>
        public bool NextButtonIsVisible
        {
            get { return (bool)this.GetValue(NextButtonIsVisibleProperty); }
            set { this.SetValue(NextButtonIsVisibleProperty, value); }
        }

        /// <summary>
        /// The back button is visible property.
        /// </summary>
        public static readonly DependencyProperty BackButtonIsVisibleProperty = DependencyProperty.Register("BackButtonIsVisible", typeof(bool), typeof(ZolyFlipView), new FrameworkPropertyMetadata(true));

        /// <summary>
        /// Gets or sets a value indicating whether back button is visible.
        /// </summary>
        public bool BackButtonIsVisible
        {
            get { return (bool)this.GetValue(BackButtonIsVisibleProperty); }
            set { this.SetValue(BackButtonIsVisibleProperty, value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ZolyFlipView"/> class.
        /// </summary>
        public ZolyFlipView()
        {
            this.DefaultStyleKey = typeof(ZolyFlipView);

            this._oldSelectedIndex = -1;
            this.SelectedIndex = -1;

            CommandBindings.Add(new CommandBinding(NextCommand, this.NextCommandExecuted, this.NextCommandCanExecute));
            CommandBindings.Add(new CommandBinding(PreviousCommand, this.PreviousCommandExecuted, this.PreviousCommandCanExecute));
        }

        #endregion

        #region Overrides

        /// <summary>
        /// The on apply template.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.PreviousContent = GetTemplateChild("PreviousContent") as ContentControl;
            this.CurrentContent = GetTemplateChild("CurrentContent") as ContentControl;
            this.NextContent = GetTemplateChild("NextContent") as ContentControl;
            this.ContentGrid = GetTemplateChild("ContentGrid") as Grid;

            var storyboard = FindResource("SlideStoryboard") as Storyboard;
            if (storyboard != null)
                this.SlideStoryboard = storyboard.Clone();

            this.Loaded += this.ZolyFlipViewLoaded;
            this.SelectionChanged += this.ZolyFlipViewSelectionChanged;
            this.SlideStoryboard.Completed += this.SlideStoryboardCompleted;
            this.ZolyFlipViewSelectionChanged(this, null);
        }

        /// <summary>
        /// The on items source changed.
        /// </summary>
        /// <param name="oldValue">
        /// The old value.
        /// </param>
        /// <param name="newValue">
        /// The new value.
        /// </param>
        protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);
            this.RefreshDisposition();
        }

        #endregion

        #region Commands

        #region Next

        /// <summary>
        /// The next command.
        /// </summary>
        public static RoutedUICommand NextCommand = new RoutedUICommand("Next", "Next", typeof(ZolyFlipView));

        /// <summary>
        /// The next command can execute.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void NextCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.SelectedIndex < (Items.Count - 1) && this.CanGoNext;
        }

        /// <summary>
        /// The next command executed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void NextCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this._oldSelectedIndex = this.SelectedIndex;
            this.SelectedIndex++;
        }

        #endregion

        #region Previous

        /// <summary>
        /// The previous command.
        /// </summary>
        public static RoutedUICommand PreviousCommand = new RoutedUICommand("Previous", "Previous", typeof(ZolyFlipView));

        /// <summary>
        /// The previous command can execute.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void PreviousCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.SelectedIndex > 0 && this.CanGoBack;
        }

        /// <summary>
        /// The previous command executed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void PreviousCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this._oldSelectedIndex = this.SelectedIndex;
            this.SelectedIndex--;
        }

        #endregion

        #endregion

        #region Handled Methods

        /// <summary>
        /// The zoly flip view loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyFlipViewLoaded(object sender, RoutedEventArgs e)
        {
            this.RefreshDisposition();
        }

        /// <summary>
        /// The zoly flip view selection changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void ZolyFlipViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in this.Items)
            {
                var panel = (Panel)item;
                KeyboardNavigation.SetTabNavigation(panel, KeyboardNavigationMode.None);
            }
            if (this.SelectedIndex > -1)
            {
                var panel = (Panel)this.Items[this.SelectedIndex];
                KeyboardNavigation.SetTabNavigation(panel, KeyboardNavigationMode.Continue);
            }

            if (this._oldSelectedIndex == this.SelectedIndex)
                return;

            double offset;
            if (this._oldSelectedIndex < this.SelectedIndex)
            {
                offset = -this.ActualWidth;
                if (this.SelectedIndex - this._oldSelectedIndex > 1)
                    this.NextContent.Content = this.GetItem(this.SelectedIndex);
            }
            else
            {
                offset = this.ActualWidth;
                if (this._oldSelectedIndex - this.SelectedIndex > 1)
                    this.PreviousContent.Content = this.GetItem(this.SelectedIndex);
            }

            this._oldSelectedIndex = this.SelectedIndex;

            ((DoubleAnimation)this.SlideStoryboard.Children[0]).To = offset;
            this.SlideStoryboard.Begin(this.ContentGrid);
        }

        /// <summary>
        /// The slide storyboard completed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void SlideStoryboardCompleted(object sender, EventArgs e)
        {
            this.RefreshDisposition();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The refresh disposition.
        /// </summary>
        private void RefreshDisposition()
        {
            Canvas.SetLeft(this.PreviousContent, -this.ActualWidth);
            Canvas.SetLeft(this.NextContent, this.ActualWidth);
            this.ContentGrid.RenderTransform = new TranslateTransform();

            this.PreviousContent.Content = this.GetItem(this.SelectedIndex - 1);
            this.CurrentContent.Content = this.GetItem(this.SelectedIndex);
            this.NextContent.Content = this.GetItem(this.SelectedIndex + 1);
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// Go to the next item.
        /// </summary>
        public void Next()
        {
            if (this.SelectedIndex < (this.Items.Count - 1))
                this.NextCommandExecuted(null, null);
        }

        /// <summary>
        /// Go to the previous item.
        /// </summary>
        public void Previous()
        {
            if (this.SelectedIndex > 0)
                this.PreviousCommandExecuted(null, null);
        }

        #endregion

        #region Functions

        /// <summary>
        /// The get item at an index.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private object GetItem(int index)
        {
            if (index < 0 || index >= this.Items.Count)
                return null;
            return this.Items[index];
        }

        #endregion
    }
}
