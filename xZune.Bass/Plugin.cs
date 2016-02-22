// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Plugin.cs
// Version: 20160221

using System;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Flags;
using xZune.Bass.Modules;

namespace xZune.Bass
{
    /// <summary>
    /// A plug-in.
    /// </summary>
    public class Plugin : HandleObject
    {
        internal Plugin(String pluginPath, BassPlugin plugin)
        {
            using (AutoFreeGCHandle pathHandle = InteropHelper.StringToPtr(pluginPath))
            {
                Handle = PluginModule.PluginLoadFunction.CheckResult(PluginModule.PluginLoadFunction.Delegate(pathHandle.Handle, PluginLoadConfig.Unicode));
                PluginPath = pluginPath;
                PluginType = plugin;
                IsAvailable = true;
                PluginManager.AddPlugin(this);
            }
        }
        
        public String PluginPath { get; private set; }
        public BassPlugin PluginType { get; private set; }

        protected override void ReleaseManaged()
        {

        }

        protected override void ReleaseUnmanaged()
        {
            PluginManager.RemovePlugin(this);
            PluginModule.PluginFreeFunction.CheckResult(PluginModule.PluginFreeFunction.Delegate(Handle));
            Handle = IntPtr.Zero;
            IsAvailable = false;
        }
    }
}