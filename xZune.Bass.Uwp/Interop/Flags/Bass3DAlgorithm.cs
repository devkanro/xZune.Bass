// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Bass3DAlgorithm.cs
// Version: 20160219

namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    ///     3D algorithm for software mixed 3D channels.
    /// </summary>
    public enum Bass3DAlgorithm
    {
        /// <summary>
        ///     The default algorithm. If the user has selected a surround sound speaker configuration (eg. 4 or 5.1) in the
        ///     control panel, the sound is panned among the available directional speakers. Otherwise it equates to
        ///     <see cref="Off" />.
        /// </summary>
        Default = Internal.Bass3DAlgorithm.Default,

        /// <summary>
        ///     Uses normal left and right panning. The vertical axis is ignored except for scaling of volume due to distance.
        ///     Doppler shift and volume scaling are still applied, but the 3D filtering is not performed. This is the most CPU
        ///     efficient algorithm, but provides no virtual 3D audio effect. Head Related Transfer Function processing will not be
        ///     done. Since only normal stereo panning is used, a channel using this algorithm may be accelerated by a 2D hardware
        ///     voice if no free 3D hardware voices are available.
        /// </summary>
        Off = Internal.Bass3DAlgorithm.Off,

        /// <summary>
        ///     This algorithm gives the highest quality 3D audio effect, but uses more CPU. This algorithm requires WDM drivers,
        ///     if it's not available then <see cref="Off" /> will automatically be used instead.
        /// </summary>
        Full = Internal.Bass3DAlgorithm.Full,

        /// <summary>
        ///     This algorithm gives a good 3D audio effect, and uses less CPU than the FULL algorithm. This algorithm also
        ///     requires WDM drivers, if it's not available then <see cref="Off" /> will automatically be used instead.
        /// </summary>
        Light = Internal.Bass3DAlgorithm.Light
    }
}