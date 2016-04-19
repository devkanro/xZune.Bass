// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: RecordModule.cs
// Version: 20160218

using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;

namespace xZune.Bass.Modules
{
    public class RecordModule : BassModule
    {
        public static RecordModule Current { get; }

        static RecordModule()
        {
            Current = new RecordModule();
        }

        internal static BassFunction<RecordFree> RecordFreeFunction;
        internal static BassFunction<RecordGetDevice> RecordGetDeviceFunction;
        internal static BassFunction<RecordGetDeviceInfo> RecordGetDeviceInfoFunction;
        internal static BassFunction<RecordGetInfo> RecordGetInfoFunction;
        internal static BassFunction<RecordGetInput> RecordGetInputFunction;
        internal static BassFunction<RecordGetInputName> RecordGetInputNameFunction;
        internal static BassFunction<RecordInit> RecordInitFunction;
        internal static BassFunction<RecordSetDevice> RecordSetDeviceFunction;
        internal static BassFunction<RecordSetInput> RecordSetInputFunction;
        internal static BassFunction<RecordStart> RecordStartFunction;

        private RecordModule()
        {

        }

        internal override void InitializeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            RecordFreeFunction = new BassFunction<RecordFree>();
            RecordGetDeviceFunction = new BassFunction<RecordGetDevice>();
            RecordGetDeviceInfoFunction = new BassFunction<RecordGetDeviceInfo>();
            RecordGetInfoFunction = new BassFunction<RecordGetInfo>();
            RecordGetInputFunction = new BassFunction<RecordGetInput>();
            RecordGetInputNameFunction = new BassFunction<RecordGetInputName>();
            RecordInitFunction = new BassFunction<RecordInit>();
            RecordSetDeviceFunction = new BassFunction<RecordSetDevice>();
            RecordSetInputFunction = new BassFunction<RecordSetInput>();
            RecordStartFunction = new BassFunction<RecordStart>();

            ModuleAvailable = true;
        }

        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            RecordFreeFunction = null;
            RecordGetDeviceFunction = null;
            RecordGetDeviceInfoFunction = null;
            RecordGetInfoFunction = null;
            RecordGetInputFunction = null;
            RecordGetInputNameFunction = null;
            RecordInitFunction = null;
            RecordSetDeviceFunction = null;
            RecordSetInputFunction = null;
            RecordStartFunction = null;

            ModuleAvailable = false;
        }
    }
}