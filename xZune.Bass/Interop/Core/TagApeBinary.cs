// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagApeBinary.cs
// Version: 20160215

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     APEv2 binary tag structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TagApeBinary
    {
        /// <summary>
        ///     The name of the tag.
        /// </summary>
        public IntPtr Key;

        /// <summary>
        ///     The tag data.
        /// </summary>
        public IntPtr Data;

        /// <summary>
        ///     The size of data in bytes.
        /// </summary>
        public uint Length;
    }
}