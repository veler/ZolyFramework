// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Consts.cs" company="Etienne BAUDOUX">
//   
// </copyright>
// <summary>
//   Defines the Consts type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZolyFramework.Core.Win32
{
    using System;

    internal class Consts
    {
        internal const int WM_SYSCOMMAND = 0x112;

        internal const uint TPM_LEFTALIGN = 0x0000;

        internal const uint TPM_RETURNCMD = 0x0100;

        internal const UInt32 MF_ENABLED = 0x00000000;

        internal const UInt32 MF_GRAYED = 0x00000001;

        internal const UInt32 SC_MAXIMIZE = 0xF030;

        internal const UInt32 SC_MINIMIZE = 0xF020;

        internal const UInt32 SC_RESTORE = 0xF120;

        internal const UInt32 SC_MOVE = 0xF010;

        internal const UInt32 SC_SIZE = 0xF000;
    }
}
