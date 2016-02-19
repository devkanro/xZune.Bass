// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Channel.cs
// Version: 20160217

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Core.Flags;
using xZune.Bass.Modules;
using ChannelFlags = xZune.Bass.Interop.Core.Flags.ChannelFlags;

namespace xZune.Bass
{
    public abstract class Channel : HandleObject, IChannel, IChannelInternal
    {
        private Channel _linkedChannel;

        protected Channel()
        {
            IsAvailable = true;
        }

        public override IntPtr Handle
        {
            protected set
            {
                base.Handle = value;
                if (base.Handle != IntPtr.Zero)
                {
                    AttachEvent();
                }
            }
        }

        protected virtual void AttachEvent()
        {
            _displayCallback?.DeattachToChannel();
            _endedCallback?.DeattachToChannel();
            _freedCallback?.DeattachToChannel();
            _metaTagAvailabledCallback?.DeattachToChannel();
            _oggChangedCallback?.DeattachToChannel();
            _positionSetCallback?.DeattachToChannel();
            _animationCompletedCallback?.DeattachToChannel();
            _stallOrResumedCallback?.DeattachToChannel();

            _displayCallback = new ChannelDisplayCallback(OnPlaybacking, 0);
            _displayCallback.AttachToChannel(this);

            _endedCallback = new ChannelSyncCallback(OnEnded, SyncHandlerType.End, 0);
            _freedCallback = new ChannelSyncCallback(OnFreed, SyncHandlerType.Free, 0);
            _metaTagAvailabledCallback = new ChannelSyncCallback(OnMetaTagAvailabled, SyncHandlerType.Meta, 0);
            _oggChangedCallback = new ChannelSyncCallback(OnOggChanged, SyncHandlerType.OggChange, 0);
            _positionSetCallback = new ChannelSyncCallback(OnPositionSet, SyncHandlerType.Setpos, 0);
            _animationCompletedCallback = new ChannelSyncCallback(OnAnimationCompleted, SyncHandlerType.Slide, 0);
            _stallOrResumedCallback = new ChannelSyncCallback(OnStallOrResumed, SyncHandlerType.Stall, 0);

            _endedCallback.AttachToChannel(this);
            _freedCallback.AttachToChannel(this);
            _metaTagAvailabledCallback.AttachToChannel(this);
            _oggChangedCallback.AttachToChannel(this);
            _positionSetCallback.AttachToChannel(this);
            _animationCompletedCallback.AttachToChannel(this);
            _stallOrResumedCallback.AttachToChannel(this);
        }
        
