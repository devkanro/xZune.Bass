// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagCoreAudioCodec.cs
// Version: 20160215

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     CoreAudio codec information structure.
    /// </summary>
    /// <remarks>
    ///     A list of file and audio data format identifiers is available from Apple, here. Additional formats may be available
    ///     via third-party codecs.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct TagCoreAudioCodec
    {
        /// <summary>
        ///     File format identifier.
        /// </summary>
        public uint FileType;

        /// <summary>
        ///     Audio data format identifier.
        /// </summary>
        public uint AudioType;

        /// <summary>
        ///     Description of the audio file format.
        /// </summary>
        public IntPtr Name;
    }
}