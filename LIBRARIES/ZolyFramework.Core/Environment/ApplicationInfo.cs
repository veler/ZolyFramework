// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationInfo.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ApplicationInfo type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.Core.Environment
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Give some information about the app.
    /// </summary>
    public static class ApplicationInfo
    {
        /// <summary>
        /// Get application name.
        /// </summary>
        /// <returns>
        /// The application name.
        /// </returns>
        public static string GetName()
        {
            return Assembly.GetEntryAssembly().GetName().Name;
        }

        /// <summary>
        /// Get application version.
        /// </summary>
        /// <returns>
        /// The application version.
        /// </returns>
        public static Version GetVersion()
        {
            return Assembly.GetEntryAssembly().GetName().Version;
        }
    }
}
