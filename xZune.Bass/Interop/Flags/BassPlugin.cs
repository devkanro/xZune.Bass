// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassPlugin.cs
// Version: 20160221

using System;

namespace xZune.Bass.Interop.Flags
{
    /// <summary>
    /// xZune.Bass support Bass plug-ins.
    /// </summary>
    public enum BassPlugin
    {
        /// <summary>
        /// BassFlac plug-in.
        /// </summary>
        BassFlac,
        /// <summary>
        /// BassApe plug-in.
        /// </summary>
        BassApe,
    }

    /// <summary>
    /// Some extension methods for <see cref="BassPlugin"/>.
    /// </summary>
    public static class BassPluginExtension
    {
        /// <summary>
        /// Get default name of plug-in file.
        /// </summary>
        /// <param name="plugin"></param>
        /// <returns></returns>
        public static String GetPluginName(this BassPlugin plugin)
        {
            switch (plugin)
            {
                case BassPlugin.BassFlac:
                    return "bassflac.dll";
                case BassPlugin.BassApe:
                    return "bass_ape.dll";
                default:
                    return null;
            }
        }
    }
}