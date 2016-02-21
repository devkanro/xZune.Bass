// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: PluginManager.cs
// Version: 20160221

using System;
using System.Collections.Generic;
using System.IO;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass
{
    /// <summary>
    ///     Bass plug-in manager.
    /// </summary>
    public static class PluginManager
    {
        public static Plugin LoadPlugin(BassPlugin plugin)
        {
            var files = Directory.GetFiles(BassManager.BassLibraryDirectory, plugin.GetPluginName());

            if (files.Length != 0)
            {
                return LoadPlugin(plugin, files[0]);
            }

            files = Directory.GetFiles(Directory.GetCurrentDirectory(), plugin.GetPluginName());

            if(files.Length != 0)
            {
                return LoadPlugin(plugin, files[0]);
            }

            throw new BassPluginNotFoundException(BassManager.BassLibraryDirectory, plugin);
        }

        public static Plugin LoadPlugin(BassPlugin plugin, string path)
        {
            if (File.Exists(path))
            {
                return new Plugin(path, plugin);
            }

            if (Directory.Exists(path))
            {
                var files = Directory.GetFiles(path, plugin.GetPluginName());

                if (files.Length != 0)
                {
                    return new Plugin(files[0], plugin);
                }
            }

            throw new BassPluginNotFoundException(BassManager.BassLibraryDirectory, plugin);
        }

        public static void FreePlugin(Plugin plugin)
        {
            plugin.Dispose();
        }

        private static List<Plugin> _loadedPlugins = new List<Plugin>();

        internal static void AddPlugin(Plugin plugin)
        {
            _loadedPlugins.Add(plugin);
            PluginLoaded?.Invoke(new PluginLoadedEventArgs(plugin.PluginType));
        }

        internal static void RemovePlugin(Plugin plugin)
        {
            _loadedPlugins.Remove(plugin);
            PluginFreed?.Invoke(new PluginFreedEventArgs(plugin.PluginType));
        }

        /// <summary>
        /// Get loaded plug-in list.
        /// </summary>
        public static ReadOnlyList<Plugin> LoadedPlugins => new ReadOnlyList<Plugin>(_loadedPlugins);

        public static event PluginLoadedEventHandler PluginLoaded;

        public static event PluginFreedEventHandler PluginFreed;
    }

    public delegate void PluginLoadedEventHandler(PluginLoadedEventArgs args);

    public class PluginLoadedEventArgs : EventArgs
    {
        public PluginLoadedEventArgs(BassPlugin plugin)
        {
            Plugin = plugin;
        }

        public BassPlugin Plugin { get; private set; }
    }

    public delegate void PluginFreedEventHandler(PluginFreedEventArgs args);

    public class PluginFreedEventArgs : EventArgs
    {
        public PluginFreedEventArgs(BassPlugin plugin)
        {
            Plugin = plugin;
        }

        public BassPlugin Plugin { get; private set; }
    }
}