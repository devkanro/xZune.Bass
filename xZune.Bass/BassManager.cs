// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassManager.cs
// Version: 20160216

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using xZune.Bass.Interop;
using xZune.Bass.Interop.Core;
using xZune.Bass.Interop.Core.Flags;
using Guid = xZune.Bass.Interop.Core.Guid;

namespace xZune.Bass
{
    /// <summary>
    ///     Bass global manager.
    /// </summary>
    public static class BassManager
    {
        private static BassFunction<GetErrorCode> _getErrorCodeFunction;
        private static BassFunction<Free> _freeFunction;
        private static BassFunction<Initialize> _initializeFunction;
        private static BassFunction<GetVersion> _getVersionFunction;
        private static BassFunction<GetInfo> _getInfoFunction;
        private static BassFunction<GetDeviceInfo> _getDeviceInfoFunction;
        private static BassFunction<GetDevice> _getDeviceFunction;
        private static BassFunction<GetCpuUsage> _getCpuUsageFunction;
        private static BassFunction<GetDSoundObject> _getDSoundObjectFunction;
        private static BassFunction<GetVolume> _getVolumeFunction;
        private static BassFunction<Pause> _pauseFunction;
        private static BassFunction<SetDevice> _setDeviceFunction;
        private static BassFunction<SetVolume> _setVolumeFunction;
        private static BassFunction<Start> _startFunction;
        private static BassFunction<Stop> _stopFunction;
        private static BassFunction<Update> _updateFunction;

        /// <summary>
        ///     Get the Bass library handle.
        /// </summary>
        public static IntPtr BassLibraryHandle { get; private set; }

        /// <summary>
        ///     Get the directory of set.
        /// </summary>
        public static String BassLibraryDirectory { get; private set; }

        /// <summary>
        ///     Get the path of "bass.dll".
        /// </summary>
        public static String BassLibraryPath { get; private set; }

        /// <summary>
        ///     Get is this module is loaded and available.
        /// </summary>
        public static bool ModuleAvailable { get; private set; }

        /// <summary>
        ///     Get is Bass loaded and available.
        /// </summary>
        public static bool Available => BassLibraryHandle != IntPtr.Zero;

        /// <summary>
        ///     Get version of Bass that is loaded.
        /// </summary>
        /// <returns>The Bass version.</returns>
        /// <remarks>
        ///     There is no guarantee that a previous or future version of Bass supports all the Bass functions that you are using,
        ///     so you should always use this function to make sure the correct version is loaded.
        /// </remarks>
        public static Version Version
        {
            get
            {
                var version = _getVersionFunction.Delegate();

                return new Version((int) ((version & 0xFF000000) >> 24), (int) ((version & 0x00FF0000) >> 16),
                    (int) ((version & 0x0000FF00) >> 8), (int) ((version & 0x0000000FF) >> 0));
            }
        }

        /// <summary>
        ///     Get the current CPU usage of Bass.
        /// </summary>
        public static float CpuUsage => _getCpuUsageFunction.Delegate();

        /// <summary>
        /// Get the current master volume level. 
        /// </summary>
        /// <exception cref="BassNotLoadedException" accessor="get">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        /// <exception cref="BassErrorException" accessor="get">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        public static float Volume
        {
            get { return _getVolumeFunction.CheckResult(_getVolumeFunction.Delegate()); }

            set { _setVolumeFunction.CheckResult(_setVolumeFunction.Delegate(value)); }
        }

        /// <summary>
        /// Get or set the device to use for subsequent calls in the current thread. 
        /// </summary>
        /// <exception cref="BassNotLoadedException" accessor="get">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        /// <exception cref="BassErrorException" accessor="get">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        public static int Device
        {
            get { return _getDeviceFunction.CheckResult(_getDeviceFunction.Delegate()); }

            set { _setDeviceFunction.CheckResult(_setDeviceFunction.Delegate(value)); }
        }

        /// <summary>
        /// Get information on the device being used. 
        /// </summary>
        /// <exception cref="BassNotLoadedException" accessor="get">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        /// <exception cref="BassErrorException" accessor="get">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        public static Info Infomation
        {
            get
            {
                Info result = new Info();
                _getInfoFunction.CheckResult(_getInfoFunction.Delegate(ref result));
                return result;
            }
        }

        #region ---- Play controls ----

