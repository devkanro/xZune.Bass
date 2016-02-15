// Project: xZune.Bass (https://github.com/higankanshi/xZune.Bass)
// Filename: BassVerificationAttribute.cs
// Version: 20160214

using System;

namespace xZune.Bass.Interop
{
    [AttributeUsage(AttributeTargets.Delegate)]
    internal abstract class BassVerificationAttribute : Attribute
    {
        public virtual bool ValidateResult(object attribute)
        {
            throw new NotImplementedException("ValidateResult muse be override.");
        }
    }

    internal class BassBooleanVerificationAttribute : BassVerificationAttribute
    {
        public override bool ValidateResult(object attribute)
        {
            return (bool) attribute;
        }
    }

    internal class BassPointerVerificationAttribute : BassVerificationAttribute
    {
        public override bool ValidateResult(object attribute)
        {
            return (IntPtr) attribute != IntPtr.Zero;
        }
    }

    internal class BassFloatVerificationAttribute : BassVerificationAttribute
    {
        public BassFloatVerificationAttribute() : this(-1)
        {
        }

        public BassFloatVerificationAttribute(float invalidValue)
        {
            InvalidValue = invalidValue;
        }

        public float InvalidValue { get; private set; }

        public override bool ValidateResult(object attribute)
        {
            return (float) attribute != InvalidValue;
        }
    }

    internal class BassDoubleVerificationAttribute : BassVerificationAttribute
    {
        public BassDoubleVerificationAttribute() : this(-1)
        {
        }

        public BassDoubleVerificationAttribute(double invalidValue)
        {
            InvalidValue = invalidValue;
        }

        public double InvalidValue { get; private set; }

        public override bool ValidateResult(object attribute)
        {
            return (double)attribute != InvalidValue;
        }
    }

    internal class BassInt32VerificationAttribute : BassVerificationAttribute
    {
        public BassInt32VerificationAttribute() : this(-1)
        {
        }

        public BassInt32VerificationAttribute(int invalidValue)
        {
            InvalidValue = invalidValue;
        }

        public int InvalidValue { get; private set; }

        public override bool ValidateResult(object attribute)
        {
            return (int) attribute != InvalidValue;
        }
    }

    internal class BassUInt32VerificationAttribute : BassVerificationAttribute
    {
        public BassUInt32VerificationAttribute() : this(0xFFFFFFFF)
        {
        }

        public BassUInt32VerificationAttribute(uint invalidValue)
        {
            InvalidValue = invalidValue;
        }

        public uint InvalidValue { get; private set; }

        public override bool ValidateResult(object attribute)
        {
            return (uint) attribute != InvalidValue;
        }
    }

    internal class BassUInt64VerificationAttribute : BassVerificationAttribute
    {
        public BassUInt64VerificationAttribute() : this(UInt64.MaxValue)
        {
        }

        public BassUInt64VerificationAttribute(UInt64 invalidValue)
        {
            InvalidValue = invalidValue;
        }

        public UInt64 InvalidValue { get; private set; }

        public override bool ValidateResult(object attribute)
        {
            return (UInt64)attribute != InvalidValue;
        }
    }

    internal class BassInt64VerificationAttribute : BassVerificationAttribute
    {
        public BassInt64VerificationAttribute() : this(-1)
        {
        }

        public BassInt64VerificationAttribute(Int64 invalidValue)
        {
            InvalidValue = invalidValue;
        }

        public Int64 InvalidValue { get; private set; }

        public override bool ValidateResult(object attribute)
        {
            return (Int64)attribute != InvalidValue;
        }
    }
}