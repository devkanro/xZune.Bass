// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: CoverTypes.cs
// Version: 20160316
namespace xZune.Bass.Tag.Interop.Core
{
    public enum CoverType
    {
        /// <summary>
        /// Other.
        /// </summary>
        Other = 0x00,
        /// <summary>
        /// 32x32 pixels 'file icon' (PNG only).
        /// </summary>
        Icon = 0x01,
        /// <summary>
        /// Other file icon.
        /// </summary>
        OtherIcon = 0x02,
        /// <summary>
        /// Cover (front).
        /// </summary>
        CoverFront = 0x03,
        /// <summary>
        /// Cover (back).
        /// </summary>
        Coverback = 0x04,
        /// <summary>
        /// Leaflet page.
        /// </summary>
        Leaflet = 0x05,
        /// <summary>
        /// Media (e.g. label side of CD).
        /// </summary>
        Label = 0x06,
        /// <summary>
        /// Lead artist/lead performer/soloist.
        /// </summary>
        Lead = 0x07,
        /// <summary>
        /// Artist/performer.
        /// </summary>
        Artist = 0x08,
        /// <summary>
        /// Conductor
        /// </summary>
        Conductor = 0x09,
        /// <summary>
        /// Band/Orchestra.
        /// </summary>
        Band = 0x0A,
        /// <summary>
        /// Composer.
        /// </summary>
        Composer = 0x0B,
        /// <summary>
        /// Lyricist/text writer.
        /// </summary>
        Lyricist = 0x0C,
        /// <summary>
        /// Recording Location.
        /// </summary>
        RecordingLocation = 0x0D,
        /// <summary>
        /// During recording.
        /// </summary>
        DuringRecording = 0x0E,
        /// <summary>
        /// During performance.
        /// </summary>
        Performance = 0x0F,
        /// <summary>
        /// Movie/video screen capture.
        /// </summary>
        Movie = 0x10,
        /// <summary>
        /// A bright colored fish (What the fuck it is?).
        /// </summary>
        ColoredFish = 0x11,
        /// <summary>
        /// Illustration.
        /// </summary>
        Illustration = 0x12,
        /// <summary>
        /// Band/artist logotype.
        /// </summary>
        BandLogo = 0x13,
        /// <summary>
        /// Publisher/Studio logotype.
        /// </summary>
        Publisher = 0x14
    }
}