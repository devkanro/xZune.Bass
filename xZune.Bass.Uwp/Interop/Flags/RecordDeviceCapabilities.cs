// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: RecordDeviceCapabilities.cs
// Version: 20160216

namespace xZune.Bass.Interop.Flags
{
    public enum RecordDeviceCapabilities
    {
        /// <summary>
        ///     The device's drivers do NOT have DirectSound support, so it is being emulated. Updated drivers should be installed.
        /// </summary>
        EmulDriver = Internal.DeviceCapabilities.EmulDriver,

        /// <summary>
        ///     The device driver has been certified by Microsoft. This flag is always set on WDM drivers.
        /// </summary>
        Certified = Internal.DeviceCapabilities.Certified
    }
}