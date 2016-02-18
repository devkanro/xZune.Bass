// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: SampleChannel.cs
// Version: 20160218

using System;

namespace xZune.Bass
{
    /// <summary>
    ///     A playback channel of sample, many event is not available. It will auto free after stopped.
    /// </summary>
    public class SampleChannel : Channel
    {
        internal SampleChannel(IntPtr handle)
        {
            Handle = handle;
        }

        protected override void ReleaseManaged()
        {
        }

        protected override void ReleaseUnmanaged()
        {
        }

        protected override void Free()
        {
            // Sample playback channel will auto free after stopped.
        }

        protected override void AttachEvent()
        {
            // Disable the events, because a sample playback channel is not support events.
        }
    }
}