// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassCoreModule.cs
// Version: 20160216

using System;
using System.Linq;
using System.Reflection;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;
using xZune.Bass.Modules.Plugins;

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
        internal static BassFunction<GetConfig> GetConfigFunction;
        internal static BassFunction<GetConfigPtr> GetConfigPtrFunction;
        internal static BassFunction<SetConfig> SetConfigFunction;
        internal static BassFunction<SetConfigPtr> SetConfigPtrFunction;
        internal static BassFunction<Apply3D> Apply3DFunction;
        internal static BassFunction<Get3DFactors> Get3DFactorsFunction;
        internal static BassFunction<Get3DPosition> Get3DPositionFunction;
        internal static BassFunction<Set3DFactors> Set3DFactorsFunction;
        internal static BassFunction<Set3DPosition> Set3DPositionFunction;
        internal static BassFunction<GetEaxParameters> GetEaxParametersFunction;
        internal static BassFunction<SetEaxParameters> SetEaxParametersFunction;


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
            GetConfigFunction = new BassFunction<GetConfig>();
            GetConfigPtrFunction = new BassFunction<GetConfigPtr>();
            SetConfigFunction = new BassFunction<SetConfig>();
            SetConfigPtrFunction = new BassFunction<SetConfigPtr>();
            Apply3DFunction = new BassFunction<Apply3D>();
            Get3DFactorsFunction = new BassFunction<Get3DFactors>();
            Get3DPositionFunction = new BassFunction<Get3DPosition>();
            Set3DFactorsFunction = new BassFunction<Set3DFactors>();
            Set3DPositionFunction = new BassFunction<Set3DPosition>();
            GetEaxParametersFunction = new BassFunction<GetEaxParameters>();
            SetEaxParametersFunction = new BassFunction<SetEaxParameters>();

            ModuleAvailable = true;
            
            ChannelModule.Current.InitializeModule();
            AudioStreamModule.Current.InitializeModule();
            AudioSampleModule.Current.InitializeModule();
            ModMusicModule.Current.InitializeModule();
            RecordModule.Current.InitializeModule();
            EffectModule.Current.InitializeModule();
            PluginModule.Current.InitializeModule();

            BassModule plugin = null;
            plugin = FlacModule.Current;
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
            GetConfigFunction = null;
            GetConfigPtrFunction = null;
            SetConfigFunction = null;
            SetConfigPtrFunction = null;
            Apply3DFunction = null;
            Get3DFactorsFunction = null;
            Get3DPositionFunction = null;
            Set3DFactorsFunction = null;
            Set3DPositionFunction = null;
            GetEaxParametersFunction = null;
            SetEaxParametersFunction = null;

            ModuleAvailable = false;

            // Other module releasing.
            ChannelModule.Current.FreeModule();
            AudioStreamModule.Current.FreeModule();
            AudioSampleModule.Current.FreeModule();
            ModMusicModule.Current.FreeModule();
            RecordModule.Current.FreeModule();
            EffectModule.Current.FreeModule();
            PluginModule.Current.FreeModule();
        }
    }
}