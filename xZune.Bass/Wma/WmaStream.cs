// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: WmaStream.cs
// Version: 20160313

using System;
using System.IO;
using System.Runtime.InteropServices;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Flags;
using xZune.Bass.Modules.Plugins;

namespace xZune.Bass.Wma
{
    /// <summary>
    ///     A Windows Media Audio stream.
    /// </summary>
    public class WmaStream : AudioStream
    {
        private ChannelSyncCallback _metaDataCallback;
        private ChannelSyncCallback _serverTrackCallback;

        protected override void AttachEvent()
        {
            base.AttachEvent();

            _metaDataCallback?.DeattachToChannel();
            _serverTrackCallback?.DeattachToChannel();

            _metaDataCallback = new ChannelSyncCallback(OnMetaDataEncountered, SyncHandlerType.WmaMeta, 0);
            _serverTrackCallback = new ChannelSyncCallback(OnServerTrackChanged, SyncHandlerType.WmaChange, 0);

            _metaDataCallback.AttachToChannel(this);
            _serverTrackCallback.AttachToChannel(this);
        }

        private void OnMetaDataEncountered(IntPtr displayHandle, IntPtr channel, uint data, IntPtr user)
        {
            MetaDataEncountered?.Invoke(this, new EventArgs());
        }

        private void OnServerTrackChanged(IntPtr displayHandle, IntPtr channel, uint data, IntPtr user)
        {
            ServerTrackChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>
        ///     When a mid-stream tag (script) is encountered in a WMA stream.
        /// </summary>
        public event EventHandler MetaDataEncountered;

        /// <summary>
        ///     When a track change in a server-side playlist.
        /// </summary>
        public event EventHandler ServerTrackChanged;

        #region -- Creator --

        internal WmaStream(IntPtr handle)
        {
            if (!PluginManager.IsPluginLoaded(BassPlugin.BassWma))
                throw new PluginNotLoadedException(BassPlugin.BassWma);

            Handle = handle;
        }

        /// <summary>
        ///     Creates a sample stream from a WMA file.
        /// </summary>
        /// <param name="file">File name.</param>
        /// <param name="configs">Configure of <see cref="WmaStream" />.</param>
        /// <param name="offset">File offset to begin streaming from.</param>
        /// <param name="length">Data length... 0 = use all data up to the end of the file.</param>
        public WmaStream(String file, WmaStreamCreateConfig configs, uint offset, uint length)
        {
            configs |= WmaStreamCreateConfig.Unicode;

            using (var fileNameHandle = InteropHelper.StringToPtr(file))
            {
                Handle = WmaModule.WmaStreamCreateFileFunction.CheckResult(
                    WmaModule.WmaStreamCreateFileFunction.Delegate(false,
                        fileNameHandle.Handle, offset, length, configs));
            }
        }

        /// <summary>
        ///     Creates a sample stream from a WMA file.
        /// </summary>
        /// <param name="file">File name.</param>
        /// <param name="configs">Configure of <see cref="WmaStream" />.</param>
        public WmaStream(String file, WmaStreamCreateConfig configs) : this(file, configs, 0, 0)
        {
        }

        /// <summary>
        ///     Creates a sample stream from a WMA file, optionally with a user name and password to authenticate. .
        /// </summary>
        /// <param name="file">File name.</param>
        /// <param name="configs">Configure of <see cref="WmaStream" />.</param>
        /// <param name="offset">File offset to begin streaming from.</param>
        /// <param name="length">Data length... 0 = use all data up to the end of the file.</param>
        /// <param name="user">
        ///     User name to use in connecting to the server... if either this or pass is NULL, then no user
        ///     name/password is sent to the server.
        /// </param>
        /// <param name="password">Password to use in connecting to the server. </param>
        public WmaStream(String file, String user, String password, WmaStreamCreateConfig configs, uint offset,
            uint length)
        {
            configs |= WmaStreamCreateConfig.Unicode;

            using (var fileNameHandle = InteropHelper.StringToPtr(file))
            {
                using (var userHandle = InteropHelper.StringToPtr(user))
                {
                    using (var passwordHandle = InteropHelper.StringToPtr(password))
                    {
                        Handle = WmaModule.WmaStreamCreateFileAuthFunction.CheckResult(
                            WmaModule.WmaStreamCreateFileAuthFunction.Delegate(false,
                                fileNameHandle.Handle, offset, length, configs, userHandle.Handle, passwordHandle.Handle));
                    }
                }
            }
        }

        /// <summary>
        ///     Creates a sample stream from a WMA file, optionally with a user name and password to authenticate.
        /// </summary>
        /// <param name="file">File name.</param>
        /// <param name="configs">Configure of <see cref="WmaStream" />.</param>
        /// <param name="user">
        ///     User name to use in connecting to the server... if either this or pass is NULL, then no user
        ///     name/password is sent to the server.
        /// </param>
        /// <param name="password">Password to use in connecting to the server. </param>
        public WmaStream(String file, String user, String password, WmaStreamCreateConfig configs)
            : this(file, user, password, configs, 0, 0)
        {
        }

        /// <summary>
        ///     Creates a sample stream from a WMA memory stream.
        /// </summary>
        /// <param name="stream">Memory stream.</param>
        /// <param name="configs">Configure of <see cref="WmaStream" />.</param>
        public WmaStream(MemoryStream stream, WmaStreamCreateConfig configs)
        {
            ArraySegment<byte> bufferSegment;
            byte[] buffer = null;
            if (stream.TryGetBuffer(out bufferSegment))
            {
                buffer = bufferSegment.Array;
            }
            else
            {
                buffer = stream.ToArray();
            }

            GCHandle bufferHandle = GCHandle.Alloc(buffer);

            Handle = WmaModule.WmaStreamCreateFileFunction.CheckResult(
                WmaModule.WmaStreamCreateFileFunction.Delegate(true,
                    bufferHandle.AddrOfPinnedObject(), 0, (uint) stream.Length, configs));

            bufferHandle.Free();
        }

        /// <summary>
        ///     Create a sample stream from a WMA file via user callback functions.
        /// </summary>
        /// <param name="handlers">The user defined file functions. </param>
        /// <param name="configs">Configure of <see cref="WmaStream" />.</param>
        /// <param name="systemType">File system to use.</param>
        /// <param name="user">User instance data to pass to the callback functions. </param>
        public WmaStream(FileHandlers handlers, WmaStreamCreateConfig configs,
            StreamFileSystemType systemType, IntPtr user)
        {
            Handle =
                WmaModule.WmaStreamCreateFileUserFunction.CheckResult(
                    WmaModule.WmaStreamCreateFileUserFunction.Delegate(systemType, configs,
                        ref handlers, user));
        }

        /// <summary>
        ///     Create a sample stream from a WMA Bass stream.
        /// </summary>
        /// <param name="bassStream">The Bass stream.</param>
        /// <param name="configs">Configure of <see cref="WmaStream" />.</param>
        /// <param name="systemType">File system to use.</param>
        public WmaStream(BassStream bassStream, WmaStreamCreateConfig configs,
            StreamFileSystemType systemType) : this(bassStream.StreamHandlers, configs, systemType, IntPtr.Zero)
        {
        }

        /// <summary>
        ///     Create a sample stream from a WMA .Net stream.
        /// </summary>
        /// <param name="stream">The .Net stream.</param>
        /// <param name="configs">Configure of <see cref="WmaStream" />.</param>
        /// <param name="systemType">File system to use.</param>
        public WmaStream(Stream stream, WmaStreamCreateConfig configs,
            StreamFileSystemType systemType) : this(stream.AsBassStream(), configs, systemType)
        {
        }

        #endregion -- Creator --
    }

    public static class WmaStreamExtension
    {
        /// <summary>
        ///     Convert a audio stream to <see cref="WmaStream" />.
        /// </summary>
        /// <param name="audioStream">Source audio stream.</param>
        /// <returns>Convert result.</returns>
        public static WmaStream AsWmaStream(this AudioStream audioStream)
        {
            if (!PluginManager.IsPluginLoaded(BassPlugin.BassWma))
                throw new PluginNotLoadedException(BassPlugin.BassWma);

            switch (audioStream.Information.Type)
            {
                case ChannelType.StreamWma:
                case ChannelType.StreamWmaMp3:
                    WmaStream result = new WmaStream(audioStream.Handle);
                    return result;

                default:
                    return null;
            }
        }
    }
}