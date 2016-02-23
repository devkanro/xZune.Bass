// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagFlacCue.cs
// Version: 20160223

using System;

namespace xZune.Bass.Interop.Flac
{
    /// <summary>
    ///     FLAC cue sheet tag structure.
    /// </summary>
    public struct TagFlacCue
    {
        /// <summary>
        ///     Media catalog number.
        /// </summary>
        public IntPtr Catalog;

        /// <summary>
        ///     The number of lead-in samples.
        /// </summary>
        public uint Leadin;

        /// <summary>
        ///     The cue sheet corresponds to a CD?
        /// </summary>
        public bool IsCD;

        /// <summary>
        ///     The number of tracks.
        /// </summary>
        public uint TracksCount;

        /// <summary>
        ///     The tracks.
        /// </summary>
        public IntPtr Tracks;
    }
}