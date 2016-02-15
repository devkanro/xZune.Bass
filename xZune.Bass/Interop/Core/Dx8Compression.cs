// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Dx8Compression.cs
// Version: 20160216

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="FXGetParameters" /> and <see cref="FXSetParameters" /> to retrieve and set the parameters of a
    ///     DX8 compression effect.
    /// </summary>
    public struct Dx8Compression
    {
        /// <summary>
        ///     Output gain of signal after compression, in the range from -60 to 60. The default value is 0 dB.
        /// </summary>
        public float Gain;

        /// <summary>
        ///     Output gain of signal after compression, in the range from -60 to 60. The default value is 0 dB.
        /// </summary>
        public float Attack;

        /// <summary>
        ///     Speed at which compression is stopped after input drops below fThreshold, in the range from 50 to 3000. The default
        ///     value is 200 ms.
        /// </summary>
        public float Release;

        /// <summary>
        ///     Point at which compression begins, in decibels, in the range from -60 to 0. The default value is -20 dB.
        /// </summary>
        public float Threshold;

        /// <summary>
        ///     Compression ratio, in the range from 1 to 100. The default value is 3, which means 3:1 compression.
        /// </summary>
        public float Ratio;

        /// <summary>
        ///     Time after fThreshold is reached before attack phase is started, in milliseconds, in the range from 0 to 4. The
        ///     default value is 4 ms.
        /// </summary>
        public float Predelay;
    }
}