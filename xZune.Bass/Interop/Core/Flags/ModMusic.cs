// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ModMusic.cs
// Version: 20160216

using System;

namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    ///     Frees a MOD music's resources, including any sync/DSP/FX it has.
    /// </summary>
    /// <param name="handle">The MOD music handle. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use BASS_ErrorGetCode to get the error code.
    /// </returns>
    [BassFunction("BASS_MusicFree")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassBooleanVerification]
    public delegate bool MusicFree(IntPtr handle);

    /// <summary>
    ///     Loads a MOD music file.
    /// </summary>
    /// <param name="mem">TRUE = load the MOD music from memory. </param>
    /// <param name="file">Filename (mem = FALSE) or a memory location (mem = TRUE). </param>
    /// <param name="offset">File offset to load the MOD music from (only used if mem = FALSE). </param>
    /// <param name="length">Data length... 0 = use all data up to the end of file (if mem = FALSE). </param>
    /// <param name="configs">Configures of load a MOD music. </param>
    /// <param name="freq">
    ///     Sample rate to render/play the MOD music at... 0 = the rate specified in the <see cref="Initialize"/> call, 1 = the
    ///     device's current output rate (or the BASS_Init rate if that is not available).
    /// </param>
    /// <returns>
    ///     If successful, the loaded MOD music's handle is returned, else 0 is returned. Use BASS_ErrorGetCode to get the
    ///     error code.
    /// </returns>
    /// <remarks>
    ///     BASS uses the same code as XMPlay for its MOD music support, giving an accurate reproduction of the MO3 / IT / XM /
    ///     S3M / MTM / MOD / UMX formats.
    ///     MO3s are treated and used in exactly the same way as normal MOD musics. The advantage of MO3s is that they can be a
    ///     lot smaller with virtually identical quality. Playing a MO3 does not use any more CPU power than playing the
    ///     original MOD version does. The only difference is a slightly longer load time as the samples are being decoded. MO3
    ///     files are created using the MO3 encoder available at the BASS website.
    ///     <para />
    ///     DMO effects (the same as available with <see cref="ChannelSetFX"/>) can be used in IT and XM files (and MO3 versions of
    ///     them) created with Modplug Tracker. This allows effects to be added to a track without having to resort to an MP3
    ///     or OGG version, so it can remain small and still sound fancy. Of course, the effects require some CPU, so should
    ///     not be used carelessly if performance is key.
    ///     <para />
    ///     "Ramping" does not take a lot of extra processing and improves the sound quality by removing clicks, by
    ///     ramping/smoothing volume and pan changes. The start of a sample may also be ramped-in. That is always the case with
    ///     XM files (or MOD files in FT2 mode) when using normal ramping, and possibly with all formats when using sensitive
    ///     ramping; senstitive ramping will only ramp-in when necessary to avoid a click. Generally, normal ramping is
    ///     recommended for XM files, and sensitive ramping for the other formats, but some XM files may also sound better
    ///     using sensitive ramping.
    ///     <para />
    ///     After loading a MOD music from memory (mem = TRUE), the memory can safely be discarded.
    ///     <para />
    /// </remarks>
    [BassFunction("BASS_MusicLoad")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.NotAvailable, "The BASS_MUSIC_AUTOFREE flag is unavailable to decoding channels.")]
    [BassError(ErrorCode.FileOpenFail, "The file could not be opened.")]
    [BassError(ErrorCode.IncorrectFileFromat, "The file's format is not recognized/supported.")]
    [BassError(ErrorCode.IncorrectFormat,
        "The sample format is not supported by the device/drivers. If using the BASS_SAMPLE_FLOAT flag, it could be that floating-point channels are not supported."
        )]
    [BassError(ErrorCode.SpeakerError,
        "The specified SPEAKER flags are invalid. The device/drivers do not support them or 3D functionality is enabled."
        )]
    [BassError(ErrorCode.BadMemory, "There is insufficient memory.")]
    [BassError(ErrorCode.No3D, "Could not initialize 3D support.")]
    [BassError(ErrorCode.Unknown, "Some other mystery problem!")]
    [BassPointerVerification]
    public delegate IntPtr MusicLoad(bool mem, IntPtr file, UInt64 offset, int length, MusicLoadConfig configs, int freq
        );
}