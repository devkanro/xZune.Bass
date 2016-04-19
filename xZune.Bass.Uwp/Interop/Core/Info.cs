// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Info.cs
// Version: 20160214

using System.Runtime.InteropServices;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="GetInfo" /> to retrieve information on the current device.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Info
    {
        /// <summary>
        ///     The device's capabilities.
        /// </summary>
        public DeviceCapabilities Capabilities;

        /// <summary>
        ///     The device's total amount of hardware memory.
        /// </summary>
        public uint HardwareSize;

        /// <summary>
        ///     The device's amount of free hardware memory.
        /// </summary>
        public uint HardwareFree;

        /// <summary>
        ///     The number of free sample slots in the hardware.
        /// </summary>
        public uint Freesam;

        /// <summary>
        ///     The number of free 3D sample slots in the hardware.
        /// </summary>
        public uint Free3D;

        /// <summary>
        ///     The minimum sample rate supported by the hardware.
        /// </summary>
        public uint MinRate;

        /// <summary>
        ///     The maximum sample rate supported by the hardware.
        /// </summary>
        public uint MaxRate;

        /// <summary>
        ///     The device supports EAX and has it enabled? The device's "Hardware acceleration" needs to be set to "Full" in its
        ///     "Advanced Properties" setup, else EAX is disabled. This is always FALSE if BASS_DEVICE_3D was not specified when
        ///     <see cref="Initialize" /> was called.
        /// </summary>
        public bool Eax;

        /// <summary>
        ///     The minimum buffer length (rounded up to the nearest millisecond) recommended for use (with the BASS_CONFIG_BUFFER
        ///     configure option).
        /// </summary>
        public uint MinBuffer;

        /// <summary>
        ///     DirectSound version... 9 = DX9/8/7/5 features are available, 8 = DX8/7/5 features are available, 7 = DX7/5 features
        ///     are available, 5 = DX5 features are available. 0 = none of the DX9/8/7/5 features are available.
        /// </summary>
        public uint DSoundVersion;

        /// <summary>
        ///     The average delay (rounded up to the nearest millisecond) for playback of HSTREAM/HMUSIC channels to start and be
        ///     heard.
        /// </summary>
        public uint Latency;

        /// <summary>
        ///     The flags parameter of the <see cref="Initialize" /> call.
        /// </summary>
        public InitializationConfig Congfig;

        /// <summary>
        ///     The number of available speakers, which can be accessed via the speaker assignment flags.
        /// </summary>
        public uint Speakers;

        /// <summary>
        ///     The device's current output sample rate.
        /// </summary>
        public uint Freq;
    }
}