// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ConfigFlags.cs
// Version: 20160317
namespace xZune.Bass.Tag.Interop.Core
{
    public enum ConfigFlags
    {
        /// <summary>
        /// Set padding size to write when saving the tags. When set as global, setting will affect all newly created Tags objects.
        /// </summary>
        PaddingSizeToWrite = 1,
        /// <summary>
        /// Set getting of Ogg Vorbis and Opus audio file's play time. Setting to 'True' results longer loading time. Default is 'True'. When set as global, setting will affect all newly created Tags objects.
        /// </summary>
        ParseOggPlaytime = 2,
        /// <summary>
        /// Set getting of MPEG, WAV, AIFF/AIFC, DSD .dsf audio file's attributes. Setting to 'False' results quicker loading. Default is 'True'. When set as global, setting will affect all newly created Tags objects.
        /// </summary>
        ParseID3V2AudioAttributes = 3,
        /// <summary>
        /// Set to preserve padding (add as much as needed to fit the new tag) or always write '<see cref="PaddingSizeToWrite"/>' value padding.
        /// </summary>
        Mp4TagKeepPadding = 4,
        /// <summary>
        /// Set getting of WavPack audio file's attributes. Setting to 'False' results quicker loading. Default is 'False'. When set as global, setting will affect all newly created Tags objects.
        /// </summary>
        ParseWavpackAudioAttributes = 5,
        /// <summary>
        /// Set getting of MusePack audio file's attributes. Setting to 'False' results quicker loading. Default is 'False'. When set as global, setting will affect all newly created Tags objects.
        /// </summary>
        ParseMusepackAudioAttributes = 6,
        /// <summary>
        /// Set deep scanning of Opus audio files and get true w/o overhead bit rate. Results slower loading of Opus audio files, default is 'False'.
        /// </summary>
        DeepOpusBitrateScan = 7

    }
}