// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: ChannelModule.cs
// Version: 20160217

using System;
using System.Runtime.Remoting.Messaging;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;

namespace xZune.Bass.Modules
{
    public class ChannelModule : BassModule
    {
        public static ChannelModule Current { get; }

        static ChannelModule()
        {
            Current = new ChannelModule();
        }

        private ChannelModule()
        {

        }

        internal static BassFunction<ChannelBytes2Seconds> ChannelBytes2SecondsFunction;
        internal static BassFunction<ChannelFlags> ChannelFlagsFunction;
        internal static BassFunction<ChannelGet3DAttributes> ChannelGet3DAttributesFunction;
        internal static BassFunction<ChannelGetAttribute> ChannelGetAttributeFunction;
        internal static BassFunction<ChannelGetAttributeEx> ChannelGetAttributeExFunction;
        internal static BassFunction<ChannelGetData> ChannelGetDataFunction;
        internal static BassFunction<ChannelGetDevice> ChannelGetDeviceFunction;
        internal static BassFunction<ChannelGetInfo> ChannelGetInfoFunction;
        internal static BassFunction<ChannelGetLength> ChannelGetLengthFunction;
        internal static BassFunction<ChannelGetLevel> ChannelGetLevelFunction;
        internal static BassFunction<ChannelGetLevelEx> ChannelGetLevelExFunction;
        internal static BassFunction<ChannelGetPosition> ChannelGetPositionFunction;
        internal static BassFunction<ChannelGetTags> ChannelGetTagsFunction;
        internal static BassFunction<ChannelIsActive> ChannelIsActiveFunction;
        internal static BassFunction<ChannelIsSliding> ChannelIsSlidingFunction;
        internal static BassFunction<ChannelLock> ChannelLockFunction;
        internal static BassFunction<ChannelPause> ChannelPauseFunction;
        internal static BassFunction<ChannelPlay> ChannelPlayFunction;
        internal static BassFunction<ChannelRemoveDSP> ChannelRemoveDSPFunction;
        internal static BassFunction<ChannelRemoveFX> ChannelRemoveFXFunction;
        internal static BassFunction<ChannelRemoveLink> ChannelRemoveLinkFunction;
        internal static BassFunction<ChannelRemoveSync> ChannelRemoveSyncFunction;
        internal static BassFunction<ChannelSeconds2Bytes> ChannelSeconds2BytesFunction;
        internal static BassFunction<ChannelSet3DAttributes> ChannelSet3DAttributesFunction;
        internal static BassFunction<ChannelSetAttribute> ChannelSetAttributeFunction;
        internal static BassFunction<ChannelSetAttributeEx> ChannelSetAttributeExFunction;
        internal static BassFunction<ChannelSetDevice> ChannelSetDeviceFunction;
        internal static BassFunction<ChannelSetDSP> ChannelSetDSPFunction;
        internal static BassFunction<ChannelSetFX> ChannelSetFXFunction;
        internal static BassFunction<ChannelSetLink> ChannelSetLinkFunction;
        internal static BassFunction<ChannelSetPosition> ChannelSetPositionFunction;
        internal static BassFunction<ChannelSetSync> ChannelSetSyncFunction;
        internal static BassFunction<ChannelStop> ChannelStopFunction;
        internal static BassFunction<ChannelUpdate> ChannelUpdateFunction;
        internal static BassFunction<ChannelSlideAttribute> ChannelSlideAttributeFunction;
        internal static BassFunction<ChannelGet3DPosition> ChannelGet3DPositionFunction;
        internal static BassFunction<ChannelSet3DPosition> ChannelSet3DPositionFunction;



