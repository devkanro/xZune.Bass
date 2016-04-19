// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: PluginManager.cs
// Version: 20160313

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass
{
    /// <summary>
    ///     Bass plug-in manager.
    /// </summary>
    public static class PluginManager
    {
        private static List<Plugin> _loadedPlugins = new List<Plugin>();

        /// <summary>
        ///     Get loaded plug-in list.
        /// </summary>
        public static ReadOnlyList<Plugin> LoadedPlugins => new ReadOnlyList<Plugin>(_loadedPlugins);

        /// <summary>
        ///     Get a bool value to check a plug-in is loaded or not.
        /// </summary>
        /// <param name="plugin">Plug-in type.</param>
        /// <returns>Plug-in is loaded or not.</returns>
        public static bool IsPluginLoaded(BassPlugin plugin)
        {
            return _loadedPlugins.Exists(p => p.PluginType == plugin);
        }

        /// <summary>
        ///     Load a bass plug-in, it will auto find plug-in DLL file.
        /// </summary>
        /// <param name="plugin">Plug-in type.</param>
        /// <returns>Bass plug-in object.</returns>
        public static Plugin LoadPlugin(BassPlugin plugin)
        {
            var files = Directory.GetFiles(BassManager.BassLibraryDirectory, plugin.GetPluginName());

            if (files.Length != 0)
            {
                return LoadPlugin(plugin, files[0]);
            }

            files = Directory.GetFiles(Directory.GetCurrentDirectory(), plugin.GetPluginName());

            if (files.Length != 0)
            {
                return LoadPlugin(plugin, files[0]);
            }

            throw new BassPluginNotFoundException(BassManager.BassLibraryDirectory, plugin);
        }

        /// <summary>
        ///     Load a bass plug-in with a DLL path or directory.
        /// </summary>
        /// <param name="plugin">Plug-in type.</param>
        /// <param name="path">Plug-in DLL path or directory.</param>
        /// <returns>Bass plug-in object.</returns>
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

        /// <summary>
        ///     Find a loaded plug-in, if it not loaded, null will be returned.
        /// </summary>
        /// <param name="plugin">Plug-in type.</param>
        /// <returns>Bass plug-in object.</returns>
        public static Plugin GetPlugin(BassPlugin plugin)
        {
            return _loadedPlugins.FirstOrDefault(p => p.PluginType == plugin);
        }

        /// <summary>
        ///     Free a Bass plug-in.
        /// </summary>
        /// <param name="plugin">Bass plug-in object.</param>
        public static void FreePlugin(BassPlugin plugin)
        {
            FreePlugin(GetPlugin(plugin));
        }

        /// <summary>
        ///     Free a Bass plug-in.
        /// </summary>
        /// <param name="plugin">Bass plug-in object.</param>
        public static void FreePlugin(Plugin plugin)
        {
            plugin?.Dispose();
        }

        internal static void AddPlugin(Plugin plugin)
        {
            _loadedPlugins.Add(plugin);
            PluginLoaded?.Invoke(new PluginEventArgs(plugin.PluginType));
        }

        internal static void RemovePlugin(Plugin plugin)
        {
            _loadedPlugins.Remove(plugin);
            PluginFreed?.Invoke(new PluginEventArgs(plugin.PluginType));
        }

        /// <summary>
        ///     Plug-in loaded event.
        /// </summary>
        public static event PluginEventHandler PluginLoaded;

        /// <summary>
        ///     Plug-in freed event.
        /// </summary>
        public static event PluginEventHandler PluginFreed;
    }

    public delegate void PluginEventHandler(PluginEventArgs args);

    public class PluginEventArgs : EventArgs
    {
        public PluginEventArgs(BassPlugin plugin)
        {
            Plugin = plugin;
        }

        public BassPlugin Plugin { get; private set; }
    }
}