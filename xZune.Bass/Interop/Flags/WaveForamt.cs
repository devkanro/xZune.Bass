// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: WaveForamt.cs
// Version: 20160216

namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    ///     The standard formats supported by the device.
    /// </summary>
    public enum WaveForamt : uint
    {
        /// <summary>
        ///     11025 Hz, Mono, 8-bit
        /// </summary>
        Format1M08 = Internal.WaveForamt.Format1M08,

        /// <summary>
        ///     11025 Hz, Stereo, 8-bit
        /// </summary>
        Format1S08 = Internal.WaveForamt.Format1S08,

        /// <summary>
        ///     11025 Hz, Mono, 16-bit
        /// </summary>
        Format1M16 = Internal.WaveForamt.Format1M16,

        /// <summary>
        ///     11025 Hz, Stereo, 16-bi
        /// </summary>
        Format1S16 = Internal.WaveForamt.Format1S16,

        /// <summary>
        ///     22050 Hz, Mono, 8-bit
        /// </summary>
        Format2M08 = Internal.WaveForamt.Format2M08,

        /// <summary>
        ///     22050 Hz, Stereo, 8-bit
        /// </summary>
        Format2S08 = Internal.WaveForamt.Format2S08,

        /// <summary>
        ///     22050 Hz, Mono, 16-bit
        /// </summary>
        Format2M16 = Internal.WaveForamt.Format2M16,

        /// <summary>
        ///     22050 Hz, Stereo, 16-bit
        /// </summary>
        Format2S16 = Internal.WaveForamt.Format2S16,

        /// <summary>
        ///     44100 Hz, Mono, 8-bit
        /// </summary>
        Format4M08 = Internal.WaveForamt.Format4M08,

        /// <summary>
        ///     44100 Hz, Stereo, 8-bit
        /// </summary>
        Format4S08 = Internal.WaveForamt.Format4S08,

        /// <summary>
        ///     44100 Hz, Mono, 16-bit
        /// </summary>
        Format4M16 = Internal.WaveForamt.Format4M16,

        /// <summary>
        ///     44100 Hz, Stereo, 16-bit
        /// </summary>
        Format4S16 = Internal.WaveForamt.Format4S16
    }
}