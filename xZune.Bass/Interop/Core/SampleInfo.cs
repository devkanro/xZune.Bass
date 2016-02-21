// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: SampleInfo.cs
// Version: 20160216

using System.Runtime.InteropServices;
using xZune.Bass.Interop.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="SampleGetInfo" /> and <see cref="SampleSetInfo" /> to retrieve and set the default playback
    ///     attributes of a sample.
    /// </summary>
    /// <remarks>
    ///     When a sample has 3D functionality, the iangle and oangle angles decide how wide the sound is projected around the
    ///     orientation angle (as set via <see cref="ChannelSet3DPosition" />). Within the inside angle the volume level is the
    ///     level set in the volume member (or the BASS_ATTRIB_VOL attribute when the sample is playing). Outside the outer
    ///     angle, the volume changes according to the outvol value. Between the inner and outer angles, the volume gradually
    ///     changes between the inner and outer volume levels. If the inner and outer angles are 360 degrees, then the sound is
    ///     transmitted equally in all directions.
    ///     <para />
    ///     When VAM is enabled, and neither the BASS_VAM_HARDWARE or BASS_VAM_SOFTWARE flags are specified, then the sample
    ///     will be played in hardware if resources are available, and in software if no hardware resources are available.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct SampleInfo
    {
        /// <summary>
        ///     Default sample rate.
        /// </summary>
        public uint Freq;

        /// <summary>
        ///     Default volume... 0 (silent) to 1 (full).
        /// </summary>
        public float Volume;

        /// <summary>
        ///     Default panning position... -1 (full left) to +1 (full right), 0 = centre.
        /// </summary>
        public float Pan;

        /// <summary>
        ///     Configure of sample.
        /// </summary>
        public SampleConfig Configs;

        /// <summary>
        ///     The length in bytes.
        /// </summary>
        public uint Length;

        /// <summary>
        ///     Maximum number of simultaneous playbacks.
        /// </summary>
        public uint Max;

        /// <summary>
        ///     The original resolution (bits per sample)... 0 = undefined.
        /// </summary>
        public uint Origres;

        /// <summary>
        ///     Number of channels... 1 = mono, 2 = stereo, etc.
        /// </summary>
        public uint Chans;

        /// <summary>
        ///     Minimum time gap in milliseconds between creating channels using BASS_SampleGetChannel. This can be used to prevent
        ///     flanging effects caused by playing a sample multiple times very close to each other. The default setting, after
        ///     loading/creating a sample, is 0 (disabled).
        /// </summary>
        public uint MinGap;

        /// <summary>
        ///     The 3D processing mode... one of these flags.
        /// </summary>
        public Channel3DMode Mode3D;

        /// <summary>
        ///     The minimum distance. The sample's volume is at maximum when the listener is within this distance.
        /// </summary>
        public float MinDist;

        /// <summary>
        ///     The maximum distance. The sample's volume stops decreasing when the listener is beyond this distance.
        /// </summary>
        public float MaxDist;

        /// <summary>
        ///     The angle of the inside projection cone in degrees... 0 (no cone) to 360 (sphere).
        /// </summary>
        public uint IAngle;

        /// <summary>
        ///     The angle of the outside projection cone in degrees... 0 (no cone) to 360 (sphere).
        /// </summary>
        public uint OAngle;

        /// <summary>
        ///     The delta-volume outside the outer projection cone... 0 (silent) to 1 (full).
        /// </summary>
        public float OutVolume;

        /// <summary>
        ///     voice allocation/management flags... a combination of these
        /// </summary>
        public uint Vam;

        /// <summary>
        ///     Priority, used with the BASS_VAM_TERM_PRIO flag... 0 (min) to 0xFFFFFFFF (max).
        /// </summary>
        public uint Priority;
    }
}