        /// <summary>
        /// Stops the output, pausing all musics/samples/streams on it. 
        /// </summary>
        /// <exception cref="BassNotLoadedException" accessor="get">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        /// <exception cref="BassErrorException" accessor="get">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        public static void PauseAll()
        {
            _pauseFunction.CheckResult(_pauseFunction.Delegate());
        }

        /// <summary>
        /// Starts (or resumes) the all output. 
        /// </summary>
        /// <exception cref="BassNotLoadedException" accessor="get">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        /// <exception cref="BassErrorException" accessor="get">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        public static void StartAll()
        {
            _startFunction.CheckResult(_startFunction.Delegate());
        }

        /// <summary>
        /// Stops the output, stopping all musics/samples/streams on it. 
        /// </summary>
        /// <exception cref="BassNotLoadedException" accessor="get">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        /// <exception cref="BassErrorException" accessor="get">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        public static void StopAll()
        {
            _stopFunction.CheckResult(_stopFunction.Delegate());
        }

        /// <summary>
        /// Updates the <see cref="StreamMedia"/> and <see cref="MusicMedia"/> channel playback buffers. 
        /// </summary>
        /// <param name="length">The amount of data to render, in milliseconds. </param>
        /// <remarks>
        ///     When automatic updating is disabled, this function or <see cref="ChannelUpdate" /> needs to be used to keep the
        ///     playback buffers updated. The length parameter should include some safety margin, in case the next update cycle
        ///     gets delayed. For example, if calling this function every 100ms, 200 would be a reasonable length parameter.
        /// </remarks>
        public static void Update(int length)
        {
            _updateFunction.CheckResult(_updateFunction.Delegate(length));
        }

        #endregion

        /// <summary>
        /// Get information on an output device. 
        /// </summary>
        /// <param name="device">The device to get the information of... 0 = first. </param>
        /// <returns>Device infomation.</returns>
        /// <exception cref="BassNotLoadedException" accessor="get">Bass DLL not loaded, you must use <see cref="BassManager.Initialize"/> to load Bass DLL first.</exception>
        /// <exception cref="BassErrorException" accessor="get">Some error occur to call a Bass function, check the error code and error message to get more error infomation.</exception>
        public static DeviceInfo GetDeviceInfo(int device)
        {
            DeviceInfo deviceInfo = new DeviceInfo();
            _getDeviceInfoFunction.CheckResult(_getDeviceInfoFunction.Delegate(device, ref deviceInfo));
            return deviceInfo;
        }

        /// <summary>
        /// Get a pointer to a DirectSound object interface. 
        /// </summary>
        /// <param name="type">DirectSound object type.</param>
        /// <returns>Pointer to the requested object.</returns>
        public static IntPtr GetDSoundObject(DSoundObjectType type)
        {
            return _getDSoundObjectFunction.CheckResult(_getDSoundObjectFunction.Delegate(type));
        }

        /// <summary>
        ///     Retrieves the error code for the most recent Bass function call in the current thread.
        /// </summary>
        /// <returns>
        ///     If no error occurred during the last Bass function call then <see cref="ErrorCode.OK" /> is returned, else others
        ///     values is returned.
        ///     <para />
        ///     Error codes are stored for each thread. So if you happen to call 2 or more Bass functions at the same time, they
        ///     will not interfere with each other's error codes.
        /// </returns>
        public static ErrorCode GetErrorCode()
        {
            return _getErrorCodeFunction.Delegate.Invoke();
        }

        #region ---- Initialize ----

