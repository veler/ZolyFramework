using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace ZolyFramework.Core.Win32
{
    public class Wm
    {
        public static IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }
            return (IntPtr)0;
        }

        public static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            var mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            // Adjust the maximized size and position to fit the work area of the correct monitor
            const int monitorDefaulttonearest = 0x00000002;
            var monitor = User32.MonitorFromWindow(hwnd, monitorDefaulttonearest);

            if (monitor != IntPtr.Zero)
            {
                var monitorInfo = new MonitorInfo();
                User32.GetMonitorInfo(monitor, monitorInfo);
                var rcWorkArea = monitorInfo.rcWork;
                var rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }

        public static Point GetMousePosition()
        {
            var w32Mouse = new Win32Point();
            User32.GetCursorPos(ref w32Mouse);
            return new Point(w32Mouse.X, w32Mouse.Y);
        }

        public static void ShowWindowSystemMenu(Window window)
        {
            var helper = new WindowInteropHelper(window);
            var callingWindow = helper.Handle;
            var wMenu = User32.GetSystemMenu(callingWindow, false);

            switch (window.ResizeMode)
            {
                case ResizeMode.CanMinimize:
                    User32.EnableMenuItem(wMenu, Consts.SC_MINIMIZE, Consts.MF_ENABLED);
                    User32.EnableMenuItem(wMenu, Consts.SC_MAXIMIZE, Consts.MF_GRAYED);
                    break;
                case ResizeMode.NoResize:
                    User32.EnableMenuItem(wMenu, Consts.SC_MINIMIZE, Consts.MF_GRAYED);
                    User32.EnableMenuItem(wMenu, Consts.SC_MAXIMIZE, Consts.MF_GRAYED);
                    break;
                default:
                    User32.EnableMenuItem(wMenu, Consts.SC_MAXIMIZE, Consts.MF_ENABLED);
                    break;
            }

            if (window.WindowState == WindowState.Maximized)
            {
                User32.EnableMenuItem(wMenu, Consts.SC_MAXIMIZE, Consts.MF_GRAYED);
                User32.EnableMenuItem(wMenu, Consts.SC_MOVE, Consts.MF_GRAYED);
                User32.EnableMenuItem(wMenu, Consts.SC_SIZE, Consts.MF_GRAYED);
                User32.EnableMenuItem(wMenu, Consts.SC_RESTORE, Consts.MF_ENABLED);
            }
            else
            {
                User32.EnableMenuItem(wMenu, Consts.SC_MOVE, Consts.MF_ENABLED);
                User32.EnableMenuItem(wMenu, Consts.SC_SIZE, Consts.MF_ENABLED);
                User32.EnableMenuItem(wMenu, Consts.SC_RESTORE, Consts.MF_GRAYED);
            }

            var command = User32.TrackPopupMenuEx(wMenu, Consts.TPM_LEFTALIGN | Consts.TPM_RETURNCMD, (int)GetMousePosition().X, (int)GetMousePosition().Y, callingWindow, IntPtr.Zero);
            if (command == 0)
                return;

            User32.PostMessage(callingWindow, Consts.WM_SYSCOMMAND, new IntPtr(command), IntPtr.Zero);
        }
    }
}
