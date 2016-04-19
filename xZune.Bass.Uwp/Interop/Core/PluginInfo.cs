// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: PluginInfo.cs
// Version: 20160215

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="PluginGetInfo" /> to retrieve information on a plug-in.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PluginInfo
    {
        /// <summary>
        ///     Plug-in version, in the same form as given by <see cref="GetVersion" />.
        /// </summary>
        public uint Version { get; private set; }

        /// <summary>
        ///     Number of supported formats.
        /// </summary>
        public uint FormatCount { get; private set; }

        /// <summary>
        ///     The array of supported formats. The array contains <see cref="FormatCount" /> elements.
        /// </summary>
        public IntPtr Formats { get; private set; }
    }
}