        private void OnEnded(IntPtr displayHandle, IntPtr channel, uint data, IntPtr user)
        {
            StatusChanged?.Invoke(this, new ChannelStatusChangedEventArgs(ChannelStatus.Stopped));
            Ended?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Sync when a channel reaches the end, including when looping. Note that some MOD musics never reach the end; they may jump to another position first.
        /// </summary>
        public event EventHandler Ended;

        private void OnFreed(IntPtr displayHandle, IntPtr channel, uint data, IntPtr user)
        {
            StatusChanged?.Invoke(this, new ChannelStatusChangedEventArgs(ChannelStatus.Stopped));
            Freed?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Sync when a channel is freed. This can be useful when you need to release some resources associated with the channel. Note that you will not be able to use any BASS functions with the channel in the callback, as the channel will no longer exist.
        /// </summary>
        public event EventHandler Freed;

        private void OnMetaTagAvailabled(IntPtr displayHandle, IntPtr channel, uint data, IntPtr user)
        {
            MetaTagAvailabled?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Sync when metadata is received in a Shoutcast stream. 
        /// </summary>
        public event EventHandler MetaTagAvailabled;

        private void OnOggChanged(IntPtr displayHandle, IntPtr channel, uint data, IntPtr user)
        {
            OggChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Sync when a new logical bit-stream begins in a chained OGG stream.
        /// </summary>
        public event EventHandler OggChanged;
        
        private void OnPositionSet(IntPtr displayHandle, IntPtr channel, uint data, IntPtr user)
        {
            PositionSet?.Invoke(this, new PositionSetEventArgs(data == 1));
        }

        /// <summary>
        /// Sync when a channel's position is set, including when looping/restarting.
        /// </summary>
        public event PositionSetEventHandler PositionSet;

        private void OnAnimationCompleted(IntPtr displayHandle, IntPtr channel, uint data, IntPtr user)
        {
            AnimationCompleted?.Invoke(this, new PropertyAnimationCompletedEventArgs((ChannelAttribute)data));
        }

        /// <summary>
        /// Sync when an property animation slide has ended.
        /// </summary>
        public event PropertyAnimationCompletedEventHandler AnimationCompleted;

        private void OnStallOrResumed(IntPtr displayHandle, IntPtr channel, uint data, IntPtr user)
        {
            StatusChanged?.Invoke(this, new ChannelStatusChangedEventArgs(data == 0 ? ChannelStatus.Stalled : ChannelStatus.Playing));
        }

        /// <summary>
        /// Sync when status of channel changed.
        /// </summary>
        public event ChannelStatusChangedEventHandler StatusChanged;


        private void OnPlaybacking(IntPtr displayHandle, IntPtr channel, IntPtr buffer, uint length, IntPtr user)
        {
            Playbacking?.Invoke(this, new PlaybackingEventArgs(buffer, length));

            Task.Run(() =>
            {
                PositionChanged?.Invoke(this, new EventArgs());
            });
        }

        /// <summary>
        /// Every sample date is ready to render, this event will be called, you can get sample data and change it. Since this event would be raised on the mixing thread, you should ensure your event handler executes quickly enough to avoid any possible noises and dropouts.
        /// </summary>
        public event PlaybackingEventHandler Playbacking;

        /// <summary>
        /// Sync when position of channel changed.
        /// </summary>
        public event EventHandler PositionChanged;

        private ChannelDisplayCallback _displayCallback;
        private ChannelSyncCallback _endedCallback;
        private ChannelSyncCallback _freedCallback;
        private ChannelSyncCallback _metaTagAvailabledCallback;
        private ChannelSyncCallback _oggChangedCallback;
        private ChannelSyncCallback _positionSetCallback;
        private ChannelSyncCallback _animationCompletedCallback;
        private ChannelSyncCallback _stallOrResumedCallback;

        /// <summary>
        /// Check a channel object is available, if not a <see cref="ChannelNotAvailableException"/> will be throwed.
        /// </summary>
        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        protected void CheckAvailable()
        {
            if (!IsAvailable) throw new ChannelNotAvailableException();
        }

        /// <summary>
        /// The available status of a channel. If a channel is not available, every calling will case exception, but this.
        /// </summary>
        public bool IsAvailable { get; protected set; }

        /// <summary>
        /// The wet (reverb) / dry (no reverb) mix ratio of a channel. 0 (full dry) to 1 (full wet), -1 = automatically calculate the mix based on the distance (the default).
        /// </summary>
        public float EaxMix
        {
            get { return ((IChannelInternal)this).GetAttribute(ChannelAttribute.Eaxmix); }
            set { ((IChannelInternal)this).SetAttribute(ChannelAttribute.Eaxmix, value); }
        }

        /// <summary>
        /// The CPU usage of a channel.
        /// </summary>
        public float CpuUsage
        {
            get { return ((IChannelInternal)this).GetAttribute(ChannelAttribute.Cpu); }
        }

        /// <summary>
        /// The sample rate of a channel. 0 = original rate.
        /// </summary>
        public float Freq
        {
            get { return ((IChannelInternal)this).GetAttribute(ChannelAttribute.Freq); }
            set { ((IChannelInternal)this).SetAttribute(ChannelAttribute.Freq, value); }
        }

        /// <summary>
        /// The panning/balance position of a channel. -1 (full left) to +1 (full right), 0 = center.
        /// </summary>
        public float PanningPosition
        {
            get { return ((IChannelInternal)this).GetAttribute(ChannelAttribute.Pan); }
            set { ((IChannelInternal)this).SetAttribute(ChannelAttribute.Pan, value); }
        }

        /// <summary>
        /// The sample rate conversion quality of a channel. 0 = linear interpolation, 1 = 8 point sinc interpolation, 2 = 16 point sinc interpolation, 3 = 32 point sinc interpolation. Other values are also accepted but will be interpreted as 0 or 3, depending on whether they are lower or higher.
        /// </summary>
        public int SampleRateConversionQuality
        {
            get { return (int)((IChannelInternal)this).GetAttribute(ChannelAttribute.Src); }
            set { ((IChannelInternal)this).SetAttribute(ChannelAttribute.Src, value); }
        }

        /// <summary>
        /// The volume level of a channel. 0 (silent) to 1.0 (full). This can go above 1.0 on decoding channels.
        /// </summary>
        public float Volume
        {
            get { return ((IChannelInternal)this).GetAttribute(ChannelAttribute.Volume); }
            set { ((IChannelInternal)this).SetAttribute(ChannelAttribute.Volume, value); }
        }

        /// <summary>
        /// Disable playback buffering?
        /// </summary>
        public bool IsBufferDisable
        {
            get { return ((IChannelInternal)this).GetAttribute(ChannelAttribute.NoBuffer).Equals(0.0f); }
            set { ((IChannelInternal)this).SetAttribute(ChannelAttribute.NoBuffer, value ? 1 : 0); }
        }

        /// <summary>
        /// The scanned info of a channel.
        /// </summary>
        public byte[] ScanInfo
        {
            get { return ((IChannelInternal)this).GetAttribute(ChannelAttributeEx.Scaninfo); }
            set { ((IChannelInternal)this).SetAttribute(ChannelAttributeEx.Scaninfo, value); }
        }

        /// <summary>
        /// A linked channel, null to remove link. Linked two channels are started/stopped/paused/resumed together.
        /// </summary>
        public Channel LinkedChannel
        {
            get { return _linkedChannel; }
            set
            {
                if (_linkedChannel == value) return;

                if (_linkedChannel != null)
                {
                    ((IChannelInternal)this).RemoveLink(_linkedChannel);
                    _linkedChannel._linkedChannel = null;
                    _linkedChannel = null;
                }

                if (value != null)
                {
                    ((IChannelInternal)this).SetLink(_linkedChannel);
                    _linkedChannel = value;
                    _linkedChannel._linkedChannel = this;
                }
            }
        }

        /// <summary>
        /// Playback time of the channel.
        /// </summary>
        public virtual TimeSpan Time
        {
            get
            {
                var seconds= ((IChannelInternal)this).Bytes2Seconds(((IChannelInternal)this).GetPosition(PositionConfig.Byte));
                return new TimeSpan(0, 0, 0, (int) seconds, (int) ((seconds - (int) seconds)*1000));
            }
            set
            {
                ((IChannelInternal) this).SetPosition(PositionConfig.Byte,
                    ((IChannelInternal) this).Seconds2Bytes(value.TotalMilliseconds/1000.0));
            }
        }

        /// <summary>
        /// Playback position of the channel, 0 ~ 1.
        /// </summary>
        public virtual double Position
        {
            get
            {
                return 1.0*((IChannelInternal) this).GetPosition(PositionConfig.Byte)/
                       ((IChannelInternal) this).GetLength(PositionConfig.Byte);
            }
            set
            {
                ((IChannelInternal) this).SetPosition(PositionConfig.Byte,
                    (UInt64) (((IChannelInternal) this).GetLength(PositionConfig.Byte)*value));
            }
        }

        /// <summary>
        /// Time length of the channel.
        /// </summary>
        public virtual TimeSpan Length
        {
            get
            {
                var seconds = ((IChannelInternal)this).Bytes2Seconds(((IChannelInternal)this).GetLength(PositionConfig.Byte));
                return new TimeSpan(0, 0, 0, (int)seconds, (int)((seconds - (int)seconds) * 1000));
            }
        }

        /// <summary>
        /// Checks if <see cref="Freq"/> is sliding.
        /// </summary>
        public bool IsFreqAnimating
        {
            get { return ((IChannelInternal)this).IsSliding(ChannelAttribute.Freq); }
        }

        /// <summary>
        /// Checks if <see cref="PanningPosition"/> is sliding.
        /// </summary>
        public bool IsPanningPositionAnimating
        {
            get { return ((IChannelInternal)this).IsSliding(ChannelAttribute.Pan); }
        }

        /// <summary>
        /// Checks if <see cref="Volume"/> is sliding.
        /// </summary>
        public bool IsVolumeAnimating
        {
            get { return ((IChannelInternal)this).IsSliding(ChannelAttribute.Volume); }
        }

        /// <summary>
        /// Checks if a sample, stream, or MOD music is active (playing) or stalled. Can also check if a recording is in progress. 
        /// </summary>
        public ChannelStatus Status
        {
            get { return ChannelModule.ChannelIsActiveFunction.CheckResult(ChannelModule.ChannelIsActiveFunction.Delegate(Handle)); }
        }

        /// <summary>
        /// Get or set the device that a channel is using. 
        /// </summary>
        public int Device
        {
            get { return ChannelModule.ChannelGetDeviceFunction.CheckResult(ChannelModule.ChannelGetDeviceFunction.Delegate(Handle)); }

            set { ChannelModule.ChannelSetDeviceFunction.CheckResult(ChannelModule.ChannelSetDeviceFunction.Delegate(Handle, value)); }
        }

        /// <summary>
        /// Get information on a channel. 
        /// </summary>
        public ChannelInfo Infomation
        {
            get
            {
                ChannelInfo info = new ChannelInfo();

                ChannelModule.ChannelGetInfoFunction.CheckResult(ChannelModule.ChannelGetInfoFunction.Delegate(Handle, ref info));

                return info;
            }
        }

        /// <summary>
        /// Retrieves the level (peak amplitude) of a sample, stream, MOD music, or recording channel. 
        /// </summary>
        public uint Level
        {
            get { return (uint)ChannelModule.ChannelGetLevelFunction.CheckResult(ChannelModule.ChannelGetLevelFunction.Delegate(Handle)); }
        }
        
        /// <summary>
        /// Slides a channel's <see cref="Volume"/> from its current value to a new value.
        /// </summary>
        /// <param name="value">New volume value. 0 (silent) to 1.0 (full). This can go above 1.0 on decoding channels. </param>
        /// <param name="time">The length of time (in milliseconds) that it should take for the <see cref="Volume"/> to reach the value. </param>
        public void SetVolumeAnimate(float value, uint time)
        {
            ((IChannelInternal)this).SlideAttribute(ChannelAttribute.Volume, value, time);
        }

        /// <summary>
        /// Slides a channel's <see cref="Freq"/> from its current value to a new value.
        /// </summary>
        /// <param name="value">New sample rate value. </param>
        /// <param name="time">The length of time (in milliseconds) that it should take for the <see cref="Freq"/> to reach the value. </param>
        public void SetFreqAnimate(float value, uint time)
        {
            ((IChannelInternal)this).SlideAttribute(ChannelAttribute.Freq, value, time);
        }

        /// <summary>
        /// Slides a channel's <see cref="PanningPosition"/> from its current value to a new value.
        /// </summary>
        /// <param name="value">New volume value. -1 (full left) to +1 (full right), 0 = center.  </param>
        /// <param name="time">The length of time (in milliseconds) that it should take for the <see cref="PanningPosition"/> to reach the value. </param>
        public void SetPanningPositionAnimate(float value, uint time)
        {
            ((IChannelInternal)this).SlideAttribute(ChannelAttribute.Pan, value, time);
        }

        /// <summary>
        /// Starts (or resumes) playback of a sample, stream, MOD music, or recording.
        /// </summary>
        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        public void Play()
        {
            CheckAvailable();

            var status = Status;

            ChannelModule.ChannelPlayFunction.CheckResult(ChannelModule.ChannelPlayFunction.Delegate(Handle, false));

            if (status != ChannelStatus.Playing && Status == ChannelStatus.Playing)
            {
                StatusChanged?.Invoke(this, new ChannelStatusChangedEventArgs(ChannelStatus.Playing));
            }
        }

        /// <summary>
        /// Restart playback of a sample, stream, MOD music, or recording.
        /// </summary>
        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        public void Replay()
        {
            CheckAvailable();
            
            var status = Status;

            ChannelModule.ChannelPlayFunction.CheckResult(ChannelModule.ChannelPlayFunction.Delegate(Handle, true));

            if (status != ChannelStatus.Playing && Status == ChannelStatus.Playing)
            {
                StatusChanged?.Invoke(this, new ChannelStatusChangedEventArgs(ChannelStatus.Playing));
            }
        }

        /// <summary>
        /// Pauses a sample, stream, MOD music, or recording.
        /// </summary>
        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        public void Pause()
        {
            CheckAvailable();

            var status = Status;

            ChannelModule.ChannelPauseFunction.CheckResult(ChannelModule.ChannelPauseFunction.Delegate(Handle));

            if (status != ChannelStatus.Paused && Status == ChannelStatus.Paused)
            {
                StatusChanged?.Invoke(this, new ChannelStatusChangedEventArgs(ChannelStatus.Paused));
            }
        }

        /// <summary>
        /// Stops a sample, stream, MOD music, or recording, <see cref="Stop"/> can be used to stop a paused channel.
        /// </summary>
        public void Stop()
        {
            CheckAvailable();

            var status = Status;

            ChannelModule.ChannelStopFunction.CheckResult(ChannelModule.ChannelStopFunction.Delegate(Handle));

            if (status != ChannelStatus.Stopped && Status == ChannelStatus.Stopped)
            {
                StatusChanged?.Invoke(this, new ChannelStatusChangedEventArgs(ChannelStatus.Stopped));
            }
        }

        /// <summary>
        /// Locks a stream, MOD music or recording channel to the current thread.
        /// </summary>
        /// <remarks>Locking a channel prevents other threads from performing most functions on it, including buffer updates. Other threads wanting to access a locked channel will block until it is unlocked, so a channel should only be locked very briefly. A channel must be unlocked in the same thread that it was locked. </remarks>
        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        public void Lock()
        {
            CheckAvailable();

            ChannelModule.ChannelLockFunction.CheckResult(ChannelModule.ChannelLockFunction.Delegate(Handle, true));
        }

        /// <summary>
        /// Unlocks a stream, MOD music or recording channel to the current thread.
        /// </summary>
        /// <remarks>Locking a channel prevents other threads from performing most functions on it, including buffer updates. Other threads wanting to access a locked channel will block until it is unlocked, so a channel should only be locked very briefly. A channel must be unlocked in the same thread that it was locked. </remarks>
        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        public void Unlock()
        {
            CheckAvailable();

            ChannelModule.ChannelLockFunction.CheckResult(ChannelModule.ChannelLockFunction.Delegate(Handle, false));
        }

        protected abstract void Free();

        #region -- IChannelInternal --

        float[] IChannelInternal.GetLevelEx(LevelConfig config)
        {
            CheckAvailable();

            throw new NotImplementedException();
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        float IChannelInternal.GetAttribute(ChannelAttribute attribute)
        {
            CheckAvailable();

            float result = 0;

            ChannelModule.ChannelGetAttributeFunction.CheckResult(ChannelModule.ChannelGetAttributeFunction.Delegate(Handle, attribute, ref result));

            return result;
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        byte[] IChannelInternal.GetAttribute(ChannelAttributeEx attribute)
        {
            CheckAvailable();

            var size = ChannelModule.ChannelGetAttributeExFunction.CheckResult(ChannelModule.ChannelGetAttributeExFunction.Delegate(Handle, attribute, IntPtr.Zero, 0));

            byte[] result = new byte[size];

            GCHandle resultHandle = GCHandle.Alloc(result, GCHandleType.Pinned);

            ChannelModule.ChannelGetAttributeExFunction.CheckResult(ChannelModule.ChannelGetAttributeExFunction.Delegate(Handle, attribute, resultHandle.AddrOfPinnedObject(), size));

            resultHandle.Free();

            return result;
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.Get3DAttribute(out Channel3DMode mode, out float min, out float max, out uint iAngle,
            out uint oAngle, out float outVloume)
        {
            CheckAvailable();

            // TODO: Check the null pointer.

            mode = Channel3DMode.Normal;
            min = 0;
            max = 0;
            iAngle = 0;
            oAngle = 0;
            outVloume = 0;

            ChannelModule.ChannelGet3DAttributesFunction.CheckResult(ChannelModule.ChannelGet3DAttributesFunction.Delegate(Handle, ref mode, ref min, ref max, ref iAngle, ref oAngle, ref outVloume));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.Get3DPosition(out Vector3 pos, out Vector3 orientation, out Vector3 vel)
        {
            CheckAvailable();

            // TODO: Check the null pointer.

            pos = new Vector3();
            orientation = new Vector3();
            vel = new Vector3();

            ChannelModule.ChannelGet3DPositionFunction.CheckResult(ChannelModule.ChannelGet3DPositionFunction.Delegate(Handle, ref pos, ref orientation, ref vel));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.SetAttribute(ChannelAttribute attribute, float value)
        {
            CheckAvailable();

            ChannelModule.ChannelSetAttributeFunction.CheckResult(ChannelModule.ChannelSetAttributeFunction.Delegate(Handle, attribute, value));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.SetAttribute(ChannelAttributeEx attribute, byte[] value)
        {
            CheckAvailable();

            GCHandle valueHandle = GCHandle.Alloc(value, GCHandleType.Pinned);

            ChannelModule.ChannelSetAttributeExFunction.CheckResult(ChannelModule.ChannelSetAttributeExFunction.Delegate(Handle, attribute, valueHandle.AddrOfPinnedObject(), (uint)value.Length));

            valueHandle.Free();
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.Set3DAttribute(Channel3DMode mode, float min, float max, uint iAngle, uint oAngle, float outVloume)
        {
            CheckAvailable();

            ChannelModule.ChannelSet3DAttributesFunction.CheckResult(ChannelModule.ChannelSet3DAttributesFunction.Delegate(Handle, mode, min, max, (int)iAngle, (int)oAngle, outVloume));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.Set3DPosition(Vector3 pos, Vector3 orientation, Vector3 vel)
        {
            CheckAvailable();

            ChannelModule.ChannelSet3DPositionFunction.CheckResult(ChannelModule.ChannelSet3DPositionFunction.Delegate(Handle, ref pos, ref orientation, ref vel));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.SetLink(Channel channel)
        {
            CheckAvailable();
            channel.CheckAvailable();

            ChannelModule.ChannelSetLinkFunction.CheckResult(ChannelModule.ChannelSetLinkFunction.Delegate(Handle, channel.Handle));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.RemoveLink(Channel channel)
        {
            CheckAvailable();
            channel.CheckAvailable();

            ChannelModule.ChannelRemoveLinkFunction.CheckResult(ChannelModule.ChannelRemoveLinkFunction.Delegate(Handle, channel.Handle));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        ulong IChannelInternal.GetPosition(PositionConfig config)
        {
            CheckAvailable();

            return ChannelModule.ChannelGetPositionFunction.CheckResult(
                ChannelModule.ChannelGetPositionFunction.Delegate(Handle, config));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.SetPosition(PositionConfig config, ulong value)
        {
            CheckAvailable();

            ChannelModule.ChannelSetPositionFunction.CheckResult(
                ChannelModule.ChannelSetPositionFunction.Delegate(Handle, value, config));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        UInt64 IChannelInternal.GetLength(PositionConfig config)
        {
            CheckAvailable();

            return ChannelModule.ChannelGetLengthFunction.CheckResult(
                ChannelModule.ChannelGetLengthFunction.Delegate(Handle, config));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        object IChannelInternal.GetTag(TagType type)
        {
            CheckAvailable();


            var data = ChannelModule.ChannelGetTagsFunction.CheckResult(
                ChannelModule.ChannelGetTagsFunction.Delegate(Handle, type));

            return data;

            switch (type)
            {
                case TagType.Ape:
                    {
                        return InteropHelper.PtrToStringArray(data).Select(s => s.Split('=', '/')).Where(d => d.Length > 1).ToDictionary(d => d[0], d => new ArraySegment<String>(d, 1, d.Length - 1).Array);
                    }
                case TagType.ApeBinary:
                    {
                        return Marshal.PtrToStructure(data, typeof(TagApeBinary));
                    }
                case TagType.CaCodec:
                    {
                        return Marshal.PtrToStructure(data, typeof(TagCoreAudioCodec));
                    }
                case TagType.ID3:
                    {
                        return Marshal.PtrToStructure(data, typeof(TagID3));
                    }
                case TagType.Lyrics3:
                case TagType.Meta:
                    {
                        return InteropHelper.PtrToString(data, Encoding.UTF8);
                    }
                case TagType.Http:
                case TagType.Icy:
                    {
                        return InteropHelper.PtrToStringArray(data);
                    }
                case TagType.ID3V2:
                    {
                        // TODO: Some other tag structures.
                        return data;
                    }
                case TagType.Mf:

                case TagType.MusicInst:
                case TagType.MusicMessage:
                case TagType.MusicName:
                case TagType.MusicOrders:
                case TagType.MusicSample:
                case TagType.Mp4:
                case TagType.Ogg:
                case TagType.RiffBext:
                case TagType.RiffCart:
                case TagType.RiffDisp:
                case TagType.RiffInfo:
                case TagType.Vendor:
                case TagType.Waveformat:
                    break;
            }
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.SetConfig(ChannelFlags config, ChannelFlags mask)
        {
            CheckAvailable();

            ChannelModule.ChannelFlagsFunction.CheckResult(
                ChannelModule.ChannelFlagsFunction.Delegate(Handle, config, (int)mask));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        double IChannelInternal.Bytes2Seconds(ulong position)
        {
            CheckAvailable();

            return ChannelModule.ChannelBytes2SecondsFunction.CheckResult(
                ChannelModule.ChannelBytes2SecondsFunction.Delegate(Handle, position));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        ulong IChannelInternal.Seconds2Bytes(double time)
        {
            CheckAvailable();

            return ChannelModule.ChannelSeconds2BytesFunction.CheckResult(
                ChannelModule.ChannelSeconds2BytesFunction.Delegate(Handle, time));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        IntPtr IChannelInternal.SetDisplayCallback(DisplayHandler handler, IntPtr user, int priority)
        {
            CheckAvailable();

            return
                ChannelModule.ChannelSetDSPFunction.CheckResult(ChannelModule.ChannelSetDSPFunction.Delegate(Handle,
                    handler, user, priority));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.RemoveDisplayCallback(IntPtr displayHandle)
        {
            CheckAvailable();

            ChannelModule.ChannelRemoveDSPFunction.CheckResult(ChannelModule.ChannelRemoveDSPFunction.Delegate(Handle,
                displayHandle));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        IntPtr IChannelInternal.SetSyncCallback(SyncHandlerType type, UInt64 param, SyncHandler handler, IntPtr user)
        {
            CheckAvailable();

            return
                ChannelModule.ChannelSetSyncFunction.CheckResult(ChannelModule.ChannelSetSyncFunction.Delegate(Handle,
                    type, param, handler, user));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.RemoveSyncCallback(IntPtr syncHandle)
        {
            CheckAvailable();

            ChannelModule.ChannelRemoveSyncFunction.CheckResult(ChannelModule.ChannelRemoveSyncFunction.Delegate(
                Handle, syncHandle));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.SlideAttribute(ChannelAttribute attribute, float value, uint time)
        {
            CheckAvailable();

            ChannelModule.ChannelSlideAttributeFunction.CheckResult(ChannelModule.ChannelSlideAttributeFunction.Delegate(Handle, attribute, value, time));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        bool IChannelInternal.IsSliding(ChannelAttribute attribute)
        {
            CheckAvailable();

            return ChannelModule.ChannelIsSlidingFunction.CheckResult(ChannelModule.ChannelIsSlidingFunction.Delegate(Handle, attribute));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        void IChannelInternal.Update(int length)
        {
            CheckAvailable();

            ChannelModule.ChannelUpdateFunction.CheckResult(ChannelModule.ChannelUpdateFunction.Delegate(Handle, length));
        }

        /// <exception cref="ChannelNotAvailableException">Channel object is no longer available.</exception>
        /// <exception cref="BassErrorException">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        uint IChannelInternal.GetDate(IntPtr buffer, SampleDataType dataType)
        {
            CheckAvailable();

            return (uint)ChannelModule.ChannelGetDataFunction.CheckResult(ChannelModule.ChannelGetDataFunction.Delegate(Handle, buffer, dataType));
        }

        #endregion -- IChannelInternal --
    }
    
    public delegate void PlaybackingEventHandler(object sender, PlaybackingEventArgs args);

    /// <summary>
    /// Some infomation of playback, you can get sample data and change it.
    /// </summary>
    public class PlaybackingEventArgs : EventArgs
    {
        internal PlaybackingEventArgs(IntPtr buffer, uint length)
        {
            Buffer = buffer;
            Length = length;
        }

        /// <summary>
        /// Pointer to the sample data to apply the playback to. The data is as follows: 8-bit samples are unsigned, 16-bit samples are signed, 32-bit floating-point samples range from -1 to +1 (not clipped, so can actually be outside this range). 
        /// </summary>
        public IntPtr Buffer { get; }

        /// <summary>
        /// The number of bytes to process. 
        /// </summary>
        public uint Length { get; }
    }

    public delegate void PositionSetEventHandler(object sender, PositionSetEventArgs args);

    /// <summary>
    /// Some infomation of position set event.
    /// </summary>
    public class PositionSetEventArgs : EventArgs
    {
        internal PositionSetEventArgs( bool bufferFlushed)
        {
            BufferFlushed = bufferFlushed;
        }

        /// <summary>
        /// Playback buffer is flushed or not. 
        /// </summary>
        public bool BufferFlushed { get; }
    }

    public delegate void PropertyAnimationCompletedEventHandler(object sender, PropertyAnimationCompletedEventArgs args);

    /// <summary>
    /// Some infomation of property animation completed event.
    /// </summary>
    public class PropertyAnimationCompletedEventArgs : EventArgs
    {
        internal PropertyAnimationCompletedEventArgs(ChannelAttribute property)
        {
            Property = property;
        }

        /// <summary>
        /// The property that has finished animating. 
        /// </summary>
        public ChannelAttribute Property { get; }
    }

    public delegate void ChannelStatusChangedEventHandler(object sender, ChannelStatusChangedEventArgs args);

    /// <summary>
    /// Some infomation of channel status changed event.
    /// </summary>
    public class ChannelStatusChangedEventArgs : EventArgs
    {
        internal ChannelStatusChangedEventArgs(ChannelStatus status)
        {
            Status = status;
        }

        /// <summary>
        /// The new status of channel. 
        /// </summary>
        public ChannelStatus Status { get; }
    }
}