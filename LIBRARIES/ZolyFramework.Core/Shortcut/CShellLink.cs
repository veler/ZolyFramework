// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CShellLink.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the CShellLink type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.Core.Shortcut
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// The shell link.
    /// </summary>
    [ComImport]
    [Guid(ShellIidGuid.CShellLink)]
    [ClassInterface(ClassInterfaceType.None)]
    internal class CShellLink
    {
    }
}
