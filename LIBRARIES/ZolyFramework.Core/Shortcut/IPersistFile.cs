// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPersistFile.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the IPersistFile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.Core.Shortcut
{
    using System.Runtime.InteropServices;
    using System.Text;

    [ComImport, Guid(ShellIidGuid.PersistFile), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPersistFile
    {
        uint GetCurFile([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile);

        uint IsDirty();

        uint Load([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, [MarshalAs(UnmanagedType.U4)] Stgm dwMode);

        uint Save([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, bool fRemember);

        uint SaveCompleted([MarshalAs(UnmanagedType.LPWStr)] string pszFileName);
    }
}
