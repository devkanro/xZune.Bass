// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Dx8Echo.cs
// Version: 20160216

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="FXGetParameters" /> and <see cref="FXSetParameters" /> to retrieve and set the parameters of a
    ///     DX8 echo effect.
    /// </summary>
    public struct Dx8Echo
    {
        /// <summary>
        ///     Ratio of wet (processed) signal to dry (unprocessed) signal. Must be in the range from 0 through 100 (all wet). The
        ///     default value is 50.
        /// </summary>
        public float WetDryMix;

        /// <summary>
        ///     Percentage of output fed back into input, in the range from 0 through 100. The default value is 50.
        /// </summary>
        public float Feedback;

        /// <summary>
        ///     Delay for left channel, in milliseconds, in the range from 1 through 2000. The default value is 500 ms.
        /// </summary>
        public float LeftDelay;

        /// <summary>
        ///     Delay for right channel, in milliseconds, in the range from 1 through 2000. The default value is 500 ms.
        /// </summary>
        public float RightDelay;

        /// <summary>
        ///     Value that specifies whether to swap left and right delays with each successive echo. The default value is FALSE,
        ///     meaning no swap.
        /// </summary>
        public int PanDelay;
    }
}