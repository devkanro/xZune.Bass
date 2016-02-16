// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassVerificationAttribute.cs
// Version: 20160216

using System;

namespace xZune.Bass.Interop
{
    /// <summary>
    ///     A base attribute class for Bass result verifier.
    /// </summary>
    [AttributeUsage(AttributeTargets.Delegate)]
    public abstract class BassVerificationAttribute : BassAttribute
    {
        /// <summary>
        ///     Verify a result is correct.
        /// </summary>
        /// <param name="result">Result of function.</param>
        /// <returns>Verification result.</returns>
        public virtual bool VerifyResult(object result)
        {
            throw new NotImplementedException("ValidateResult muse be override.");
        }
    }

    /// <summary>
    ///     A attribute class for Bass <see cref="bool" /> result verification.
    /// </summary>
    public class BassBooleanVerificationAttribute : BassVerificationAttribute
    {
        /// <summary>
        ///     Verify a bool result is correct.
        /// </summary>
        /// <param name="result">Result of function.</param>
        /// <returns>Verification result.</returns>
        public override bool VerifyResult(object result)
        {
            return (bool) result;
        }
    }

    /// <summary>
    ///     A attribute class for Bass <see cref="IntPtr" /> result verification.
    /// </summary>
    public class BassPointerVerificationAttribute : BassVerificationAttribute
    {
        /// <summary>
        ///     Verify a pointer result is correct.
        /// </summary>
        /// <param name="result">Result of function.</param>
        /// <returns>Verification result.</returns>
        public override bool VerifyResult(object result)
        {
            return (IntPtr) result != IntPtr.Zero;
        }
    }

    /// <summary>
    ///     A attribute class for Bass <see cref="float" /> result verification.
    /// </summary>
    public class BassFloatVerificationAttribute : BassVerificationAttribute
    {
        /// <summary>
        ///     Create <see cref="BassFloatVerificationAttribute" /> with default <see cref="InvalidValue" />.
        /// </summary>
        public BassFloatVerificationAttribute() : this(-1)
        {
        }

        /// <summary>
        ///     Create <see cref="BassFloatVerificationAttribute" /> with custom <see cref="InvalidValue" />.
        /// </summary>
        /// <param name="invalidValue">Custom invalid value.</param>
        public BassFloatVerificationAttribute(float invalidValue)
        {
            InvalidValue = invalidValue;
        }

        /// <summary>
        ///     When result equals this value, will check the error.
        /// </summary>
        public float InvalidValue { get; private set; }

        /// <summary>
        ///     Verify a float result is correct.
        /// </summary>
        /// <param name="result">Result of function.</param>
        /// <returns>Verification result.</returns>
        public override bool VerifyResult(object result)
        {
            return !result.Equals(InvalidValue);
        }
    }

    /// <summary>
    ///     A attribute class for Bass <see cref="double" /> result verification.
    /// </summary>
    public class BassDoubleVerificationAttribute : BassVerificationAttribute
    {
        /// <summary>
        ///     Create <see cref="BassDoubleVerificationAttribute" /> with default <see cref="InvalidValue" />.
        /// </summary>
        public BassDoubleVerificationAttribute() : this(-1)
        {
        }

        /// <summary>
        ///     Create <see cref="BassDoubleVerificationAttribute" /> with custom <see cref="InvalidValue" />.
        /// </summary>
        /// <param name="invalidValue">Custom invalid value.</param>
        public BassDoubleVerificationAttribute(double invalidValue)
        {
            InvalidValue = invalidValue;
        }

        /// <summary>
        ///     When result equals this value, will check the error.
        /// </summary>
        public double InvalidValue { get; private set; }

        /// <summary>
        ///     Verify a double result is correct.
        /// </summary>
        /// <param name="result">Result of function.</param>
        /// <returns>Verification result.</returns>
        public override bool VerifyResult(object result)
        {
            return !result.Equals(InvalidValue);
        }
    }

    /// <summary>
    ///     A attribute class for Bass <see cref="Int32" /> result verification.
    /// </summary>
    public class BassInt32VerificationAttribute : BassVerificationAttribute
    {
        /// <summary>
        ///     Create <see cref="BassInt32VerificationAttribute" /> with default <see cref="InvalidValue" />.
        /// </summary>
        public BassInt32VerificationAttribute() : this(-1)
        {
        }

