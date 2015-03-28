// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User32.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the User32 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.Core.Win32
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Provide some functions of User32.
    /// </summary>
    public static class User32
    {
        [DllImport("user32")]
        public static extern bool GetMonitorInfo(IntPtr hMonitor, MonitorInfo lpmi);

        [DllImport("user32")]
        public static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        public static extern int TrackPopupMenuEx(IntPtr hmenu, uint fuFlags, int x, int y, IntPtr hwnd, IntPtr lptpm);

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(ref Win32Point pt);

        [DllImport("user32.dll")]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("user32.dll")]
        public static extern uint GetDoubleClickTime();
    }
}
