// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: IChannel.cs
// Version: 20160312

using System;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Flags;
using ChannelFlags = xZune.Bass.Interop.Flags.ChannelFlags;

namespace xZune.Bass
{
    internal interface IChannelInternal
    {
        float GetAttribute(ChannelAttribute attribute);

        byte[] GetAttribute(ChannelAttributeEx attribute);

        void SetAttribute(ChannelAttribute attribute, float value);

        void SetAttribute(ChannelAttributeEx attribute, byte[] value);

        void SetLink(Channel channel);

        void RemoveLink(Channel channel);

        UInt64 GetPosition(PositionConfig config);

        void SetPosition(PositionConfig config, UInt64 value);

        UInt64 GetLength(PositionConfig config);

        object GetTag(TagType type);

        void SetConfig(ChannelFlags config, ChannelFlags mask);

        double Bytes2Seconds(UInt64 position);

        UInt64 Seconds2Bytes(double time);

        IntPtr SetDisplayCallback(DisplayHandler handler, IntPtr user, int priority);

        void RemoveDisplayCallback(IntPtr displayHandle);

        IntPtr SetSyncCallback(SyncHandlerType type, UInt64 param, SyncHandler handler, IntPtr user);

        void RemoveSyncCallback(IntPtr syncHandle);

        void SlideAttribute(ChannelAttribute attribute, float value, uint time);

        bool IsSliding(ChannelAttribute attribute);

        void Update(int length);
    }

    /// <summary>
    ///     A "channel" can be a sample playback channel (<see cref="ISampleChannel" />), a sample stream (
    ///     <see cref="IStream" />), a
    ///     MOD music (<see cref="IMusic" />), or a recording (<see cref="IRecord" />). Each "Channel" function can be used
    ///     with one or more of these channel types.
    /// </summary>
    public interface IChannel : IHandleObject
    {
        int Device { get; set; }

        ChannelInfo Infomation { get; }

        uint Level { get; }

        bool IsAvailable { get; }

        float CpuUsage { get; }

        float EaxMix { get; set; }

        float Freq { get; set; }

        bool IsBufferDisable { get; set; }

        float PanningPosition { get; set; }

        int SampleRateConversionQuality { get; set; }

        float Volume { get; set; }

        byte[] ScanInfo { get; set; }

        Channel LinkedChannel { get; set; }

        bool IsFreqAnimating { get; }

        bool IsPanningPositionAnimating { get; }

        bool IsVolumeAnimating { get; }

        ChannelStatus Status { get; }

        TimeSpan Time { get; set; }

        Double Position { get; set; }
        TimeSpan Length { get; }

        void SetVolumeAnimate(float value, uint time);

        void SetFreqAnimate(float value, uint time);

        void SetPanningPositionAnimate(float value, uint time);

        void Play();

        void Replay();

        void Pause();

        void Stop();

        void Lock();

        void Unlock();

        uint GetDate(IntPtr buffer, SampleDataType dataType);

        float[] GetLevelEx(LevelConfig config, float length);

        void Get3DAttribute(out Channel3DMode mode, out float min, out float max, out uint iAngle, out uint oAngle,
            out float outVloume);

        void Get3DPosition(out Vector3 pos, out Vector3 orientation, out Vector3 vel);

        void Set3DAttribute(Channel3DMode mode, float min, float max, uint iAngle, uint oAngle, float outVloume);

        void Set3DPosition(Vector3 pos, Vector3 orientation, Vector3 vel);

        event PlaybackingEventHandler Playbacking;

        event ChannelStatusChangedEventHandler StatusChanged;

        event PropertyAnimationCompletedEventHandler AnimationCompleted;

        event PositionSetEventHandler PositionSet;

        event EventHandler OggChanged;

        event EventHandler MetaTagAvailabled;

        event EventHandler Freed;

        event EventHandler Ended;

        event EventHandler PositionChanged;
    }
}