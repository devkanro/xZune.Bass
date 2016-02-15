// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: SampleDataType.cs
// Version: 20160215
namespace xZune.Bass.Interop.Core.Flags.Internal
{
    internal enum SampleDataType : uint
    {
        Available = 0,
        Fixed = 0x20000000,
        Float = 0x40000000,
        FFT256 = 0x80000000,
        FFT512 = 0x80000001,
        FFT1024 = 0x80000002,
        FFT2048 = 0x80000003,
        FFT4096 = 0x80000004,
        FFT8192 = 0x80000005,
        FFT16384 = 0x80000006,
        FFTIndividual = 0x10,
        FFTNoWindow = 0x20,
        FFTRemovedc = 0x40,
        FFTComplex = 0x80
    }
}