// Not from Etienne

namespace ZolyFramework.UI.Behaviors.Tilt
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interactivity;
    using System.Windows.Media;

    public class TiltEffect : Behavior<FrameworkElement>
    {
        #region Fields

        private FrameworkElement _attachedElement;
        private Panel _originalPanel;
        private Thickness _originalMargin;
        private Size _originalSize;
        private Point _current = new Point(-99, -99);
        private bool _isPressed;
        private int _times = -1;

        private static FrameworkElement _currentTiltedControl;

        #endregion

        #region Properties

        public static readonly DependencyProperty KeepDraggingProperty = DependencyProperty.Register("KeepDragging", typeof(bool), typeof(TiltEffect), new PropertyMetadata(true));
        public bool KeepDragging
        {
            get { return (bool)this.GetValue(KeepDraggingProperty); }
            set { this.SetValue(KeepDraggingProperty, value); }
        }


        public static readonly DependencyProperty TiltFactorProperty = DependencyProperty.Register("TiltFactor", typeof(Int32), typeof(TiltEffect), new PropertyMetadata(5));
        public Int32 TiltFactor
        {
            get { return (Int32)this.GetValue(TiltFactorProperty); }
            set { this.SetValue(TiltFactorProperty, value); }
        }

        public Planerator RotatorParent { get; set; }

        #endregion

        #region Overrides

        protected override void OnAttached()
        {
            this._attachedElement = this.AssociatedObject;

            if (this._attachedElement as Panel != null)
            {
                this._attachedElement.Loaded += this.TiltEffect_Loaded;
                return;
            }

            this._originalPanel = this._attachedElement.Parent as Panel;
            this._originalMargin = this._attachedElement.Margin;
            this._originalSize = new Size(this._attachedElement.Width, this._attachedElement.Height);
            var left = Canvas.GetLeft(this._attachedElement);
            var right = Canvas.GetRight(this._attachedElement);
            var top = Canvas.GetTop(this._attachedElement);
            var bottom = Canvas.GetBottom(this._attachedElement);
            var z = Canvas.GetZIndex(this._attachedElement);
            var va = this._attachedElement.VerticalAlignment;
            var ha = this._attachedElement.HorizontalAlignment;

            this.RotatorParent = new Planerator();
            this.RotatorParent.Margin = this._originalMargin;
            this.RotatorParent.Width = this._originalSize.Width;
            this.RotatorParent.Height = this._originalSize.Height;
            this.RotatorParent.VerticalAlignment = va;
            this.RotatorParent.HorizontalAlignment = ha;
            this.RotatorParent.SetValue(Canvas.LeftProperty, left);
            this.RotatorParent.SetValue(Canvas.RightProperty, right);
            this.RotatorParent.SetValue(Canvas.TopProperty, top);
            this.RotatorParent.SetValue(Canvas.BottomProperty, bottom);
            this.RotatorParent.SetValue(Canvas.ZIndexProperty, z);

            this._originalPanel.Children.Remove(this._attachedElement);
            this._attachedElement.Margin = new Thickness();
            this._attachedElement.Width = double.NaN;
            this._attachedElement.Height = double.NaN;

            this._originalPanel.Children.Add(this.RotatorParent);
            this.RotatorParent.Child = this._attachedElement;

            CompositionTarget.Rendering += this.CompositionTarget_Rendering;
        }

        #endregion

        #region Handled Methods

        private void TiltEffect_Loaded(object sender, RoutedEventArgs e)
        {
            var elements = new List<UIElement>();

            foreach (UIElement ui in ((Panel)this._attachedElement).Children)
                elements.Add(ui);

            elements.ForEach(element => Interaction.GetBehaviors(element).Add(new TiltEffect { KeepDragging = this.KeepDragging, TiltFactor = this.TiltFactor }));
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (this.KeepDragging)
            {
                this._current = Mouse.GetPosition(this.RotatorParent.Child);
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {
                    if ((this._attachedElement.Equals(_currentTiltedControl) || _currentTiltedControl == null) && this._current.X > 0 && this._current.X < this._attachedElement.ActualWidth && this._current.Y > 0 && this._current.Y < this._attachedElement.ActualHeight)
                    {
                        _currentTiltedControl = this._attachedElement;
                        this.RotatorParent.RotationY = -1 * this.TiltFactor + this._current.X * 2 * this.TiltFactor / this._attachedElement.ActualWidth;
                        this.RotatorParent.RotationX = -1 * this.TiltFactor + this._current.Y * 2 * this.TiltFactor / this._attachedElement.ActualHeight;
                    }
                }
                else
                {
                    _currentTiltedControl = null;
                    this.RotatorParent.RotationY = this.RotatorParent.RotationY - 5 < 0 ? 0 : this.RotatorParent.RotationY - 5;
                    this.RotatorParent.RotationX = this.RotatorParent.RotationX - 5 < 0 ? 0 : this.RotatorParent.RotationX - 5;
                }
            }
            else
            {

                if (Mouse.LeftButton == MouseButtonState.Pressed)
                {

                    if (!this._isPressed)
                    {
                        this._current = Mouse.GetPosition(this.RotatorParent.Child);
                        if (this._current.X > 0 && this._current.X < this._attachedElement.ActualWidth && this._current.Y > 0 && this._current.Y < this._attachedElement.ActualHeight)
                        {
                            this.RotatorParent.RotationY = -1 * this.TiltFactor + this._current.X * 2 * this.TiltFactor / this._attachedElement.ActualWidth;
                            this.RotatorParent.RotationX = -1 * this.TiltFactor + this._current.Y * 2 * this.TiltFactor / this._attachedElement.ActualHeight;
                        }
                        this._isPressed = true;
                    }


                    if (this._isPressed && this._times == 7)
                    {
                        this.RotatorParent.RotationY = this.RotatorParent.RotationY - 5 < 0 ? 0 : this.RotatorParent.RotationY - 5;
                        this.RotatorParent.RotationX = this.RotatorParent.RotationX - 5 < 0 ? 0 : this.RotatorParent.RotationX - 5;
                    }
                    else if (this._isPressed && this._times < 7)
                        this._times++;
                }
                else
                {
                    this._isPressed = false;
                    this._times = -1;
                    this.RotatorParent.RotationY = this.RotatorParent.RotationY - 5 < 0 ? 0 : this.RotatorParent.RotationY - 5;
                    this.RotatorParent.RotationX = this.RotatorParent.RotationX - 5 < 0 ? 0 : this.RotatorParent.RotationX - 5;
                }
            }
        }

        #endregion
    }
}
