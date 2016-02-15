// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: RecordInitializationConfig.cs
// Version: 20160216

namespace xZune.Bass.Interop.Core.Flags
{
    public enum RecordInitializationConfig
    {
        /// <summary>
        ///     Use 8-bit resolution. If neither this or the <see cref="Float" /> flag are specified, then the recorded data is
        ///     16-bit.
        /// </summary>
        _8Bits = Internal.SampleConfig._8Bits,

        /// <summary>
        ///     Use 32-bit floating-point sample data. See Floating-point channels for info.
        /// </summary>
        Float = Internal.SampleConfig.Float,

        /// <summary>
        ///     Start the recording paused. Use <see cref="ChannelPlay" /> to resume it.
        /// </summary>
        Pause = Internal.RecordConfig.Pause
    }
}