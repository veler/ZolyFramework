// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPropertyStore.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the IPropertyStore type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.Core.Shortcut
{
    using System;
    using System.Runtime.InteropServices;

    using ZolyFramework.Core.Win32.PropertySystem;

    [ComImport]
    [Guid(ShellIidGuid.PropertyStore)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IPropertyStore
    {
        UInt32 GetCount([Out] out uint propertyCount);
        UInt32 GetAt([In] uint propertyIndex, out PropertyKey key);
        UInt32 GetValue([In] ref PropertyKey key, [Out] PropVariant pv);
        uint SetValue([In] ref PropertyKey key, [In] PropVariant pv);
        UInt32 Commit();
    }
}
