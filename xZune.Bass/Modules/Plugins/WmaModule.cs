// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: WmaModule.cs
// Version: 20160313

using xZune.Bass.Interop;
using xZune.Bass.Interop.Flags;
using xZune.Bass.Interop.Wma;

namespace xZune.Bass.Modules.Plugins
{
    public class WmaModule : BassModule
    {
        internal static BassFunction<WmaStreamCreateFile> WmaStreamCreateFileFunction;
        internal static BassFunction<WmaStreamCreateFileAuth> WmaStreamCreateFileAuthFunction;
        internal static BassFunction<WmaStreamCreateFileUser> WmaStreamCreateFileUserFunction;

        static WmaModule()
        {
            Current = new WmaModule();
            PluginManager.PluginLoaded += OnPluginLoaded;
            PluginManager.PluginFreed += OnPluginFreed;
        }

        private WmaModule()
        {
        }

        public static WmaModule Current { get; }

        private static void OnPluginFreed(PluginEventArgs args)
        {
            if (args.Plugin == BassPlugin.BassWma)
            {
                Current.FreeModule();
            }
        }

        private static void OnPluginLoaded(PluginEventArgs args)
        {
            if (args.Plugin == BassPlugin.BassWma)
            {
                Current.InitializeModule();
            }
        }

        internal override void InitializeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            WmaStreamCreateFileFunction = new BassFunction<WmaStreamCreateFile>();
            WmaStreamCreateFileAuthFunction = new BassFunction<WmaStreamCreateFileAuth>();
            WmaStreamCreateFileUserFunction = new BassFunction<WmaStreamCreateFileUser>();

            ModuleAvailable = true;
        }

        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            WmaStreamCreateFileFunction = null;
            WmaStreamCreateFileUserFunction = null;

            ModuleAvailable = false;
        }
    }
}