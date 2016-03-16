// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: TagsLibModule.cs
// Version: 20160317
namespace xZune.Bass.Tag.Modules
{
    public abstract class TagsLibModule
    {
        /// <summary>
        ///     Get is this module is loaded and available.
        /// </summary>
        public bool ModuleAvailable { get; protected set; }


        internal abstract void InitializeModule();


        internal abstract void FreeModule();
    }
}