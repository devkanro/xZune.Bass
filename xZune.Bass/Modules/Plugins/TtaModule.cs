// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TtaModule.cs
// Version: 20160316

using xZune.Bass.Interop;
using xZune.Bass.Interop.Flags;
using xZune.Bass.Interop.Tta;

namespace xZune.Bass.Modules.Plugins
{
    public class TtaModule : BassModule
    {
        internal static BassFunction<TtaStreamCreateFile> TtaStreamCreateFileFunction;
        internal static BassFunction<TtaStreamCreateFileUser> TtaStreamCreateFileUserFunction;

        static TtaModule()
        {
            Current = new TtaModule();
            PluginManager.PluginLoaded += OnPluginLoaded;
            PluginManager.PluginFreed += OnPluginFreed;
        }

        private TtaModule()
        {
        }

        public static TtaModule Current { get; }

        private static void OnPluginFreed(PluginEventArgs args)
        {
            if (args.Plugin == BassPlugin.BassTta)
            {
                Current.FreeModule();
            }
        }

        private static void OnPluginLoaded(PluginEventArgs args)
        {
            if (args.Plugin == BassPlugin.BassTta)
            {
                Current.InitializeModule();
            }
        }

        internal override void InitializeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            TtaStreamCreateFileFunction = new BassFunction<TtaStreamCreateFile>();
            TtaStreamCreateFileUserFunction = new BassFunction<TtaStreamCreateFileUser>();

            ModuleAvailable = true;
        }

        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            TtaStreamCreateFileFunction = null;
            TtaStreamCreateFileUserFunction = null;

            ModuleAvailable = false;
        }
    }
}