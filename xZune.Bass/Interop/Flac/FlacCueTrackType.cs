// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: FlacCueTrackType.cs
// Version: 20160223

using System;

namespace xZune.Bass.Interop.Flac
{
    [Flags]
    public enum FlacCueTrackType
    {
        /// <summary>
        ///     Non-audio.
        /// </summary>
        Data = 1,

        /// <summary>
        ///     Pre-emphasis.
        /// </summary>
        Pre = 2
    }
}