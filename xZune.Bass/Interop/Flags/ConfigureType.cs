﻿// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ConfigureType.cs
// Version: 20160313

using xZune.Bass.Interop.Core;

namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    ///     Some configure type of <see cref="GetConfig" /> and <see cref="SetConfig" />.
    /// </summary>
    public enum ConfigureType
    {
        /// <summary>
        ///     The playback buffer length for HSTREAM and HMUSIC channels.
        /// </summary>
        Buffer = Internal.ConfigureType.Buffer,

        /// <summary>
        ///     The update period of HSTREAM and HMUSIC channel playback buffers.
        /// </summary>
        UpdatePeriod = Internal.ConfigureType.UpdatePeriod,

        /// <summary>
        ///     The global sample volume level.
        /// </summary>
        GvolSample = Internal.ConfigureType.GvolSample,

        /// <summary>
        ///     The global stream volume level.
        /// </summary>
        GvolStream = Internal.ConfigureType.GvolStream,

        /// <summary>
        ///     The global MOD music volume level.
        /// </summary>
        GvolMusic = Internal.ConfigureType.GvolMusic,

        /// <summary>
        ///     The translation curve of volume values.
        /// </summary>
        CurveVol = Internal.ConfigureType.CurveVol,

        /// <summary>
        ///     The translation curve of panning values.
        /// </summary>
        CurvePan = Internal.ConfigureType.CurvePan,

        /// <summary>
        ///     Pass 32-bit floating-point sample data to all DSP functions?
        /// </summary>
        Floatdsp = Internal.ConfigureType.Floatdsp,

        /// <summary>
        ///     The 3D algorithm for software mixed 3D channels.
        /// </summary>
        _3DAlgorithm = Internal.ConfigureType._3DAlgorithm,

        /// <summary>
        ///     The time to wait for a server to respond to a connection request.
        /// </summary>
        NetTimeout = Internal.ConfigureType.NetTimeout,

        /// <summary>
        ///     The Internet download buffer length.
        /// </summary>
        NetBuffer = Internal.ConfigureType.NetBuffer,

        /// <summary>
        ///     Prevent channels being played while the output is paused?
        /// </summary>
        PauseNoplay = Internal.ConfigureType.PauseNoplay,

        /// <summary>
        ///     Amount to pre-buffer when opening Internet streams.
        /// </summary>
        NetPrebuf = Internal.ConfigureType.NetPrebuf,

        /// <summary>
        ///     Use passive mode in FTP connections?
        /// </summary>
        NetPassive = Internal.ConfigureType.NetPassive,

        /// <summary>
        ///     The buffer length for recording channels.
        /// </summary>
        RecBuffer = Internal.ConfigureType.RecBuffer,

        /// <summary>
        ///     Process URLs in PLS and M3U playlists?
        /// </summary>
        NetPlaylist = Internal.ConfigureType.NetPlaylist,

        /// <summary>
        ///     The maximum number of virtual channels to use in the rendering of IT files.
        /// </summary>
        MusicVirtual = Internal.ConfigureType.MusicVirtual,

        /// <summary>
        ///     The amount of data to check in order to verify/detect the file format.
        /// </summary>
        Verify = Internal.ConfigureType.Verify,

        /// <summary>
        ///     The number of threads to use for updating playback buffers.
        /// </summary>
        UpdateThreads = Internal.ConfigureType.UpdateThreads,

        /// <summary>
        ///     The output device buffer length.
        /// </summary>
        DevBuffer = Internal.ConfigureType.DevBuffer,

        /// <summary>
        ///     Enable true play position mode on Windows Vista and newer?
        /// </summary>
        VistaTruepos = Internal.ConfigureType.VistaTruepos,

        IosMixaudio = Internal.ConfigureType.IosMixaudio,

        /// <summary>
        ///     Include a "Default" entry in the output device list?
        /// </summary>
        DevDefault = Internal.ConfigureType.DevDefault,

        /// <summary>
        ///     The time to wait for a server to deliver more data for an Internet stream.
        /// </summary>
        NetReadtimeout = Internal.ConfigureType.NetReadtimeout,

        /// <summary>
        ///     Enable speaker assignment with panning/balance control on Windows Vista and newer?
        /// </summary>
        VistaSpeakers = Internal.ConfigureType.VistaSpeakers,

        IosSpeaker = Internal.ConfigureType.IosSpeaker,
        MfDisable = Internal.ConfigureType.MfDisable,
        Handles = Internal.ConfigureType.Handles,

        /// <summary>
        ///     Use the Unicode character set in device information?
        /// </summary>
        Unicode = Internal.ConfigureType.Unicode,

        /// <summary>
        ///     The default sample rate conversion quality.
        /// </summary>
        Src = Internal.ConfigureType.Src,

        /// <summary>
        ///     The default sample rate conversion quality for samples.
        /// </summary>
        SrcSample = Internal.ConfigureType.SrcSample,

        /// <summary>
        ///     The buffer length for asynchronous file reading.
        /// </summary>
        AsyncfileBuffer = Internal.ConfigureType.AsyncfileBuffer,

        /// <summary>
        ///     Pre-scan chained OGG files?
        /// </summary>
        OggPrescan = Internal.ConfigureType.OggPrescan,

        /// <summary>
        ///     Play the audio from video files using Media Foundation?
        /// </summary>
        MfVideo = Internal.ConfigureType.MfVideo,

        /// <summary>
        ///     Enabled Airplay receivers.
        /// </summary>
        Airplay = Internal.ConfigureType.Airplay,

        DevNonstop = Internal.ConfigureType.DevNonstop,
        IosNocategory = Internal.ConfigureType.IosNocategory,

        /// <summary>
        ///     The amount of data to check in order to verify/detect the file format of Internet streams.
        /// </summary>
        VerifyNet = Internal.ConfigureType.VerifyNet,

        #region BassWma plug-in configures

        WmaPrecheck = Internal.ConfigureType.WmaPrecheck,

        /// <summary>
        ///     Pre-buffer Internet streams during creation.
        /// </summary>
        WmaPrebuf = Internal.ConfigureType.WmaPrebuf,

        /// <summary>
        ///     BASS should handle file reading?
        /// </summary>
        WmaBassfile = Internal.ConfigureType.WmaBassfile,

        WmaNetseek = Internal.ConfigureType.WmaNetseek,

        /// <summary>
        ///     Play the audio from Windows Media Video (WMV) files?
        /// </summary>
        WmaVideo = Internal.ConfigureType.WmaVideo,

        WmaBuftime = Internal.ConfigureType.WmaBuftime,

        #endregion
        
        #region BassAac plug-in configures

        /// <summary>
        /// Play the audio from MP4 videos.
        /// </summary>
        Mp4Video = Internal.ConfigureType.Mp4Video,

        /// <summary>
        /// Support MP4 in AAC functions (no need for MP4 functions).
        /// </summary>
        AacMp4 = Internal.ConfigureType.AacMp4,

        /// <summary>
        /// Pre-scan ADTS AAC files for seek points and accurate length.
        /// </summary>
        AacPrescan = Internal.ConfigureType.AacPrescan

        #endregion

    }
}