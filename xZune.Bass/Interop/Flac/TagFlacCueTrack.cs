// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagFlacCueTrack.cs
// Version: 20160223

using System;

namespace xZune.Bass.Interop.Flac
{
    /// <summary>
    ///     FLAC cue sheet tag track structure.
    /// </summary>
    public struct TagFlacCueTrack
    {
        /// <summary>
        ///     Track offset in samples.
        /// </summary>
        public ulong Offset;

        /// <summary>
        ///     The track number.
        /// </summary>
        public uint Number;

        /// <summary>
        ///     International Standard Recording Code.
        /// </summary>
        public IntPtr ISRC;

        /// <summary>
        ///     Track type.
        /// </summary>
        public FlacCueTrackType Type;

        /// <summary>
        ///     The number of indexes.
        /// </summary>
        public uint IndexesCount;

        /// <summary>
        ///     The indexes.
        /// </summary>
        public IntPtr Indexes;
    }
}