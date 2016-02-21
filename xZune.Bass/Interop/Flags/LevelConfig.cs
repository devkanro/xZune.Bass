// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: LevelConfig.cs
// Version: 20160215

using System;

namespace xZune.Bass.Interop.Flags
{
    [Flags]
    public enum LevelConfig
    {
        None,
        /// <summary>
        ///     Get a mono level. If neither this or the <see cref="Stereo" /> flag is used, then a separate level is retrieved for
        ///     each channel.
        /// </summary>
        Mono = Internal.LevelConfig.Mono,

        /// <summary>
        ///     Get a stereo level. The left level will be from the even channels, and the right level will be from the odd
        ///     channels. If there are an odd number of channels then the left and right levels will both include all channels.
        /// </summary>
        Stereo = Internal.LevelConfig.Stereo,

        /// <summary>
        ///     Get the RMS level. Otherwise the peak level.
        /// </summary>
        Rms = Internal.LevelConfig.Rms
    }
}