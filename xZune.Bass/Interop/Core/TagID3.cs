// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagID3.cs
// Version: 20160215

using System.Runtime.InteropServices;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     ID3v1 tag structure.
    /// </summary>
    /// <remarks>
    ///     See http://www.id3.org/ID3v1 for further details.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct TagID3
    {
        /// <summary>
        ///     ID3v1 tag identifier... "TAG".
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 3)]
        public byte[] Id;

        /// <summary>
        ///     Song title.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 30)]
        public byte[] Title;

        /// <summary>
        ///     Artist name.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 30)]
        public byte[] Artist;

        /// <summary>
        ///     Album title.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 30)]
        public byte[] Album;

        /// <summary>
        ///     Year.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 4)]
        public byte[] Year;

        /// <summary>
        ///     Comment. If the 30th character is non-null whilst the 29th character is null, then the 30th character is the track
        ///     number and the comment is limited to the first 28 characters.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 30)]
        public byte[] Comment;

        /// <summary>
        ///     Genre number. The number can be translated to a genre, using the list at www.id3.org.
        /// </summary>
        public byte Genre;
    }
}