// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: DSoundObjectType.cs
// Version: 20160215

using xZune.Bass.Interop.Core;

namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    ///     Some DSoundObject type enum used in <see cref="GetDSoundObject" />.
    /// </summary>
    public enum DSoundObjectType
    {
        /// <summary>
        ///     Retrieve the IDirectSound interface.
        /// </summary>
        DirectSound = Internal.DSoundObjectType.DirectSound,

        /// <summary>
        ///     Retrieve the IDirectSound3DListener interface.
        /// </summary>
        DirectSound3DListener = Internal.DSoundObjectType.DirectSound3DListener
    }
}