// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Dx8Reverb.cs
// Version: 20160216

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="FXGetParameters" /> and <see cref="FXSetParameters" /> to retrieve and set the parameters of a
    ///     DX8 reverb effect.
    /// </summary>
    public struct Dx8Reverb
    {
        #region Public Fields

        /// <summary>
        ///     High-frequency reverb time ratio, in the range from 0.001 through 0.999. The default value is 0.001.
        /// </summary>
        public float HighFreqRTRatio;

        /// <summary>
        ///     Input gain of signal, in decibels (dB), in the range from -96 through 0. The default value is 0 dB.
        /// </summary>
        public float InGain;

        /// <summary>
        ///     Reverb mix, in dB, in the range from -96 through 0. The default value is 0 dB.
        /// </summary>
        public float ReverbMix;

        /// <summary>
        ///     Reverb time, in milliseconds, in the range from 0.001 through 3000. The default value is 1000.
        /// </summary>
        public float ReverbTime;

        #endregion Public Fields
    }
}