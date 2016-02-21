// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: StreamFileSystemType.cs
// Version: 20160215

using xZune.Bass.Interop.Core;

namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    ///     File system to use.
    /// </summary>
    public enum StreamFileSystemType
    {
        /// <summary>
        ///     Unbuffered.
        /// </summary>
        NoBuffer = Internal.StreamFileSystemType.NoBuffer,

        /// <summary>
        ///     Buffered.
        /// </summary>
        Buffer = Internal.StreamFileSystemType.Buffer,

        /// <summary>
        ///     Buffered, with the data pushed to BASS via <see cref="StreamPutFileData" />.
        /// </summary>
        BufferPush = Internal.StreamFileSystemType.BufferPush
    }
}