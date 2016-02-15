// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Dx8Chorus.cs
// Version: 20160216

using System.Runtime.InteropServices;
using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="FXGetParameters" /> and <see cref="FXSetParameters" /> to retrieve and set the parameters of a
    ///     DX8 chorus effect.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Dx8Chorus
    {
        /// <summary>
        ///     Ratio of wet (processed) signal to dry (unprocessed) signal. Must be in the range from 0 through 100 (all wet). The
        ///     default value is 50.
        /// </summary>
        public float WetDryMix;

        /// <summary>
        ///     Percentage by which the delay time is modulated by the low-frequency oscillator (LFO). Must be in the range from 0
        ///     through 100. The default value is 10.
        /// </summary>
        public float Depth;

        /// <summary>
        ///     Percentage of output signal to feed back into the effect's input, in the range from -99 to 99. The default value is
        ///     25.
        /// </summary>
        public float Feedback;

        /// <summary>
        ///     Frequency of the LFO, in the range from 0 to 10. The default value is 1.1.
        /// </summary>
        public float Frequency;

        /// <summary>
        ///     Waveform of the LFO... 0 = triangle, 1 = sine. By default, the waveform is sine.
        /// </summary>
        public uint WaveFormat;

        /// <summary>
        ///     Number of milliseconds the input is delayed before it is played back, in the range from 0 to 20. The default value
        ///     is 16 ms.
        /// </summary>
        public float Delay;

        /// <summary>
        ///     Phase differential between left and right LFOs, one of <see cref="Dx8PhaseType" />. The default value is
        ///     <see cref="Dx8PhaseType.Phase90" />.
        /// </summary>
        public uint Phase;
    }
}