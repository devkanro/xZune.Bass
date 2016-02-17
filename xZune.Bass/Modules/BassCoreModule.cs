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

        internal static BassFunction<GetErrorCode> GetErrorCodeFunction;
        internal static BassFunction<Free> FreeFunction;
        internal static BassFunction<Initialize> InitializeFunction;
        internal static BassFunction<GetVersion> GetVersionFunction;
        internal static BassFunction<GetInfo> GetInfoFunction;
        internal static BassFunction<GetDeviceInfo> GetDeviceInfoFunction;
        internal static BassFunction<GetDevice> GetDeviceFunction;
        internal static BassFunction<GetCpuUsage> GetCpuUsageFunction;
        internal static BassFunction<GetDSoundObject> GetDSoundObjectFunction;
        internal static BassFunction<GetVolume> GetVolumeFunction;
        internal static BassFunction<Pause> PauseFunction;
        internal static BassFunction<SetDevice> SetDeviceFunction;
        internal static BassFunction<SetVolume> SetVolumeFunction;
        internal static BassFunction<Start> StartFunction;
        internal static BassFunction<Stop> StopFunction;
        internal static BassFunction<Update> UpdateFunction;

        private BassCoreModule()
        {
            
        }

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

            GetErrorCodeFunction = new BassFunction<GetErrorCode>();
            FreeFunction = new BassFunction<Free>();
            InitializeFunction = new BassFunction<Initialize>();
            GetVersionFunction = new BassFunction<GetVersion>();
            GetInfoFunction = new BassFunction<GetInfo>();
            GetDeviceInfoFunction = new BassFunction<GetDeviceInfo>();
            GetDeviceFunction = new BassFunction<GetDevice>();
            GetCpuUsageFunction = new BassFunction<GetCpuUsage>();
            GetDSoundObjectFunction = new BassFunction<GetDSoundObject>();
            GetVolumeFunction = new BassFunction<GetVolume>();
            PauseFunction = new BassFunction<Pause>();
            SetDeviceFunction = new BassFunction<SetDevice>();
            SetVolumeFunction = new BassFunction<SetVolume>();
            StartFunction = new BassFunction<Start>();
            StopFunction = new BassFunction<Stop>();
            UpdateFunction = new BassFunction<Update>();

            ModuleAvailable = true;

            // Other module initialization.
            ChannelModule.Current.InitializeModule();
            AudioStreamModule.Current.InitializeModule();
        }

        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use Bass to load Bass DLL
        ///     first.
        /// </exception>
        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            GetErrorCodeFunction = null;
            FreeFunction = null;
            InitializeFunction = null;
            GetVersionFunction = null;
            GetInfoFunction = null;
            GetDeviceInfoFunction = null;
            GetDeviceFunction = null;
            GetCpuUsageFunction = null;
            GetDSoundObjectFunction = null;
            GetVolumeFunction = null;
            PauseFunction = null;
            SetDeviceFunction = null;
            SetVolumeFunction = null;
            StartFunction = null;
            StopFunction = null;
            UpdateFunction = null;

            ModuleAvailable = false;

            // Other module releasing.
            ChannelModule.Current.FreeModule();
            AudioStreamModule.Current.FreeModule();
        }
    }
}