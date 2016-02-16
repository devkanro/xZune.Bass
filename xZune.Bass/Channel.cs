// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Channel.cs
// Version: 20160216

namespace xZune.Bass
{
    public abstract class Channel : HandleObject, IChannel
    {
        protected Channel()
        {
            IsAvailable = true;
        }

        public abstract void Free();

        public bool IsAvailable { get; protected set; }
    }
}