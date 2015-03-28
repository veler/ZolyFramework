// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperatingSystemInfo.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the OperatingSystemInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.Core.Environment
{
    using System;

    /// <summary>
    /// Get some operating system's information.
    /// </summary>
    public static class OperatingSystemInfo
    {
        /// <summary>
        /// Check if the application is actually running under windows 8 or higher.
        /// </summary>
        /// <returns>
        /// Returns True if the operating system is Windows 8 or higher.
        /// </returns>
        public static bool RunningOnWindows8OrHigher()
        {
            return Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 2;
        }

        /// <summary>
        /// Get the current Windows version.
        /// </summary>
        /// <returns>
        /// Return a <see cref="WindowsVersion"/> value corresponding to the detected version of Windows.
        /// </returns>
        public static WindowsVersion GetWindowsVersion()
        {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                return WindowsVersion.Unknow;

            switch (Environment.OSVersion.Version.Major)
            {
                case 5:
                    switch (Environment.OSVersion.Version.Minor)
                    {
                        case 1:
                            return WindowsVersion.Xp;
                        case 2:
                            return WindowsVersion.Server2003;
                    }
                    break;

                case 6:
                    switch (Environment.OSVersion.Version.Minor)
                    {
                        case 0:
                            return WindowsVersion.VistaOrServer2008;
                        case 1:
                            return WindowsVersion.SevenOrServer2008R2;
                        case 2:
                            return WindowsVersion.HeightOrServer2012;
                        case 3:
                            return WindowsVersion.HeightPointOneOrServer2012R2;
                        case 4:
                            return WindowsVersion.Ten;
                    }
                    break;
            }

            return WindowsVersion.Unknow;
        }
    }
}
