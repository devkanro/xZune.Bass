// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: DeviceState.cs
// Version: 20160215

using System;

namespace xZune.Bass.Interop.Core.Flags.Internal
{
    [Flags]
    internal enum DeviceStatus : uint
    {
        /// <summary>
        ///     The device is enabled. It will not be possible to initialize the device if this flag is not present.
        /// </summary>
        Enable = 1,

        /// <summary>
        ///     The device is the system default.
        /// </summary>
        Default = 2,

        /// <summary>
        ///     The device is initialized, eg. <see cref="Initialize" /> or <see cref="RecordInitialize" /> has been called.
        /// </summary>
        Initialized = 4
    }
}