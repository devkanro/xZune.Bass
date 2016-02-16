using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    /// Parameter of EAX preset environment.
    /// </summary>
    public struct EaxEnvironmentParameter
    {
        public EaxEnvironmentParameter(EaxEnvironment environment, float volume, float decay, float damp)
        {
            Environment = environment;
            Volume = volume;
            Decay = decay;
            Damp = damp;
        }

        /// <summary>
        /// The EAX environment.
        /// </summary>
        public EaxEnvironment Environment;
        /// <summary>
        /// The volume of the reverb... 0 (off) to 1 (max). 
        /// </summary>
        public float Volume;
        /// <summary>
        /// The time in seconds it takes the reverb to diminish by 60 dB... 0.1 (min) to 20 (max).
        /// </summary>
        public float Decay;
        /// <summary>
        /// The damping, high or low frequencies decay faster... 0 = high decays quickest, 1 = low/high decay equally, 2 = low decays quickest.
        /// </summary>
        public float Damp;
    }
}