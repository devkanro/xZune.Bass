using System;
using System.Runtime.InteropServices;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    /// Version of the data structure. 
    /// </summary>
    /// <remarks>
    /// The structure is given by BASS_ChannelGetTags as it is in the RIFF file, which is little-endian, so the dwLevelReference and PostTimer members will need to be reversed on big-endian platforms. 
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct TagCart
    {
        /// <summary>
        /// Title of cart audio sequence. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 4)]
        public byte[] Version;

        /// <summary>
        /// Title of cart audio sequence. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
        public byte[] Title;

        /// <summary>
        /// Artist or creator name. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
        public byte[] Artist;

        /// <summary>
        /// Cut number identification. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
        public byte[] CutID;

        /// <summary>
        /// Client identification. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
        public byte[] ClientID;

        /// <summary>
        /// Category ID, PSA, NEWS, etc. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
        public byte[] Category;

        /// <summary>
        /// Classification or auxiliary key. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
        public byte[] Classification;

        /// <summary>
        /// Out cue text. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
        public byte[] OutCue;

        /// <summary>
        /// Start date, in the form of "yyyy-mm-dd" (year-month-day). 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 10)]
        public byte[] StartDate;

        /// <summary>
        /// Start time, in the form of "hh-mm-ss" (hours-minutes-seconds). 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 8)]
        public byte[] StartTime;

        /// <summary>
        /// End date, in the form of "yyyy-mm-dd" (year-month-day). 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 10)]
        public byte[] EndDate;

        /// <summary>
        /// End time, in the form of "hh-mm-ss" (hours-minutes-seconds).
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 8)]
        public byte[] EndTime;

        /// <summary>
        /// Name of vendor or application. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
        public byte[] ProducerAppID;

        /// <summary>
        /// Version of producer application. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
        public byte[] ProducerAppVersion;

        /// <summary>
        /// User defined text. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 64)]
        public byte[] UserDef;

        /// <summary>
        /// Sample value for 0 dB reference. 
        /// </summary>
        public uint LevelReference;

        /// <summary>
        /// 8 time markers after head. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U8, SizeConst = 8)]
        public TagCartTimer[] PostTimer;

        /// <summary>
        /// Reserved for extensions. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 276)]
        public byte[] Reserved;

        /// <summary>
        /// Uniform resource locator. 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 1024)]
        public byte[] URL;

        /// <summary>
        /// Free form text for scripts or tags. 
        /// </summary>
        public IntPtr TagText;
    }
}