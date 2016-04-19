// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: SampleConfig.cs
// Version: 20160216

using System;

namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    ///     Configure of sample.
    /// </summary>
    [Flags]
    public enum SampleConfig
    {
        None,
        /// <summary>
        ///     Use 8-bit resolution. If neither this or the BASS_SAMPLE_FLOAT flags are specified, then the sample is 16-bit.
        /// </summary>
        _8Bits = Internal.SampleConfig._8Bits,

        /// <summary>
        ///     Use 32-bit floating-point sample data. Not really recommended for samples as it (at least) doubles the memory
        ///     usage.
        /// </summary>
        Float = Internal.SampleConfig.Float,

        /// <summary>
        ///     Looped? Note that only complete sample loops are allowed; you cannot loop just a part of the sample. More fancy
        ///     looping can be achieved via streaming.
        /// </summary>
        Loop = Internal.SampleConfig.Loop,

        /// <summary>
        ///     Enable 3D functionality. This requires that the BASS_DEVICE_3D flag was specified when calling BASS_Init, and the
        ///     sample must be mono (chans=1).
        /// </summary>
        _3D = Internal.SampleConfig._3D,

        /// <summary>
        ///     Force the sample to not use hardware mixing.
        /// </summary>
        Software = Internal.SampleConfig.Software,

        /// <summary>
        ///     Mute the sample when it is at (or beyond) its max distance (software-mixed 3D samples only).
        /// </summary>
        Mutemax = Internal.SampleConfig.Mutemax,

        /// <summary>
        ///     Enables the DX7 voice allocation and management features on the sample, which allows the sample to be played in
        ///     software or hardware. This flag is ignored if the BASS_SAMPLE_SOFTWARE flag is also specified.
        /// </summary>
        Vam = Internal.SampleConfig.Vam,

        /// <summary>
        ///     Override: the channel with the lowest volume is overridden.
        /// </summary>
        OverVol = Internal.SampleConfig.OverVol,

        /// <summary>
        ///     Override: the longest playing channel is overridden.
        /// </summary>
        OverPos = Internal.SampleConfig.OverPos,

        /// <summary>
        ///     Override: the channel furthest away (from the listener) is overridden (3D samples only).
        /// </summary>
        OverDist = Internal.SampleConfig.OverDist
    }
}