// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Dx8ParametricEqualizer.cs
// Version: 20160216

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="FXGetParameters" /> and <see cref="FXSetParameters" /> to retrieve and set the parameters of a
    ///     DX8 parametric equalizer effect.
    /// </summary>
    public struct Dx8ParametricEqualizer
    {
        #region Public Fields

        /// <summary>
        ///     Bandwidth, in semitones, in the range from 1 to 36. The default value is 12.
        /// </summary>
        public float Bandwidth;

        /// <summary>
        ///     Center frequency, in hertz.
        /// </summary>
        public float Center;

        /// <summary>
        ///     Gain, in the range from -15 to 15. The default value is 0 dB.
        /// </summary>
        public float Gain;

        #endregion Public Fields
    }
}