// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: FxType.cs
// Version: 20160215
namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    /// Types of fx effect.
    /// </summary>
    public enum FxType
    {
        /// <summary>
        /// DX8 Chorus. Use <see cref="Core.Dx8Chorus"/> structure to set/get parameters.
        /// </summary>
        Dx8Chorus = Internal.FxType.Dx8Chorus,
        /// <summary>
        /// DX8 Compression. Use <see cref="Core.Dx8Compressor"/> structure to set/get parameters. 
        /// </summary>
        Dx8Compressor = Internal.FxType.Dx8Compressor,
        /// <summary>
        /// DX8 Distortion. Use <see cref="Core.Dx8Distortion"/> structure to set/get parameters. 
        /// </summary>
        Dx8Distortion = Internal.FxType.Dx8Distortion,
        /// <summary>
        /// DX8 Echo. Use <see cref="Core.Dx8Echo"/> structure to set/get parameters. 
        /// </summary>
        Dx8Echo = Internal.FxType.Dx8Echo,
        /// <summary>
        /// DX8 Flanger. Use <see cref="Core.Dx8Flanger"/> structure to set/get parameters. 
        /// </summary>
        Dx8Flanger = Internal.FxType.Dx8Flanger,
        /// <summary>
        /// DX8 Gargle. Use <see cref="Core.Dx8Gargle"/> structure to set/get parameters. 
        /// </summary>
        Dx8Gargle = Internal.FxType.Dx8Gargle,
        /// <summary>
        /// DX8 I3DL2 (Interactive 3D Audio Level 2) reverb. Use <see cref="Core.Dx8I3Dl2"/> structure to set/get parameters. 
        /// </summary>
        Dx8I3Dl2Reverb = Internal.FxType.Dx8I3Dl2Reverb,
        /// <summary>
        /// DX8 Parametric equalizer. Use <see cref="Core.Dx8ParametricEqualizer"/> structure to set/get parameters. 
        /// </summary>
        Dx8Parameq = Internal.FxType.Dx8Parameq,
        /// <summary>
        /// DX8 Reverb. Use <see cref="Core.Dx8Reverb"/> structure to set/get parameters. 
        /// </summary>
        Dx8Reverb = Internal.FxType.Dx8Reverb
    }
}