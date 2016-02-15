// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: DeviceCapabilities.cs
// Version: 20160215

namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    ///     Some capabilities enum used in <see cref="Info" />.
    /// </summary>
    public enum DeviceCapabilities
    {
        /// <summary>
        ///     The device supports all sample rates between min-rate and max-rate.
        /// </summary>
        Continuousrate = Internal.DeviceCapabilities.Continuousrate,

        /// <summary>
        ///     The device's drivers do NOT have DirectSound support, so it is being emulated. Updated drivers should be installed.
        /// </summary>
        EmulDriver = Internal.DeviceCapabilities.EmulDriver,

        /// <summary>
        ///     The device driver has been certified by Microsoft. This flag is always set on WDM drivers.
        /// </summary>
        Certified = Internal.DeviceCapabilities.Certified,

        /// <summary>
        ///     Mono samples are supported by hardware mixing.
        /// </summary>
        SecondaryMono = Internal.DeviceCapabilities.SecondaryMono,

        /// <summary>
        ///     Stereo samples are supported by hardware mixing.
        /// </summary>
        SecondaryStereo = Internal.DeviceCapabilities.SecondaryStereo,

        /// <summary>
        ///     8-bit samples are supported by hardware mixing.
        /// </summary>
        Secondary8Bit = Internal.DeviceCapabilities.Secondary8Bit,

        /// <summary>
        ///     16-bit samples are supported by hardware mixing.
        /// </summary>
        Secondary16Bit = Internal.DeviceCapabilities.Secondary16Bit
    }
}