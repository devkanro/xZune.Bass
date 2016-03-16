// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: RecordManager.cs
// Version: 20160219

using System;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Flags;
using xZune.Bass.Modules;

namespace xZune.Bass
{
    /// <summary>
    ///     Manage record channels.
    /// </summary>
    public static class RecordManager
    {
        /// <summary>
        ///     Get or set the recording device setting of the current thread.
        /// </summary>
        public static int Device
        {
            get
            {
                return RecordModule.RecordGetDeviceFunction.CheckResult(RecordModule.RecordGetDeviceFunction.Delegate());
            }
            set
            {
                RecordModule.RecordSetDeviceFunction.CheckResult(RecordModule.RecordSetDeviceFunction.Delegate(value));
            }
        }

        /// <summary>
        ///     Initializes a recording device.
        /// </summary>
        /// <param name="device">
        ///     The device to use... -1 = default device, 0 = first. <see cref="GetDeviceInfomation" /> can be
        ///     used to enumerate the available devices.
        /// </param>
        public static void Initialize(int device)
        {
            RecordModule.RecordInitFunction.CheckResult(RecordModule.RecordInitFunction.Delegate(device));
        }

        /// <summary>
        ///     Frees all resources used by the recording device.
        /// </summary>
        public static void Free()
        {
            RecordModule.RecordFreeFunction.CheckResult(RecordModule.RecordFreeFunction.Delegate());
        }

        /// <summary>
        ///     Get information on a recording device.
        /// </summary>
        /// <param name="device">The device to get the information of... 0 = first. </param>
        /// <returns>Information of device.</returns>
        public static DeviceInfo GetDeviceInfomation(int device)
        {
            DeviceInfo result = new DeviceInfo();

            RecordModule.RecordGetDeviceInfoFunction.CheckResult(
                RecordModule.RecordGetDeviceInfoFunction.Delegate(device, ref result));

            return result;
        }

        /// <summary>
        ///     Get the current settings of a recording input source.
        /// </summary>
        /// <param name="input">The input to get the settings of... 0 = first, -1 = master. </param>
        /// <param name="volume">Get volume, 0 = don't retrieve the volume.</param>
        /// <returns></returns>
        public static RecordInputType GetInput(int input, ref float volume)
        {
            return RecordModule.RecordGetInputFunction.CheckResult(
                RecordModule.RecordGetInputFunction.Delegate(input, ref volume));
        }

        /// <summary>
        ///     Adjusts the settings of a recording input source.
        /// </summary>
        /// <param name="input">The input to adjust the settings of... 0 = first, -1 = master. </param>
        /// <param name="volume">The volume level... 0 (silent) to 1 (max), less than 0 = leave current. </param>
        /// <param name="staus">The new setting. </param>
        public static void SetInput(int input, float volume, RecordInputStatus staus)
        {
            RecordModule.RecordSetInputFunction.CheckResult(
                RecordModule.RecordSetInputFunction.Delegate(input, staus, volume));
        }

        /// <summary>
        ///     Get the text description of a recording input source.
        /// </summary>
        /// <param name="input">The input to get the description of... 0 = first, -1 = master. </param>
        /// <returns>Description of a recording input source.</returns>
        public static String GetInputName(int input)
        {
            var name =
                RecordModule.RecordGetInputNameFunction.CheckResult(
                    RecordModule.RecordGetInputNameFunction.Delegate(input));

            return InteropHelper.PtrToString(name);
        }

        /// <summary>
        ///     Get information on the recording device being used.
        /// </summary>
        /// <returns></returns>
        public static RecordInfo GetInfomation()
        {
            var result = new RecordInfo();

            RecordModule.RecordGetInfoFunction.CheckResult(RecordModule.RecordGetInfoFunction.Delegate(ref result));

            return result;
        }

        /// <summary>
        ///     Starts recording.
        /// </summary>
        /// <param name="freq">The sample rate to record at. </param>
        /// <param name="channels">The number of channels... 1 = mono, 2 = stereo, etc. </param>
        /// <param name="configs">Configures of recording.</param>
        /// <param name="period">
        ///     The period (in milliseconds) between calls to the callback function. The minimum period is 5ms,
        ///     the maximum is half the BASS_CONFIG_REC_BUFFER setting. If the period specified is outside this range, it is
        ///     automatically capped. The default is 100ms.
        /// </param>
        /// <returns>A record.</returns>
        public static Record Start(uint freq, uint channels, RecordInitializationConfig configs, ushort period)
        {
            Record result = new Record();

            result.SetHandle(
                RecordModule.RecordStartFunction.CheckResult(RecordModule.RecordStartFunction.Delegate(freq, channels,
                    (uint) ((uint) configs | period << 16), result.RecordHandler, IntPtr.Zero)));

            return result;
        }
    }
}