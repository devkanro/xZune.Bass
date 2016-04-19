// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagCartTimer.cs
// Version: 20160215

using System.Runtime.InteropServices;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     BWF "cart" tag timer structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TagCartTimer
    {
        /// <summary>
        ///     FOURCC timer usage ID.
        /// </summary>
        public uint Usage;

        /// <summary>
        ///     Timer value in samples from head.
        /// </summary>
        public uint Value;
    }
}