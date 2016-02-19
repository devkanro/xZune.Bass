// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassConfig.cs
// Version: 20160219

using System;
using System.Runtime.InteropServices;
using System.Text;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Core.Flags;
using xZune.Bass.Modules;

namespace xZune.Bass
{
    /// <summary>
    ///     Set global configures in Bass.
    /// </summary>
    public static class BassConfig
    {
        private static byte[] _networkAgentBuffer = new byte[0];
        private static GCHandle _networkAgentBufferHandle = GCHandle.Alloc(_networkAgentBuffer, GCHandleType.Pinned);

        private static byte[] _networkProxy = new byte[0];
        private static GCHandle _networkProxyHandle = GCHandle.Alloc(_networkProxy, GCHandleType.Pinned);

        /// <summary>
        ///     Get or set 3D algorithm for software mixed 3D channels.
        /// </summary>
        /// <remarks>
        ///     These algorithms only affect 3D channels that are being mixed in software. <see cref="Channel.Infomation" /> can be
        ///     used to check whether a channel is being software mixed.
        ///     <para />
        ///     Changing the algorithm only affects subsequently created or loaded samples, musics, or streams; it does not affect
        ///     any that already exist.
        /// </remarks>
        public static Bass3DAlgorithm Bass3DAlgorithm
        {
            get
            {
                return
                    (Bass3DAlgorithm)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType._3DAlgorithm));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType._3DAlgorithm, (int) value));
            }
        }

        /// <summary>
        ///     Get or set Airplay status. the 1st bit is the 1st receiver, the 2nd bit is the 2nd receiver, etc. If a bit is set,
        ///     then the corresponding receiver is enabled.
        /// </summary>
        /// <remarks>
        ///     This configure option determines which Airplay receivers will receive the sound when the Airplay output device is
        ///     used. The receiver configuration is a global setting, so changes will also affect any other software that uses the
        ///     Airplay device.
        /// </remarks>
        public static uint AirplayStatus
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.Airplay));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.Airplay, (int) value));
            }
        }

        /// <summary>
        ///     Get or set the buffer length in bytes for asynchronous file reading. This will be rounded up to the nearest 4096
        ///     byte (4KB) boundary.
        /// </summary>
        /// <remarks>
        ///     This determines the amount of file data that can be read ahead of time with asynchronous file reading. The default
        ///     setting is 65536 bytes (64KB). Changes only affect streams that are created afterwards, not any that already exist.
        ///     So it is possible to have streams with differing buffer lengths by using this configure option before creating each
        ///     of them.
        /// </remarks>
        public static uint AsyncFileBufferLength
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.AsyncfileBuffer));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.AsyncfileBuffer, (int) value));
            }
        }

        /// <summary>
        ///     Get or set the playback buffer length in milliseconds for <see cref="AudioStream" /> and <see cref="ModMusic" />
        ///     channels.
        /// </summary>
        /// <remarks>
        ///     The default buffer length is 500 milliseconds. Increasing the length, decreases the chance of the sound possibly
        ///     breaking-up on slower computers, but also increases the latency for DSP/FX.
        ///     <para />
        ///     Small buffer lengths are only required if the sound is going to be changing in real-time, for example, in a
        ///     soft-synth. If you need to use a small buffer, then the min-buffer member of <see cref="BassManager.Infomation" />
        ///     should be used to get the recommended minimum buffer length supported by the device and its drivers. Even at this
        ///     default length, it's still possible that the sound could break up on some systems, it's also possible that smaller
        ///     buffers may be fine. So when using small buffers, you should have an option in your software for the user to
        ///     finetune the length used, for optimal performance.
        ///     <para />
        ///     Using this configure option only affects the <see cref="AudioStream" />/<see cref="ModMusic" /> channels that are
        ///     created afterwards, not any that have already been created. So you can have channels with differing buffer lengths
        ///     by using this configure option each time before creating them.
        ///     <para />
        ///     If automatic updating is disabled, make sure you call <see cref="BassManager.Update" /> frequently enough to keep
        ///     the buffers updated.
        /// </remarks>
        public static uint PlaybackBufferLength
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.Buffer));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.Buffer, (int) value));
            }
        }

        /// <summary>
        ///     Get or set the translation curve of volume values. false = linear, true = logarithmic.
        /// </summary>
        /// <remarks>
        ///     When using the linear curve, the volume range is from 0% (silent) to 100% (full). When using the logarithmic curve,
        ///     the volume range is from -100 dB (effectively silent) to 0 dB (full). For example, a volume level of 0.5 is 50%
        ///     linear or -50 dB logarithmic.
        ///     <para />
        ///     The linear curve is used by default.
        /// </remarks>
        public static bool VloumeCurve
        {
            get
            {
                return BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.CurveVol)) != 0;
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.CurveVol, value ? 1 : 0));
            }
        }

        /// <summary>
        ///     Get or set the translation curve of panning values. false = linear, true = logarithmic.
        /// </summary>
        /// <remarks>
        ///     The panning curve affects panning in exactly the same way as the volume curve (<see cref="VloumeCurve" />) affects
        ///     the volume.
        ///     <para />
        ///     The linear curve is used by default.
        /// </remarks>
        public static bool PanningCurve
        {
            get
            {
                return BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.CurvePan)) != 0;
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.CurvePan, value ? 1 : 0));
            }
        }

        /// <summary>
        ///     The output device buffer length in milliseconds.
        /// </summary>
        /// <remarks>
        ///     The device buffer is where the final mix of all playing channels is placed, ready for the device to play. Its
        ///     length affects the latency of things like starting and stopping playback of a channel, so you will probably want to
        ///     avoid setting it unnecessarily high, but setting it too short could result in breaks in the output.
        ///     <para />
        ///     When using a large device buffer, the <see cref="Channel.IsBufferDisable" /> property could be used to skip the
        ///     channel buffering stage, to avoid further increasing latency for real-time generated sound and/or DSP/FX changes.
        ///     <para />
        ///     Changes to this configure setting only affect subsequently initialized devices, not any that are already
        ///     initialized.
        /// </remarks>
        public static uint DeviceBufferLength
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.DevBuffer));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.DevBuffer, (int) value));
            }
        }

        /// <summary>
        ///     Include a "Default" entry in the output device list? If true, a "Default" device will be included in the device
        ///     list.
        /// </summary>
        /// <remarks>
        ///     BASS does not usually include a "Default" entry in its device list, as that would ultimately map to one of the
        ///     other devices and be a duplicate entry. When the default device is requested in a <see cref="Initialize" /> call
        ///     (with device = -1), BASS will check the default device at that time, and initialize it. But Windows 7 has the
        ///     ability to automatically switch the default output to the new default device whenever it changes, and in order for
        ///     that to happen, the default device (rather than a specific device) needs to be used. That is where this option
        ///     comes in.
        ///     <para />
        ///     When enabled, the "Default" device will also become the default device to <see cref="Initialize" /> (with device =
        ///     -1). When the "Default" device is used, the <see cref="BassManager.Volume" /> property work a bit differently to
        ///     usual; they deal with the "session" volume, which only affects the current process's output on the device, rather
        ///     than the device's volume.
        ///     <para />
        ///     This option can only be set before <see cref="BassManager.GetDeviceInfo" /> or <see cref="Initialize" /> has been
        ///     called.
        /// </remarks>
        public static bool IsShowDefaultDevice
        {
            get
            {
                return BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.DevDefault)) != 0;
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.DevDefault, value ? 1 : 0));
            }
        }

        /// <summary>
        ///     Pass 32-bit floating-point sample data to <see cref="Channel.Playbacking" /> event?
        /// </summary>
        /// <remarks>
        ///     Normally <see cref="Channel.Playbacking" /> event receive sample data in whatever format the channel is using, ie.
        ///     it can be 8, 16 or 32-bit. But using this configure option, BASS will convert 8/16-bit sample data to 32-bit
        ///     floating-point before passing it to <see cref="Channel.Playbacking" /> event, and then convert it back after all
        ///     the DSP functions are done. As well as simplifying the DSP code (no need for 8/16-bit processing), this also means
        ///     that there is no degradation of quality as sample data passes through a chain of DSP.
        /// </remarks>
        public static bool FloatSampleInPlayback
        {
            get
            {
                return BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.Floatdsp)) != 0;
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.Floatdsp, value ? 1 : 0));
            }
        }

        /// <summary>
        ///     Get or set global <see cref="ModMusic" /> volume level. 0 (silent) to 10000 (full).
        /// </summary>
        /// <remarks>
        ///     This configure option allows you to have control over the volume levels of all the MOD musics, which is useful for
        ///     setup options, eg. separate music and FX volume controls.
        ///     <para />
        ///     A channel's final volume = channel volume x global volume / 10000. For example, if a stream's volume is 0.5 and the
        ///     global stream volume is 8000, then effectively the stream's volume level is 0.4 (0.5 x 8000 / 10000 = 0.4).
        /// </remarks>
        public static uint ModMusicClobalVolume
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.GvolMusic));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.GvolMusic, (int) value));
            }
        }

        /// <summary>
        ///     Get or set global <see cref="SampleChannel" /> volume level. 0 (silent) to 10000 (full).
        /// </summary>
        /// <remarks>
        ///     This option allows you to have control over the volume levels of all the MOD musics, which is useful for setup
        ///     options, eg. separate music and FX volume controls.
        ///     <para />
        ///     A channel's final volume = channel volume x global volume / 10000. For example, if a stream's volume is 0.5 and the
        ///     global stream volume is 8000, then effectively the stream's volume level is 0.4 (0.5 x 8000 / 10000 = 0.4).
        /// </remarks>
        public static uint SampleChannelGlobalVolume
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.GvolSample));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.GvolSample, (int) value));
            }
        }

        /// <summary>
        ///     Get or set global <see cref="AudioStream" /> volume level. 0 (silent) to 10000 (full).
        /// </summary>
        /// <remarks>
        ///     This configure option allows you to have control over the volume levels of all the MOD musics, which is useful for
        ///     setup options, eg. separate music and FX volume controls.
        ///     <para />
        ///     A channel's final volume = channel volume x global volume / 10000. For example, if a stream's volume is 0.5 and the
        ///     global stream volume is 8000, then effectively the stream's volume level is 0.4 (0.5 x 8000 / 10000 = 0.4).
        /// </remarks>
        public static uint AudioStreamGlobalVolume
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.GvolStream));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.GvolStream, (int) value));
            }
        }

        /// <summary>
        ///     Play the audio from video files using Media Foundation?
        /// </summary>
        public static bool AcceptVideo
        {
            get
            {
                return BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.MfVideo)) != 0;
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.MfVideo, value ? 1 : 0));
            }
        }

        /// <summary>
        ///     Get or set maximum number of virtual channels to use in the rendering of IT files. 1 (min) to 512 (max). If the
        ///     value specified is outside this range, it is automatically capped.
        /// </summary>
        /// <remarks>
        ///     This setting only affects IT files, as the other MOD music formats do not have virtual channels. The default
        ///     setting is 64. Changes only apply to subsequently loaded files, not any that are already loaded.
        /// </remarks>
        public static uint ModMusicMaxVirtualChannels
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.MusicVirtual));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.MusicVirtual, (int) value));
            }
        }

        /// <summary>
        ///     Get or set "User-Agent" request header sent to servers.
        /// </summary>
        /// <remarks>
        ///     Changes take effect from the next Internet stream creation call.
        /// </remarks>
        public static String NetworkAgent
        {
            get { return Encoding.UTF8.GetString(_networkAgentBuffer); }

            set
            {
                if (value == null)
                {
                    _networkAgentBufferHandle.Free();
                    _networkAgentBuffer = new byte[0];
                    BassCoreModule.SetConfigPtrFunction.CheckResult(
                        BassCoreModule.SetConfigPtrFunction.Delegate(PointerConfigureType.NetAgent, IntPtr.Zero));

                    return;
                }

                var byteCount = Encoding.UTF8.GetByteCount(value);

                if (byteCount > _networkAgentBuffer.Length)
                {
                    _networkAgentBufferHandle.Free();
                    _networkAgentBuffer = new byte[byteCount*2];
                    _networkAgentBufferHandle = GCHandle.Alloc(_networkAgentBuffer, GCHandleType.Pinned);
                    BassCoreModule.SetConfigPtrFunction.CheckResult(
                        BassCoreModule.SetConfigPtrFunction.Delegate(PointerConfigureType.NetAgent,
                            _networkAgentBufferHandle.AddrOfPinnedObject()));
                }

                Encoding.UTF8.GetBytes(value, 0, value.Length, _networkAgentBuffer, 0);
            }
        }

        /// <summary>
        ///     The Internet download buffer length.
        /// </summary>
        /// <remarks>
        ///     Changes take effect from the next Internet stream creation call.
        ///     <para />
        ///     Increasing the buffer length decreases the chance of the stream stalling, but also increases the time taken to
        ///     create the stream as more data has to be pre-buffered (adjustable via the <see cref="NetworkPrebufferLength" />
        ///     configure option). Aside from the pre-buffering, this setting has no effect on streams without either the
        ///     <see cref="StreamCreateUrlConfig.Block" /> or <see cref="StreamCreateUrlConfig.RestRate" /> flags.
        ///     <para />
        ///     When streaming in blocks, this option determines the download buffer length. The effective buffer length can
        ///     actually be a bit more than that specified, including data that has been read from the buffer by the decoder but
        ///     not yet decoded.
        ///     <para />
        ///     This configure option also determines the buffering used by "buffered" user file streams created with
        ///     <see cref="AudioFileStream(FileHandlers, StreamCreateFileUserConfig ,StreamFileSystemType, IntPtr)" />.
        ///     <para />
        ///     Using this configure option only affects streams created afterwards, not any that have already been created.
        /// </remarks>
        public static uint NetworkBufferLength
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.NetBuffer));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.NetBuffer, (int) value));
            }
        }

        /// <summary>
        ///     Use passive mode in FTP connections? true, passive mode is used, otherwise normal/active mode is used.
        /// </summary>
        /// <remarks>
        ///     Changes take effect from the next Internet stream creation call. By default, passive mode is enabled.
        /// </remarks>
        public static bool IsFtpPassiveModeEnable
        {
            get
            {
                return BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.NetPassive)) != 0;
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.NetPassive, value ? 1 : 0));
            }
        }

        /// <summary>
        ///     Process URLs in PLS and M3U playlists?
        /// </summary>
        /// <remarks>
        ///     When enabled, BASS will process PLS and M3U playlists, trying each URL until it finds one that it can play.
        ///     <see cref="Channel.Infomation" /> can be used to find out the URL that was successfully opened.
        ///     <para />
        ///     Nested playlists are supported, that is a playlist can contain the URL of another playlist.
        ///     <para />
        ///     By default, playlist processing is disabled.
        /// </remarks>
        public static NetworkPlaylistConfig IsNetPlayListEnable
        {
            get
            {
                return (NetworkPlaylistConfig) BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.NetPlaylist));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.NetPlaylist, (int) value));
            }
        }

        /// <summary>
        ///     Amount to pre-buffer when opening Internet streams.
        /// </summary>
        /// <remarks>
        ///     This setting determines what percentage of the buffer length (<see cref="NetworkBufferLength" />) should be filled
        ///     by <see cref="AudioNetworkStream(String,StreamCreateUrlConfig,int)" />. The default is 75%. Setting this lower (eg.
        ///     0) is useful if you want to display a "buffering progress" (using <see cref="AudioStream.GetFilePosition" />) when
        ///     opening Internet streams, but note that this setting is just a minimum; BASS will always pre-download a certain
        ///     amount to verify the stream.
        /// </remarks>
        public static uint NetworkPrebufferLength
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.NetPrebuf));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.NetPrebuf, (int) value));
            }
        }

        /// <summary>
        ///     Get or set proxy server settings. NULL = don't use a proxy. "" (empty string) = use the OS's default proxy
        ///     settings. If only the "user:pass@" part is specified, then those authorization credentials are used with the
        ///     default proxy server. If only the "server:port" part is specified, then that proxy server is used without any
        ///     authorization credentials.
        /// </summary>
        /// <remarks>
        ///     Changes take effect from the next Internet stream creation call.
        /// </remarks>
        public static String NetworkProxy
        {
            get { return Encoding.UTF8.GetString(_networkProxy); }

            set
            {
                if (value == null)
                {
                    _networkProxyHandle.Free();
                    _networkProxy = new byte[0];
                    BassCoreModule.SetConfigPtrFunction.CheckResult(
                        BassCoreModule.SetConfigPtrFunction.Delegate(PointerConfigureType.NetProxy, IntPtr.Zero));

                    return;
                }

                var byteCount = Encoding.UTF8.GetByteCount(value);

                if (byteCount > _networkProxy.Length)
                {
                    _networkProxyHandle.Free();
                    _networkProxy = new byte[byteCount*2];
                    _networkProxyHandle = GCHandle.Alloc(_networkProxy, GCHandleType.Pinned);
                    BassCoreModule.SetConfigPtrFunction.CheckResult(
                        BassCoreModule.SetConfigPtrFunction.Delegate(PointerConfigureType.NetProxy,
                            _networkAgentBufferHandle.AddrOfPinnedObject()));
                }

                Encoding.UTF8.GetBytes(value, 0, value.Length, _networkProxy, 0);
            }
        }

        /// <summary>
        ///     The time to wait for a server to deliver more data for an Internet stream.
        /// </summary>
        /// <remarks>
        ///     When the timeout is hit, the connection with the server will be closed.
        ///     <para />
        ///     The default setting is 0, no timeout.
        /// </remarks>
        public static TimeSpan NetworkReadTimeout
        {
            get
            {
                var ms = BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.NetReadtimeout));

                return new TimeSpan(0, 0, 0, 0, ms);
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.NetReadtimeout,
                        (int) value.TotalMilliseconds));
            }
        }

        /// <summary>
        ///     The time to wait for a server to respond to a connection request.
        /// </summary>
        /// <remarks>
        ///     The default timeout is 5 seconds (5000 milliseconds).
        /// </remarks>
        public static TimeSpan NetworkTimeout
        {
            get
            {
                var ms = BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.NetTimeout));

                return new TimeSpan(0, 0, 0, 0, ms);
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.NetTimeout, (int) value.TotalMilliseconds));
            }
        }

        /// <summary>
        ///     Pre-scan chained OGG files? If true, chained OGG files are pre-scanned.
        /// </summary>
        /// <remarks>
        ///     This option is enabled by default, and is equivalent to including the <see cref="StreamCreateFileConfig.Prescan" />
        ///     flag in a <see cref="AudioFileStream" /> call when opening an OGG file. It can be disabled if seeking and an
        ///     accurate length reading are not required from chained OGG files, for faster stream creation.
        /// </remarks>
        public static bool IsPrescanOggEnable
        {
            get
            {
                return BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.OggPrescan)) != 0;
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.OggPrescan, value ? 1 : 0));
            }
        }

        /// <summary>
        ///     Prevent channels being played while the output is paused? If true, channels cannot be played while the output is
        ///     paused.
        /// </summary>
        /// <remarks>
        ///     When the output is paused using <see cref="BassManager.PauseAll" />, and this configure option is enabled, channels
        ///     cannot be played until the output is resumed using <see cref="BassManager.StartAll" />. Any attempts to play a
        ///     channel will result in a <see cref="ErrorCode.StartFail" /> error.
        /// </remarks>
        public static bool IsPauseNoPlay
        {
            get
            {
                return BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.PauseNoplay)) != 0;
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.PauseNoplay, value ? 1 : 0));
            }
        }

        /// <summary>
        ///     The buffer length for recording channels in milliseconds. 1000 (min) - 5000 (max). If the length specified is
        ///     outside this range, it is automatically capped.
        /// </summary>
        /// <remarks>
        ///     Unlike a playback buffer, where the aim is to keep the buffer full, a recording buffer is kept as empty as possible
        ///     and so this setting has no effect on latency. The default recording buffer length is 2000 milliseconds. Unless
        ///     processing of the recorded data could cause significant delays, or you want to use a large recording period with
        ///     <see cref="RecordManager.Start" />, there should be no need to increase this.
        ///     <para />
        ///     Using this configure option only affects the recording channels that are created afterwards, not any that have
        ///     already been created. So it is possible to have channels with differing buffer lengths by using this configure
        ///     option each time before creating them.
        /// </remarks>
        public static uint RecordBufferLength
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.RecBuffer));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.RecBuffer, (int) value));
            }
        }

        /// <summary>
        ///     The default sample rate conversion quality. 0 = linear interpolation, 1 = 8 point sinc interpolation, 2 = 16 point
        ///     sinc interpolation, 3 = 32 point sinc interpolation. Other values are also accepted.
        /// </summary>
        /// <remarks>
        ///     This configure option determines what sample rate conversion quality new channels will initially have, except for
        ///     sample channels (<see cref="SampleChannel" />), which use the <see cref="DefaultSampleRateConversionQuality" />
        ///     setting. A channel's sample rate conversion quality can subsequently be changed via the
        ///     <see cref="DefaultRateConversionQuality" /> attribute.
        /// </remarks>
        public static int DefaultRateConversionQuality
        {
            get
            {
                return
                    BassCoreModule.GetConfigFunction.CheckResult(
                        BassCoreModule.GetConfigFunction.Delegate(ConfigureType.Src));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(BassCoreModule.SetConfigFunction.Delegate(
                    ConfigureType.Src, value));
            }
        }

        /// <summary>
        ///     The default sample rate conversion quality for samples. 0 = linear interpolation, 1 = 8 point sinc interpolation, 2
        ///     = 16 point sinc interpolation, 3 = 32 point sinc interpolation. Other values are also accepted.
        /// </summary>
        /// <remarks>
        ///     This configure option determines what sample rate conversion quality a new sample channel will initially have,
        ///     following a <see cref="AudioSample.GetChannel" /> call. The channel's sample rate conversion quality can
        ///     subsequently be changed via the <see cref="DefaultRateConversionQuality" /> attribute.
        /// </remarks>
        public static int DefaultSampleRateConversionQuality
        {
            get
            {
                return
                    BassCoreModule.GetConfigFunction.CheckResult(
                        BassCoreModule.GetConfigFunction.Delegate(ConfigureType.SrcSample));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.SrcSample, value));
            }
        }

        /// <summary>
        ///     Use the Unicode character set in device information? If true, device information will be in UTF-8 form. Otherwise
        ///     it will be ANSI.
        /// </summary>
        /// <remarks>
        ///     This configure option determines what character set is used in the <see cref="DeviceInfo" /> structure and by the
        ///     <see cref="RecordManager.GetInputName" /> function. The default setting is ANSI, and it can only be changed before
        ///     <see cref="BassManager.GetDeviceInfo" /> or BASS_Init or <see cref="RecordManager.GetDeviceInfomation" /> or
        ///     <see cref="RecordManager.Initialize" /> has been called.
        /// </remarks>
        public static bool IsUnicodeEnable
        {
            get
            {
                return BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.Unicode)) != 0;
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.Unicode, value ? 1 : 0));
            }
        }

        /// <summary>
        ///     The update period of <see cref="AudioStream" /> and <see cref="ModMusic" /> channel playback buffers. 0 = disable
        ///     automatic updating. The minimum period is 5ms, the maximum is 100ms. If the period specified is outside this range,
        ///     it is automatically capped.
        /// </summary>
        /// <remarks>
        ///     The update period is the amount of time between updates of the playback buffers of <see cref="AudioStream" />/
        ///     <see cref="ModMusic" /> channels. Shorter update periods allow smaller buffers to be set with the
        ///     <see cref="PlaybackBufferLength" /> configure option, but as the rate of updates increases, so the overhead of
        ///     setting up the updates becomes a greater part of the CPU usage. The update period only affects
        ///     <see cref="AudioStream" /> and <see cref="ModMusic" /> channels; it does not affect samples. Nor does it have any
        ///     effect on decoding channels, as they are not played.
        ///     <para />
        ///     The update period can be altered at any time, including during playback. The default period is 100ms.
        /// </remarks>
        public static uint UpdatePeriod
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.UpdatePeriod));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.UpdatePeriod, (int) value));
            }
        }

        /// <summary>
        ///     The number of threads to use for updating playback buffers. 0 = disable automatic updating.
        /// </summary>
        /// <remarks>
        ///     The number of update threads determines how many <see cref="AudioStream" />/<see cref="ModMusic" /> channel
        ///     playback buffers can be updated in parallel; each thread can process one channel at a time. The default is to use a
        ///     single thread, but additional threads can be used to take advantage of multiple CPU cores. There is generally
        ///     nothing much to be gained by creating more threads than there are CPU cores, but one benefit of using multiple
        ///     threads even with a single CPU core is that a slowly updating channel need not delay the updating of other
        ///     channels.
        ///     <para />
        ///     When automatic updating is disabled (threads = 0), <see cref="BassManager.Update" /> or
        ///     <see cref="Channel.Update" /> should be used instead.
        ///     <para />
        ///     The number of update threads can be changed at any time, including during playback.
        /// </remarks>
        public static uint UpdateThread
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.UpdateThreads));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.UpdateThreads, (int) value));
            }
        }

        /// <summary>
        ///     The amount of data to check in order to verify/detect the file format. 1000 (min) to 1000000 (max). If the value
        ///     specified is outside this range, it is automatically capped.
        /// </summary>
        /// <remarks>
        ///     Of the file formats supported as standard, this setting only affects the detection of MP3/MP2/MP1 formats, but it
        ///     may also be used by add-ons (see the documentation). The verification length excludes any tags that may be found at
        ///     the start of the file. The default length is 16000 bytes.
        ///     <para />
        ///     For Internet (and "buffered" user file) streams, the <see cref="VerifyNetwork" /> setting determines how much data
        ///     is checked.
        /// </remarks>
        public static uint Verify
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.UpdateThreads));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.UpdateThreads, (int) value));
            }
        }

        /// <summary>
        ///     The amount of data to check in order to verify/detect the file format of Internet streams. 1000 (min) to 1000000
        ///     (max), or 0 = 25% of the <see cref="Verify" /> setting (with a minimum of 1000 bytes). If the value specified is
        ///     outside this range, it is automatically capped.
        /// </summary>
        /// <remarks>
        ///     Of the file formats supported as standard, this setting only affects the detection of MP3/MP2/MP1 formats, but it
        ///     may also be used by add-ons (see the documentation). The verification length excludes any tags that may be found at
        ///     the start of the file. The default setting is 0, which means 25% of the <see cref="Verify" /> setting.
        ///     <para />
        ///     As well as Internet streams, this configure setting also applies to "buffered" user file streams created with
        ///     <see cref="AudioFileStream(FileHandlers, StreamCreateFileUserConfig ,StreamFileSystemType, IntPtr)" />.
        /// </remarks>
        public static uint VerifyNetwork
        {
            get
            {
                return
                    (uint)
                        BassCoreModule.GetConfigFunction.CheckResult(
                            BassCoreModule.GetConfigFunction.Delegate(ConfigureType.UpdateThreads));
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.UpdateThreads, (int) value));
            }
        }

        /// <summary>
        ///     Enable speaker assignment with panning/balance control on Windows Vista and newer? If true, speaker assignment with
        ///     panning/balance control is enabled on Windows Vista and newer.
        /// </summary>
        /// <remarks>
        ///     Panning/balance control via the <see cref="Channel.PanningPosition" /> attribute is not available when speaker
        ///     assignment is used on Windows due to the way that the speaker assignment needs to be implemented there. The
        ///     situation is improved with Windows Vista, and speaker assignment can generally be done in a way that does permit
        ///     panning/balance control to be used at the same time, but there may still be some drivers that it does not work
        ///     properly with, so it is disabled by default and can be enabled via this config option. Changes only affect channels
        ///     that are created afterwards, not any that already exist.
        /// </remarks>
        public static bool IsVistaSpeakerEnable
        {
            get
            {
                return BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.VistaSpeakers)) != 0;
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.VistaSpeakers, value ? 1 : 0));
            }
        }

        /// <summary>
        ///     Enable true play position mode on Windows Vista and newer? If true, DirectSound's "true play position" mode is
        ///     enabled on Windows Vista and newer.
        /// </summary>
        /// <remarks>
        ///     Unless this option is enabled, the reported playback position will advance in 10ms steps on Windows Vista and
        ///     newer. As well as affecting the precision of <see cref="Channel.Position" />, this also affects the timing of
        ///     non-mixtime syncs. When this option is enabled, it allows finer position reporting but it also increases latency.
        ///     <para />
        ///     The default setting is enabled. Changes only affect channels that are created afterwards, not any that already
        ///     exist. The latency and minbuf values in the <see cref="BassManager.Infomation" /> structure reflect the setting at
        ///     the time of the device's <see cref="BassManager.Initialize" /> call.
        /// </remarks>
        public static bool IsVistaTruePositionModeEnable
        {
            get
            {
                return BassCoreModule.GetConfigFunction.CheckResult(
                    BassCoreModule.GetConfigFunction.Delegate(ConfigureType.VistaTruepos)) != 0;
            }

            set
            {
                BassCoreModule.SetConfigFunction.CheckResult(
                    BassCoreModule.SetConfigFunction.Delegate(ConfigureType.VistaTruepos, value ? 1 : 0));
            }
        }
    }
}