        /// <summary>
        ///     Create <see cref="BassInt32VerificationAttribute" /> with custom <see cref="InvalidValue" />.
        /// </summary>
        /// <param name="invalidValue">Custom invalid value.</param>
        public BassInt32VerificationAttribute(int invalidValue)
        {
            InvalidValue = invalidValue;
        }

        /// <summary>
        ///     When result equals this value, will check the error.
        /// </summary>
        public int InvalidValue { get; private set; }

        /// <summary>
        ///     Verify a Int32 result is correct.
        /// </summary>
        /// <param name="result">Result of function.</param>
        /// <returns>Verification result.</returns>
        public override bool VerifyResult(object result)
        {
            return (int) result != InvalidValue;
        }
    }

    /// <summary>
    ///     A attribute class for Bass <see cref="UInt32" /> result verification.
    /// </summary>
    public class BassUInt32VerificationAttribute : BassVerificationAttribute
    {
        /// <summary>
        ///     Create <see cref="BassUInt32VerificationAttribute" /> with default <see cref="InvalidValue" />.
        /// </summary>
        public BassUInt32VerificationAttribute() : this(0xFFFFFFFF)
        {
        }

        /// <summary>
        ///     Create <see cref="BassUInt32VerificationAttribute" /> with custom <see cref="InvalidValue" />.
        /// </summary>
        /// <param name="invalidValue">Custom invalid value.</param>
        public BassUInt32VerificationAttribute(uint invalidValue)
        {
            InvalidValue = invalidValue;
        }

        /// <summary>
        ///     When result equals this value, will check the error.
        /// </summary>
        public uint InvalidValue { get; private set; }

        /// <summary>
        ///     Verify a UInt32 result is correct.
        /// </summary>
        /// <param name="result">Result of function.</param>
        /// <returns>Verification result.</returns>
        public override bool VerifyResult(object result)
        {
            return (uint) result != InvalidValue;
        }
    }

    /// <summary>
    ///     A attribute class for Bass <see cref="UInt64" /> result verification.
    /// </summary>
    public class BassUInt64VerificationAttribute : BassVerificationAttribute
    {
        /// <summary>
        ///     Create <see cref="BassUInt64VerificationAttribute" /> with default <see cref="InvalidValue" />.
        /// </summary>
        public BassUInt64VerificationAttribute() : this(UInt64.MaxValue)
        {
        }

        /// <summary>
        ///     Create <see cref="BassUInt64VerificationAttribute" /> with custom <see cref="InvalidValue" />.
        /// </summary>
        /// <param name="invalidValue">Custom invalid value.</param>
        public BassUInt64VerificationAttribute(UInt64 invalidValue)
        {
            InvalidValue = invalidValue;
        }

        /// <summary>
        ///     When result equals this value, will check the error.
        /// </summary>
        public UInt64 InvalidValue { get; private set; }

        /// <summary>
        ///     Verify a UInt64 result is correct.
        /// </summary>
        /// <param name="result">Result of function.</param>
        /// <returns>Verification result.</returns>
        public override bool VerifyResult(object result)
        {
            return (UInt64) result != InvalidValue;
        }
    }

    /// <summary>
    ///     A attribute class for Bass <see cref="Int64" /> result verification.
    /// </summary>
    public class BassInt64VerificationAttribute : BassVerificationAttribute
    {
        /// <summary>
        ///     Create <see cref="BassInt64VerificationAttribute" /> with default <see cref="InvalidValue" />.
        /// </summary>
        public BassInt64VerificationAttribute() : this(-1)
        {
        }

        /// <summary>
        ///     Create <see cref="BassInt64VerificationAttribute" /> with custom <see cref="InvalidValue" />.
        /// </summary>
        /// <param name="invalidValue">Custom invalid value.</param>
        public BassInt64VerificationAttribute(Int64 invalidValue)
        {
            InvalidValue = invalidValue;
        }

        /// <summary>
        ///     When result equals this value, will check the error.
        /// </summary>
        public Int64 InvalidValue { get; private set; }

        /// <summary>
        ///     Verify a Int64 result is correct.
        /// </summary>
        /// <param name="result">Result of function.</param>
        /// <returns>Verification result.</returns>
        public override bool VerifyResult(object result)
        {
            return (Int64) result != InvalidValue;
        }
    }
}