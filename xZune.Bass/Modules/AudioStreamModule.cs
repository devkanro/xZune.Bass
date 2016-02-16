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

        internal static BassFunction<StreamCreate> _streamCreateFunction;
        internal static BassFunction<StreamCreateFile> _streamCreateFileFunction;
        internal static BassFunction<StreamCreateFileUser> _streamCreateFileUserFunction;
        internal static BassFunction<StreamCreateUrl> _streamCreateUrlFunction;
        internal static BassFunction<StreamFree> _streamFreeFunction;
        internal static BassFunction<StreamGetFilePosition> _streamGetFilePositionFunction;
        internal static BassFunction<StreamPutData> _streamPutDataFunction;
        internal static BassFunction<StreamPutFileData> _streamPutFileDataFunction;

        private AudioStreamModule()
        {

        }

        /// <summary>
        ///     Get is this module is loaded and available.
        /// </summary>
        public bool ModuleAvailable { get; private set; }

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

            _streamCreateFunction = new BassFunction<StreamCreate>();
            _streamCreateFileFunction = new BassFunction<StreamCreateFile>();
            _streamCreateFileUserFunction = new BassFunction<StreamCreateFileUser>();
            _streamCreateUrlFunction = new BassFunction<StreamCreateUrl>();
            _streamFreeFunction = new BassFunction<StreamFree>();
            _streamGetFilePositionFunction = new BassFunction<StreamGetFilePosition>();
            _streamPutDataFunction = new BassFunction<StreamPutData>();
            _streamPutFileDataFunction = new BassFunction<StreamPutFileData>();

            ModuleAvailable = true;
        }

        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use Bass to load Bass DLL
        ///     first.
        /// </exception>
        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            _streamCreateFunction = null;
            _streamCreateFileFunction = null;
            _streamCreateFileUserFunction = null;
            _streamCreateUrlFunction = null;
            _streamFreeFunction = null;
            _streamGetFilePositionFunction = null;
            _streamPutDataFunction = null;
            _streamPutFileDataFunction = null;

            ModuleAvailable = false;
        }
    }
}