        /// <summary>
        ///     Load Bass library and initialize it, it will automatically call <see cref="InitializeBass" />, we will try find
        ///     Bass library in last time used directory and current directory.
        /// </summary>
        /// <param name="device">
        ///     The device to use... -1 = default device, 0 = no sound, 1 = first real output device.
        ///     <see cref="GetDeviceInfo" /> can be used to enumerate the available devices.
        /// </param>
        /// <param name="freq">Output sample rate. </param>
        /// <param name="configs">Configures of initialize Bass.</param>
        /// <param name="windowHandle">The application's main window... 0 = the desktop window (use this for console applications). </param>
        /// <param name="dSoundGuid">
        ///     Class identifier of the object to create, that will be used to initialize DirectSound... NULL
        ///     = use default.
        /// </param>
        /// <remarks>
        ///     This function must be successfully called before using any functions, others remarks see
        ///     <seealso cref="InitializeBass" />.
        /// </remarks>
        /// <exception cref="BassAlreadyInitilizedException">
        ///     Bass has initialized, maybe you should call
        ///     <see cref="BassManager.ReleaseAll" /> to dispose all resource, then call <see cref="BassManager.Initialize" />
        ///     initialize Bass again.
        /// </exception>
        /// <exception cref="BassLibraryNotFoundException">Can't find Bass DLL.</exception>
        /// <exception cref="BassLoadLibraryException">
        ///     Can't load Bass DLL, check the platform and Bass target platform (should be same, x86 or x64).
        /// </exception>
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
        /// <exception cref="BassErrorException">
        ///     Some error occur to call a Bass function, check the error code and error message
        ///     to get more error infomation.
        /// </exception>
        public static void Initialize(int device, uint freq, InitializationConfig configs,
            IntPtr windowHandle, Guid? dSoundGuid)
        {
            String path = null;

            if (BassLibraryPath != null)
            {
                if (File.Exists(BassLibraryPath))
                {
                    path = BassLibraryPath;

                    goto INIT;
                }
            }

            if (BassLibraryDirectory != null)
            {
                if (Directory.Exists(BassLibraryDirectory))
                {
                    path = BassLibraryDirectory;

                    goto INIT;
                }
            }

            path = Directory.GetCurrentDirectory();

            INIT:
            Initialize(path, device, freq, configs, windowHandle, dSoundGuid);
        }

