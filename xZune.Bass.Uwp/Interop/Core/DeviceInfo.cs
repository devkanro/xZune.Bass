// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: DeviceInfo.cs
// Version: 20160215

using System;
using System.Runtime.InteropServices;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="GetDeviceInfo" /> or <see cref="RecordGetDeviceInfo" /> to retrieve information on a device.
    /// </summary>
    /// <remarks>
    ///     When a device is disabled/disconnected, it is still retained in the device list, but the BASS_DEVICE_ENABLED flag
    ///     is removed from it. If the device is subsequently re-enabled, it may become available again with the same device
    ///     number, or the system may add a new entry for it.
    ///     <para />
    ///     When a new device is connected, it can affect the other devices and result in the system moving them to new device
    ///     entries. If an affected device is initialized, it will stop working and will need to be reinitialized using its new
    ///     device number.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct DeviceInfo
    {
        /// <summary>
        ///     Description of the device.
        /// </summary>
        public IntPtr Name;

        /// <summary>
        ///     The filename of the driver.
        /// </summary>
        public IntPtr Driver;

        /// <summary>
        ///     The device's current status.
        /// </summary>
        public DeviceStatus Status;
    }
}