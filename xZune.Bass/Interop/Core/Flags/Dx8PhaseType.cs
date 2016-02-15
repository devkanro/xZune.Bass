// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Dx8PhaseType.cs
// Version: 20160216
namespace xZune.Bass.Interop.Core.Flags
{
    /// <summary>
    /// Phase differential between left and right LFOs.
    /// </summary>
    public enum Dx8PhaseType
    {
        PhaseNeg180 = Internal.Dx8PhaseType.PhaseNeg180,
        PhaseNeg90 = Internal.Dx8PhaseType.PhaseNeg90,
        PhaseZero = Internal.Dx8PhaseType.PhaseZero,
        Phase90 = Internal.Dx8PhaseType.Phase90,
        Phase180 = Internal.Dx8PhaseType.Phase180
    }
}