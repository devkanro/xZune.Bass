// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassModule.cs
// Version: 20160216

namespace xZune.Bass.Modules
{
    public abstract class BassModule
    {
        /// <summary>
        ///     Get is this module is loaded and available.
        /// </summary>
        public bool ModuleAvailable { get; protected set; }


        internal abstract void InitializeModule();


        internal abstract void FreeModule();
    }
}