// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorHelper.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the ErrorHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.Core.Win32
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Check automatically if a PInvoke returns an error.
    /// </summary>
    public static class ErrorHelper
    {
        /// <summary>
        /// Check automatically if a PInvoke returns an error.
        /// </summary>
        /// <param name="hresult">
        /// The HRESULT.
        /// </param>
        /// <exception cref="COMException">
        /// Correspond to the HRESULT number.
        /// </exception>
        public static void VerifySucceeded(uint hresult)
        {
            if (hresult > 1)
                throw new COMException("Failed with HRESULT: " + hresult.ToString("X"));
        }
    }
}
