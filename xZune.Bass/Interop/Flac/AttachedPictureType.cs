// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: AttachedPictureType.cs
// Version: 20160223

namespace xZune.Bass.Interop.Flac
{
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
}