// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: DeviceStatus.cs
// Version: 20160215

using System;

namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    ///     Some flags used in <see cref="DeviceInfo" />.
    /// </summary>
    [Flags]
    public enum DeviceStatus : uint
    {
        /// <summary>
        ///     The device is enabled. It will not be possible to initialize the device if this flag is not present.
        /// </summary>
        Enable = Internal.DeviceStatus.Enable,

        /// <summary>
        ///     The device is the system default.
        /// </summary>
        Default = Internal.DeviceStatus.Default,

        /// <summary>
        ///     The device is initialized, eg. <see cref="Initialize" /> or <see cref="RecordInitialize" /> has been called.
        /// </summary>
        Initialized = Internal.DeviceStatus.Initialized,

        /// <summary>
        ///     An audio endpoint device that the user accesses remotely through a network.
        /// </summary>
        Network = Internal.DeviceType.Network,

        /// <summary>
        ///     A set of speakers.
        /// </summary>
        Speakers = Internal.DeviceType.Speakers,

        /// <summary>
        ///     An audio endpoint device that sends a line-level analog signal to a line-input jack on an audio adapter or that
        ///     receives a line-level analog signal from a line-output jack on the adapter.
        /// </summary>
        Line = Internal.DeviceType.Line,

        /// <summary>
        ///     A set of headphones.
        /// </summary>
        Headphones = Internal.DeviceType.Headphones,

        /// <summary>
        ///     A microphone.
        /// </summary>
        Microphone = Internal.DeviceType.Microphone,

        /// <summary>
        ///     An earphone or a pair of earphones with an attached mouthpiece for two-way communication.
        /// </summary>
        Headset = Internal.DeviceType.Headset,

        /// <summary>
        ///     The part of a telephone that is held in the hand and that contains a speaker and a microphone for two-way
        ///     communication.
        /// </summary>
        Handset = Internal.DeviceType.Handset,

        /// <summary>
        ///     An audio endpoint device that connects to an audio adapter through a connector for a digital interface of unknown
        ///     type.
        /// </summary>
        Digital = Internal.DeviceType.Digital,

        /// <summary>
        ///     An audio endpoint device that connects to an audio adapter through a Sony/Philips Digital Interface (S/PDIF)
        ///     connector.
        /// </summary>
        Spdif = Internal.DeviceType.Spdif,

        /// <summary>
        ///     An audio endpoint device that connects to an audio adapter through a High-Definition Multimedia Interface (HDMI)
        ///     connector.
        /// </summary>
        Hdmi = Internal.DeviceType.Hdmi,

        /// <summary>
        ///     An audio endpoint device that connects to an audio adapter through a DisplayPort connector.
        /// </summary>
        Displayport = Internal.DeviceType.Displayport,

        /// <summary>
        ///     A mask of device types.
        /// </summary>
        TypeMask = Internal.DeviceType.Mask
    }
}