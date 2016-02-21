// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: PluginModule.cs
// Version: 20160221

using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;

namespace xZune.Bass.Modules
{
    public class PluginModule : BassModule
    {
        internal static BassFunction<PluginFree> PluginFreeFunction;
        internal static BassFunction<PluginLoad> PluginLoadFunction;
        internal static BassFunction<PluginGetInfo> PluginGetInfoFunction;

        static PluginModule()
        {
            Current = new PluginModule();
        }

        private PluginModule()
        {
        }

        public static PluginModule Current { get; }

        internal override void InitializeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            PluginFreeFunction = new BassFunction<PluginFree>();
            PluginLoadFunction = new BassFunction<PluginLoad>();
            PluginGetInfoFunction = new BassFunction<PluginGetInfo>();

            ModuleAvailable = true;
        }

        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            PluginFreeFunction = null;
            PluginLoadFunction = null;
            PluginGetInfoFunction = null;

            ModuleAvailable = false;
        }
    }
}