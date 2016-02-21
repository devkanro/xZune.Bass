// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: RecordInputStatus.cs
// Version: 20160216

namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    ///     Status of record input.
    /// </summary>
    public enum RecordInputStatus
    {
        /// <summary>
        ///     Disable the input. This flag cannot be used when the device supports only one input at a time.
        /// </summary>
        Off = Internal.RecordInputStatus.Off,

        /// <summary>
        ///     Enable the input. If the device only allows one input at a time, then any previously enabled input will be disabled
        ///     by this.
        /// </summary>
        On = Internal.RecordInputStatus.On
    }
}