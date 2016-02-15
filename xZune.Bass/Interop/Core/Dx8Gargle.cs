// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Dx8Gargle.cs
// Version: 20160216

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="FXGetParameters" /> and <see cref="FXSetParameters" /> to retrieve and set the parameters of a
    ///     gargle DX8 (amplitude modulation) effect.
    /// </summary>
    public struct Dx8Gargle
    {
        /// <summary>
        ///     Rate of modulation, in Hertz. Must be in the range from 1 through 1000. The default value is 20.
        /// </summary>
        public uint RateHz;

        /// <summary>
        ///     Shape of the modulation waveform... 0 = triangle, 1 = square. By default, the waveform is triangle.
        /// </summary>
        public uint WaveShape;
    }
}