        /// <exception cref="NoBassFunctionAttributeException">Can't find <see cref="BassFunctionAttribute" /> in this Bass function.</exception>
        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize" /> to load Bass DLL first.</exception>
        /// <exception cref="TypeLoadException">A custom attribute type cannot be loaded. </exception>
        /// <exception cref="FunctionNotFoundException">Can't find this function in Bass DLL.</exception>
        internal override void InitializeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            ChannelBytes2SecondsFunction = new BassFunction<ChannelBytes2Seconds>();
            ChannelFlagsFunction = new BassFunction<ChannelFlags>();
            ChannelGet3DAttributesFunction = new BassFunction<ChannelGet3DAttributes>();
            ChannelGetAttributeFunction = new BassFunction<ChannelGetAttribute>();
            ChannelGetAttributeExFunction = new BassFunction<ChannelGetAttributeEx>();
            ChannelGetDataFunction = new BassFunction<ChannelGetData>();
            ChannelGetDeviceFunction = new BassFunction<ChannelGetDevice>();
            ChannelGetInfoFunction = new BassFunction<ChannelGetInfo>();
            ChannelGetLengthFunction = new BassFunction<ChannelGetLength>();
            ChannelGetLevelFunction = new BassFunction<ChannelGetLevel>();
            ChannelGetLevelExFunction = new BassFunction<ChannelGetLevelEx>();
            ChannelGetPositionFunction = new BassFunction<ChannelGetPosition>();
            ChannelGetTagsFunction = new BassFunction<ChannelGetTags>();
            ChannelIsActiveFunction = new BassFunction<ChannelIsActive>();
            ChannelIsSlidingFunction = new BassFunction<ChannelIsSliding>();
            ChannelLockFunction = new BassFunction<ChannelLock>();
            ChannelPauseFunction = new BassFunction<ChannelPause>();
            ChannelPlayFunction = new BassFunction<ChannelPlay>();
            ChannelRemoveDSPFunction = new BassFunction<ChannelRemoveDSP>();
            ChannelRemoveFXFunction = new BassFunction<ChannelRemoveFX>();
            ChannelRemoveLinkFunction = new BassFunction<ChannelRemoveLink>();
            ChannelRemoveSyncFunction = new BassFunction<ChannelRemoveSync>();
            ChannelSeconds2BytesFunction = new BassFunction<ChannelSeconds2Bytes>();
            ChannelSet3DAttributesFunction = new BassFunction<ChannelSet3DAttributes>();
            ChannelSetAttributeFunction = new BassFunction<ChannelSetAttribute>();
            ChannelSetAttributeExFunction = new BassFunction<ChannelSetAttributeEx>();
            ChannelSetDeviceFunction = new BassFunction<ChannelSetDevice>();
            ChannelSetDSPFunction = new BassFunction<ChannelSetDSP>();
            ChannelSetFXFunction = new BassFunction<ChannelSetFX>();
            ChannelSetLinkFunction = new BassFunction<ChannelSetLink>();
            ChannelSetPositionFunction = new BassFunction<ChannelSetPosition>();
            ChannelSetSyncFunction = new BassFunction<ChannelSetSync>();
            ChannelStopFunction = new BassFunction<ChannelStop>();
            ChannelUpdateFunction = new BassFunction<ChannelUpdate>();
            ChannelSlideAttributeFunction = new BassFunction<ChannelSlideAttribute>();
            ChannelGet3DPositionFunction = new BassFunction<ChannelGet3DPosition>();
            ChannelSet3DPositionFunction = new BassFunction<ChannelSet3DPosition>();

            ModuleAvailable = true;
        }

        /// <exception cref="BassNotLoadedException">Bass DLL not loaded, you must use <see cref="BassManager.Initialize" /> to load Bass DLL first.</exception>
        internal override void FreeModule()
        {
            if (!BassManager.Available) throw new BassNotLoadedException();

            ChannelBytes2SecondsFunction = null;
            ChannelFlagsFunction = null;
            ChannelGet3DAttributesFunction = null;
            ChannelGetAttributeFunction = null;
            ChannelGetAttributeExFunction = null;
            ChannelGetDataFunction = null;
            ChannelGetDeviceFunction = null;
            ChannelGetInfoFunction = null;
            ChannelGetLengthFunction = null;
            ChannelGetLevelFunction = null;
            ChannelGetLevelExFunction = null;
            ChannelGetPositionFunction = null;
            ChannelGetTagsFunction = null;
            ChannelIsActiveFunction = null;
            ChannelIsSlidingFunction = null;
            ChannelLockFunction = null;
            ChannelPauseFunction = null;
            ChannelPlayFunction = null;
            ChannelRemoveDSPFunction = null;
            ChannelRemoveFXFunction = null;
            ChannelRemoveLinkFunction = null;
            ChannelRemoveSyncFunction = null;
            ChannelSeconds2BytesFunction = null;
            ChannelSet3DAttributesFunction = null;
            ChannelSetAttributeFunction = null;
            ChannelSetAttributeExFunction = null;
            ChannelSetDeviceFunction = null;
            ChannelSetDSPFunction = null;
            ChannelSetFXFunction = null;
            ChannelSetLinkFunction = null;
            ChannelSetPositionFunction = null;
            ChannelSetSyncFunction = null;
            ChannelStopFunction = null;
            ChannelUpdateFunction = null;
            ChannelSlideAttributeFunction = null;
            ChannelGet3DPositionFunction = null;
            ChannelSet3DPositionFunction = null;
            ModuleAvailable = false;
        }
    }
}