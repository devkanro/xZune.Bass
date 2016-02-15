// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: PluginLoadConfig.cs
// Version: 20160215

namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    ///     Some configure used in <see cref="PluginLoad" />.
    /// </summary>
    public enum PluginLoadConfig : uint
    {
        /// <summary>
        ///     None.
        /// </summary>
        None = Internal.BassConfig.None,

        /// <summary>
        ///     file is in UTF-16 form. Otherwise it is ANSI on Windows or Windows CE, and UTF-8 on other platforms.
        /// </summary>
        Unicode = Internal.BassConfig.Unicode
    }
}