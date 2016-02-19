// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: IFileStream.cs
// Version: 20160216

namespace xZune.Bass
{
    public interface IFileStream : IStream
    {

    }

    public interface INetworkStream : IStream
    {
        float BufferLevel { get; set; }
    }
}