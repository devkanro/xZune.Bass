// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassCoreModule.cs
// Version: 20160216

using System;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;

namespace xZune.Bass.Modules
{
    public class BassCoreModule : BassModule
    {
        public static BassCoreModule Current { get; }


        static BassCoreModule()
        {
            Current = new BassCoreModule();
        }

        internal static BassFunction<GetErrorCode> _getErrorCodeFunction;
        internal static BassFunction<Free> _freeFunction;
        internal static BassFunction<Initialize> _initializeFunction;
        internal static BassFunction<GetVersion> _getVersionFunction;
        internal static BassFunction<GetInfo> _getInfoFunction;
        internal static BassFunction<GetDeviceInfo> _getDeviceInfoFunction;
        internal static BassFunction<GetDevice> _getDeviceFunction;
        internal static BassFunction<GetCpuUsage> _getCpuUsageFunction;
        internal static BassFunction<GetDSoundObject> _getDSoundObjectFunction;
        internal static BassFunction<GetVolume> _getVolumeFunction;
        internal static BassFunction<Pause> _pauseFunction;
        internal static BassFunction<SetDevice> _setDeviceFunction;
        internal static BassFunction<SetVolume> _setVolumeFunction;
        internal static BassFunction<Start> _startFunction;
        internal static BassFunction<Stop> _stopFunction;
        internal static BassFunction<Update> _updateFunction;

        private BassCoreModule()
        {
            
        }

        /// <summary>
        ///     Get is this module is loaded and available.
        /// </summary>
        public bool ModuleAvailable { get; private set; }

        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use Bass to load Bass DLL
        ///     first.
        /// </exception>
        /// <exception cref="NoBassFunctionAttributeException">
        ///     Can't find <see cref="T:xZune.Bass.Interop.BassFunctionAttribute" />
        ///     in this Bass function.
        /// </exception>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded. </exception>
        /// <exception cref="FunctionNotFoundException">Can't find this function in Bass DLL.</exception>
        internal override void InitializeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            _getErrorCodeFunction = new BassFunction<GetErrorCode>();
            _freeFunction = new BassFunction<Free>();
            _initializeFunction = new BassFunction<Initialize>();
            _getVersionFunction = new BassFunction<GetVersion>();
            _getInfoFunction = new BassFunction<GetInfo>();
            _getDeviceInfoFunction = new BassFunction<GetDeviceInfo>();
            _getDeviceFunction = new BassFunction<GetDevice>();
            _getCpuUsageFunction = new BassFunction<GetCpuUsage>();
            _getDSoundObjectFunction = new BassFunction<GetDSoundObject>();
            _getVolumeFunction = new BassFunction<GetVolume>();
            _pauseFunction = new BassFunction<Pause>();
            _setDeviceFunction = new BassFunction<SetDevice>();
            _setVolumeFunction = new BassFunction<SetVolume>();
            _startFunction = new BassFunction<Start>();
            _stopFunction = new BassFunction<Stop>();
            _updateFunction = new BassFunction<Update>();

            ModuleAvailable = true;

            // Other module initialization.
            AudioStreamModule.Current.InitializeModule();
        }

        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use Bass to load Bass DLL
        ///     first.
        /// </exception>
        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            _getErrorCodeFunction = null;
            _freeFunction = null;
            _initializeFunction = null;
            _getVersionFunction = null;
            _getInfoFunction = null;
            _getDeviceInfoFunction = null;
            _getDeviceFunction = null;
            _getCpuUsageFunction = null;
            _getDSoundObjectFunction = null;
            _getVolumeFunction = null;
            _pauseFunction = null;
            _setDeviceFunction = null;
            _setVolumeFunction = null;
            _startFunction = null;
            _stopFunction = null;
            _updateFunction = null;

            ModuleAvailable = false;

            // Other module releasing.
            AudioStreamModule.Current.FreeModule();
        }
    }
}