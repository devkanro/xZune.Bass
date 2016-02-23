// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagFlacPicture.cs
// Version: 20160222

using System;

namespace xZune.Bass.Interop.Flac
{
    /// <summary>
    ///     FLAC picture tag structure.
    /// </summary>
    public struct TagFlacPicture
    {
        /// <summary>
        ///     The picture type, according to the ID3v2 "APIC" frame specification: see http://www.id3.org/id3v2.3.0 for details.
        /// </summary>
        public AttachedPictureType AttachedPictureType;

        /// <summary>
        ///     The MIME type. This may be "-->" to signify that data contains a URL of the picture rather than the picture data
        ///     itself.
        /// </summary>
        public IntPtr MimeType;

        /// <summary>
        ///     A description of the picture, in UTF-8 form.
        /// </summary>
        public IntPtr Description;

        /// <summary>
        ///     The width in pixels.
        /// </summary>
        public uint Width;

        /// <summary>
        ///     The height in pixels.
        /// </summary>
        public uint Height;

        /// <summary>
        ///     The color depth in bits-per-pixel.
        /// </summary>
        public uint Depth;

        /// <summary>
        ///     The number of colors used for indexed-color pictures (eg. GIF).
        /// </summary>
        public uint Colors;

        /// <summary>
        ///     The size of data in bytes.
        /// </summary>
        public uint DataLength;

        /// <summary>
        ///     The picture data.
        /// </summary>
        public IntPtr Data;
    }
}