        /// <summary>
        ///     Load Bass library and initialize it, it will automatically call <see cref="InitializeBass" />.
        /// </summary>
        /// <param name="bassLibraryPath">
        ///     Path of the Bass library, if it is a file, will load this file, if it is a directory,
        ///     will search "bass.dll" in it.
        /// </param>
        /// <param name="device">
        ///     The device to use... -1 = default device, 0 = no sound, 1 = first real output device.
        ///     <see cref="GetDeviceInfo" /> can be used to enumerate the available devices.
        /// </param>
        /// <param name="freq">Output sample rate. </param>
        /// <param name="configs">Configures of initialize Bass.</param>
        /// <param name="windowHandle">The application's main window... 0 = the desktop window (use this for console applications). </param>
        /// <param name="dSoundGuid">
        ///     Class identifier of the object to create, that will be used to initialize DirectSound... NULL
        ///     = use default.
        /// </param>
        /// <remarks>
        ///     This function must be successfully called before using any functions, others remarks see
        ///     <seealso cref="InitializeBass" />.
        /// </remarks>
        /// <exception cref="BassAlreadyInitilizedException">
        ///     Bass has initialized, maybe you should call
        ///     <see cref="BassManager.ReleaseAll" /> to dispose all resource, then call <see cref="BassManager.Initialize" />
        ///     initialize Bass again.
        /// </exception>
        /// <exception cref="BassLibraryNotFoundException">Can't find Bass DLL.</exception>
        /// <exception cref="BassLoadLibraryException">
        ///     Can't load Bass DLL, check the platform and Bass target platform (should be same, x86 or x64).
        /// </exception>
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
        /// <exception cref="BassErrorException">
        ///     Some error occur to call a Bass function, check the error code and error message
        ///     to get more error infomation.
        /// </exception>
        public static void Initialize(String bassLibraryPath, int device, uint freq, InitializationConfig configs,
            IntPtr windowHandle, Guid? dSoundGuid)
        {
            if (Available) throw new BassAlreadyInitilizedException();

            // If bassLibraryPath is file, then we initialize Bass with this file.
            if (File.Exists(bassLibraryPath))
            {
                FileInfo bassLibrary = new FileInfo(bassLibraryPath);

                BassLibraryPath = bassLibrary.FullName;
                BassLibraryDirectory = bassLibrary.DirectoryName;
            }
            // If bassLibraryPath is a directory, we will find "bass.dll" in this directory, then we initialize Bass with found file.
            else if (Directory.Exists(bassLibraryPath))
            {
                DirectoryInfo bassLibrary = new DirectoryInfo(bassLibraryPath);

                BassLibraryDirectory = bassLibrary.FullName;

                var files = bassLibrary.GetFiles("bass.dll", SearchOption.AllDirectories);

                if (files.Length == 0) throw new BassLibraryNotFoundException();

                BassLibraryPath = files[0].FullName;
            }
            // Provided path is not existing.
            else
            {
                throw new BassLibraryNotFoundException(bassLibraryPath);
            }

            try
            {
                BassLibraryHandle = Win32Api.LoadLibrary(BassLibraryPath);
            }
            catch (Win32Exception e)
            {
                throw new BassLoadLibraryException(e);
            }

            if (Available)
            {
                InitializeModule();
                InitializeBass(device, freq, configs, windowHandle, dSoundGuid);
            }
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
        internal static void InitializeModule()
        {
            if (!Available) throw new BassNotLoadedException();

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
        }

        /// <summary>
        ///     Initializes an output device.
        /// </summary>
        /// <param name="device">
        ///     The device to use... -1 = default device, 0 = no sound, 1 = first real output device.
        ///     <see cref="GetDeviceInfo" /> can be used to enumerate the available devices.
        /// </param>
        /// <param name="freq">Output sample rate. </param>
        /// <param name="configs">Configures of initialize Bass.</param>
        /// <param name="windowHandle">The application's main window... 0 = the desktop window (use this for console applications). </param>
        /// <param name="dSoundGuid">
        ///     Class identifier of the object to create, that will be used to initialize DirectSound... NULL
        ///     = use default.
        /// </param>
        /// <remarks>
        ///     This function must be successfully called before using any sample, stream or MOD music functions. The recording
        ///     functions may be used without having called this function.
        ///     <para />
        ///     Playback is not possible with the "no sound" device, but it does allow the use of "decoding channels", eg. to
        ///     decode files.
        ///     <para />
        ///     Simultaneously using multiple devices is supported in the Bass API via a context switching system; instead of there
        ///     being an extra "device" parameter in the function calls, the device to be used is set prior to calling the
        ///     functions. <see cref="SetDevice" /> is used to switch the current device. When successful,
        ///     <see cref="InitializeBass" /> automatically sets the current thread's device to the one that was just initialized.
        ///     <para />
        ///     When using the default device (device = -1), <see cref="GetDevice" /> can be used to find out which device it was
        ///     mapped to.
        /// </remarks>
        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="BassManager.Initialize" /> to
        ///     load Bass DLL first.
        /// </exception>
        /// <exception cref="BassErrorException">
        ///     Some error occur to call a Bass function, check the error code and error message
        ///     to get more error infomation.
        /// </exception>
        public static void InitializeBass(int device, uint freq, InitializationConfig configs, IntPtr windowHandle,
            Guid? dSoundGuid)
        {
            GCHandle? guidHandle = null;

            if (dSoundGuid != null)
            {
                guidHandle = GCHandle.Alloc(dSoundGuid.Value, GCHandleType.Pinned);
            }

            _initializeFunction.CheckResult(_initializeFunction.Delegate(device, freq, configs, windowHandle,
                guidHandle?.AddrOfPinnedObject() ?? IntPtr.Zero));

            guidHandle?.Free();
        }

        #endregion ---- Initialize ----

        #region ---- Release ----

        /// <summary>
        ///     Free Bass library and release all resource it used, it will automatically call <see cref="FreeBass" />.
        /// </summary>
        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="BassManager.Initialize" /> to load Bass DLL
        ///     first.
        /// </exception>
        /// <exception cref="BassErrorException">
        ///     Some error occur to call a Bass function, check the error code and error message
        ///     to get more error infomation.
        /// </exception>
        public static void ReleaseAll()
        {
            if (!Available) throw new BassNotLoadedException();

            FreeBass();

            FreeModule();

            Win32Api.FreeLibrary(BassLibraryHandle);

            BassLibraryHandle = IntPtr.Zero;
        }

        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use Bass to load Bass DLL
        ///     first.
        /// </exception>
        internal static void FreeModule()
        {
            if (!Available) throw new BassNotLoadedException();

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
        }

        /// <summary>
        ///     Frees all resources used by the output device, including all its samples, streams and MOD musics.
        /// </summary>
        /// <remarks>
        ///     This function should be called for all initialized devices before the program closes. It is not necessary to
        ///     individually free the samples/streams/musics as these are all automatically freed by this function.
        ///     <para />
        ///     When using multiple devices, the current thread's device setting (as set with <see cref="SetDevice" />) determines
        ///     which device this function call applies to.
        /// </remarks>
        /// <seealso cref="Interop.Core.Initialize" />
        /// <exception cref="BassErrorException">
        ///     Some error occur to call a Bass function, check the error code and error message
        ///     to get more error infomation.
        /// </exception>
        /// <exception cref="BassNotLoadedException">
        ///     Bass DLL not loaded, you must use <see cref="BassManager.Initialize" /> to
        ///     load Bass DLL first.
        /// </exception>
        public static void FreeBass()
        {
            _freeFunction.CheckResult(_freeFunction.Delegate());
        }

        #endregion ---- Release ----
    }
}