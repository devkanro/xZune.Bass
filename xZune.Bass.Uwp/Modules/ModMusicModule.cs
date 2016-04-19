// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ModMusicModule.cs
// Version: 20160218

using System;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;

namespace xZune.Bass.Modules
{
    public class ModMusicModule : BassModule
    {
        public static ModMusicModule Current { get; }

        static ModMusicModule()
        {
            Current = new ModMusicModule();
        }

        internal static BassFunction<MusicLoad> MusicLoadFunction;
        internal static BassFunction<MusicFree> MusicFreeFunction;

        private ModMusicModule()
        {

        }

        /// <exception cref="NoBassFunctionAttributeException">
        ///     Can't find <see cref="T:xZune.Bass.Interop.BassFunctionAttribute" />
        ///     in this Bass function.
        /// </exception>
        /// <exception cref="FunctionNotFoundException">Can't find this function in Bass DLL.</exception>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded. </exception>
        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="BassManager.Initialize" /> to
        ///     load Bass DLL first.
        /// </exception>
        internal override void InitializeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            MusicLoadFunction = new BassFunction<MusicLoad>();
            MusicFreeFunction = new BassFunction<MusicFree>();

            ModuleAvailable = true;
        }

        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="BassManager.Initialize" /> to
        ///     load Bass DLL first.
        /// </exception>
        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            MusicLoadFunction = null;
            MusicFreeFunction = null;

            ModuleAvailable = false;
        }
    }
}