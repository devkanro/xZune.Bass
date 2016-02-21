// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: SampleDataType.cs
// Version: 20160215

namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    ///     Types of sample data.
    /// </summary>
    public enum SampleDataType : uint
    {
        /// <summary>
        ///     Query the amount of data the channel has buffered for playback, or from recording. This flag cannot be used with
        ///     decoding channels as they do not have playback buffers. buffer is ignored when using this flag.
        /// </summary>
        Available = Internal.SampleDataType.Available,

        /// <summary>
        ///     Return 8.24 fixed-point data.
        /// </summary>
        Fixed = Internal.SampleDataType.Fixed,

        /// <summary>
        ///     Return floating-point sample data.
        /// </summary>
        Float = Internal.SampleDataType.Float,

        /// <summary>
        ///     256 sample FFT (returns 128 values).
        /// </summary>
        FFT256 = Internal.SampleDataType.FFT256,

        /// <summary>
        ///     512 sample FFT (returns 256 values).
        /// </summary>
        FFT512 = Internal.SampleDataType.FFT512,

        /// <summary>
        ///     1024 sample FFT (returns 512 values).
        /// </summary>
        FFT1024 = Internal.SampleDataType.FFT1024,

        /// <summary>
        ///     2048 sample FFT (returns 1024 values).
        /// </summary>
        FFT2048 = Internal.SampleDataType.FFT2048,

        /// <summary>
        ///     4096 sample FFT (returns 2048 values).
        /// </summary>
        FFT4096 = Internal.SampleDataType.FFT4096,

        /// <summary>
        ///     8192 sample FFT (returns 4096 values).
        /// </summary>
        FFT8192 = Internal.SampleDataType.FFT8192,

        /// <summary>
        ///     16384 sample FFT (returns 8192 values).
        /// </summary>
        FFT16384 = Internal.SampleDataType.FFT16384,

        /// <summary>
        ///     Perform a separate FFT for each channel, rather than a single combined FFT. The size of the data returned (as
        ///     listed above) is multiplied by the number of channels.
        /// </summary>
        FFTIndividual = Internal.SampleDataType.FFTIndividual,

        /// <summary>
        ///     Prevent a Hann window being applied to the sample data when performing an FFT.
        /// </summary>
        FFTNoWindow = Internal.SampleDataType.FFTNoWindow,

        /// <summary>
        ///     Remove any DC bias from the sample data when performing an FFT.
        /// </summary>
        FFTRemovedc = Internal.SampleDataType.FFTRemovedc,

        /// <summary>
        ///     Return the complex FFT result rather than the magnitudes. This increases the amount of data returned (as listed
        ///     above) fourfold, as it returns real and imaginary parts and the full FFT result (not only the first half). The real
        ///     and imaginary parts are interleaved in the returned data.
        /// </summary>
        FFTComplex = Internal.SampleDataType.FFTComplex
    }
}