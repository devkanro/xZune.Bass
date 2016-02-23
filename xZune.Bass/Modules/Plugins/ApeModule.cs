// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ApeModule.cs
// Version: 20160223

using xZune.Bass.Interop;
using xZune.Bass.Interop.Ape;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Modules.Plugins
{
    public class ApeModule : BassModule
    {
        internal static BassFunction<ApeStreamCreateFile> ApeStreamCreateFileFunction;
        internal static BassFunction<ApeStreamCreateFileUser> ApeStreamCreateFileUserFunction;

        static ApeModule()
        {
            Current = new ApeModule();
            PluginManager.PluginLoaded += PluginManagerPluginLoaded;
            PluginManager.PluginFreed += PluginManagerPluginFreed;
        }

        private ApeModule()
        {
        }

        public static ApeModule Current { get; }

        private static void PluginManagerPluginFreed(PluginFreedEventArgs args)
        {
            if (args.Plugin == BassPlugin.BassApe)
            {
                Current.FreeModule();
            }
        }

        private static void PluginManagerPluginLoaded(PluginLoadedEventArgs args)
        {
            if (args.Plugin == BassPlugin.BassApe)
            {
                Current.InitializeModule();
            }
        }

        internal override void InitializeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            ApeStreamCreateFileFunction = new BassFunction<ApeStreamCreateFile>();
            ApeStreamCreateFileUserFunction = new BassFunction<ApeStreamCreateFileUser>();

            ModuleAvailable = true;
        }

        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            ApeStreamCreateFileFunction = null;
            ApeStreamCreateFileUserFunction = null;

            ModuleAvailable = false;
        }
    }
}