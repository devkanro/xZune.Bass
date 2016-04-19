// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: AudioStreamModule.cs
// Version: 20160216

using System;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;

namespace xZune.Bass.Modules
{
    public class AudioStreamModule : BassModule
    {
        public static AudioStreamModule Current { get; }

        static AudioStreamModule()
        {
            Current = new AudioStreamModule();
        }

        internal static BassFunction<StreamCreate> StreamCreateFunction;
        internal static BassFunction<StreamCreateFile> StreamCreateFileFunction;
        internal static BassFunction<StreamCreateFileUser> StreamCreateFileUserFunction;
        internal static BassFunction<StreamCreateUrl> StreamCreateUrlFunction;
        internal static BassFunction<StreamFree> StreamFreeFunction;
        internal static BassFunction<StreamGetFilePosition> StreamGetFilePositionFunction;
        internal static BassFunction<StreamPutData> StreamPutDataFunction;
        internal static BassFunction<StreamPutFileData> StreamPutFileDataFunction;

        private AudioStreamModule()
        {

        }
        
        /// <exception cref="NoBassFunctionAttributeException">
        ///     Can't find <see cref="T:xZune.Bass.Interop.BassFunctionAttribute" />
        ///     in this Bass function.
        /// </exception>
        /// <exception cref="FunctionNotFoundException">Can't find this function in Bass DLL.</exception>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded. </exception>
        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="!:BassManager.Initialize" /> to
        ///     load Bass DLL first.
        /// </exception>
        internal override void InitializeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            StreamCreateFunction = new BassFunction<StreamCreate>();
            StreamCreateFileFunction = new BassFunction<StreamCreateFile>();
            StreamCreateFileUserFunction = new BassFunction<StreamCreateFileUser>();
            StreamCreateUrlFunction = new BassFunction<StreamCreateUrl>();
            StreamFreeFunction = new BassFunction<StreamFree>();
            StreamGetFilePositionFunction = new BassFunction<StreamGetFilePosition>();
            StreamPutDataFunction = new BassFunction<StreamPutData>();
            StreamPutFileDataFunction = new BassFunction<StreamPutFileData>();

            ModuleAvailable = true;
        }

        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use Bass to load Bass DLL
        ///     first.
        /// </exception>
        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            StreamCreateFunction = null;
            StreamCreateFileFunction = null;
            StreamCreateFileUserFunction = null;
            StreamCreateUrlFunction = null;
            StreamFreeFunction = null;
            StreamGetFilePositionFunction = null;
            StreamPutDataFunction = null;
            StreamPutFileDataFunction = null;

            ModuleAvailable = false;
        }
    }
}