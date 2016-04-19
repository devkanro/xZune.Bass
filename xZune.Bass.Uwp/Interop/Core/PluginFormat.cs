// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: PluginFormat.cs
// Version: 20160215

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Information on a plug-in supported format.
    /// </summary>
    /// <remarks>
    ///     The extension filter is for information only. A plug-in will check the file contents rather than file extension, to
    ///     verify that it is a supported format.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct PluginFormat
    {
        /// <summary>
        ///     The channel type, as would appear in the <see cref="ChannelInfo" /> structure.
        /// </summary>
        public uint Type { get; private set; }

        /// <summary>
        ///     Format description.
        /// </summary>
        public IntPtr Name { get; private set; }

        /// <summary>
        ///     File extension filter, in the form of "*.ext1;*.ext2;...".
        /// </summary>
        public IntPtr Exts { get; private set; }
    }
}