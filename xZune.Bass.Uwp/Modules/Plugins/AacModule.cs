// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: AacModule.cs
// Version: 20160316

using xZune.Bass.Interop;
using xZune.Bass.Interop.Aac;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Modules.Plugins
{
    public class AacModule : BassModule
    {
        internal static BassFunction<AacStreamCreateFile> AacStreamCreateFileFunction;
        internal static BassFunction<AacStreamCreateUrl> AacStreamCreateUrlFunction;
        internal static BassFunction<AacStreamCreateFileUser> AacStreamCreateFileUserFunction;
        internal static BassFunction<Mp4StreamCreateFile> Mp4StreamCreateFileFunction;
        internal static BassFunction<Mp4StreamCreateFileUser> Mp4StreamCreateFileUserFunction;

        static AacModule()
        {
            Current = new AacModule();
            PluginManager.PluginLoaded += OnPluginLoaded;
            PluginManager.PluginFreed += OnPluginFreed;
        }

        private AacModule()
        {
        }

        public static AacModule Current { get; }

        private static void OnPluginFreed(PluginEventArgs args)
        {
            if (args.Plugin == BassPlugin.BassAac)
            {
                Current.FreeModule();
            }
        }

        private static void OnPluginLoaded(PluginEventArgs args)
        {
            if (args.Plugin == BassPlugin.BassAac)
            {
                Current.InitializeModule();
            }
        }

        internal override void InitializeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            AacStreamCreateFileFunction = new BassFunction<AacStreamCreateFile>();
            AacStreamCreateUrlFunction = new BassFunction<AacStreamCreateUrl>();
            AacStreamCreateFileUserFunction = new BassFunction<AacStreamCreateFileUser>();
            Mp4StreamCreateFileFunction = new BassFunction<Mp4StreamCreateFile>();
            Mp4StreamCreateFileUserFunction = new BassFunction<Mp4StreamCreateFileUser>();

            ModuleAvailable = true;
        }

        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            AacStreamCreateFileFunction = null;
            AacStreamCreateFileUserFunction = null;
            AacStreamCreateFileUserFunction = null;
            Mp4StreamCreateFileFunction = null;
            Mp4StreamCreateFileUserFunction = null;

            ModuleAvailable = false;
        }
    }
}