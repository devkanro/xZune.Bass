// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: DeviceCapabilities.cs
// Version: 20160215

using System;

namespace xZune.Bass.Interop.Core.Flags.Internal
{
    [Flags]
    internal enum DeviceCapabilities
    {
        /// <summary>
        ///     The device supports all sample rates between min-rate and max-rate.
        /// </summary>
        Continuousrate = 0x00000010,

        /// <summary>
        ///     The device's drivers do NOT have DirectSound support, so it is being emulated. Updated drivers should be installed.
        /// </summary>
        EmulDriver = 0x00000020,

        /// <summary>
        ///     The device driver has been certified by Microsoft. This flag is always set on WDM drivers.
        /// </summary>
        Certified = 0x00000040,

        /// <summary>
        ///     Mono samples are supported by hardware mixing.
        /// </summary>
        SecondaryMono = 0x00000100,

        /// <summary>
        ///     Stereo samples are supported by hardware mixing.
        /// </summary>
        SecondaryStereo = 0x00000200,

        /// <summary>
        ///     8-bit samples are supported by hardware mixing.
        /// </summary>
        Secondary8Bit = 0x00000400,

        /// <summary>
        ///     16-bit samples are supported by hardware mixing.
        /// </summary>
        Secondary16Bit = 0x00000800
    }
}