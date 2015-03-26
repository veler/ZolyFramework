using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZolyFramework.UI.Tests.Converters
{
    [TestClass]
    public class Converters
    {
        [TestMethod]
        public void BooleanToThicknessConverterTest()
        {
            var converter = new ZolyFramework.UI.Converters.BooleanToThicknessConverter();
            Assert.AreEqual(new Thickness(1), converter.Convert(true, typeof(Thickness), null, null));
            Assert.AreEqual(true, converter.ConvertBack(new Thickness(1), typeof(Thickness), null, null));
        }

        [TestMethod]
        public void ResizeModeToVisibilityConverterTest()
        {
            var converter = new ZolyFramework.UI.Converters.ResizeModeToVisibilityConverter();
            Assert.AreEqual(Visibility.Visible, converter.Convert(ResizeMode.CanMinimize, typeof(Visibility), null, null));
            Assert.AreEqual(Visibility.Collapsed, converter.Convert(ResizeMode.NoResize, typeof(Visibility), null, null));
            Assert.AreEqual(Visibility.Visible, converter.Convert(ResizeMode.CanResize, typeof(Visibility), null, null));
            Assert.AreEqual(Visibility.Visible, converter.Convert(ResizeMode.CanResizeWithGrip, typeof(Visibility), null, null));
        }

        [TestMethod]
        public void WindowStateToThicknessConverterTest()
        {
            var converter = new ZolyFramework.UI.Converters.WindowStateToThicknessConverter();
            Assert.AreEqual(new Thickness(0), converter.Convert(WindowState.Maximized, typeof(WindowState), null, null));
            Assert.AreEqual(new Thickness(1), converter.Convert(WindowState.Minimized, typeof(WindowState), null, null));
            Assert.AreEqual(new Thickness(1), converter.Convert(WindowState.Normal, typeof(WindowState), null, null));
        }

        [TestMethod]
        public void WindowStateToVisibilityConverterTest()
        {
            var converter = new ZolyFramework.UI.Converters.WindowStateToVisibilityConverter();
            Assert.AreEqual(Visibility.Collapsed, converter.Convert(WindowState.Maximized, typeof(WindowState), null, null));
            Assert.AreEqual(Visibility.Visible, converter.Convert(WindowState.Minimized, typeof(WindowState), null, null));
            Assert.AreEqual(Visibility.Visible, converter.Convert(WindowState.Normal, typeof(WindowState), null, null));
        }
    }
}
