// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: NetworkPlaylistConfig.cs
// Version: 20160219
namespace xZune.Bass.Interop.Flags
{
    public enum NetworkPlaylistConfig
    {
        /// <summary>
        /// Never use playlist.
        /// </summary>
        Off,
        /// <summary>
        /// Use playlist in <see cref="AudioNetworkStream"/>.
        /// </summary>
        NetworkOnly,
        /// <summary>
        /// Use playlist in <see cref="AudioNetworkStream"/> and <see cref="AudioFileStream"/>.
        /// </summary>
        All
    }
}