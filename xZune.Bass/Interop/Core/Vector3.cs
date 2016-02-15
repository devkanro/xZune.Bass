// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: Vector3.cs
// Version: 20160215

using System.Runtime.InteropServices;

namespace xZune.Bass.Interop.Core
{
    /// <summary>
    ///     Structure used by the 3D functions to describe positions, velocities, and orientations.
    /// </summary>
    /// <remarks>
    ///     As can be seen above, the left-handed coordinate system is used.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3
    {
        /// <summary>
        ///     +ve = right, -ve = left.
        /// </summary>
        public float X;

        /// <summary>
        ///     +ve = up, -ve = down.
        /// </summary>
        public float Y;

        /// <summary>
        ///     +ve = front, -ve = behind.
        /// </summary>
        public float Z;
    }
}