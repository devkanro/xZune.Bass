// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ISample.cs
// Version: 20160218

using xZune.Bass.Interop.Core;

namespace xZune.Bass
{
    /// <summary>
    ///     A audio sample.
    /// </summary>
    public interface ISample
    {
        SampleInfo Infomation { get; set; }

        byte[] Data { get; set; }

        void Stop();

        SampleChannel GetChannel(bool recycle);

        SampleChannel[] GetChannels();
    }
}