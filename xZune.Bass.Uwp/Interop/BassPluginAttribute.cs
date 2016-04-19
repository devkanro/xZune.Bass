// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassPluginAttribute.cs
// Version: 20160221

using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Interop
{
    /// <summary>
    ///     A attribute class of Bass plug-in function information.
    /// </summary>
    public class BassPluginAttribute : BassAttribute
    {
        /// <summary>
        ///     Create a <see cref="BassPluginAttribute" /> with a plug-in type.
        /// </summary>
        /// <param name="plugin"></param>
        public BassPluginAttribute(BassPlugin plugin)
        {
            Plugin = plugin;
        }

        /// <summary>
        ///     Type of Bass plug-in.
        /// </summary>
        public BassPlugin Plugin { get; private set; }
    }
}