// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: AlacModule.cs
// Version: 20160316

using xZune.Bass.Interop;
using xZune.Bass.Interop.Alac;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Modules.Plugins
{
    public class AlacModule : BassModule
    {
        internal static BassFunction<AlacStreamCreateFile> AlacStreamCreateFileFunction;
        internal static BassFunction<AlacStreamCreateFileUser> AlacStreamCreateFileUserFunction;
        internal static BassFunction<AlacStreamCreateUrl> AlacStreamCreateUrlFunction;

        static AlacModule()
        {
            Current = new AlacModule();
            PluginManager.PluginLoaded += OnPluginLoaded;
            PluginManager.PluginFreed += OnPluginFreed;
        }

        private AlacModule()
        {
        }

        public static AlacModule Current { get; }

        private static void OnPluginFreed(PluginEventArgs args)
        {
            if (args.Plugin == BassPlugin.BassAlac)
            {
                Current.FreeModule();
            }
        }

        private static void OnPluginLoaded(PluginEventArgs args)
        {
            if (args.Plugin == BassPlugin.BassAlac)
            {
                Current.InitializeModule();
            }
        }

        internal override void InitializeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            AlacStreamCreateFileFunction = new BassFunction<AlacStreamCreateFile>();
            AlacStreamCreateFileUserFunction = new BassFunction<AlacStreamCreateFileUser>();
            AlacStreamCreateUrlFunction = new BassFunction<AlacStreamCreateUrl>();

            ModuleAvailable = true;
        }

        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            AlacStreamCreateFileFunction = null;
            AlacStreamCreateFileUserFunction = null;
            AlacStreamCreateUrlFunction = null;

            ModuleAvailable = false;
        }
    }
}