// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: SyncHandlerType.cs
// Version: 20160216

using System;

namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    ///     Type of sync handler.
    /// </summary>
    [Flags]
    public enum SyncHandlerType : uint
    {
        /// <summary>
        ///     Sync when a channel reaches a position.
        ///     <para />
        ///     param : position in bytes (automatically rounded down to nearest sample). data : not used.
        /// </summary>
        Pos = Internal.SyncHandlerType.Pos,

        /// <summary>
        ///     Sync when a channel reaches the end, including when looping. Note that some MOD musics never reach the end; they
        ///     may jump to another position first. If the BASS_MUSIC_STOPBACK flag is used with a MOD music (through
        ///     BASS_MusicLoad or BASS_ChannelFlags), then this sync will also be called when a backward jump effect is played.
        ///     <para />
        ///     param : not used. data : 1 = the sync is triggered by a backward jump in a MOD music, otherwise not used.
        /// </summary>
        End = Internal.SyncHandlerType.End,

        /// <summary>
        ///     [mixtime only] Sync when metadata is received in a Shoutcast stream. The updated metadata is available from
        ///     BASS_ChannelGetTags.
        ///     <para />
        ///     param : not used. data : not used.
        /// </summary>
        Meta = Internal.SyncHandlerType.Meta,

        /// <summary>
        ///     [mixtime only] Sync when an attribute slide has ended.
        ///     <para />
        ///     param : not used. data : the attribute that has finished sliding.
        /// </summary>
        Slide = Internal.SyncHandlerType.Slide,

        /// <summary>
        ///     [mixtime only] Sync when playback of the channel is stalled/resumed.
        ///     <para />
        ///     param : not used. data : 0 = stalled, 1 = resumed.
        /// </summary>
        Stall = Internal.SyncHandlerType.Stall,

        /// <summary>
        ///     [mixtime only] Sync when downloading of an internet (or "buffered" user file) stream is done.
        ///     <para />
        ///     param : not used. data : not used.
        /// </summary>
        Download = Internal.SyncHandlerType.Download,

        /// <summary>
        ///     [mixtime only] Sync when a channel is freed. This can be useful when you need to release some resources associated
        ///     with the channel. Note that you will not be able to use any BASS functions with the channel in the callback, as the
        ///     channel will no longer exist.
        ///     <para />
        ///     param : not used. data : not used.
        /// </summary>
        Free = Internal.SyncHandlerType.Free,

        /// <summary>
        ///     Sync when a channel's position is set, including when looping/restarting.
        ///     <para />
        ///     param : not used. data : 0 = playback buffer is not flushed, 1 = playback buffer is flushed.
        /// </summary>
        Setpos = Internal.SyncHandlerType.Setpos,

        /// <summary>
        ///     Sync when a MOD music reaches an order.row position.
        ///     <para />
        ///     param : LOWORD = order (0=first, -1=all), HIWORD = row (0=first, -1=all). data : LOWORD = order, HIWORD = row.
        /// </summary>
        MusicPos = Internal.SyncHandlerType.MusicPos,

        /// <summary>
        ///     Sync when an instrument (sample for the MOD/S3M/MTM formats) is played in a MOD music (not including retrigs).
        ///     <para />
        ///     param : LOWORD = instrument (1=first), HIWORD = note (0=c0...119=b9, -1=all). data : LOWORD = note, HIWORD = volume
        ///     (0-64).
        /// </summary>
        MusicInst = Internal.SyncHandlerType.MusicInst,

        /// <summary>
        ///     Sync when the sync effect is used in a MOD music. The sync effect is E8x or Wxx for the XM/MTM/MOD formats, and S2x
        ///     for the IT/S3M formats (where x = any value).
        ///     <para />
        ///     param : 0 = the position is passed to the callback (data : LOWORD = order, HIWORD = row), 1 = the value of x is
        ///     passed to the callback (data : x value).
        /// </summary>
        MusicFx = Internal.SyncHandlerType.MusicFx,

        /// <summary>
        ///     Sync when a new logical bit-stream begins in a chained OGG stream. Updated tags are available from
        ///     <see cref="ChannelGetTags" />.
        ///     <para />
        ///     param : not used. data : not used.
        /// </summary>
        OggChange = Internal.SyncHandlerType.OggChange,

        /// <summary>
        ///     Call the sync function immediately when the sync is triggered, instead of delaying the call until the sync event is
        ///     actually heard. This is automatic with some sync types (see table below), and always with decoding and recording
        ///     channels, as they cannot be played/heard.
        /// </summary>
        Mixtime = Internal.SyncHandlerType.Mixtime,

        /// <summary>
        ///     Call the sync only once, and then remove it from the channel.
        /// </summary>
        Onetime = Internal.SyncHandlerType.Onetime
    }
}