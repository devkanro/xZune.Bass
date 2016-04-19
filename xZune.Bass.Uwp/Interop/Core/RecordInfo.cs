// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: RecordInfo.cs
// Version: 20160216

using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="RecordGetInfo" /> to retrieve information on the current recording device.
    /// </summary>
    public struct RecordInfo
    {
        /// <summary>
        ///     The device's capabilities.
        /// </summary>
        public RecordDeviceCapabilities DeviceCapabilities;

        /// <summary>
        ///     The standard formats supported by the device.
        /// </summary>
        public WaveForamt Formats;

        /// <summary>
        ///     The number of input sources available to the device.
        /// </summary>
        public uint Inputs;

        /// <summary>
        ///     TRUE = only one input may be active at a time.
        /// </summary>
        public uint SingleIn;

        /// <summary>
        ///     The device's current input sample rate. Recording at this rate will give the best quality and performance, as no
        ///     resampling is required.
        /// </summary>
        public uint Freq;
    }
}