// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlurBackgroundEffect.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the BlurBackgroundEffect type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.UI.Behaviors.BlurBackground
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    using System.Windows.Media;
    using System.Windows.Media.Effects;
    using System.Windows.Shapes;

    /// <summary>
    /// Blur the background of a FrameworkElement.
    /// </summary>
    public class BlurBackgroundEffect : Behavior<FrameworkElement>
    {
        #region Fields

        /// <summary>
        /// The attached element.
        /// </summary>
        private Panel _attachedElement;

        /// <summary>
        /// The translate transform.
        /// </summary>
        private TranslateTransform _translateTransform;

        /// <summary>
        /// The visual brush.
        /// </summary>
        private VisualBrush _visualBrush;

        /// <summary>
        /// The blur effect.
        /// </summary>
        private static BlurEffect _blurEffect;

        #endregion

        #region Properties

        /// <summary>
        /// The radius property.
        /// </summary>
        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(BlurBackgroundEffect), new FrameworkPropertyMetadata(5.0, RadiusPropertyChangedCallback));

        /// <summary>
        /// Gets or sets the radius.
        /// </summary>
        public double Radius
        {
            get { return (double)this.GetValue(RadiusProperty); }
            set { this.SetValue(RadiusProperty, value); }
        }

        /// <summary>
        /// The mask brush property.
        /// </summary>
        public static readonly DependencyProperty MaskBrushProperty = DependencyProperty.Register("MaskBrush", typeof(Brush), typeof(BlurBackgroundEffect), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the mask brush.
        /// </summary>
        public Brush MaskBrush
        {
            get { return (Brush)this.GetValue(MaskBrushProperty); }
            set { this.SetValue(MaskBrushProperty, value); }
        }

        /// <summary>
        /// The visual property.
        /// </summary>
        public static readonly DependencyProperty VisualProperty = DependencyProperty.Register("Visual", typeof(Panel), typeof(BlurBackgroundEffect), new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Gets or sets the visual.
        /// </summary>
        public Panel Visual
        {
            get { return (Panel)this.GetValue(VisualProperty); }
            set { this.SetValue(VisualProperty, value); }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// On attached.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// The container argument should be able to receive several children (like Grid, Panel, but not Border for example).
        /// </exception>
        protected override void OnAttached()
        {
            if (this.AssociatedObject as Panel == null)
                throw new ArgumentException("The container argument should be able to receive several children (like Grid, Panel, but not Border for example).", "AssociatedObject");

            this._attachedElement = (Panel)this.AssociatedObject;
            this._attachedElement.Loaded += this.BlurBackgroundEffectLoaded;

            CompositionTarget.Rendering += this.CompositionTargetRendering;
        }

        #endregion

        #region Handled Methods

        /// <summary>
        /// The radius property changed callback.
        /// </summary>
        /// <param name="d">
        /// The dependency object.
        /// </param>
        /// <param name="e">
        /// The information on the property.
        /// </param>
        private static void RadiusPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (_blurEffect != null)
                _blurEffect.Radius = (double)e.NewValue;
        }

        /// <summary>
        /// The blur background effect loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void BlurBackgroundEffectLoaded(object sender, RoutedEventArgs e)
        {
            if (this._attachedElement.RenderTransform == null || !(this._attachedElement.RenderTransform is TranslateTransform || this._attachedElement.RenderTransform is TransformGroup))
            {
                Debug.Write("[BlurBackgroundEffect] the container's RenderTransform will be override.");
                var transformGroup = new TransformGroup();
                transformGroup.Children.Add(new ScaleTransform());
                transformGroup.Children.Add(new SkewTransform());
                transformGroup.Children.Add(new RotateTransform());
                transformGroup.Children.Add(new TranslateTransform());
                this._attachedElement.RenderTransform = transformGroup;
                this._attachedElement.RenderTransformOrigin = new Point(0.5, 0.5);
            }

            _blurEffect = new BlurEffect();
            _blurEffect.RenderingBias = RenderingBias.Performance;
            _blurEffect.Radius = this.Radius;

            if (this.Visual != null)
                this._visualBrush = new VisualBrush(this.Visual);
            else
                this._visualBrush = new VisualBrush(this._attachedElement);
            this._visualBrush.Stretch = Stretch.None;
            this._visualBrush.AlignmentX = AlignmentX.Left;
            this._visualBrush.AlignmentY = AlignmentY.Top;
            this._visualBrush.ViewboxUnits = BrushMappingMode.Absolute;
            this._visualBrush.Transform = new TranslateTransform();
            if (this._attachedElement.RenderTransform is TranslateTransform)
                this._translateTransform = (TranslateTransform)this._attachedElement.RenderTransform;
            else if (this._attachedElement.RenderTransform is TransformGroup)
            {
                var transformGroup = (TransformGroup)this._attachedElement.RenderTransform;
                if (transformGroup.Children.Any(transform => transform is TranslateTransform))
                    this._translateTransform = (TranslateTransform)transformGroup.Children.First(transform => transform is TranslateTransform);
            }
            this.CompositionTargetRendering(null, null);

            var blurRectangle = new Rectangle();
            blurRectangle.Effect = _blurEffect;
            blurRectangle.Fill = this._visualBrush;

            var maskRectangle = new Rectangle();
            maskRectangle.Fill = this.MaskBrush;

            this._attachedElement.Children.Insert(0, blurRectangle);
            this._attachedElement.Children.Insert(1, maskRectangle);
        }

        /// <summary>
        /// The composition target rendering.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void CompositionTargetRendering(object sender, EventArgs e)
        {
            if (this._translateTransform != null)
                this._visualBrush.Viewbox = new Rect(this._translateTransform.X, this._translateTransform.Y, 0d, 0d);
        }

        #endregion
    }
}
