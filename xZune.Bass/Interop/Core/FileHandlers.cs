// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: FileHandlers.cs
// Version: 20160215

using System.Runtime.InteropServices;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Table of callback functions used with <see cref="StreamCreateFileUser" />.
    /// </summary>
    public struct FileHandlers
    {
        /// <summary>
        ///     Callback function to close the file.
        /// </summary>
        [MarshalAs(UnmanagedType.FunctionPtr)] public FileCloseHandler CloseHandler;

        /// <summary>
        ///     Callback function to get the file length.
        /// </summary>
        [MarshalAs(UnmanagedType.FunctionPtr)] public FileLengthHandler LengthHandler;

        /// <summary>
        ///     Callback function to read from the file.
        /// </summary>
        [MarshalAs(UnmanagedType.FunctionPtr)] public FileReadHandler ReadHandler;

        /// <summary>
        ///     Callback function to seek in the file. Not used by buffered file streams.
        /// </summary>
        [MarshalAs(UnmanagedType.FunctionPtr)] public FileSeekHandler SeekHandler;
    }
}