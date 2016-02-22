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

    /// <summary>
    ///     APIC type enum of ID3v2.
    /// </summary>
    public enum AttachedPictureType
    {
        /// <summary>
        ///     Other
        /// </summary>
        Other,

        /// <summary>
        ///     32x32 pixels "file icon" (PNG only).
        /// </summary>
        FileIcon,

        /// <summary>
        ///     Other file icon.
        /// </summary>
        OtherFileIcon,

        /// <summary>
        ///     Cover (front).
        /// </summary>
        FrontCover,

        /// <summary>
        ///     Cover (back).
        /// </summary>
        BackCover,

        /// <summary>
        ///     Leaflet page.
        /// </summary>
        LeafletPage,

        /// <summary>
        ///     Media (e.g. label side of CD).
        /// </summary>
        Media,

        /// <summary>
        ///     Lead artist/lead performer/soloist.
        /// </summary>
        LeadArtist,

        /// <summary>
        ///     Artist/performer.
        /// </summary>
        Artist,

        /// <summary>
        ///     Conductor.
        /// </summary>
        Conductor,

        /// <summary>
        ///     Band/Orchestra.
        /// </summary>
        Orchestr,

        /// <summary>
        ///     Composer.
        /// </summary>
        Composer,

        /// <summary>
        ///     Lyricist/text writer.
        /// </summary>
        Lyricist,

        /// <summary>
        ///     Recording Location.
        /// </summary>
        RecordingLocation,

        /// <summary>
        ///     During recording.
        /// </summary>
        DuringRecording,

        /// <summary>
        ///     During performance.
        /// </summary>
        DuringPerformance,

        /// <summary>
        ///     Movie/video screen capture.
        /// </summary>
        MovieCapture,

        /// <summary>
        ///     A bright colored fish, WTF?
        /// </summary>
        WhatTheFuckingItIs,

        /// <summary>
        ///     Illustration.
        /// </summary>
        Illustration,

        /// <summary>
        ///     Band/artist logotype.
        /// </summary>
        ArtistLogotype,

        /// <summary>
        ///     Publisher/Studio logotype.
        /// </summary>
        StudioLogotype
    }

    /// <summary>
    ///     FLAC cue sheet tag structure.
    /// </summary>
    public struct TagFlacCue
    {
        /// <summary>
        ///     Media catalog number.
        /// </summary>
        public IntPtr Catalog;

        /// <summary>
        ///     The number of lead-in samples.
        /// </summary>
        public uint Leadin;

        /// <summary>
        ///     The cue sheet corresponds to a CD?
        /// </summary>
        public bool IsCD;

        /// <summary>
        ///     The number of tracks.
        /// </summary>
        public uint TracksCount;

        /// <summary>
        ///     The tracks.
        /// </summary>
        public IntPtr Tracks;
    }

    /// <summary>
    ///     FLAC cue sheet tag track structure.
    /// </summary>
    public struct TagFlacCueTrack
    {
        /// <summary>
        ///     Track offset in samples.
        /// </summary>
        public ulong Offset;

        /// <summary>
        ///     The track number.
        /// </summary>
        public uint Number;

        /// <summary>
        ///     International Standard Recording Code.
        /// </summary>
        public IntPtr ISRC;

        /// <summary>
        ///     Track type.
        /// </summary>
        public FlacCueTrackType Type;

        /// <summary>
        ///     The number of indexes.
        /// </summary>
        public uint IndexesCount;

        /// <summary>
        ///     The indexes.
        /// </summary>
        public IntPtr Indexes;
    }

    public struct TagFlacCueTrackIndex
    {
        /// <summary>
        ///     Index offset in samples relative to the track offset.
        /// </summary>
        public ulong Offset;

        /// <summary>
        ///     The index number.
        /// </summary>
        public uint Number;
    }

    [Flags]
    public enum FlacCueTrackType
    {
        /// <summary>
        ///     Non-audio.
        /// </summary>
        Data = 1,

        /// <summary>
        ///     Pre-emphasis.
        /// </summary>
        Pre = 2
    }
}