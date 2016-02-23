// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: FlacModule.cs
// Version: 20160221

using xZune.Bass.Interop;
using xZune.Bass.Interop.Flac;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Modules.Plugins
{
    public class FlacModule : BassModule
    {
        internal static BassFunction<FlacStreamCreateFile> FlacStreamCreateFileFunction;
        internal static BassFunction<FlacStreamCreateFileUser> FlacStreamCreateFileUserFunction;
        internal static BassFunction<FlacStreamCreateUrl> FlacStreamCreateUrlFunction;

        static FlacModule()
        {
            Current = new FlacModule();
            PluginManager.PluginLoaded += PluginManagerPluginLoaded;
            PluginManager.PluginFreed += PluginManagerPluginFreed;
        }

        private FlacModule()
        {
        }

        public static FlacModule Current { get; }

        private static void PluginManagerPluginFreed(PluginFreedEventArgs args)
        {
            if (args.Plugin == BassPlugin.BassFlac)
            {
                Current.FreeModule();
            }
        }

        private static void PluginManagerPluginLoaded(PluginLoadedEventArgs args)
        {
            if (args.Plugin == BassPlugin.BassFlac)
            {
                Current.InitializeModule();
            }
        }

        internal override void InitializeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            FlacStreamCreateFileFunction = new BassFunction<FlacStreamCreateFile>();
            FlacStreamCreateFileUserFunction = new BassFunction<FlacStreamCreateFileUser>();
            FlacStreamCreateUrlFunction = new BassFunction<FlacStreamCreateUrl>();

            ModuleAvailable = true;
        }

        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            FlacStreamCreateFileFunction = null;
            FlacStreamCreateFileUserFunction = null;
            FlacStreamCreateUrlFunction = null;

            ModuleAvailable = false;
        }
    }
}