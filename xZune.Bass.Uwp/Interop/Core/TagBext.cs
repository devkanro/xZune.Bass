// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagBext.cs
// Version: 20160215

using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     BWF "bext" tag structure.
    /// </summary>
    /// <remarks>
    ///     The structure is given by BASS_ChannelGetTags as it is in the RIFF file, which is little-endian, so the
    ///     TimeReference and Version members will need to be reversed on big-endian platforms. The UMID member is only
    ///     available with BWF version 1 (and above).
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct TagBext
    {
        /// <summary>
        ///     A free description of the sequence. To help applications which only display a short description, it is recommended
        ///     that a summary of the description is contained in the first 64 characters, and the last 192 characters are used for
        ///     details.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 256)]
        public byte[] Description;

        /// <summary>
        ///     The name of the originator/producer of the audio file.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 32)]
        public byte[] Originator;

        /// <summary>
        ///     A non ambiguous reference allocated by the originating organization.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 32)]
        public byte[] OriginatorReference;

        /// <summary>
        ///     The date of creation of the audio sequence, in the form of "yyyy-mm-dd" (year-month-day).
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 10)]
        public byte[] OriginationDate;

        /// <summary>
        ///     The time of creation of the audio sequence, in the form of "hh-mm-ss" (hours-minutes-seconds).
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 8)]
        public byte[] OriginationTime;

        /// <summary>
        ///     The timecode of the sequence. The first sample count since midnight.
        /// </summary>
        public UInt64 TimeReference;

        /// <summary>
        ///     The BWF version.
        /// </summary>
        public UInt16 Version;

        /// <summary>
        ///     64 bytes containing a UMID (Unique Material Identifier) to the SPMTE 330M standard. If only a 32 byte "basic UMID"
        ///     is used, the last 32 bytes should be set to zero.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
        public byte[] UMID;

        /// <summary>
        ///     Reserved for extensions.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 190)]
        public byte[] Reserved;

        /// <summary>
        ///     A series of CR/LF terminated strings, each containing a description of a coding process applied to the audio data.
        /// </summary>
        public IntPtr CodingHistory;
    }
}