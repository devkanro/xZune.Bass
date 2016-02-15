// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Plugin.cs
// Version: 20160215

using System;
using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Unplugs an add-on.
    /// </summary>
    /// <param name="handle">The plug-in handle... 0 = all plug-ins. </param>
    /// <returns>
    ///     If successful, TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error code.
    /// </returns>
    /// <remarks>
    ///     If there are streams created by a plug-in in existence when it is being freed, the streams will automatically be
    ///     freed too. Samples loaded by the plug-in are unaffected as the plug-in has nothing to do with them once they are
    ///     loaded; the sample data is already fully decoded.
    /// </remarks>
    [BassFuction("BASS_plug-inFree")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    [BassBooleanVerification]
    public delegate bool PluginFree(IntPtr handle);

    /// <summary>
    ///     Retrieves information on a plug-in.
    /// </summary>
    /// <param name="handle">The plug-in handle. </param>
    /// <returns>
    ///     If successful, a pointer to the plug-in info is returned, else NULL is returned. Use <see cref="GetErrorCode" /> to
    ///     get the
    ///     error code.
    /// </returns>
    /// <remarks>
    ///     The plug-in information does not change, so the returned pointer remains valid for as long as the plug-in is
    ///     loaded.
    /// </remarks>
    [BassFuction("BASS_plug-inGetInfo")]
    [BassError(ErrorCode.BadHandle, "handle is not valid.")]
    public delegate IntPtr PluginGetInfo(IntPtr handle);

    /// <summary>
    ///     Plugs an "add-on" into the standard stream and sample creation functions.
    /// </summary>
    /// <param name="file">Filename of the add-on/plug-in. </param>
    /// <param name="flags">A combination of these flags. </param>
    /// <returns>
    ///     If successful, the loaded plug-in's handle is returned, else 0 is returned. Use <see cref="GetErrorCode" /> to get
    ///     the error
    ///     code.
    ///     <para />
    /// </returns>
    /// <remarks>
    ///     There are 2 ways in which add-ons can provide support for additional formats. They can provide dedicated functions
    ///     to create streams of the specific format(s) they support and/or they can plug into the standard stream creation
    ///     functions: <see cref="StreamCreateFile" />, <see cref="StreamCreateUrl" />, and <see cref="StreamCreateFileUser" />
    ///     . This function enables the
    ///     latter method. Both methods can be used side by side. The obvious advantage of the plug-in system is convenience,
    ///     while the dedicated functions can provide extra options that are not possible via the shared function interfaces.
    ///     See an add-on's documentation for more specific details on it.
    ///     As well as the stream creation functions, plug-ins also add their additional format support to BASS_SampleLoad.
    ///     <para />
    ///     Information on what file formats a plug-in supports is available via the BASS_PluginGetInfo function.
    ///     <para />
    ///     When using multiple plug-ins, the stream/sample creation functions will try each of them in the order that they
    ///     were loaded via this function, until one that accepts the file is found.
    ///     <para />
    ///     When an add-on is already loaded (eg. if you are using functions from it), the plug-in system will use the same
    ///     instance (the reference count will just be incremented); there will not be 2 copies of the add-on in memory.
    ///     <para />
    /// </remarks>
    [BassFuction("BASS_PluginLoad")]
    [BassError(ErrorCode.FileOpenFail, "The file could not be opened.")]
    [BassError(ErrorCode.IncorrectFileFromat, "The file is not a plug-in.")]
    [BassError(ErrorCode.VersionError,
        "The plug-in requires a different BASS version. Due to the use of the \"stdcall\" calling-convention, and so risk of stack faults from unexpected API differences, an add-on won't load at all on Windows if the BASS version is unsupported, and a BASS_ERROR_FILEFORM error will be generated instead of this."
        )]
    [BassError(ErrorCode.Already, "The plug-in is already loaded.")]
    [BassPointerVerification]
    public delegate IntPtr PluginLoad(IntPtr file, PluginLoadConfig config);
}