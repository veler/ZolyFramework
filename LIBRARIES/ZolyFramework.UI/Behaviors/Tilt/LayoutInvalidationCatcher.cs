// Not from Etienne

namespace ZolyFramework.UI.Behaviors.Tilt
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Wrap this around a class that we want to catch the measure and arrange 
    /// processes occuring on, and propagate to the parent Planerator, if any.
    /// Do this because layout invalidations don't flow up out of a 
    /// Viewport2DVisual3D object.
    /// </summary>
    public class LayoutInvalidationCatcher : Decorator
    {
        public Planerator PlaParent { get { return this.Parent as Planerator; } }

        protected override Size MeasureOverride(Size constraint)
        {
            var pl = this.PlaParent;
            if (pl != null)
                pl.InvalidateMeasure();
            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var pl = this.PlaParent;
            if (pl != null)
                pl.InvalidateArrange();
            return base.ArrangeOverride(arrangeSize);
        }
    }
}
