// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Dx8I3Dl2.cs
// Version: 20160216

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Used with <see cref="FXGetParameters" /> and <see cref="FXSetParameters" /> to retrieve and set the parameters of a
    ///     DX8 I3DL2 (Interactive 3D Audio Level 2) reverberation effect.
    /// </summary>
    public struct Dx8I3Dl2
    {
        /// <summary>
        ///     Attenuation of the room effect, in millibels (mB), in the range from -10000 to 0. The default value is -1000 mB.
        /// </summary>
        public int Room;

        /// <summary>
        ///     Attenuation of the room high-frequency effect, in mB, in the range from -10000 to 0. The default value is -100 mB.
        /// </summary>
        public int RoomHF;

        /// <summary>
        ///     Rolloff factor for the reflected signals, in the range from 0 to 10. The default value is 0.0.
        /// </summary>
        public float RoomRolloffFactor;

        /// <summary>
        ///     Decay time, in seconds, in the range from 0.1 to 20. The default value is 1.49 seconds.
        /// </summary>
        public float DecayTime;

        /// <summary>
        ///     Ratio of the decay time at high frequencies to the decay time at low frequencies, in the range from 0.1 to 2. The
        ///     default value is 0.83.
        /// </summary>
        public float DecayHFRatio;

        /// <summary>
        ///     Attenuation of early reflections relative to lRoom, in mB, in the range from -10000 to 1000. The default value is
        ///     -2602 mB.
        /// </summary>
        public int Reflections;

        /// <summary>
        ///     Delay time of the first reflection relative to the direct path, in seconds, in the range from 0 to 0.3. The default
        ///     value is 0.007 seconds.
        /// </summary>
        public float ReflectionsDelay;

        /// <summary>
        ///     Attenuation of late reverberation relative to lRoom, in mB, in the range from -10000 to 2000. The default value is
        ///     200 mB.
        /// </summary>
        public int Reverb;

        /// <summary>
        ///     Time limit between the early reflections and the late reverberation relative to the time of the first reflection,
        ///     in seconds, in the range from 0 to 0.1. The default value is 0.011 seconds.
        /// </summary>
        public float ReverbDelay;

        /// <summary>
        ///     Echo density in the late reverberation decay, in percent, in the range from 0 to 100. The default value is 100.0
        ///     percent.
        /// </summary>
        public float Diffusion;

        /// <summary>
        ///     Modal density in the late reverberation decay, in percent, in the range from 0 to 100. The default value is 100.0
        ///     percent.
        /// </summary>
        public float Density;

        /// <summary>
        ///     Reference high frequency, in hertz, in the range from 20 to 20000. The default value is 5000.0 Hz.
        /// </summary>
        public float HFReference;
    }
}