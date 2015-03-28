// Not from Etienne

namespace ZolyFramework.UI.Behaviors.Tilt
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;

    [ContentProperty("Child")]
    public class Planerator : FrameworkElement
    {
        #region Fields

        private FrameworkElement _logicalChild;
        private FrameworkElement _visualChild;
        private FrameworkElement _originalChild;

        private QuaternionRotation3D _quaternionRotation = new QuaternionRotation3D();
        private RotateTransform3D _rotationTransform = new RotateTransform3D();
        private Viewport3D _viewport3d;
        private ScaleTransform3D _scaleTransform = new ScaleTransform3D();

        static private readonly Point3D[] _mesh = { new Point3D(0, 0, 0), new Point3D(0, 1, 0), new Point3D(1, 1, 0), new Point3D(1, 0, 0) };
        static private readonly Point[] _texCoords = { new Point(0, 1), new Point(0, 0), new Point(1, 0), new Point(1, 1) };
        static private readonly int[] _indices = { 0, 2, 1, 0, 3, 2 };
        static private readonly Vector3D _xAxis = new Vector3D(1, 0, 0);
        static private readonly Vector3D _yAxis = new Vector3D(0, 1, 0);
        static private readonly Vector3D _zAxis = new Vector3D(0, 0, 1);

        #endregion

        #region Properties

        public static readonly DependencyProperty RotationXProperty = DependencyProperty.Register("RotationX", typeof(double), typeof(Planerator), new UIPropertyMetadata(0.0, (d, args) => ((Planerator)d).UpdateRotation()));
        public double RotationX
        {
            get { return (double)this.GetValue(RotationXProperty); }
            set { this.SetValue(RotationXProperty, value); }
        }

        public static readonly DependencyProperty RotationYProperty = DependencyProperty.Register("RotationY", typeof(double), typeof(Planerator), new UIPropertyMetadata(0.0, (d, args) => ((Planerator)d).UpdateRotation()));
        public double RotationY
        {
            get { return (double)this.GetValue(RotationYProperty); }
            set { this.SetValue(RotationYProperty, value); }
        }

        public static readonly DependencyProperty RotationZProperty = DependencyProperty.Register("RotationZ", typeof(double), typeof(Planerator), new UIPropertyMetadata(0.0, (d, args) => ((Planerator)d).UpdateRotation()));
        public double RotationZ
        {
            get { return (double)this.GetValue(RotationZProperty); }
            set { this.SetValue(RotationZProperty, value); }
        }

        public static readonly DependencyProperty FieldOfViewProperty = DependencyProperty.Register("FieldOfView", typeof(double), typeof(Planerator), new UIPropertyMetadata(45.0, (d, args) => ((Planerator)d).Update3D(), (d, val) => Math.Min(Math.Max((double)val, 0.5), 179.9))); // clamp to a meaningful range
        public double FieldOfView
        {
            get { return (double)this.GetValue(FieldOfViewProperty); }
            set { this.SetValue(FieldOfViewProperty, value); }
        }

        public FrameworkElement Child
        {
            get
            {
                return this._originalChild;
            }
            set
            {
                if (this._originalChild == value)
                    return;
                this.RemoveVisualChild(this._visualChild);
                this.RemoveLogicalChild(this._logicalChild);

                this._originalChild = value;
                this._logicalChild = new LayoutInvalidationCatcher { Child = this._originalChild };
                this._visualChild = this.CreateVisualChild();

                this.AddVisualChild(this._visualChild);

                this.AddLogicalChild(this._logicalChild);
                this.InvalidateMeasure();
            }
        }

        #endregion

        #region Override

        protected override Size MeasureOverride(Size availableSize)
        {
            Size result;
            if (this._logicalChild != null)
            {
                this._logicalChild.Measure(availableSize);
                result = this._logicalChild.DesiredSize;
                this._visualChild.Measure(result);
            }
            else
                result = new Size(0, 0);
            return result;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (this._logicalChild != null)
            {
                this._logicalChild.Arrange(new Rect(finalSize));
                this._visualChild.Arrange(new Rect(finalSize));
                this.Update3D();
            }
            return base.ArrangeOverride(finalSize);
        }

        protected override Visual GetVisualChild(int index)
        {
            return this._visualChild;

        }

        protected override int VisualChildrenCount
        {
            get
            {
                return this._visualChild == null ? 0 : 1;
            }
        }

        #endregion

        #region Methods

        private void SetCachingForObject(DependencyObject d)
        {
            RenderOptions.SetCachingHint(d, CachingHint.Cache);
            RenderOptions.SetCacheInvalidationThresholdMinimum(d, 0.5);
            RenderOptions.SetCacheInvalidationThresholdMaximum(d, 2.0);
        }

        private void UpdateRotation()
        {
            var qx = new Quaternion(_xAxis, this.RotationX);
            var qy = new Quaternion(_yAxis, this.RotationY);
            var qz = new Quaternion(_zAxis, this.RotationZ);

            this._quaternionRotation.Quaternion = qx * qy * qz;
        }

        private void Update3D()
        {
            var logicalBounds = VisualTreeHelper.GetDescendantBounds(this._logicalChild);
            var w = logicalBounds.Width;
            var h = logicalBounds.Height;

            var fovInRadians = this.FieldOfView * (Math.PI / 180);
            var zValue = w / Math.Tan(fovInRadians / 2) / 2;
            this._viewport3d.Camera = new PerspectiveCamera(new Point3D(w / 2, h / 2, zValue), -_zAxis, _yAxis, this.FieldOfView);

            this._scaleTransform.ScaleX = w;
            this._scaleTransform.ScaleY = h;
            this._rotationTransform.CenterX = w / 2;
            this._rotationTransform.CenterY = h / 2;
        }

        #endregion

        #region Functions

        private FrameworkElement CreateVisualChild()
        {
            var simpleQuad = new MeshGeometry3D();
            simpleQuad.Positions = new Point3DCollection(_mesh);
            simpleQuad.TextureCoordinates = new PointCollection(_texCoords);
            simpleQuad.TriangleIndices = new Int32Collection(_indices);

            Material frontMaterial = new DiffuseMaterial(Brushes.White);
            frontMaterial.SetValue(Viewport2DVisual3D.IsVisualHostMaterialProperty, true);

            var vb = new VisualBrush(this._logicalChild);
            this.SetCachingForObject(vb);  // big perf wins by caching!!
            Material backMaterial = new DiffuseMaterial(vb);

            this._rotationTransform.Rotation = this._quaternionRotation;
            var xfGroup = new Transform3DGroup();
            xfGroup.Children.Add(this._scaleTransform);
            xfGroup.Children.Add(this._rotationTransform);

            var backModel = new GeometryModel3D();
            backModel.Geometry = simpleQuad;
            backModel.Transform = xfGroup;
            backModel.BackMaterial = backMaterial;

            var m3dGroup = new Model3DGroup();
            m3dGroup.Children.Add(new DirectionalLight(Colors.White, new Vector3D(0, 0, -1)));
            m3dGroup.Children.Add(new DirectionalLight(Colors.White, new Vector3D(0.1, -0.1, 1)));
            m3dGroup.Children.Add(backModel);

            var mv3d = new ModelVisual3D();
            mv3d.Content = m3dGroup;

            var frontModel = new Viewport2DVisual3D();
            frontModel.Geometry = simpleQuad;
            frontModel.Visual = this._logicalChild;
            frontModel.Material = frontMaterial;
            frontModel.Transform = xfGroup;

            // Big perf wins.
            this.SetCachingForObject(frontModel);

            this._viewport3d = new Viewport3D();
            this._viewport3d.ClipToBounds = false;
            this._viewport3d.Children.Add(mv3d);
            this._viewport3d.Children.Add(frontModel);

            this.UpdateRotation();

            return this._viewport3d;
        }

        #endregion
    }
}
