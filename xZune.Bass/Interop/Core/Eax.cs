// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Eax.cs
// Version: 20160216

using xZune.Bass.Interop.Core.Flags;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Retrieves the current type of EAX environment and its parameters.
    /// </summary>
    /// <param name="env">
    ///     The EAX environment... NULL = don't retrieve it.
    ///     environments.
    /// </param>
    /// <param name="vol">The volume of the reverb... NULL = don't retrieve it. </param>
    /// <param name="decay">The decay duration... NULL = don't retrieve it. </param>
    /// <param name="damp">The damping... NULL = don't retrieve it. </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     When using multiple devices, the current thread's device setting (as set with <see cref="SetDevice" />) determines
    ///     which
    ///     device this function call applies to.
    /// </remarks>
    [BassFuction("BASS_GetEAXParameters")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.NoEAX, "The current device does not support EAX.")]
    [BassBooleanVerification]
    public delegate bool GetEaxParameters(ref EaxEnvironment env, ref float vol, ref float decay, ref float damp);

    /// <summary>
    ///     Sets the type of EAX environment and its parameters.
    /// </summary>
    /// <param name="env">The EAX environment... -1 = leave current, or one of the <see cref="EaxEnvironment" />. </param>
    /// <param name="vol">The volume of the reverb... 0 (off) to 1 (max), less than 0 = leave current. </param>
    /// <param name="decay">
    ///     The time in seconds it takes the reverb to diminish by 60 dB... 0.1 (min) to 20 (max), less than 0
    ///     = leave current.
    /// </param>
    /// <param name="damp">
    ///     The damping, high or low frequencies decay faster... 0 = high decays quickest, 1 = low/high decay
    ///     equally, 2 = low decays quickest, less than 0 = leave current.
    /// </param>
    /// <returns>
    ///     If successful, then TRUE is returned, else FALSE is returned. Use <see cref="GetErrorCode" /> to get the error
    ///     code.
    /// </returns>
    /// <remarks>
    ///     The use of EAX functions requires that the output device supports EAX. <see cref="GetInfo"/> can be used to check that. EAX
    ///     only affects 3D channels, but EAX functions do not require <see cref="Apply3D" /> to apply the changes.
    ///     Presets are provided for all the EAX environments. To use a preset, simply call <see cref="SetEAXParameters" />(),
    ///     where preset is one of the <see cref="PresetEaxEnvironment" />.
    ///     <para />
    ///     When using multiple devices, the current thread's device setting (as set with <see cref="SetDevice" />) determines
    ///     which device this function call applies to.
    ///     <para />
    /// </remarks>
    [BassFuction("BASS_SetEAXParameters")]
    [BassError(ErrorCode.InitializeFail, "Initialize() has not been successfully called.")]
    [BassError(ErrorCode.NoEAX, "The output device does not support EAX.")]
    [BassBooleanVerification]
    public delegate bool SetEAXParameters(EaxEnvironment env, float vol, float decay, float damp);

    /// <summary>
    ///     Preset EAX environments.
    /// </summary>
    public static class PresetEaxEnvironment
    {
        public static EaxEnvironmentParameter Generic { get; } = new EaxEnvironmentParameter(EaxEnvironment.Generic,
            0.5F, 1.493F, 0.5F);

        public static EaxEnvironmentParameter PaddedCell { get; } =
            new EaxEnvironmentParameter(EaxEnvironment.PaddedCell, 0.25F, 0.1F, 0.0F);

        public static EaxEnvironmentParameter Room { get; } = new EaxEnvironmentParameter(EaxEnvironment.Room, 0.417F,
            0.4F, 0.666F);

        public static EaxEnvironmentParameter BathRoom { get; } = new EaxEnvironmentParameter(EaxEnvironment.BathRoom,
            0.653F, 1.499F, 0.166F);

        public static EaxEnvironmentParameter LivingRoom { get; } =
            new EaxEnvironmentParameter(EaxEnvironment.LivingRoom, 0.208F, 0.478F, 0.0F);

        public static EaxEnvironmentParameter StoneRoom { get; } = new EaxEnvironmentParameter(
            EaxEnvironment.StoneRoom, 0.5F, 2.309F, 0.888F);

        public static EaxEnvironmentParameter Auditorium { get; } =
            new EaxEnvironmentParameter(EaxEnvironment.Auditorium, 0.403F, 4.279F, 0.5F);

        public static EaxEnvironmentParameter ConcertHall { get; } =
            new EaxEnvironmentParameter(EaxEnvironment.ConcertHall, 0.5F, 3.961F, 0.5F);

        public static EaxEnvironmentParameter Cave { get; } = new EaxEnvironmentParameter(EaxEnvironment.Cave, 0.5F,
            2.886F, 1.304F);

        public static EaxEnvironmentParameter Arena { get; } = new EaxEnvironmentParameter(EaxEnvironment.Arena, 0.361F,
            7.284F, 0.332F);

        public static EaxEnvironmentParameter Hangar { get; } = new EaxEnvironmentParameter(EaxEnvironment.Hangar, 0.5F,
            10.0F, 0.3F);

        public static EaxEnvironmentParameter CarpetedHallway { get; } =
            new EaxEnvironmentParameter(EaxEnvironment.CarpetedHallway, 0.153F, 0.259F, 2.0F);

        public static EaxEnvironmentParameter Hallway { get; } = new EaxEnvironmentParameter(EaxEnvironment.Hallway,
            0.361F, 1.493F, 0.0F);

        public static EaxEnvironmentParameter StoneCorridor { get; } =
            new EaxEnvironmentParameter(EaxEnvironment.StoneCorridor, 0.444F, 2.697F, 0.638F);

        public static EaxEnvironmentParameter Alley { get; } = new EaxEnvironmentParameter(EaxEnvironment.Alley, 0.25F,
            1.752F, 0.776F);

        public static EaxEnvironmentParameter Forest { get; } = new EaxEnvironmentParameter(EaxEnvironment.Forest,
            0.111F, 3.145F, 0.472F);

        public static EaxEnvironmentParameter City { get; } = new EaxEnvironmentParameter(EaxEnvironment.City, 0.111F,
            2.767F, 0.224F);

        public static EaxEnvironmentParameter Mountains { get; } = new EaxEnvironmentParameter(
            EaxEnvironment.Mountains, 0.194F, 7.841F, 0.472F);

        public static EaxEnvironmentParameter Quarry { get; } = new EaxEnvironmentParameter(EaxEnvironment.Quarry, 1.0F,
            1.499F, 0.5F);

        public static EaxEnvironmentParameter Plain { get; } = new EaxEnvironmentParameter(EaxEnvironment.Plain, 0.097F,
            2.767F, 0.224F);

        public static EaxEnvironmentParameter Parkinglot { get; } =
            new EaxEnvironmentParameter(EaxEnvironment.Parkinglot, 0.208F, 1.652F, 1.5F);

        public static EaxEnvironmentParameter SewerPipe { get; } = new EaxEnvironmentParameter(
            EaxEnvironment.SewerPipe, 0.652F, 2.886F, 0.25F);

        public static EaxEnvironmentParameter UnderWater { get; } =
            new EaxEnvironmentParameter(EaxEnvironment.UnderWater, 1.0F, 1.499F, 0.0F);

        public static EaxEnvironmentParameter Drugged { get; } = new EaxEnvironmentParameter(EaxEnvironment.Drugged,
            0.875F, 8.392F, 1.388F);

        public static EaxEnvironmentParameter Dizzy { get; } = new EaxEnvironmentParameter(EaxEnvironment.Dizzy, 0.139F,
            17.234F, 0.666F);

        public static EaxEnvironmentParameter Psychotic { get; } = new EaxEnvironmentParameter(
            EaxEnvironment.Psychotic, 0.486F, 7.563F, 0.806F);
    }
}