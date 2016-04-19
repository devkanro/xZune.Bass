// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagFlacCueTrackIndex.cs
// Version: 20160223

namespace xZune.Bass.Interop.Flac
{
    public struct TagFlacCueTrackIndex
    {
        /// <summary>
        ///     Index offset in samples relative to the track offset.
        /// </summary>
        public ulong Offset;

        /// <summary>
        ///     The index number.
        /// </summary>
        public uint Number;
    }
}