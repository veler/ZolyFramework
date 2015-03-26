using System.Runtime.InteropServices;

namespace ZolyFramework.Core.Win32
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal class MonitorInfo
    {
        public int cbSize = Marshal.SizeOf(typeof(MonitorInfo));

        public RECT rcMonitor = new RECT();

        public RECT rcWork = new RECT();

        public int dwFlags = 0;
    }
}
