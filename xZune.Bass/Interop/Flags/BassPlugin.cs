﻿// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
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
        /// <summary>
        /// BassWma plug-in.
        /// </summary>
        BassWma,
        /// <summary>
        /// BassAac plug-in.
        /// </summary>
        BassAac,
        /// <summary>
        /// BassAlac plug-in.
        /// </summary>
        BassAlac,
        /// <summary>
        /// BassTta plug-in.
        /// </summary>
        BassTta,
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
                case BassPlugin.BassWma:
                    return "basswma.dll";
                case BassPlugin.BassAac:
                    return "bass_aac.dll";
                case BassPlugin.BassAlac:
                    return "bassalac.dll";
                case BassPlugin.BassTta:
                    return "bass_tta.dll";
                default:
                    return null;
            }
        }
    }
}