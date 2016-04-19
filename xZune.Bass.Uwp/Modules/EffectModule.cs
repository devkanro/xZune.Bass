// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: EffectModule.cs
// Version: 20160220

using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;

namespace xZune.Bass.Modules
{
    public class EffectModule : BassModule
    {
        internal static BassFunction<FXReset> FXResetFunction;
        internal static BassFunction<FXGetParameters> FXGetParametersFunction;
        internal static BassFunction<FXSetParameters> FXSetParametersFunction;

        static EffectModule()
        {
            Current = new EffectModule();
        }

        private EffectModule()
        {
        }

        public static EffectModule Current { get; }

        internal override void InitializeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            FXResetFunction = new BassFunction<FXReset>();
            FXGetParametersFunction = new BassFunction<FXGetParameters>();
            FXSetParametersFunction = new BassFunction<FXSetParameters>();

            ModuleAvailable = true;
        }

        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            FXResetFunction = null;
            FXGetParametersFunction = null;
            FXSetParametersFunction = null;

            ModuleAvailable = false;
        }
    }
}