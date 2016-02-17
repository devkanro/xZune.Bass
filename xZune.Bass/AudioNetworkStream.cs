// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: AudioNetworkStream.cs
// Version: 20160217

using System;
using System.IO;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core.Flags;
using xZune.Bass.Modules;

namespace xZune.Bass
{
    /// <summary>
    ///     A audio network sample stream.
    /// </summary>
    public class AudioNetworkStream : AudioStream , INetworkStream
    {
        private Stream _saveStream;

        private uint _totalBytes;

        /// <summary>
        /// The download buffer level required to resume stalled playback. 0 - 100, default is 50. 
        /// </summary>
        public float BufferLevel
        {
            get { return ((IChannelInternal) this).GetAttribute(ChannelAttribute.NetResume); }

            set { ((IChannelInternal) this).SetAttribute(ChannelAttribute.NetResume, value); }
        }



        #region -- Creator --

        /// <summary>
        ///     Creates a sample stream from an MP3, MP2, MP1, OGG, WAV, AIFF or plug-in supported file on the Internet.
        /// </summary>
        /// <param name="url">
        ///     URL of the file to stream. Should begin with "http://" or "https://" or "ftp://", or another add-on
        ///     supported protocol. The URL can be followed by custom HTTP request headers to be sent to the server; the URL and
        ///     each header should be terminated with a carriage return and line feed ("\r\n").
        /// </param>
        /// <param name="configs">Configures of <see cref="AudioNetworkStream" />. </param>
        /// <param name="offset">
        ///     File position to start streaming from. This is ignored by some servers, specifically when the
        ///     length is unknown/undefined.
        /// </param>
        /// <param name="saveStream">Save network stream to local .NET stream.</param>
        public AudioNetworkStream(String url, StreamCreateUrlConfig configs, int offset, Stream saveStream)
        {
            configs |= StreamCreateUrlConfig.Unicode;

            var urlHandle = InteropHelper.StringToPtr(url);

            _saveStream = saveStream;

            try
            {
                Handle =
                    AudioStreamModule.StreamCreateUrlFunction.CheckResult(
                        AudioStreamModule.StreamCreateUrlFunction.Delegate(urlHandle.AddrOfPinnedObject(),
                            offset, configs, OnDownloadProcessing, IntPtr.Zero));
            }
            catch (Exception)
            {
                _saveStream = null;
                throw;
            }

            urlHandle.Free();
        }

        /// <summary>
        ///     Creates a sample stream from an MP3, MP2, MP1, OGG, WAV, AIFF or plug-in supported file on the Internet.
        /// </summary>
        /// <param name="url">
        ///     URL of the file to stream. Should begin with "http://" or "https://" or "ftp://", or another add-on
        ///     supported protocol. The URL can be followed by custom HTTP request headers to be sent to the server; the URL and
        ///     each header should be terminated with a carriage return and line feed ("\r\n").
        /// </param>
        /// <param name="configs">Configures of <see cref="AudioNetworkStream" />. </param>
        /// <param name="offset">
        ///     File position to start streaming from. This is ignored by some servers, specifically when the
        ///     length is unknown/undefined.
        /// </param>
        public AudioNetworkStream(String url, StreamCreateUrlConfig configs, int offset) : this(url, configs, 0, null)
        {
        }

        /// <summary>
        ///     Creates a sample stream from an MP3, MP2, MP1, OGG, WAV, AIFF or plug-in supported file on the Internet.
        /// </summary>
        /// <param name="url">
        ///     URL of the file to stream. Should begin with "http://" or "https://" or "ftp://", or another add-on
        ///     supported protocol. The URL can be followed by custom HTTP request headers to be sent to the server; the URL and
        ///     each header should be terminated with a carriage return and line feed ("\r\n").
        /// </param>
        /// <param name="configs">Configures of <see cref="AudioNetworkStream" />. </param>
        /// <param name="saveStream">Save network stream to local .NET stream.</param>
        public AudioNetworkStream(String url, StreamCreateUrlConfig configs, Stream saveStream)
            : this(url, configs, 0, saveStream)
        {
        }

        /// <summary>
        ///     Creates a sample stream from an MP3, MP2, MP1, OGG, WAV, AIFF or plug-in supported file on the Internet.
        /// </summary>
        /// <param name="url">
        ///     URL of the file to stream. Should begin with "http://" or "https://" or "ftp://", or another add-on
        ///     supported protocol. The URL can be followed by custom HTTP request headers to be sent to the server; the URL and
        ///     each header should be terminated with a carriage return and line feed ("\r\n").
        /// </param>
        /// <param name="configs">Configures of <see cref="AudioNetworkStream" />. </param>
        public AudioNetworkStream(String url, StreamCreateUrlConfig configs) : this(url, configs, 0)
        {
        }

        #endregion -- Creator --

        #region -- Event --

        protected override void AttachEvent()
        {
            base.AttachEvent();

            _downloadCompeletedCallback?.DeattachToChannel();
            _downloadCompeletedCallback = new ChannelSyncCallback(OnDownloadCompeleted, SyncHandlerType.Download, 0);
            _downloadCompeletedCallback.AttachToChannel(this);
        }

        private void OnDownloadProcessing(IntPtr buffer, uint length, IntPtr user)
        {
            _totalBytes += length;
            DownloadProcessing?.Invoke(this,
                new DownloadProcessingEventArgs(buffer, length, _totalBytes));
        }

        /// <summary>
        /// The callback will be called before the ctor of <see cref="AudioNetworkStream"/> call returns (if it's successful), with the initial downloaded data. So any initialization (eg. creating the file if writing to disk) needs to be done either before the call, or in the callback function. 
        /// </summary>
        public event DownloadProcessingHandler DownloadProcessing;

        private void OnDownloadCompeleted(IntPtr displayHandle, IntPtr channel, uint data, IntPtr user)
        {
            DownloadCompeleted?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Sync when downloading of an Internet (or "buffered" user file) stream is done.
        /// </summary>
        public event EventHandler DownloadCompeleted;
        
        private ChannelSyncCallback _downloadCompeletedCallback;

        #endregion -- Event --
    }

    /// <summary>
    /// A handler of download processing event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DownloadProcessingHandler(object sender, DownloadProcessingEventArgs e);

    /// <summary>
    /// Some event arguments of download processing event.
    /// </summary>
    public class DownloadProcessingEventArgs : EventArgs
    {
        internal DownloadProcessingEventArgs(IntPtr buffer, uint transferBytes, uint totalBytes)
        {
            Buffer = buffer;
            TransferBytes = transferBytes;
            TotalBytes = totalBytes;
        }

        /// <summary>
        ///     Network steam is finished downloading.
        /// </summary>
        public bool IsComplete => Buffer == IntPtr.Zero;

        /// <summary>
        ///     Total byte count have transfered.
        /// </summary>
        public uint TotalBytes { get; private set; }

        /// <summary>
        ///     Buffer size.
        /// </summary>
        public uint TransferBytes { get; private set; }

        /// <summary>
        ///     Pointer to the downloaded data... NULL = finished downloading.
        /// </summary>
        public IntPtr Buffer { get; private set; }
    }
}