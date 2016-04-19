// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Dx8Distortion.cs
// Version: 20160216

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="FXGetParameters" /> and <see cref="FXSetParameters" /> to retrieve and set the parameters of a
    ///     DX8 distortion effect.
    /// </summary>
    public struct Dx8Distortion
    {
        /// <summary>
        ///     Amount of signal change after distortion, in the range from -60 through 0. The default value is -18 dB.
        /// </summary>
        public float Gain;

        /// <summary>
        ///     Percentage of distortion intensity, in the range in the range from 0 through 100. The default value is 15 percent.
        /// </summary>
        public float Edge;

        /// <summary>
        ///     Center frequency of harmonic content addition, in the range from 100 through 8000. The default value is 2400 Hz.
        /// </summary>
        public float PostEQCenterFrequency;

        /// <summary>
        ///     Width of frequency band that determines range of harmonic content addition, in the range from 100 through 8000. The
        ///     default value is 2400 Hz.
        /// </summary>
        public float PostEQBandwidth;

        /// <summary>
        ///     Filter cutoff for high-frequency harmonics attenuation, in the range from 100 through 8000. The default value is
        ///     8000 Hz.
        /// </summary>
        public float PreLowpassCutoff;
    }
}