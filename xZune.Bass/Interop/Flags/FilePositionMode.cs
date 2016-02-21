// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: FilePositionMode.cs
// Version: 20160215
namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    /// The file position/status to retrieve.
    /// </summary>
    public enum FilePositionMode
    {
        /// <summary>
        /// The amount of data in the asynchronous file reading buffer. This requires that the <see cref="StreamCreateFileConfig.AsyncFile"/> flag was used at the stream's creation. 
        /// </summary>
        AsyncBuffer = Internal.FilePositionMode.AsyncBuffer,
        /// <summary>
        /// The amount of data in the buffer of an Internet file stream or "buffered" user file stream. Unless streaming in blocks, this is the same as <see cref="Downlad"/>. 
        /// </summary>
        Buffer = Internal.FilePositionMode.Buffer,
        /// <summary>
        /// Internet file stream or "buffered" user file stream is still connected? 0 = no, 1 = yes. 
        /// </summary>
        Connected = Internal.FilePositionMode.Connected,
        /// <summary>
        /// Position that is to be decoded for playback next. This will be a bit ahead of the position actually being heard due to buffering. 
        /// </summary>
        Current = Internal.FilePositionMode.Current,
        Decode = Internal.FilePositionMode.Decode,
        /// <summary>
        /// Download progress of an Internet file stream or "buffered" user file stream. 
        /// </summary>
        Downlad = Internal.FilePositionMode.Download,
        /// <summary>
        /// End of audio data. When streaming in blocks (the BASS_STREAM_BLOCK flag is in effect), the download buffer length is given. 
        /// </summary>
        End = Internal.FilePositionMode.End,
        /// <summary>
        /// Total size of the file. 
        /// </summary>
        Size = Internal.FilePositionMode.Size,
        /// <summary>
        /// Start of audio data. 
        /// </summary>
        Start = Internal.FilePositionMode.Start,
        Socket = Internal.FilePositionMode.Socket
    }
}