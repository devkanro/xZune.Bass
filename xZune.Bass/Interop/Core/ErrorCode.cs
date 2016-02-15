// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ErrorCode.cs
// Version: 20160214

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Bass error code.
    /// </summary>
    public enum ErrorCode
    {
        OK = 00,
        BadMemory = 01,
        FileOpenFail = 02,
        DriverError = 03,
        BufferLost = 04,
        BadHandle = 05,
        IncorrectFormat = 06,
        PositionError = 07,

        /// <summary>
        ///     <see cref="Initialize" /> has not been successfully called; there are no initialized devices.
        /// </summary>
        InitializeFail = 08,

        StartFail = 09,
        SSLError = 10,
        Already = 14,
        NoChannel = 18,
        IllegalType = 19,

        /// <summary>
        ///     Parameter is invalid.
        /// </summary>
        IllegalParam = 20,

        No3D = 21,
        NoEAX = 22,

        /// <summary>
        ///     Device is invalid.
        /// </summary>
        InvalidDevice = 23,

        NoPlay = 24,
        Frequency = 25,
        NotFile = 27,
        NoHardware = 29,
        Empty = 31,
        NoNetwork = 32,
        CreateFail = 33,
        NoFX = 34,

        /// <summary>
        ///     The requested object is not available with the current device.
        /// </summary>
        NotAvailable = 37,

        DecodeError = 38,
        DirectXError = 39,
        TimeOut = 40,
        IncorrectFileFromat = 41,
        SpeakerError = 42,
        VersionError = 43,
        CodecError = 44,
        Ended = 45,
        Busy = 46,
        Unknown = -1
    }
}