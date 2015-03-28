// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MonitorInfo.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the MonitorInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace ZolyFramework.Core.Win32
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MonitorInfo
    {
        public int cbSize = Marshal.SizeOf(typeof(MonitorInfo));

        public RECT rcMonitor = new RECT();

        public RECT rcWork = new RECT();

        public int dwFlags = 0;
    }
}
