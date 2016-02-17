// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: AudioSampleModule.cs
// Version: 20160218

using System;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;

namespace xZune.Bass.Modules
{
    public class AudioSampleModule : BassModule
    {
        public static AudioSampleModule Current { get; }

        static AudioSampleModule()
        {
            Current = new AudioSampleModule();
        }

        internal static BassFunction<SampleCreate> SampleCreateFunction;
        internal static BassFunction<SampleFree> SampleFreeFunction;
        internal static BassFunction<SampleGetChannel> SampleGetChannelFunction;
        internal static BassFunction<SampleGetChannels> SampleGetChannelsFunction;
        internal static BassFunction<SampleGetData> SampleGetDataFunction;
        internal static BassFunction<SampleGetInfo> SampleGetInfoFunction;
        internal static BassFunction<SampleLoad> SampleLoadFunction;
        internal static BassFunction<SampleSetData> SampleSetDataFunction;
        internal static BassFunction<SampleSetInfo> SampleSetInfoFunction;
        internal static BassFunction<SampleStop> SampleStopFunction;

        private AudioSampleModule()
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

            SampleCreateFunction = new BassFunction<SampleCreate>();
            SampleFreeFunction = new BassFunction<SampleFree>();
            SampleGetChannelFunction = new BassFunction<SampleGetChannel>();
            SampleGetChannelsFunction = new BassFunction<SampleGetChannels>();
            SampleGetDataFunction = new BassFunction<SampleGetData>();
            SampleGetInfoFunction = new BassFunction<SampleGetInfo>();
            SampleLoadFunction = new BassFunction<SampleLoad>();
            SampleSetDataFunction = new BassFunction<SampleSetData>();
            SampleSetInfoFunction = new BassFunction<SampleSetInfo>();
            SampleStopFunction = new BassFunction<SampleStop>();

            ModuleAvailable = true;
        }

        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="BassManager.Initialize" /> to
        ///     load Bass DLL first.
        /// </exception>
        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            SampleCreateFunction = null;
            SampleFreeFunction = null;
            SampleGetChannelFunction = null;
            SampleGetChannelsFunction = null;
            SampleGetDataFunction = null;
            SampleGetInfoFunction = null;
            SampleLoadFunction = null;
            SampleSetDataFunction = null;
            SampleSetInfoFunction = null;
            SampleStopFunction = null;

            ModuleAvailable = false;
        }
    }
}